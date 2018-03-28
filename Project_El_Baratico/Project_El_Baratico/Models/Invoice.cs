using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_El_Baratico.Models
{
    public class Invoice
    {
        // Atributtes

        int totalMount;
        List<Product> listProduct;
        Client client;
        List<Offer> listOffer;

        // Getter and setter

        public int TotalMount { get; set; }
        public List<Product> ListProduct { get;}
        public Client Client { get; set; }
        public List<Offer> ListOffer { get; set; }

        // Constructor

        public Invoice()
        {
            listProduct = new List<Product>();
            listOffer = new List<Offer>();
            totalMount = 0;
            client = new Client();
        }

        // Getter and setter

        public void setListProduct(List<Product> pListProduct)
        {
            this.listProduct = pListProduct;
        }

        public void setListOffer(List<Offer> pListOffer)
        {
            this.listOffer = pListOffer;
        }

        /**
         * Method calculate mount
         * Author: Danny Xie Li
         * Description: Calculate the mount of the products and offer.
         * Created: 22/03/18
         * Last modification: 22/03/18
        */
        public int calculateMount()
        {
            int mount = 0;
            int counter = 0;
            while(listProduct.Count > counter)
            {
                mount = listProduct[counter].Price + mount;
                counter = counter + 1;
            }
            counter = 0;
            while(listOffer.Count > counter)
            {
                mount = listOffer[counter].OfferPrice + mount;
                counter = counter + 1;
            }
            return mount;
        }
    }
}