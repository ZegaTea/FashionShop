using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.ViewModel
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {

        }
        public string maLoaiSanPham { get; set; }
        public string tenLoaiSanPham { get; set; }
        public string nhomMa { get; set; }
        public string tenNhom { get; set; }
        public List<GroupPr> ListGroup { get; set; }
        public List<GroupDetail> ListGroupDetail { get; set; }
    }
}
