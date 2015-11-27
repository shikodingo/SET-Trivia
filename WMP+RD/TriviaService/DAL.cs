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
            host = "localhost";	// ip address of host //need to change this to the variable got from the first form
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
                Logging.Log("Connection was successful!");
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
                        Logging.Log("Cannot connect to the server!");
                        break;
                    case 1045:
                        Logging.Log("Invalid username/password, please try again");
                        break;
                    default:
                        Logging.Log("Exception caught");
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
                Logging.Log("Connection was closed successfully!");
            }
            catch (MySqlException ex)
            {
                Logging.Log("Exception caught");

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
                Logging.Log("Exception caught");
            }
            this.CloseConnection();//close Connection
            return outputQ;
        }

        //Select statement for answers
        public string SelectQAnswers(int Qnum)
        {
            //Create a list to store the result
            string answers = "";
            string currentAnswer = "";
            //Open connection
            try
            {
                this.OpenConnection();
                if (connection.State == ConnectionState.Open)
                {
                    string aQuery = "Select * FROM answers Where QuestionID=" + Qnum + ";";//string aQuery = "Select A_Letter ADesription FROM answers Where QuestionID=" + Qnum + ";";
                    MySqlCommand cmd = new MySqlCommand(aQuery, connection);//Create Command
                    
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        currentAnswer = (string)dataReader["A_Letter"] + ". " + (string)dataReader["ADescription"] + " | " + (string)dataReader["A_ID"] + " | " + (string)dataReader["ACorrect"] + " | " + (string)dataReader["QuestionID"];
                      
                        
                        answers += currentAnswer + System.Environment.NewLine;
                    }

                    //close Data Reader
                    dataReader.Close();
                }
            }
            catch
            {
                Logging.Log("Exception caught");
            }
            this.CloseConnection();//close Connection
            return answers;//return answers to be displayed
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
                Logging.Log("Exception caught");
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
                Logging.Log("Exception caught");
            }
        }

        public void saveUserAnswer(string userName, int qNum, string usersAnswer, int aScore)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string usersAQuery = "INSERT INTO UsersAnswers (Name, Q_ID, A_ID, ACorrect)" + "VALUES (" + userName + ", " + qNum + ", " + usersAnswer + ", " + aScore + ");";
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(usersAQuery, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logging.Log("Exception caught");
            }
        }

        //update leaderboard
        public void updateLeaderboard(int userID, int score)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    string leaderboardUpdateQuery = "UPDATE Leaderboard SET UScore=" + score + "WHERE uNID=" + userID + ";";
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(leaderboardUpdateQuery, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logging.Log("Exception caught");
            }
        }

        //show leaderboard
        public List<string> showLeaderboard()
        {
            //Create a list to store the result
            List<string> rankInfo = new List<string>();

            try
            {
                this.OpenConnection();//Open connection
                if (connection.State == ConnectionState.Open)
                {
                    string leaderboardQuery = "SELECT uNID, UScore FROM Leaderboard ORDER BY UScore DESC;";
                    MySqlCommand cmd = new MySqlCommand(leaderboardQuery, connection);//Create Command
                    
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        rankInfo.Add(dataReader.GetString(0) + " " + dataReader.GetString(1));// name score
                    }

                    //close Data Reader
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Logging.Log("Exception caught");
            }
            return rankInfo;
        }
            
        //deactivate user
        public void deactivateUser(int U_ID)
        {
            try
            {
                this.OpenConnection();//Open connection
                if (connection.State == ConnectionState.Open)
                {
                    string userStatusQuery = "UPDATE User SET UStatus=FLASE WHERE U_ID=" + U_ID + ";";
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(userStatusQuery, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                Logging.Log("Exception caught");
            }
            this.CloseConnection();//close Connection
        }

        //reactivate user
        public void reactivateUser(int U_ID)//might not need
        {
            try
            {
                this.OpenConnection();//Open connection
                if (connection.State == ConnectionState.Open)
                {
                    string userStatusQuery = "UPDATE User SET UStatus=TRUE WHERE U_ID=" + U_ID + ";";
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(userStatusQuery, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                Logging.Log("Exception caught");
            }
            this.CloseConnection();//close Connection
        }

        //see current status of live users
        public List<string> showCurrentStatus()//unfinsihed*******************
        {
            /*output Needs:
             * users name
             * score
             * current question
             * questions answered and score got on the questions
             */

            //Create a list to store the result
            List<string> userInfo = new List<string>();

            try
            {
                this.OpenConnection();//Open connection
                if (connection.State == ConnectionState.Open)
                {
                    string leaderboardQuery = "SELECT uNID, UScore FROM Leaderboard ORDER BY UScore DESC;";
                    MySqlCommand cmd = new MySqlCommand(leaderboardQuery, connection);//Create Command

                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        userInfo.Add(dataReader.GetString(0) + " " + dataReader.GetString(1));// name score
                    }

                    //close Data Reader
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Logging.Log("Exception caught");
            }
            this.CloseConnection();//close Connection
            return userInfo;
        }

        //find correct answer for question
        public string showCorrectAnswer(int Q_ID)
        {
            string correctAnswer = "";
            try
            {
                this.OpenConnection();//Open connection
                if (connection.State == ConnectionState.Open)
                {
                    string answerTestQuery = "SELECT A_ID FROM ANSWERS WHERE ACorrect=TRUE AND QuestionID=" + Q_ID + ";";
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(answerTestQuery, connection);

                    correctAnswer = Convert.ToString(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Logging.Log("Exception caught");
            }
            this.CloseConnection();//close Connection
            return correctAnswer;
        }

        //edit questions answers
        public void adminEdit(string adminsQuery)
        {
            try
            {
                this.OpenConnection();//Open connection
                if (connection.State == ConnectionState.Open)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(adminsQuery, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logging.Log("Exception caught");
            }
            this.CloseConnection();//close Connection
        }
        
        
        /*
         * average time to answer correctly-excel?
         * num of incorrect answers for question
         * num of correct answers for question
         * percentage of correct answers-excel?
         */
    }
}
