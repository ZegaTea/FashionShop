using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Areas.Admin.Models.DTO
{
    public class adminProductViewDto
    {
        public string maSanPham { get; set; }
        public string moTa { get; set; }
        public int giaSanPham { get; set; }
        public string chatLieu { get; set; }
        public int soLuongDatMua { get; set; }
        public string mauSac { get; set; }
        public string urlAnh { get; set; }
        public DateTime ngayTao { get; set; }
        public string tenSanPham { get; set; }
        public string tenNhom { get; set; }
        public string tenLoai { get; set; }
    }
}