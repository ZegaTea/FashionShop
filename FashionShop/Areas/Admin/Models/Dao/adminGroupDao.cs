using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entities;

namespace FashionShop.Areas.Admin.Models.Dao
{
    public class adminGroupDao
    {
        private FashionShopDbContext db = null;
        public adminGroupDao()
        {
            db = new FashionShopDbContext();
        }

        public IEnumerable<GroupPr> getList()
        {
            var model = db.GroupPr.ToList();
            return model.ToList();
        }

        public GroupPr detail(string id)
        {
            var model = db.GroupPr.Find(id);
            return model;
        }
    }
}