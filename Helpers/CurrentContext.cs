﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T2P_Project.Models;

namespace T2P_Project.Helpers
{
    public class CurrentContext
    {
        public static bool IsLogged()
        {
            var flag = HttpContext.Current.Session["isLogin"];
            if (flag == null || (int)flag == 0)
            {
                return false;
            }
            return true;
        }
        public static User GetCurUser(){
            return (User)HttpContext.Current.Session["user"];
        }

        public static void Destroy()
        {
            HttpContext.Current.Session["isLogin"] = 0;
            HttpContext.Current.Session["user"] = null;
        }
    }
}