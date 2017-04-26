using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Areas.Admin.Models.Dao;
using FashionShop.Areas.Admin.Models.DTO;
using Model.Entities;

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


        public ActionResult Detail(string id)
        {
            var model = new Models.DTO.ProductDetail();
            
            model.product = new adminProductDao().getProductDto(id).ToList();
            model.groupDetail = new adminGroupDetailDao().getList().ToList();
            return View(model);
        }

        public JsonResult UpdateProduct(Product product)
        {
            FashionShopDbContext db = new FashionShopDbContext();
            Product pr = db.Product.Find(product.maSanPham);
            if (pr != null)
            {
                pr.tenSanPham = product.tenSanPham;
                pr.soLuongDatMua = product.soLuongDatMua;
                pr.moTa = product.moTa;
                pr.mauSac = product.mauSac;
                pr.loaiSanPhamMa = product.loaiSanPhamMa;
                pr.giaSanPham = product.giaSanPham;
                pr.chatLieu = product.chatLieu;

                db.SaveChanges();
            }
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteProduct(string maSanPham)
        {
            FashionShopDbContext db = new FashionShopDbContext();
            Product pr = db.Product.Find(maSanPham);
            if (pr != null)
            {
                db.Product.Remove(pr);
                db.SaveChanges();
            }
            return Json(new {
                status = true
            });
        }
    }
}