using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Common;
using FashionShop.Models;

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
            sessionCart.RemoveAll(x => x.product.maSanPham == maSanPham && x.size==size);
            Session[Common.CommonConstants.CART_SESSION] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
    }
}