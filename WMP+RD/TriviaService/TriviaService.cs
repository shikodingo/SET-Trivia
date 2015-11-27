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
         * create service, user, admin files within the main file
         * files meant for users will be sent to user file, files meant for admin will be sent to admin file, and files coming back to service will go in service file
         * when a user is sending a file back the users name will be in the file header to identify them
         * when the game starts a file for each question will be sent to the user folder. these files will also include all answers for that question
         * the question files will have the question number in the file title to identify them
         * the users will need to parse the data in the file to take out the question and seperate the answers
         * once the user has answered a question they will send a file to the service folder with the question # in the title and the answer in the file
         * the location of the main folder and there for the 3 sub folders will be able to  be changed by the admin with a file in the service folder called directory
         * the service will keep track of user scores by reading in the answers put into the serivce folder and storeing them in the UsersAnswers table
         * when a user is created they will amek a new file in service folder called "newUser" with their user name in the file. the service will store these users in the Users MySQL table
         * 
         */

        delegate void MyCallback(Object obj);       // Delegate declaration for use in Invoke
        FileSystemWatcher fsw;
        const string directory = @"message\";//puts message into message folder under same directory as the exe   
        StreamReader file = null;
        static Mutex mut;

        public TriviaService()
        {
            InitializeComponent();

            if (!Mutex.TryOpenExisting("MyMutex", out mut))
            {
                mut = new Mutex(true, "MyMutex");
                mut.ReleaseMutex();
            }

            fsw = new FileSystemWatcher(directory);//awesome file system watcher that sends an event when something changes in the file
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
            if (status == "OK")
            {
                Thread t1 = new Thread(new ParameterizedThreadStart(SetLblInvoke));//test sending to file
                t1.Start(fileData);//currently overwriting message need to make it use += not =
                if (fileData == "Shutdown")
                {

                }
            }
            else
            {
                Logging.Log("connection lost");
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
            for (int i=1; i<=10; i++)//currently this creates a file for each question with the file having a randomly generated title and the question as text in the file
            {
                string question = accessData.SelectAQuestion(i);
                createNewMessage.WriteData(question, "temp");//write question into file
            }
            
        }

        protected override void OnStart(string[] args)
        {
            //this chunk of code should create one file called questions that will put all the questions from the MySQL database into a txt file to give to the users
            string question = "";
            IPCFileProducer createNewMessage = new IPCFileProducer();
            DAL accessData = new DAL();
            for (int i=1; i<=10; i++)
            {
                question += accessData.SelectAQuestion(i) + System.Environment.NewLine;               
            }
            createNewMessage.WriteData(question, "Questions");//write question into file

            //this chunk of code should create a file called Answers that will put all the answers form the MySQL database into a txt file to give to the users *note i am thinking of changing this to create a file for each question that will also contain its corrisponding answers
            string answers = "";
            for (int i = 1; i <= 10; i++)
            {
                answers = accessData.SelectQAnswers(i);
            }
            createNewMessage.WriteData(answers, "Answers");//write question into file
        }

        protected override void OnStop()
        {

        }


    }
}
