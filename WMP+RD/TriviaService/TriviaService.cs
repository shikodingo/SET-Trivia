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

        // FUNCTION     : SetLblInvoke(Object str)
        // DESCRIPTION  : allows the text box to be altered from places other than where it was created
        // PARAMETERS   : <Object><str><the data you want to put into the textbox>
        // RETURNS      : void
        private void SetLblInvoke(Object str)
        {
            if (messageOutputBox.InvokeRequired)                                  // InvokeRequired property is true if child thread
            {
                MyCallback callback = new MyCallback(SetLblInvoke);        // Callback is instance of delegate
                Invoke(callback, new object[] { str });
            }
            else                                                        // Direct access to Control if parent thread
            {
                messageOutputBox.Text += (String)str + "\r\n";
            }
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
                Thread t1 = new Thread(new ParameterizedThreadStart(SetLblInvoke));
                t1.Start(fileData);//currently overwriting message need to make it use += not =
                if (fileData == "Shutdown")
                {

                }
            }
            else
            {
                this.messageOutputBox.Text += status + "\r\n";
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
                createNewMessage.WriteData(question);//write question into file
            }
            
        }

        protected override void OnStart(string[] args)
        {
 
        }

        protected override void OnStop()
        {

        }


    }
}
