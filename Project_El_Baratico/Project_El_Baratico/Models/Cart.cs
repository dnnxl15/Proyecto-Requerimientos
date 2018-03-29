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

        public List<Product> ListProduct { get; set; }

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

        public List<Product> getProductInequal()
        {
            List<Product> listProductTmp = new List<Product>();
            List<int> listId = new List<int>();
            for (int firstCount = 0; firstCount < this.listProduct.Count; firstCount++)
            {
                if(listId.Contains(listProduct[firstCount].Id))
                {
                }
                else
                {
                    listId.Add(listProduct[firstCount].Id);
                }
            }
            for (int count = 0; count < listId.Count; count++)
            {
                Product tmp = getProduct(listId[count]);
                Product tmpProduct = new Product
                {
                    Category = tmp.Category,
                    Id = tmp.Id,
                    Mount = mountOfItem(tmp),
                    Price = tmp.Price * mountOfItem(tmp),
                    Name = tmp.Name,
                    Rate = tmp.Rate
                };
                listProductTmp.Add(tmpProduct);
            }
            return listProductTmp;
        }

        public int mountOfItem(Product pProduct)
        {
            int mount = 0;
            for (int thirdCount = 0; thirdCount < listProduct.Count; thirdCount++)
            {
                if (listProduct[thirdCount].Id == pProduct.Id)
                {
                    mount = mount + 1;
                    
                }

            }
            return mount;
        }

        public Product getProduct(int pId)
        {
            for (int thirdCount = 0; thirdCount < listProduct.Count; thirdCount++)
            {
                if (listProduct[thirdCount].Id == pId)
                {
                    return listProduct[thirdCount];
                }
            }
            return null;
        }


        public List<Offer> getOfferInequal()
        {
            List<Offer> listOfferTmp = new List<Offer>();
            List<int> listId = new List<int>();
            for (int firstCount = 0; firstCount < this.listOffer.Count; firstCount++)
            {
                if (listId.Contains(listOffer[firstCount].idOffer))
                {
                }
                else
                {
                    listId.Add(listOffer[firstCount].idOffer);
                }
            }
            for (int count = 0; count < listId.Count; count++)
            {
                Offer tmp = getOffer(listId[count]);
                Offer tmpOffer = new Offer
                {
                    idOffer = tmp.idOffer,
                    Mount = mountOfItemOffer(tmp),
                    OfferPrice = tmp.OfferPrice * mountOfItemOffer(tmp),
                    OriginalPrice = tmp.OriginalPrice,
                    Name = tmp.Name
                };
                listOfferTmp.Add(tmpOffer);
            }
            return listOfferTmp;
        }

        public int mountOfItemOffer(Offer pOffer)
        {
            int mount = 0;
            for (int thirdCount = 0; thirdCount < listOffer.Count; thirdCount++)
            {
                if (listOffer[thirdCount].idOffer == pOffer.idOffer)
                {
                    mount = mount + 1;

                }

            }
            return mount;
        }

        public Offer getOffer(int pId)
        {
            for (int thirdCount = 0; thirdCount < listOffer.Count; thirdCount++)
            {
                if (listOffer[thirdCount].idOffer == pId)
                {
                    return listOffer[thirdCount];
                }
            }
            return null;
        }

        public void setListOffer(List<Offer> pListOffer)
        {
            this.listOffer = pListOffer;
        }

        public void setListProduct(List<Product> pListProduct)
        {
            this.listProduct = pListProduct;
        }

    }
}