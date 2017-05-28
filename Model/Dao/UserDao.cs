using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Dao
{
    public class UserDao
    {
        FashionShopDbContext db = null;
        public UserDao()
        {
            db = new FashionShopDbContext();
        }

        public bool CheckLogin(string userName, string passWord)
        {
            var result = db.User.Count(x => x.username == userName && x.password == passWord);
            if(result == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public IQueryable<User> List()
        {
            var rs = from us in db.User
                     select us;
            return rs;
        }

        public User getUser(string id)
        {
            return db.User.Find(id);
        }
    }
}
