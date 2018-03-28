using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_El_Baratico.Models
{
    public class Cart
    {
        // Atributes

        private static Cart instance;
        List<Product> listProduct;
        List<Offer> listOffer;
        Invoice invoice;

        // Getter and setter

        public List<Offer> ListOffer { get; set; }
        public Invoice Invoice { get; set; }

        // Constructor

        private Cart()
        {
            listProduct = new List<Product>();
            listOffer = new List<Offer>();
            invoice = new Invoice();
        }

        // Instance

        public static Cart Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Cart();
                }
                return instance;
            }
        }

        /**
         * Method get the list of products
         * Author: Danny Xie Li
         * Description: Get the list of products.
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public List<Product> getListProduct()
        {
            return this.listProduct;
        }

        /**
         * Method get the list of offer
         * Author: Danny Xie Li
         * Description: Get the list of offer.
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public List<Offer> getListOffer()
        {
            return this.listOffer;
        }

        /**
         * Method add a product
         * Author: Danny Xie Li
         * Description: add a product.
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public void addProduct(Product pProduct)
        {
            listProduct.Add(pProduct);
        }

        /**
         * Method add an offer 
         * Author: Danny Xie Li
         * Description: add an offer.
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public void addOffer(Offer pOffer)
        {
            listOffer.Add(pOffer);
        }

        
        public Invoice generateInvoice()
        {
            return null;
        }

        /**
          * Method a calculate the mount
          * Author: Danny Xie Li
          * Description: calculate the mount with all the products and offers.
          * Created: 25/03/18
          * Last modification: 27/03/18
          */
        public int calculateInvoice()
        {
            invoice.setListOffer(listOffer);
            invoice.setListProduct(listProduct);
            return invoice.calculateMount(); 
        }
    }
}