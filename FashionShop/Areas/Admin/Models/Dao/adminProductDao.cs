using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entities;
using FashionShop.Areas.Admin.Models.DTO;
namespace FashionShop.Areas.Admin.Models.Dao
{
    public class adminProductDao
    {
        private FashionShopDbContext db = null;
        public adminProductDao()
        {
            db = new FashionShopDbContext();
        }

        public IEnumerable<adminProductViewDto> getList()
        {
            var model = from a in db.Product
                        join b in db.GroupDetail on a.loaiSanPhamMa equals b.maLoaiSanPham
                        join c in db.GroupPr on b.nhomMa equals c.maNhom
                        select new adminProductViewDto()
                        {
                            maSanPham = a.maSanPham,
                            moTa = a.moTa,
                            giaSanPham = a.giaSanPham,
                            chatLieu = a.chatLieu,
                            soLuongDatMua = a.soLuongDatMua,
                            mauSac = a.mauSac,
                            urlAnh = a.urlAnh,
                            ngayTao = a.ngayTao,
                            tenSanPham = a.tenSanPham,
                            tenNhom = c.tenNhom,
                            tenLoai = b.tenLoaiSanPham
                        };
            return model.ToList();
        }

        public IEnumerable<adminProductViewDto> getProductDto(string id)
        {
            var model = from a in db.Product
                        where a.maSanPham == id
                        join b in db.GroupDetail on a.loaiSanPhamMa equals b.maLoaiSanPham
                        join c in db.GroupPr on b.nhomMa equals c.maNhom
                        select new adminProductViewDto()
                        {
                            maSanPham = a.maSanPham,
                            moTa = a.moTa,
                            giaSanPham = a.giaSanPham,
                            chatLieu = a.chatLieu,
                            soLuongDatMua = a.soLuongDatMua,
                            mauSac = a.mauSac,
                            urlAnh = a.urlAnh,
                            ngayTao = a.ngayTao,
                            tenSanPham = a.tenSanPham,
                            tenLoai = b.tenLoaiSanPham
                        };
            return model.ToList();
        }

        public Product detail(string id)
        {
            return db.Product.Find(id);
        }
    }
}