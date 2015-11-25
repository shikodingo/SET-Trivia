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

        delegate void MyCallback(string str);       // Delegate declaration for use in Invoke
        StreamReader input; // The stream reader
        StreamWriter output; // The stream writer
        Thread tInput; // A thread used for the callback
        bool done = false; // A bool for running whiles
        static string machineName = "WIN10-b08"; // Please change this variable to match the computer name before running

        public TriviaService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            


            //The creation of Named Pipes 
            NamedPipeServerStream inputServer = new NamedPipeServerStream("inputPipe");
            NamedPipeClientStream outputClient = new NamedPipeClientStream(machineName, "outputPipe");

            // The connecting and waiting of Named Pipes
            inputServer.WaitForConnection();
            outputClient.Connect();

            // Having the streams equal their specific pipes
            input = new StreamReader(inputServer); 
            output = new StreamWriter(outputClient);

            // Have the thread start with the method getMessage
            tInput = new Thread(new ThreadStart(getMessage));
            // Start thread
            tInput.Start();


            // Set the string outp to the users message so we can write it out
            string outp = txtInput.Text;
            // Write the outp 
            output.WriteLine(outp);
            // Delete
            output.Flush();
            // Set the txt box to blank
            txtInput.Text = "";
        
 
     
                    // The callback is connected to the printMessage function so that it can print the clients msg
                    MyCallback callback = new MyCallback(printMessage); // Callback is instance of delegate
                    // This invokes the callback
                    Invoke(callback, new object[] { inp });
        }

        protected override void OnStop()
        {

        }


    }
}
