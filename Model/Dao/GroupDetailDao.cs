using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Dao
{
    public class GroupDetailDao
    {
        FashionShopDbContext db = null;
        public GroupDetailDao()
        {
            db = new FashionShopDbContext();
        }
        public List<GroupDetail> getList()
        {
            return db.GroupDetail.ToList();
        }
    }
}
