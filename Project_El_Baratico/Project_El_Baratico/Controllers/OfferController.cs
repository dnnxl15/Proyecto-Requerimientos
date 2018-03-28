using Project_El_Baratico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Project_El_Baratico.Controllers
{
    public class OfferController : Controller
    {
        Cart cart = Cart.Instance; // Singleton of the instance of cart
        ControlData control;

        /**
         * Method Index
         * Author: Danny Xie Li
         * Description: Index, index of the view controller offer
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult Index()
        {
            return View();
        }

        /**
         * Method See product
         * Author: Danny Xie Li
         * Description: See product, see product view
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult seeProduct()
        {
            control = new ControlData();
            ViewBag.Collection = control.getProduct();
            ViewBag.Second = control.getCategory();
            return View();
        }

        /**
         * Method show view Offer
         * Author: Danny Xie Li
         * Description: Show view offer, show all the offers in a view
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult Offer()
        {
            control = new ControlData();
            ViewBag.Collection = control.getOffer();
            ViewBag.Second = control.getCategory();
            return View();
        }

        /**
         * Method action add offer to the cart
         * Author: Danny Xie Li
         * Description: Redirect to the view offer after add some product to the cart, action add offer to the cart and receive the id of the offer
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult addOffer(string id)
        {
            control = new ControlData();
            Offer offerTmp = control.getOfferById(Int32.Parse(id));
            cart.addOffer(offerTmp);
            ViewBag.Id = id;
            return RedirectToAction("Offer", "Offer");
        }

        /**
         * Method action add product to the cart
         * Author: Danny Xie Li
         * Description: Redirect to the view product after add some product to the cart, action add offer to the cart and receive the id of the product
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult addProduct(string id)
        {
            control = new ControlData();
            Product productTmp = control.getProductById(Int32.Parse(id));
            cart.addProduct(productTmp);
            ViewBag.Id = id;
            return RedirectToAction("seeProduct","Offer");
        }

        /**
         * Method action pay the cart
         * Author: Danny Xie Li
         * Description: Redirect to the view cart, to pay the cart
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult payCart()
        {
            control = new ControlData();
            ViewBag.Second = control.getCategory();
            ViewBag.product = cart.getListProduct();
            ViewBag.offer = cart.getListOffer();
            ViewBag.totalMount = cart.calculateInvoice();
            return View();
        }

        /**
         * Method search a product by category
         * Author: Danny Xie Li
         * Description: Redirect to the view of category search a product by category and receive the category as a string.
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult searchCategory(string pCategory)
        {
            control = new ControlData();
            ViewBag.Second = control.getCategory();
            ViewBag.productCategory = control.getProductByCategory(pCategory);
            ViewBag.title = "Categoria " + pCategory;
            return View();
        }

        /**
        * Method search product
        * Author: Danny Xie Li
        * Description: Redirect to the view of product, search product by name using post.
        * Created: 25/03/18
        * Last modification: 27/03/18
        */
        [HttpPost]
        public ActionResult searchProduct()
        {
            string name = Request.Form["pProduct"].ToString();
            control = new ControlData();
            ViewBag.title = "Search " + name;
            ViewBag.Collection = control.searchProduct(name);
            ViewBag.Second = control.getCategory();
            return View();
        }
    }
}