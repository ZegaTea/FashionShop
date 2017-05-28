using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Areas.Admin.Models.Dao;
using FashionShop.Areas.Admin.Models.DTO;
using Model.Entities;
using Model.Dao;

namespace FashionShop.Areas.Admin.Controllers
{
    public class GroupDetailController : BaseController
    {
        // GET: Admin/GroupDetail
        public ActionResult Index()
        {
            var dao = new adminGroupDetailDao().getListDetail().ToList();
            return View(dao);
        }

        public ActionResult Detail(string id)
        {
            GroupDetailDTO model = new GroupDetailDTO();
            model.groupDetail = new adminGroupDetailDao().getDetail(id);
            model.listGroupPr = new adminGroupDao().getList().ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new adminGroupDao().getList().ToList();
            return View(model);
        }


        public JsonResult CreateGroupDetail(string maLoai, string tenLoai, string tittle, string manhom)
        {
            FashionShopDbContext db = new FashionShopDbContext();
            GroupDetail temp = db.GroupDetail.Find(maLoai);
            if (temp == null)
            {
                var list = db.GroupDetail.Where(x => x.meta_tittle == tittle).ToList();
                if (list.Count() == 0)
                {
                    GroupDetail grDetail = new GroupDetail();
                    grDetail.maLoaiSanPham = maLoai;
                    grDetail.tenLoaiSanPham = tenLoai;
                    grDetail.meta_tittle = tittle;
                    grDetail.nhomMa = manhom;
                    db.GroupDetail.Add(grDetail);
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
        public JsonResult DeleteGroupDetail(string id)
        {
            FashionShopDbContext db = new FashionShopDbContext();
            GroupDetail grDetail = db.GroupDetail.Find(id);
            if (grDetail != null)
            {
                db.GroupDetail.Remove(grDetail);
                db.SaveChanges();
            }
            return Json(new
            {
                status = true
            });
        }

        public JsonResult UpdateGroupDetail(string maLoai, string tenLoai, string tittle, string maNhom)
        {
            FashionShopDbContext db = new FashionShopDbContext();
            GroupDetail grDetail = db.GroupDetail.Find(maLoai);
            if (grDetail != null)
            {
                grDetail.tenLoaiSanPham = tenLoai;
                grDetail.meta_tittle = tittle;
                grDetail.nhomMa = maNhom;
                db.SaveChanges();
            }
            return Json(new
            {
                status = true
            });
        }
    }
}