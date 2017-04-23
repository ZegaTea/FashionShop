using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Common
{
    [Serializable]
    public class AdminLogin
    {
        public string userName { get; set; }
        public string passWord { get; set; }
    }
}