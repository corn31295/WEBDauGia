using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T2P_Project.Models;
using T2P_Project.Helpers;
namespace T2P_Project.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(Login1 model)
        {

            using (var ctx = new T2PEntities())
            {
                var user = ctx.Users
                    .Where(u => u.UserName == model.UserName && u.Password == model.Password)
                    .FirstOrDefault();
                if  (user != null)
                {
                    Session["isLogin"] = 1;
                    Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMsg = "Fail to login!!!";
                    return View(); 
                }
            } 
        }

        //
        // POST: /Account/Logout
        [HttpPost]
        public ActionResult Logout()
        {
            CurrentContext.Destroy();
            return RedirectToAction("Index", "Home");
        }
        //public  ActionResult Register()
        //{
        //    return View();
        //}
	}
}