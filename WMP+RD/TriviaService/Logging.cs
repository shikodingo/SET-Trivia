using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TriviaService
{
    public static class Logging
    {

        //string className, string methodName, 
        public static void Log(string eventDetails)
        {
            EventLog serviceEventLog = new EventLog();
            string formattedS = "SETTrivia" + "-" + eventDetails;

            if (!EventLog.SourceExists("SETTrivia"))
            {
                EventLog.CreateEventSource("SETTrivia", "SETTriviaEvents");
            }
            serviceEventLog.Source = "SETTrivia";
            serviceEventLog.Log = "SETTriviaEvents";

            serviceEventLog.WriteEntry(formattedS);
        }
    }
}