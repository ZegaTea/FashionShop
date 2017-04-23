using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Dao
{
    public class AdminDao
    {
        FashionShopDbContext db = null;
        public AdminDao()
        {
            db = new FashionShopDbContext();
        }

        public bool CheckLogin(string adminName, string adminPass)
        {
            var result = db.Admin.Count(x => x.userName == adminName && x.passWord == adminPass);
            if(result == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
