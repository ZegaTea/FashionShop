using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.Entities;

namespace FashionShop.Controllers
{
    public class UserController : Controller
    {
        public static string url = "/";
        // GET: User
        public ActionResult Index()
        {
            var userDao = new UserDao();
            IQueryable<User> lsUser = userDao.List();
            return View(lsUser);
        }

        public ActionResult Login()
        {
            var temp = Session[Common.CommonConstants.URL_SESSISON];          
            if (temp != null)
            {
                url = temp.ToString();
                //Session[URL] = url1;
            }
            return View();
        }

        public ActionResult LoginAction(string user, string pass)
        {
           
            var dao = new UserDao();
            bool result = dao.CheckLogin(user, pass);
            if (result)
            {
                //string link = Session[URL].ToString();
                return Redirect(url);
            } else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}