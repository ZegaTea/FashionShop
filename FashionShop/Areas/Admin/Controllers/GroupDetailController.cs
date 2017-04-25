using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Areas.Admin.Models.Dao;

namespace FashionShop.Areas.Admin.Controllers
{
    public class GroupDetailController : Controller
    {
        // GET: Admin/GroupDetail
        public ActionResult Index()
        {
            var temp = Session[Common.CommonConstants.ADMIN_SESSION];
            if (temp == null)
            {
                return Redirect("../Login/Index");
            }
            else
            {
                var dao = new adminGroupDetailDao().getListDetail().ToList();
                return View(dao);
            }
            
        }

        public ActionResult Detail(string id)
        {
            return View();
        }
    }
}