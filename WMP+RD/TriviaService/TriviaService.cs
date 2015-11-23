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
using MySql.Data.MySqlClient;


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

        private MySqlConnection connection;
        string host;	// ip address of host
        string user;		// user name
        string password;	// password
        string db;		// database name
        string connectionString;
        int port = 3306;	// You may also use 0, which uses the default anyway (3306)
        
        static string strQuery; // query string
        public TriviaService()
        {
            InitializeComponent();         
        }

        //Initialize values
        private void Initialize()
        {
            host = "localhost";	// ip address of host
            user = "superuser";		// user name
            password = "admin";	// password
            db = "settriviaDataSet";		// database name
            connectionString = "SERVER=" + host + ";" + "DATABASE=" + db + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        throw new System.Exception("Cannot connect to server.");

                    case 1045:
                        throw new System.Exception("Invalid username/password, please try again");
                }
                return false;
            }
            
            
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                throw new System.Exception(ex.Message);
                //return false;
            }
        }

        //Insert statement
        public void Insert(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string query)
        {
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select(string query)
        {
            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count(string query)//"SELECT Count(*) FROM tableinfo"
        {
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
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
