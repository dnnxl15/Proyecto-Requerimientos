using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_El_Baratico.Controllers
{
    public class LoginController : Controller
    {
        /**
         * Method Index
         * Author: Danny Xie Li
         * Description: Index, main page of the controller
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult Index()
        {
            return View();
        }

        /**
         * Method Login User view
         * Author: Danny Xie Li
         * Description: Login user, main page of the controller login
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult LoginUser()
        {
            return View();
        }

        /**
         * Method sign client
         * Author: Danny Xie Li
         * Description: Link, link the page to sign client view
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult signClient()
        {
            return RedirectToAction("registerClient","SignUpClient");
        }

        /**
         * Method sign administrator
         * Author: Danny Xie Li
         * Description: Link, link the page to sign administrator view
         * Created: 25/03/18
         * Last modification: 27/03/18
         */
        public ActionResult signAdministrator()
        {
            return RedirectToAction("registerAdministrator", "SignUpAdministrator");
        }
    }
}