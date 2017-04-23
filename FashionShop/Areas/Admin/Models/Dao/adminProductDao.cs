using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entities;

namespace FashionShop.Areas.Admin.Models.Dao
{
    public class adminProductDao
    {
        private FashionShopDbContext db = null;
        public adminProductDao()
        {
            db = new FashionShopDbContext();
        }

        public IEnumerable<Product> getList()
        {
            var model = db.Product.ToList();
            return model.ToList();
        }

        public Product detail(string id)
        {
            return db.Product.Find(id);
        }
    }
}