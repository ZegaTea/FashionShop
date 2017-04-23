using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models
{
    public class Items
    {
        public int id { get; set; }
        public string urlImage { get; set; }
        public string price { get; set; }
        public string detail { get; set; }

        public static IEnumerable<Items> getTopRate()
        {
            List<Items> li = new List<Items>();
            Items it;
            for (int i = 0; i < 6; i++)
            {
                it = new Items();
                it.id = 0;
                it.price = (int.Parse("300000".ToString()) + i * 10000).ToString();
                it.detail = "Áo nam mã số " + (i + 1);
                it.urlImage = "../Resources/images/items/ao/ao_nam_" + (i + 1) + ".jpg";
                li.Add(it);
            }
            for (int i = 0; i < 6; i++)
            {
                it = new Items();
                it.id = 1;
                it.price = (int.Parse("300000".ToString()) + i * 10000).ToString();
                it.detail = "Quần nam mã số " + (i + 1);
                it.urlImage = "../Resources/images/items/quan/quan_nam_" + (i + 1) + ".jpg";
                li.Add(it);
            }
            return li;
        }
        public static IEnumerable<Items> getData(int n)
        {
            List<Items> li = new List<Items>();
            Items it;
            for (int i = 0; i < n; i++)
            {
                it = new Items();
                it.id = i;
                it.price = (int.Parse("300000".ToString()) + i * 10000).ToString();
                it.detail = "Áo nam mã số " + (i + 1);
                it.urlImage = "../Resources/images/items/ao/ao_nam_" + (i + 1) + ".jpg";
                li.Add(it);
            }
            return li;
        }
    }
}