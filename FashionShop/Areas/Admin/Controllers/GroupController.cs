using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Areas.Admin.Models.Dao;
using Model.Entities;

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

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult UpdateGroupPr(string maNhom, string tenNhom, string tittle)
        {
            FashionShopDbContext db = new FashionShopDbContext();
            GroupPr gr = db.GroupPr.Find(maNhom);
            if (gr != null)
            {
                gr.tenNhom = tenNhom;
                gr.meta_tittle = tittle;
                db.SaveChanges();
            }
            return Json(new
            {
                status = true
            });
        }

        public JsonResult CreateGroupPr(string maNhom, string tenNhom, string tittle)
        {
            FashionShopDbContext db = new FashionShopDbContext();
            GroupPr temp = db.GroupPr.Find(maNhom);
            if(temp == null)
            {
                var list = db.GroupPr.Where(x => x.meta_tittle == tittle).ToList();
                if(list.Count() == 0)
                {
                    GroupPr gr = new GroupPr();
                    gr.maNhom = maNhom;
                    gr.tenNhom = tenNhom;
                    gr.meta_tittle = tittle;
                    db.GroupPr.Add(gr);
                    db.SaveChanges();
                    return Json(new
                    {
                        status = 1
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = 3
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = 2
                });
            }
        }
    }
}