using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data;
using MySql.Data.MySqlClient;
using Project_El_Baratico.Interface;


namespace Project_El_Baratico.Models
{
    public class DBConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;
        private string connectValue;

        //Constructor
        public DBConnection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = Interface.IConstant.SERVER;
            database = Interface.IConstant.DATABASE;
            username = Interface.IConstant.USERNAME;
            password = Interface.IConstant.PASSWORD;
            connectValue = Interface.IConstant.CONNECTION;
            connection = new MySqlConnection(connectValue);
        }

        //open connection to database
        public bool OpenConnection()
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
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public MySqlConnection getConnection()
        {
            return this.connection;
        }

        public MySqlCommand getCommand(String pProcedure)
        {
            MySqlCommand cmd = new MySqlCommand(pProcedure, connection);
            return cmd;
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}