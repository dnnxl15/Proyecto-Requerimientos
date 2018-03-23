using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_El_Baratico.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginUser()
        {
            return View();
        }

        public ActionResult signClient()
        {
            return RedirectToAction("registerClient","SignUpClient");
        }

        public ActionResult signAdministrator()
        {
            return RedirectToAction("registerAdministrator", "SignUpAdministrator");
        }
    }
}