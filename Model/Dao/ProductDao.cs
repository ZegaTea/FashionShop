using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.ViewModel;

namespace Model.Dao
{
    public class ProductDao
    {
        FashionShopDbContext db = null;
        public ProductDao()
        {
            db = new FashionShopDbContext();
        }
        /// <summary>
        /// Lấy full danh sách, dùng cho Home/Index
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductViewModel> getListAll()
        {
            var model = from a in db.Product
                        join b in db.GroupDetail on a.loaiSanPhamMa equals b.maLoaiSanPham
                        join c in db.GroupPr on b.nhomMa equals c.maNhom
                        select new ProductViewModel()
                        {
                            maSanPham = a.maSanPham,
                            moTa = a.moTa,
                            tenSanPham = a.tenSanPham,
                            giaSanPham = a.giaSanPham,
                            chatLieu = a.chatLieu,
                            soLuongDatMua = a.soLuongDatMua,
                            mauSac = a.mauSac,
                            urlAnh = a.urlAnh,
                            ngayTao = a.ngayTao,
                            nhomMa = b.nhomMa,
                            maLoaiSanPham = b.maLoaiSanPham,
                            groupDetailTittle = b.meta_tittle,
                            groupTittle = c.meta_tittle
                        };
            return model.ToList();
        }
        /// <summary>
        /// Lấy danh sách theo danh mục(id), dùng cho Product/Index
        /// </summary>
        /// <param name="id"></param>
        /// <param name="totalRecord"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<ProductViewModel> getListById(string id, ref int totalRecord, int page, int pageSize)
        {
            var model = from a in db.Product
                        join b in db.GroupDetail on a.loaiSanPhamMa equals b.maLoaiSanPham
                        where b.meta_tittle == id
                        select new ProductViewModel()
                        {
                            maSanPham = a.maSanPham,
                            moTa = a.moTa,
                            tenSanPham = a.tenSanPham,
                            giaSanPham = a.giaSanPham,
                            chatLieu = a.chatLieu,
                            soLuongDatMua = a.soLuongDatMua,
                            mauSac = a.mauSac,
                            urlAnh = a.urlAnh,
                            ngayTao = a.ngayTao,
                            
                            maLoaiSanPham = b.maLoaiSanPham,

                            groupDetailTittle = b.meta_tittle,
                        };
            totalRecord = model.Count();
            return model.OrderByDescending(x => x.ngayTao).Skip((page - 1) * pageSize).Take(pageSize);
        }
        /// <summary>
        /// Lấy chi tiết sản phẩm theo mã sp(id), dùng cho Product/Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product ViewDetail(string id)
        {
            return db.Product.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ProductDetail> ViewProductDetail(string id)
        {
            return db.ProductDetail.Where(x => x.maSanPham == id).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ProductDetailViewModel> Detail(string id)
        {
            var model = from a in db.Product
                        where a.maSanPham == id
                        join b in db.ProductDetail on a.maSanPham equals b.maSanPham
                        orderby b.size
                        select new ProductDetailViewModel()
                        {
                            maSanPham = a.maSanPham,
                            moTa = a.moTa,
                            giaSanPham = a.giaSanPham,
                            chatLieu = a.chatLieu,
                            loaiSanPhamMa = a.loaiSanPhamMa,
                            soLuongDatMua = a.soLuongDatMua,
                            mauSac = a.mauSac,
                            urlAnh = a.urlAnh,
                            ngayTao = a.ngayTao,
                            tenSanPham = a.tenSanPham,
                            size = b.size,
                            soLuong = b.soLuong
                        };
            return model.ToList();
        }
    }
}
