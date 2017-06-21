using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAMT2P.Helpers;
using TEAMT2P.Models;
namespace TEAMT2P.Controllers
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
        public ActionResult Login(LoginVM model)
        {
    
            using (var ctx = new QLBHEntities())
            {
                
                var user = ctx.Users
                    .Where(u => u.f_Username == model.Username && u.f_Password == model.RawPWD)
                    .FirstOrDefault();
                if (user != null)
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