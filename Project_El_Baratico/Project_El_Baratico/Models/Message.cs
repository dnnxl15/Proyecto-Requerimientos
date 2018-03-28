using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Project_El_Baratico.Models
{
    public class Message
    {
        // Atributes

        string menssage;
        SqlDateTime dateOfMessage;
        Client client;
        string response;

        public string Menssage { get; set ; }
        public SqlDateTime DateOfMessage { get; set; }
        public Client Client { get; set; }
        public string Response { get; set; }

        public string getDateString()
        {
            return dateOfMessage.ToString();
        }
    }
}