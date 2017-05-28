using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Common;
using FashionShop.Models;
using Model.Entities;
using Model.Dao;

namespace FashionShop.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[Common.CommonConstants.CART_SESSION];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public JsonResult DeleteItem(string maSanPham, string size)
        {
            var sessionCart = (List<CartItem>)Session[Common.CommonConstants.CART_SESSION];
            sessionCart.RemoveAll(x => x.product.maSanPham == maSanPham && x.size == size);
            Session[Common.CommonConstants.CART_SESSION] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[Common.CommonConstants.CART_SESSION];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string ten, string diachi, string sdt, string email)
        {
            var user = (User)Session[FashionShop.Common.CommonConstants.USER_SESSION];
            Receipt re = new Receipt();
            re.diaChiGiaoHang = diachi;
            re.soDienThoai = sdt;
            re.username = user.username;
            re.tinhTrang = "Chưa giao hàng";
            try
            {
                ReceiptDao dao = new ReceiptDao();
                var ma = dao.Insert(re);
                var cart = (List<CartItem>)Session[Common.CommonConstants.CART_SESSION];
                foreach (var item in cart)
                {
                    ReceiptDetail detail = new ReceiptDetail();
                    detail.maHoaDon = ma;
                    detail.maSanPham = item.product.maSanPham;
                    detail.size = item.size;
                    detail.soLuongDatMua = item.soLuong;
                    detail.thanhTien = (long)(item.soLuong * int.Parse(item.product.giaSanPham.ToString()));
                    dao.InsertDetail(detail);
                    
                }
            }
            catch
            {
                return View("Error");
            }
            return View("Success");
        }
    }
}