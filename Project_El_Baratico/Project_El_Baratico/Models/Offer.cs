using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_El_Baratico.Models
{
    public class Offer
    {
        // Attributes

        public int idOffer;
        int originalPrice;
        int offerPrice;
        string name;

        // Getter and setter

        public int OriginalPrice { get; set; }
        public int OfferPrice { get; set; }
        public string Name { get; set; }
        public int IdOffer { get; set; }
    }
}