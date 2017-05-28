using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;
using Model.Dao;
using Model.Entities;

namespace FashionShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            var model = new ProductDao().getListAll();    
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult LeftMenu()
        {
            var model = new CategoryDao().ListCategory();
            return PartialView("_PartialLeftMenu",model);
        }

        [ChildActionOnly]
        public ActionResult HeaderMenu()
        {
            var model = new CategoryDao().ListCategory();
            return PartialView("_PartialHeader", model);
        }
    }
}