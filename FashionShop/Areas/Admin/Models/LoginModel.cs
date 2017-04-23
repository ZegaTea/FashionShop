using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập Username")]
        public string userName { get; set; }
        [Required(ErrorMessage ="Mời nhập Password")]
        public string passWord { get; set; }
    }
}