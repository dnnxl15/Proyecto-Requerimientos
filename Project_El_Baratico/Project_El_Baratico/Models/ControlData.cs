using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;


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
            command.Parameters.AddWithValue("@name", pName);          // Set the parameter
            command.Parameters.AddWithValue("@lastname", pLastname);  // Set the parameter
            command.Parameters.AddWithValue("@username", pUsername);  // Set the parameter
            command.Parameters.AddWithValue("@password", pPassword);  // Set the parameter
            command.Parameters.AddWithValue("@address", pAddress);    // Set the parameter
            command.Parameters.AddWithValue("@email", pEmail);        // Set the parameter
            MySqlTransaction trx = conection.getConnection().BeginTransaction(); // Begin the transaction
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
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_INSERT_CLIENT, conection.getConnection()); 
            command.CommandType = CommandType.StoredProcedure;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", pName);          // Set the parameter
            command.Parameters.AddWithValue("@lastname", pLastname);  // Set the parameter
            command.Parameters.AddWithValue("@username", pUsername);  // Set the parameter
            command.Parameters.AddWithValue("@password", pPassword);  // Set the parameter
            command.Parameters.AddWithValue("@address", pAddress);    // Set the parameter
            command.Parameters.AddWithValue("@email", pEmail);        // Set the parameter
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

        /**
         * Method get all the products register in the database
         * Author: Danny Xie Li
         * Description:  get all the products register in the database.
         * Created: 22/03/18
         * Last modification: 22/03/18
         */
        public List<Product> getProduct()
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_GET_PRODUCT, conection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            List<Product> listProduct = new List<Product>();
            while (reader.Read())
            {
                Product tmp = new Product // Create an instance of the object product
                {
                    Category = reader.GetString("Category"),
                    Price = reader.GetInt16("Price"),
                    Id = reader.GetInt16("ID"),
                    Name = reader.GetString("name")
                };
                listProduct.Add(tmp);
            }
            return listProduct;
        }

        /**
          * Method get all the offer register in the database
          * Author: Danny Xie Li
          * Description: get all the offer register in the database.
          * Created: 22/03/18
          * Last modification: 22/03/18
        */
        public List<Offer> getOffer()
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            // Change procedure to administrator
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_GET_OFFER, conection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            List<Offer> listOffer = new List<Offer>();
            while (reader.Read())
            {
                Offer tmp = new Offer // Create an instance of the object offer
                {
                    idOffer = reader.GetInt16("IdOffer"),
                    OriginalPrice = reader.GetInt16("Original"),
                    OfferPrice = reader.GetInt16("OfferPrice"),
                    Name = reader.GetString("Name")
                };
                listOffer.Add(tmp);
            }
            return listOffer;
        }

        /**
          * Method get all the category register in the database
          * Author: Danny Xie Li
          * Description: get all the category register in the database.
          * Created: 22/03/18
          * Last modification: 22/03/18
         */
        public List<Category> getCategory()
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_GET_CATEGORY, conection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            List<Category> listCategory = new List<Category>();
            while (reader.Read())
            {
                string url = "searchCategory/" + reader.GetString("Category") + "?";
                string name = reader.GetString("Category");
                Category category = new Category(url, name);
                listCategory.Add(category);
            }
            return listCategory;
        }

        /**
          * Method get offer by id
          * Author: Danny Xie Li
          * Description: get offer by id
          * Created: 22/03/18
          * Last modification: 22/03/18
         */
        public Offer getOfferById(int pId)
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_GET_OFFER_BY_ID, conection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pId", pId);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Offer tmp = new Offer // Create an instance of the object offer
                {
                    idOffer = reader.GetInt16("IdOffer"),
                    OriginalPrice = reader.GetInt16("Original"),
                    OfferPrice = reader.GetInt16("OfferPrice"),
                    Name = reader.GetString("Name")
                };
                return tmp;
            }
            return null;
        }

        /**
         * Method get product by id
         * Author: Danny Xie Li
         * Description: get product by id
         * Created: 22/03/18
         * Last modification: 22/03/18
        */
        public Product getProductById(int pId)
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            // Change procedure to administrator
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_GET_PRODUCT_BY_ID, conection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pId", pId);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product tmp = new Product // Create an instance of the product
                {
                    Id = reader.GetInt16("id"),
                    Price = reader.GetInt16("price"),
                    Category = reader.GetString("category"),
                    Name = reader.GetString("name")
                };
                return tmp;
            }
            return null;
            
        }

        /**
         * Method get product by category
         * Author: Danny Xie Li
         * Description: get product by category
         * Created: 22/03/18
         * Last modification: 22/03/18
         */
        public List<Product> getProductByCategory(String pCategory)
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_GET_PRODUCT_BY_CATEGORY, conection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pCategory", pCategory);
            MySqlDataReader reader = command.ExecuteReader();
            List<Product> listProduct = new List<Product>();
            while (reader.Read())
            {
                Product tmp = new Product
                {
                    Id = reader.GetInt16("ID"),
                    Price = reader.GetInt16("Price"),
                    Category = reader.GetString("Category"),
                    Name = reader.GetString("Name")
                };
                listProduct.Add(tmp);
            }
            return listProduct;
        }

        /**
          * Method search product by name
          * Author: Danny Xie Li
          * Description: search product by name
          * Created: 22/03/18
          * Last modification: 22/03/18
         */
        public List<Product> searchProduct(String pName)
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_GET_PRODUCT_BY_NAME, conection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pName", "%"+pName+"%");
            MySqlDataReader reader = command.ExecuteReader();
            List<Product> listProduct = new List<Product>();
            while (reader.Read())
            {
                Product tmp = new Product //Create an instance of the object product
                {
                    Id = reader.GetInt16("ID"),
                    Price = reader.GetInt16("Price"),
                    Category = reader.GetString("Category"),
                    Name = reader.GetString("Name")
                };
                listProduct.Add(tmp);
            }
            return listProduct;
        }

        /**
          * Method get the message from a client
          * Author: Danny Xie Li
          * Description: get the message from a specific client
          * Created: 28/03/18
          * Last modification: 28/03/18
         */
        public List<Message> getMessage(int pId)
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_GET_MESSAGE_BY_CLIENT, conection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pId", pId);
            MySqlDataReader reader = command.ExecuteReader();
            List<Message> listMessage = new List<Message>();
            while (reader.Read())
            {
                string response;
                if (reader.GetString("admiText") == null)
                {
                    response = "";
                }
                else
                {
                    response = reader.GetString("admiText");
                }
                Message tmp = new Message //Create an instance of the object product
                {
                    Menssage = reader.GetString("clientText"),
                    Client = new Client {
                        Id = reader.GetInt16("clientID")
                    },
                    DateOfMessage = reader.GetMySqlDateTime("date").GetDateTime(),
                    Response = response
                };
                listMessage.Add(tmp);
            }
            return listMessage;
        }

        /**
          * Method insert the message from a client
          * Author: Danny Xie Li
          * Description: insert the message from a specific client
          * Created: 28/03/18
          * Last modification: 28/03/18
         */
        public void insertMessage(String pText, int pIdClient)
        {
            DBConnection conection = new DBConnection();
            conection.OpenConnection();
            MySqlCommand command = new MySqlCommand(Interface.IConstant.PROCEDURE_INSERT_MESSAGE, conection.getConnection());
            command.CommandType = CommandType.StoredProcedure;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pClientText", pText);          // Set the parameter
            command.Parameters.AddWithValue("@pClientId", pIdClient);  // Set the parameter
          
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