using FashionShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace FashionShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var result = dao.CheckLogin(lm.userName, lm.passWord);
                if (result)
                {
                    Session.Add(Common.CommonConstants.ADMIN_SESSION, lm.userName.ToString());
                    return RedirectToAction("Index", "Main");
                }
            }
            return View("Index");
        }
    }
}