using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ProductDetailViewModel
    {
        public string maSanPham { get; set; }
        public string moTa { get; set; }
        public int giaSanPham { get; set; }
        public string chatLieu { get; set; }
        public string loaiSanPhamMa { get; set; }
        public int soLuongDatMua { get; set; }
        public string mauSac { get; set; }
        public string urlAnh { get; set; }
        public DateTime ngayTao { get; set; }
        public string tenSanPham { get; set; }
        public string size { get; set; }
        public int soLuong { get; set; }
    }
}
