using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Areas.Admin.Models.Dao;

namespace FashionShop.Areas.Admin.Controllers
{
    public class GroupController : Controller
    {
        // GET: Admin/Group
        public ActionResult Index()
        {
            var temp = Session[Common.CommonConstants.ADMIN_SESSION];
            if (temp == null)
            {
                return Redirect("../Login/Index");
            }
            else
            {
                var dao = new adminGroupDao().getList();
                return View(dao);
            }
        }

        public ActionResult Detail(string id)
        {
            var dao = new adminGroupDao().detail(id);
            return View(dao);
        }
    }
}