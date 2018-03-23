using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Project_El_Baratico.Models
{
    public class ControlData
    {
        /**
         * Method insert client in the database
         * Author: Danny Xie Li
         * Description: Insert data into the table client.
         * Created: 22/03/18
         * Last modification: 22/03/18
         */ 
        public void insertClient(String pName, String pLastname, String pEmail, String pUsername, String pPassword, String pAddress)
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_INSERT_CLIENT, conection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", pName);
            command.Parameters.AddWithValue("@lastname", pLastname);
            command.Parameters.AddWithValue("@email", pEmail);
            command.Parameters.AddWithValue("@username", pUsername);
            command.Parameters.AddWithValue("@password", pPassword);
            command.Parameters.AddWithValue("@address", pAddress);
            MySqlTransaction trx = conection.getConnection().BeginTransaction();
            try
            {
                command.Prepare();
                
            }
            catch(Exception e)
            {

            }
            command.Transaction = trx;
                command.ExecuteNonQuery();
                trx.Commit();
        }

        /**
         * Method insert administrator in the database
         * Author: Danny Xie Li
         * Description: Insert data into the table administrator.
         * Created: 22/03/18
         * Last modification: 22/03/18
         */
        public void insertAdministrator(String pName, String pLastname, String pEmail, String pUsername, String pPassword, String pAddress)
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            // Change procedure to administrator
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_INSERT_CLIENT, conection.getConnection()); 
            command.CommandType = CommandType.StoredProcedure;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", pName);
            command.Parameters.AddWithValue("@lastname", pLastname);
            command.Parameters.AddWithValue("@email", pEmail);
            command.Parameters.AddWithValue("@username", pUsername);
            command.Parameters.AddWithValue("@password", pPassword);
            command.Parameters.AddWithValue("@address", pAddress);
            MySqlTransaction trx = conection.getConnection().BeginTransaction();
            try
            {
                command.Prepare();

            }
            catch (Exception e)
            {

            }
            command.Transaction = trx;
            command.ExecuteNonQuery();
            trx.Commit();
        }
    }
}