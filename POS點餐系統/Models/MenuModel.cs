using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Models
{
    public class MenuModel
    {

        public Menu[] Menus { get; set; }
        public Discount[] Discounts { get; set; }

        public class Menu
        {
            public string MenuType { get; set; }
            public Meal[] Meal { get; set; }
        }

        public class Meal
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public class Discount
        {
            public string Name { get; set; }
            public string Strategy { get; set; }
            public Multiplediscount MultipleDiscount { get; set; }
            public Setsitems SetsItems { get; set; }
            public Totalcheck TotalCheck { get; set; }
        }

        public class Multiplediscount
        {
            public string ItemName { get; set; }
            public int Amount { get; set; }
            public Discount1 Discount { get; set; }
        }

        public class Discount1
        {
            public string FreeItem { get; set; }
            public int Count { get; set; }
            public float Percentage { get; set; }
            public int TotalPrice { get; set; }
        }

        public class Setsitems
        {
            public string Item1Name { get; set; }
            public string Item2Name { get; set; }
            public Discount2 Discount { get; set; }
            public object[] ItemName { get; set; }
            public int Price { get; set; }
            public float Percentage { get; set; }
            public int TotalPrice { get; set; }
        }

        public class Discount2
        {
            public string FreeItem { get; set; }
            public int Count { get; set; }
            public int Percentage { get; set; }
            public int TotalPrice { get; set; }
        }

        public class Totalcheck
        {
            public int TotalPay { get; set; }
            public Discount3 Discount { get; set; }
        }

        public class Discount3
        {
            public string FreeItem { get; set; }
            public int Count { get; set; }
            public float Percentage { get; set; }
            public int TotalPrice { get; set; }
        }

    }
}
