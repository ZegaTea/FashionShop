using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;
using Model.Dao;
using System.Web.Script.Serialization;

namespace FashionShop.Controllers
{
    public class ProductController : Controller
    {
        
        public ActionResult Index(string id, int page = 1, int pageSize = 2)
        {
            int totalRecord = 0;
            var dao = new ProductDao();

            var model = dao.getListById(id, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = totalRecord / pageSize;
            totalRecord = totalRecord - (totalPage * pageSize);
            if (totalRecord > 0) totalPage++;
            
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            ViewBag.ProductType = id;

            return View(model);
        }
        // GET: Product
        public ActionResult Detail(string id)
        {
            
            var dao = new ProductDao();
            var model = new RelaProducts();
            model.product = dao.ViewDetail(id);
            model.productDetail = dao.ViewProductDetail(id);
            model.listRelaProduct = dao.getListAll().Where(x => x.maLoaiSanPham == model.product.loaiSanPhamMa && x.maSanPham!= model.product.maSanPham).Take(3);
            return View(model);
        }    
        
        public JsonResult AddCart(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<CartItem>(cartModel);
            var sessionCart = (List<CartItem>)Session[Common.CommonConstants.CART_SESSION];
            var product = new ProductDao().ViewDetail(jsonCart.product.maSanPham);
            var cart = Session[Common.CommonConstants.CART_SESSION];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x=>x.product.maSanPham == jsonCart.product.maSanPham && x.size == jsonCart.size))
                {
                    foreach(var item in list)
                    {
                        if(item.product.maSanPham == jsonCart.product.maSanPham && item.size == jsonCart.size)
                        {
                            item.soLuong += jsonCart.soLuong;
                        }
                    }
                } else
                {
                    var item = new CartItem();
                    item.product = product;
                    item.size = jsonCart.size;
                    item.soLuong = jsonCart.soLuong; 
                    list.Add(item);
                }
                Session[Common.CommonConstants.CART_SESSION] = list;
            } else
            {
                var item = new CartItem();
                item.product = product;
                item.size = jsonCart.size;
                item.soLuong = jsonCart.soLuong;
                var list = new List<CartItem>();
                list.Add(item);
                Session[Common.CommonConstants.CART_SESSION] = list;
            }

            return Json(new
            {
                status = true,
            });
        }       
    }
}