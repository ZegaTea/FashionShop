using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.ViewModel;
using Model.Entities;

namespace FashionShop.Models
{
    public class RelaProducts
    {
        public  Product product { get; set; }
        public IEnumerable<ProductViewModel> listRelaProduct { get; set; }
        public List<ProductDetail> productDetail { get; set; }

    }
}