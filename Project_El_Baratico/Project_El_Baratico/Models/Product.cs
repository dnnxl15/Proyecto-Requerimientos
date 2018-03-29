using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_El_Baratico.Models
{
    public class Product
    {
        // Attributes

        string name;
        int price;
        string category;
        int id;
        int rate;
        int mount;

        // Getter and setter

        public int Rate { get; set;}
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int Id { get; set; }
        public int Mount { get; set; }
    }
}