using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace TriviaService
{
    class IPCFileProducer
    {
        static Mutex mut;
        //const string directory = @"C:\Users\Nathan\OneDrive\Windows and Mobile Programming\Assign 6\main\";//send message files to this folder
        StreamWriter file = null;

        // FUNCTION     : IPCFileProducer()
        // DESCRIPTION  : constructor
        // PARAMETERS   : void
        // RETURNS      : void
        public IPCFileProducer()
        {
            if (!Mutex.TryOpenExisting("MyMutex", out mut))
            {
                mut = new Mutex(true, "MyMutex");
                mut.ReleaseMutex();
            }
        }

        // FUNCTION     : newMessage_KeyPress(object sender, KeyPressEventArgs e)
        // DESCRIPTION  : writes data/message to a text file
        // PARAMETERS   : <string><data><data to be written>
        // RETURNS      : <string><result><was write sucessful or not>
        public string WriteData(string data, string fileTitle, string directory)
        {
            string filePath = directory + fileTitle + ".txt";//string filePath = directory + Guid.NewGuid().ToString() + ".txt";
            string result = "OK";

            mut.WaitOne();
            try
            {
                file = new StreamWriter(filePath);
                file.WriteLine(data);
            }
            catch (Exception ex)
            {
                result = "Exception: " + ex.Message;
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                    file = null;
                }
            }
            mut.ReleaseMutex();
            return result;
        }
    }
}
