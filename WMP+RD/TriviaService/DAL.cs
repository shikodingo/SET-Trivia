using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Data;

namespace TriviaService
{
    class DAL
    {
        private MySqlConnection connection;
        string host;	// ip address of host
        string user;		// user name
        string password;	// password
        string db;		// database name
        string connectionString;
        int port = 3306;	// You may also use 0, which uses the default anyway (3306)



        //Initialize values
        private void Initialize()//remember to allow this to be changed*************************************
        {
            host = "localhost";	// ip address of host
            user = "root";		// user name
            password = "root";	// password
            db = "settriviaDataSet";		// database name
            connectionString = "SERVER=" + host + ";" + "DATABASE=" + db + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        private void OpenConnection()
        {
            try
            {
                connection.Open();
                //log that connection was sucessful
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
                        //log: "Cannot connect to server."
                        break;
                    case 1045:
                        //log: "Invalid username/password, please try again"
                        break;
                    default:
                        //log: ex.Message
                        break;
                }
            }


        }

        //Close connection
        private void CloseConnection()
        {
            try
            {
                connection.Close();
                //log connection was closed sucessfully
            }
            catch (MySqlException ex)
            {
                //log ex.Message

            }
        }

        //Select statement for questions
        public String SelectAQuestion(int Qnum)
        {
            String outputQ = "";//have to default this or else default is Null and the return doesnt like that.
            //Open connection
            try
            {
                this.OpenConnection();
                if (connection.State == ConnectionState.Open)
                {
                    string qQuery = "Select QDesription FROM questions Where Q_ID=" + Qnum + ";";
                    MySqlCommand cmd = new MySqlCommand(qQuery, connection);//Create Command
                    outputQ = Convert.ToString(cmd.ExecuteScalar());
                }
            }
            catch
            {
                //log: ex.Message
            }
            this.CloseConnection();//close Connection
            return outputQ;
        }

        //Select statement for answers
        public List<string>[] SelectQAnswers(int Qnum)//double check this******************************
        {
            //Create a list to store the result
            List<string>[] answers = new List<string>[5];

            answers[0] = new List<string>();
            answers[1] = new List<string>();
            answers[2] = new List<string>();
            answers[3] = new List<string>();
            answers[4] = new List<string>();

            //Open connection
            try
            {
                this.OpenConnection();
                if (connection.State == ConnectionState.Open)
                {
                    string aQuery = "Select A_Letter ADesription FROM answers Where A_ID=" + Qnum + ";";
                    MySqlCommand cmd = new MySqlCommand(aQuery, connection);//Create Command
                    
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        answers[0].Add(dataReader["A_ID"] + "");
                        answers[1].Add(dataReader["A_Letter"] + "");
                        answers[2].Add(dataReader["ADescription"] + "");
                        answers[3].Add(dataReader["ACorrect"] + "");
                        answers[4].Add(dataReader["TimeTaken"] + "");
                    }

                    //close Data Reader
                    dataReader.Close();

                    

                }
            }
            catch
            {
                //log ex.Message
            }
            this.CloseConnection();//close Connection
            return answers;//return list to be displayed
        }

        public void SaveUsersName(String name)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    String nameQuery = "INSERT INTO Users (Name, IsActive) VALUES ('" + name + "', TRUE);";

                    MySqlCommand cmd = new MySqlCommand(nameQuery, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //log: ex.Message
            }
        }

        public void storeInLeaderboard(string userName, int score)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string lQuery = "INSERT INTO leaderboard (Name, Score) VALUES (" + userName + ", " + score +");";
                    MySqlCommand cmd = new MySqlCommand(lQuery, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //log: ex.Message
            }
        }

        public void saveUserAnswer(string userName, int qNum, string usersAnswer, int aScore)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string usersAQuery = "INSERT INTO UserAnswer (Name, Q_ID, A_ID, ACorrect)" + "VALUES (" + userName + ", " + qNum + ", " + usersAnswer + ", " + aScore + ");";
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(usersAQuery, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //log: ex.Message
            }
        }

        //update leaderboard
        public void updateLeaderboard(string userName, int score)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string leaderboardUpdateQuery = "";
                }
            }
            catch (Exception ex)
            {
                //log: ex.Message
            }
        }

        //show leaderboard
        //deactivate user
        //see current status of live users

        //excel stuff think Jen did already????????



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
    }
}
