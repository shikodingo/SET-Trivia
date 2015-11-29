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
        string directory = @"C:\Users\Nathan\OneDrive\Windows and Mobile Programming\Assign 6\main\User\";//change. *this is modifyible when the program is running but needs to be defaulted to a shared file to start
        string[] questions = new string[10];
        string[,] answers = new string[10, 4];//10q, 4a

        public frmMainUserQ()
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
                    directory = newPath;
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
            // TODO: This line of code loads data into the 'settriviaDataSet.questions' table. You can move, or remove it, as needed.
            this.questionsTableAdapter.Fill(this.settriviaDataSet.questions);

        }

        private void tmr20_Tick(object sender, EventArgs e)
        {
            int timeLeft = 20;
            while (timeLeft != 0)
            {
                if (timeLeft > 0)
                {
                    // Display the new time left
                    // by updating the Time Left label.
                    timeLeft = timeLeft - 1;
                    lblTime.Text = timeLeft + " seconds";
                }
                else
                {
                    // If the user ran out of time, stop the timer
                    tmr20.Stop();
                    lblTime.Text = "Time's up!";
                }
            }
        }
    }
}
