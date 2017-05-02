using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Entities;

namespace FashionShop.Areas.Admin.Models.DTO
{
    public class GroupDetailDTO
    {
        public GroupDetail groupDetail { get; set; }
        public List<GroupPr> listGroupPr { get; set; }
    }
}