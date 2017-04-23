using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.ViewModel;

namespace Model.Dao
{
    public class CategoryDao
    {
        FashionShopDbContext db = null;
        public CategoryDao()
        {
            db = new FashionShopDbContext();
        }

        public CategoryViewModel ListCategory()
        {
            //var model = from a in db.GroupPr
            //            join b in db.GroupDetail
            //            on a.maNhom equals b.nhomMa
            //            select new CategoryViewModel()
            //            {
            //                maLoaiSanPham = b.maLoaiSanPham,
            //                tenLoaiSanPham = b.tenLoaiSanPham,
            //                nhomMa = a.maNhom,
            //                tenNhom = a.tenNhom,
            //            };
            var model = new CategoryViewModel();
            model.ListGroup = db.GroupPr.ToList();
            model.ListGroupDetail = db.GroupDetail.ToList();
            return model;
        }
    }
}
