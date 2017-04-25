using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entities;


namespace FashionShop.Areas.Admin.Models.DTO
{
    public class ProductDetail
    {
        public List<adminProductViewDto> product { get; set; }
        public List<GroupDetail> groupDetail { get; set; }
    }
}