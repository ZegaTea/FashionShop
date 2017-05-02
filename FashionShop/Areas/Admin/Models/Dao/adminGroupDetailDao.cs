using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entities;
using FashionShop.Areas.Admin.Models.DTO;

namespace FashionShop.Areas.Admin.Models.Dao
{
    public class adminGroupDetailDao
    {
        private FashionShopDbContext db = null;
        public adminGroupDetailDao()
        {
            db = new FashionShopDbContext();
        }

        public IEnumerable<adminGroupDetailDTO> getListDetail()
        {
            var model = from a in db.GroupDetail
                        join b in db.GroupPr on a.nhomMa equals b.maNhom
                        select new adminGroupDetailDTO()
                        {
                            maLoaiSanPham = a.maLoaiSanPham,
                            tenLoaiSanPham = a.tenLoaiSanPham,
                            tenNhom = b.tenNhom,
                            meta_tittle = a.meta_tittle
                        };
            return model.ToList();
        }
        public IEnumerable<GroupDetail> getList()
        {
            return db.GroupDetail.ToList();
        }

        public GroupDetail getDetail(string id)
        {
            return db.GroupDetail.Find(id);
        }
    }
}