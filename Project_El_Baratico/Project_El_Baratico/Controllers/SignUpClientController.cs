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
        // GET: SignUpClient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult any()
        {
            return Content("This");
        }

        public ActionResult registerClient()
        {
            return View();
        }

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
    

        public ActionResult loginUser()
        {
            return RedirectToAction("LoginUser", "Login");
        }
    }
}