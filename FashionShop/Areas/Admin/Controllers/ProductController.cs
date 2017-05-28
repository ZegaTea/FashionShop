using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Areas.Admin.Models.Dao;
using FashionShop.Areas.Admin.Models.DTO;
using Model.Dao;
using Model.Entities;

namespace FashionShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var dao = new adminProductDao().getList();
            return View(dao);
        }


        public ActionResult Detail(string id)
        {
            var model = new Models.DTO.ProductDetail();
            model.product = new adminProductDao().getProductDto(id).ToList();
            model.groupDetail = new adminGroupDetailDao().getList().ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new GroupDetailDao().getList();
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
            return Json(new
            {
                status = true
            });
        }

        public JsonResult CreateProduct(Product pr)
        {
            FashionShopDbContext db = new FashionShopDbContext();
            Product temp = db.Product.Find(pr.maSanPham);
            if (temp == null)
            {
                Product pro = new Product();
                pro.maSanPham = pr.maSanPham;
                pro.moTa = pr.moTa;
                pro.giaSanPham = pr.giaSanPham;
                pro.chatLieu = pr.chatLieu;
                pro.loaiSanPhamMa = pr.loaiSanPhamMa;
                pro.soLuongDatMua = 0;
                pro.mauSac = pr.mauSac;
                pro.urlAnh = pr.urlAnh;
                pro.tenSanPham = pr.tenSanPham;
                db.Product.Add(pro);
                db.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        public JsonResult loadChiTiet(string id)
        {
            FashionShopDbContext db = new FashionShopDbContext();
            GroupDetail gr = db.GroupDetail.Find(id);
            return Json(new
            {
                data = gr.nhomMa
            });
        }
    }
}