﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Areas.Admin.Models.Dao;

namespace FashionShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var temp = Session[Common.CommonConstants.ADMIN_SESSION];
            if (temp == null)
            {
                return Redirect("../Login/Index");
            }
            else
            {
                var dao = new adminProductDao().getList();
                return View(dao);
            }

        }

        public ActionResult Delete(string id)
        {
            return View();
        }

        public ActionResult Detail(string id)
        {
            var model = new adminProductDao().detail(id);
            return View(model);
        }
    }
}