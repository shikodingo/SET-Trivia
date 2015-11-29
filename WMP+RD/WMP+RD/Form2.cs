using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace WMP_RD
{
    public partial class frmMainUserQ : Form
    {
        StreamReader file = null;
        static Mutex mut;
        FileSystemWatcher fsw;
        string directory = @"C:\Users\Nathan\OneDrive\Windows and Mobile Programming\Assign 6\main\";//change. *this is modifyible when the program is running but needs to be defaulted to a shared file to start
        const string watchExt = @"User\";
        const string writeExt = @"Service\";
        string[] questions = new string[10];
        string[,] answers = new string[10, 4];//10q, 4a
        int currentQuestionCounter = 1;
        string usersName = "";//need to set some how

        public frmMainUserQ()
        {
            InitializeComponent();

            if (!Mutex.TryOpenExisting("MyMutex", out mut))
            {
                mut = new Mutex(true, "MyMutex");
                mut.ReleaseMutex();
            }
            fsw = new FileSystemWatcher(directory + watchExt);//awesome file system watcher that sends an event when something changes in the file
            fsw.Filter = "*.txt";
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            fsw.InternalBufferSize = 65535;
            fsw.EnableRaisingEvents = true;

            fsw.Created += new FileSystemEventHandler(fsw_Created);
        }


        void fsw_Created(object sender, FileSystemEventArgs e)
        {
            string status;
            string fileData = ReadFile(e.FullPath, out status);
            string fileTitle = Path.GetFileName(e.FullPath);
            char[] delimiterChars = { '|' };
            string[] words = fileData.Split(delimiterChars);
            if (status == "OK")//file was read correctly
            {
                if (fileTitle == "changeDirectory")//just the main directory auto generates Service, Admin, User sub folders
                {
                    string newPath = fileData;
                    directory = newPath;//newPath should just be the "main" path
                }                    
                else if (fileTitle.Contains("Question"))
                {
                    if(fileTitle.Contains("1"))
                    {
                        if(fileTitle.Contains("10"))
                        {                    
                            int counter = 0;
                            foreach (string segment in words)
                            {
                                if (counter == 0)
                                {
                                    questions[10] = segment;
                                }
                                else if (counter <= 4 && counter >= 1)
                                {
                                    answers[10, counter] = segment;
                                }
                                else
                                {
                                    Logging.Log("Too many pieces of data in Question 10 file");
                                }
                                counter++;
                            }
                        }
                        else
                        {
                            int counter = 0;
                            foreach (string segment in words)
                            {
                                if (counter == 0)
                                {
                                    questions[1] = segment;
                                }
                                else if (counter <= 4 && counter >= 1)
                                {
                                    answers[1, counter] = segment;
                                }
                                else
                                {
                                    Logging.Log("Too many pieces of data in Question 1 file");
                                }
                                counter++;
                            }
                        }
                    }
                    else if (fileTitle.Contains("2"))
                    {
                        int counter = 0;
                        foreach (string segment in words)
                        {
                            if (counter == 0)
                            {
                                questions[2] = segment;
                            }
                            else if (counter <= 4 && counter >= 1)
                            {
                                answers[2, counter] = segment;
                            }
                            else
                            {
                                Logging.Log("Too many pieces of data in Question 2 file");
                            }
                            counter++;
                        }
                    }
                    else if (fileTitle.Contains("3"))
                    {
                        int counter = 0;
                        foreach (string segment in words)
                        {
                            if (counter == 0)
                            {
                                questions[3] = segment;
                            }
                            else if (counter <= 4 && counter >= 1)
                            {
                                answers[3, counter] = segment;
                            }
                            else
                            {
                                Logging.Log("Too many pieces of data in Question 3 file");
                            }
                            counter++;
                        }
                    }
                    else if (fileTitle.Contains("4"))
                    {
                        int counter = 0;
                        foreach (string segment in words)
                        {
                            if (counter == 0)
                            {
                                questions[4] = segment;
                            }
                            else if (counter <= 4 && counter >= 1)
                            {
                                answers[4, counter] = segment;
                            }
                            else
                            {
                                Logging.Log("Too many pieces of data in Question 4 file");
                            }
                            counter++;
                        }
                    }
                    else if (fileTitle.Contains("5"))
                    {
                        int counter = 0;
                        foreach (string segment in words)
                        {
                            if (counter == 0)
                            {
                                questions[5] = segment;
                            }
                            else if (counter <= 4 && counter >= 1)
                            {
                                answers[5, counter] = segment;
                            }
                            else
                            {
                                Logging.Log("Too many pieces of data in Question 5 file");
                            }
                            counter++;
                        }
                    }
                    else if (fileTitle.Contains("6"))
                    {
                        int counter = 0;
                        foreach (string segment in words)
                        {
                            if (counter == 0)
                            {
                                questions[6] = segment;
                            }
                            else if (counter <= 4 && counter >= 1)
                            {
                                answers[6, counter] = segment;
                            }
                            else
                            {
                                Logging.Log("Too many pieces of data in Question 6 file");
                            }
                            counter++;
                        }
                    }
                    else if (fileTitle.Contains("7"))
                    {
                        int counter = 0;
                        foreach (string segment in words)
                        {
                            if (counter == 0)
                            {
                                questions[7] = segment;
                            }
                            else if (counter <= 4 && counter >= 1)
                            {
                                answers[7, counter] = segment;
                            }
                            else
                            {
                                Logging.Log("Too many pieces of data in Question 7 file");
                            }
                            counter++;
                        }
                    }
                    else if (fileTitle.Contains("8"))
                    {
                        int counter = 0;
                        foreach (string segment in words)
                        {
                            if (counter == 0)
                            {
                                questions[8] = segment;
                            }
                            else if (counter <= 4 && counter >= 1)
                            {
                                answers[8, counter] = segment;
                            }
                            else
                            {
                                Logging.Log("Too many pieces of data in Question 8 file");
                            }
                            counter++;
                        }
                    }
                    else if (fileTitle.Contains("9"))
                    {
                        int counter = 0;
                        foreach (string segment in words)
                        {
                            if (counter == 0)
                            {
                                questions[9] = segment;
                            }
                            else if (counter <= 4 && counter >= 1)
                            {
                                answers[9, counter] = segment;
                            }
                            else
                            {
                                Logging.Log("Too many pieces of data in Question 9 file");
                            }
                            counter++;
                        }
                    }
                    else
                    {
                        Logging.Log("Error determining question number");
                    }
                    if(currentQuestionCounter == 1)
                    {
                        txtQuestion.Text = questions[0];
                        rdba.Text = answers[0, 0];
                        rdbb.Text = answers[0, 1];
                        rdbc.Text = answers[0, 2];
                        rdbd.Text = answers[0, 3];
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



        private void frmMainUserQ1_Load(object sender, EventArgs e)
        {
            txtQuestion.Text = questions[0];
            rdba.Text = answers[0, 0];
            rdbb.Text = answers[0, 1];
            rdbc.Text = answers[0, 2];
            rdbd.Text = answers[0, 3];
        }

        private void tmr20_Tick(object sender, EventArgs e)
        {
            int timeLeft = 20;
            while (currentQuestionCounter <= 10)//while (timeLeft != 0)
            {
                if (timeLeft > 0)
                {
                    // Display the new time left
                    // by updating the Time Left label.
                    timeLeft = timeLeft - 1;
                    lblTime.Text = timeLeft + " seconds";
                }
                else if(currentQuestionCounter > 9)
                {
                    tmr20.Stop();
                    //end game
                }
                else
                {
                    // If the user ran out of time, stop the time
                    //tmr20.Stop();
                    timeLeft = 20;

                    txtQuestion.Text = questions[currentQuestionCounter];
                    rdba.Text = answers[currentQuestionCounter, 0];
                    rdbb.Text = answers[currentQuestionCounter, 1];
                    rdbc.Text = answers[currentQuestionCounter, 2];
                    rdbd.Text = answers[currentQuestionCounter, 3];

                    currentQuestionCounter++;
                    lblTime.Text = "Time's up!";
                }
            }
        }

        private void rdba_CheckedChanged(object sender, EventArgs e)
        {
            string extension = writeExt;
            string usersAnswer = "";
            IPCFileProducer createNewMessage = new IPCFileProducer();
            for (int i = 1; i <= 10; i++)
            {
                usersAnswer = currentQuestionCounter + rdba.Text;
                createNewMessage.WriteData(usersAnswer, userName, directory + extension);//write question into file
            }
        }

        private void rdbb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbc_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbd_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
