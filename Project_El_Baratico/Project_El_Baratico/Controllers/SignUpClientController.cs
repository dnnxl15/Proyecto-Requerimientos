using Project_El_Baratico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_El_Baratico.Controllers
{
    public class SignUpClientController : Controller
    {
        /**
         * Method Index
         * Author: Danny Xie Li
         * Description: Index view of the Sign up control.
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult Index()
        {
            return View();
        }

        /**
         * Method register client
         * Author: Danny Xie Li
         * Description: Register client view.
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult registerClient()
        {
            return View();
        }

        /**
         * Method save client
         * Author: Danny Xie Li
         * Description: Save client to the database.
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        [HttpPost]
        public ActionResult saveClient()
        {
            string name = Request.Form["pName"].ToString();
            string lastname = Request.Form["pLastname"];
            string username = Request.Form["pUsername"];
            string password = Request.Form["pPassword"];
            string email = Request.Form["pEmail"];
            string address = Request.Form["pAddress"];
            string confirm = Request.Form["pConfirm"];
            if (confirm.Equals(password))
            {
                ControlData control = new ControlData();
                control.insertClient(name, lastname, email, username, password, address);
                return RedirectToAction("LoginUser", "Login");
            }
            else
            {
                ViewData["Password"] = "Password don't match";
                return registerClient();
            }
        }

       /**
        * Method login user
        * Author: Danny Xie Li
        * Description: Login user view.
        * Created: 25/03/18
        * Last modification: 27/03/18
        */
        public ActionResult loginUser()
        {
            return RedirectToAction("LoginUser", "Login");
        }
    }
}