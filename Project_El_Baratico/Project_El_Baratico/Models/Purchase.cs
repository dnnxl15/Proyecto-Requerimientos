using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Project_El_Baratico.Models
{
    public class Purchase
    {
        String productName;
        int amount;
        int finalAmount;
        SqlDateTime dateOfPurchase;

        public string ProductName { get; set; }
        public int Amount { get; set; }
        public int FinalAmount { get; set; }
        public SqlDateTime DateOfPurchase { get; set;}

        public string getDate()
        {
            return DateOfPurchase.ToString();
        }
    }
}