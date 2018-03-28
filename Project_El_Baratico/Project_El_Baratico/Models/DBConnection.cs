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
        // Atributtes

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

        /**
         * Method open connection
         * Author: Danny Xie Li
         * Description: Open connection to the database return true or false if the database is connected.
         * Created: 22/03/18
         * Last modification: 22/03/18
        */
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        break;

                    case 1045:
                        break;
                }
                return false;
            }
        }

        /**
          * Method get connection
          * Author: Danny Xie Li
          * Description: Get the object connection.
          * Created: 22/03/18
          * Last modification: 22/03/18
        */
        public MySqlConnection getConnection()
        {
            return this.connection;
        }

        /**
          * Method get command
          * Author: Danny Xie Li
          * Description: Get command putting the parameter the string procedure.
          * Created: 22/03/18
          * Last modification: 22/03/18
        */
        public MySqlCommand getCommand(String pProcedure)
        {
            MySqlCommand cmd = new MySqlCommand(pProcedure, connection);
            return cmd;
        }

        /**
          * Method close connection
          * Author: Danny Xie Li
          * Description: close connection return a boolean if the connection is close.
          * Created: 22/03/18
          * Last modification: 22/03/18
        */
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}