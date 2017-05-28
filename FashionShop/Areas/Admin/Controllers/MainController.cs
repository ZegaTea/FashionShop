using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Areas.Admin.Controllers
{
    public class MainController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            //var temp = Session[Common.CommonConstants.ADMIN_SESSION];
            //if (temp == null)
            //{
            //    return Redirect("../Login/Index");
            //}
            return View();
        }
    }
}