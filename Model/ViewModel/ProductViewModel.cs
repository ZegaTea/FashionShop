using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ProductViewModel
    {
        public string maSanPham { get; set; }
        public string moTa { get; set; }
        public string tenSanPham { get; set; }
        public int giaSanPham { get; set; }
        public string chatLieu { get; set; }
        public int soLuongDatMua { get; set; }
        public string mauSac { get; set; }
        public string urlAnh { get; set; }
        public DateTime ngayTao { get; set; }
        public string maLoaiSanPham { get; set; }
        public string nhomMa { get; set; }
        public string groupTittle { get; set; }
        public string groupDetailTittle { get; set; }
    }
}
