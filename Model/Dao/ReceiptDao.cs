using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Dao
{
    public class ReceiptDao
    {
        FashionShopDbContext db = null;
        public ReceiptDao()
        {
            db = new FashionShopDbContext();
        }

        public int Insert(Receipt re)
        {
            db.Receipt.Add(re);
            db.SaveChanges();
            return re.maHoaDon;
        }

        public void InsertDetail(ReceiptDetail detail)
        {
            db.ReceiptDetail.Add(detail);
            db.SaveChanges();
        }
    }
}
