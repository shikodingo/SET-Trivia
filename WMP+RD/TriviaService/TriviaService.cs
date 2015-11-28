using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;



namespace TriviaService
{
    public partial class TriviaService : ServiceBase
    {
        /*
         * create a default main folder in the C:\
         * create service, user, admin files within the main folder
         * files meant for users will be sent to user file, files meant for admin will be sent to admin file, and files coming back to service will go in service file
         * when a user is sending a file back the users name will be in the file header to identify them
         * when the game starts a file for each question will be sent to the user folder. these files will also include all answers for that question
         * the question files will have the question number in the file title to identify them
         * the users will need to parse the data in the file to take out the question and seperate the answers
         * once the user has answered a question they will send a file to the service folder with the question # in the title and the answer in the file
         * the location of the main folder and there for the 3 sub folders will be able to  be changed by the admin with a file in the service folder called changeDirectory
         * the service will keep track of user scores by reading in the answers put into the serivce folder and storeing them in the UsersAnswers table
         * when a user is created they will make a new file in service folder called "newUser" with their user name in the file. the service will store these users in the Users MySQL table
         * once question 10 is sent to the service folder by a user their total score will be calculated and they will be added to the leaderboard
         * if the admin wishes to change a question or answer the admin form will create a file in the service folder called either changeQuestion or changeAnswer with the questions number on the end for the file name. if the admin changes a question then the letter for that question will also be in the file
         * if the admin wants to see current status of users the admin will create a file in the Service folder named viewUserStatus which the server will then respond by creating a file called usersStatus in the admin folder
         * 
         */

        delegate void MyCallback(Object obj);       // Delegate declaration for use in Invoke
        FileSystemWatcher fsw;
        const string directory = @"C:\Users\Nathan\OneDrive\Windows and Mobile Programming\Assign 6\main\";//change. *this is modifyible when the program is running but needs to be defaulted to a shared file to start
        StreamReader file = null;
        static Mutex mut;
        const string userFolder = @"User\";
        const string adminFolder = @"Admin\";
        const string serviceFolder = @"Service\";

        public TriviaService()
        {
            InitializeComponent();

            if (!Mutex.TryOpenExisting("MyMutex", out mut))
            {
                mut = new Mutex(true, "MyMutex");
                mut.ReleaseMutex();
            }

            fsw = new FileSystemWatcher(directory + serviceFolder);//awesome file system watcher that sends an event when something changes in the file
            fsw.Filter = "*.txt";
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            fsw.InternalBufferSize = 65535;
            fsw.EnableRaisingEvents = true;

            fsw.Created += new FileSystemEventHandler(fsw_Created);
        }

        // FUNCTION     : fsw_Created(object sender, FileSystemEventArgs e)
        // DESCRIPTION  : watches the file
        // PARAMETERS   : <Object><sender><event sender> : <FileSystemEventArgs><e><the event>
        // RETURNS      : void
        void fsw_Created(object sender, FileSystemEventArgs e)
        {
            string status;
            string fileData = ReadFile(e.FullPath, out status);
            string fileTitle = Path.GetFileName(e.FullPath);
            if (status == "OK")//file was read correctly
            {
                if (fileData == "Shutdown")
                {
                    OnStop();//end service
                }
                else if (fileTitle == "changeDirectory")//just the main directory auto generates Service, Admin, User sub folders
                {
                    string newPath = fileData;
                    try
                    {
                        // Determine whether the directory exists.
                        if (Directory.Exists(newPath))
                        {
                            Console.WriteLine("That path exists already.");
                        }
                        else
                        {
                            // Try to create the main directory.
                            DirectoryInfo main = Directory.CreateDirectory(newPath);
                            Logging.Log("The main directory was created successfully at. " + Directory.GetCreationTime(newPath));

                            // Try to create the User directory.
                            DirectoryInfo user = Directory.CreateDirectory(newPath + userFolder);
                            Logging.Log("The user directory was created successfully at. " + Directory.GetCreationTime(newPath));

                            // Try to create the Admin directory.
                            DirectoryInfo admin = Directory.CreateDirectory(newPath + adminFolder);
                            Logging.Log("The admin directory was created successfully at. " + Directory.GetCreationTime(newPath));

                            // Try to create the Service directory.
                            DirectoryInfo service = Directory.CreateDirectory(newPath + serviceFolder);
                            Logging.Log("The service directory was created successfully at. " + Directory.GetCreationTime(newPath));
                        }      
                    }
                    catch (Exception ex)
                    {
                        Logging.Log("Directory could not be changed");
                    }
                }
            }
            else
            {
                Logging.Log("A file could not be read: " + fileTitle);
            }
        }

        // FUNCTION     : ReadFile(string filePath, out string status)
        // DESCRIPTION  : reads the file
        // PARAMETERS   : <string><filePath><the path of the file to be read> : <out string ><status><status of the file>
        // RETURNS      : <string><data><the data in the file>
        private string ReadFile(string filePath, out string status)
        {
            string data = String.Empty;
            bool done = false;
            status = "";
            mut.WaitOne();
            while (!done)
            {
                try
                {
                    file = new StreamReader(filePath);
                    data = file.ReadLine();
                    status = "OK";
                    done = true;

                }
                catch (Exception ex)
                {
                    status = ex.Message;
                }
                finally
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
            }
            mut.ReleaseMutex();
            return data;
        }

        private void SendMessageToFile(object sender, EventArgs e)//send message
        {
            IPCFileProducer createNewMessage = new IPCFileProducer();
            DAL accessData = new DAL();
            for (int i = 1; i <= 10; i++)//currently this creates a file for each question with the file having a randomly generated title and the question as text in the file
            {
                string question = accessData.SelectAQuestion(i);
                createNewMessage.WriteData(question, "temp", "temp");//write question into file
            }

        }

        protected override void OnStart(string[] args)
        {
            //this chunk of code should create one file for each question that will contain the question and the corrisponding answers
            string extension = userFolder;
            string questionPlusAnswers = "";
            IPCFileProducer createNewMessage = new IPCFileProducer();
            DAL accessData = new DAL();
            for (int i = 1; i <= 10; i++)
            {
                questionPlusAnswers = accessData.SelectAQuestion(i) + System.Environment.NewLine;
                questionPlusAnswers += accessData.SelectQAnswers(i);
                createNewMessage.WriteData(questionPlusAnswers, i + "Question", directory + extension);//write question into file
            }
        }

        protected override void OnStop()
        {

        }


    }
}
