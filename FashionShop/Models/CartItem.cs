using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entities;

namespace FashionShop.Models
{
    public class CartItem
    {
        public string size { get; set; }
        public int soLuong { get; set; }
        public Product product { get; set; }
    }
}