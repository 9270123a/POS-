using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using POS點餐系統.Discounts;

namespace POS點餐系統
{
    internal class DisCount
    {
        public static void DisCountOrders(List<CheckDetail> list,string type)
        {


            list = list.Where(t => !t.product.Contains("(折扣)")).ToList();

            ADiscount discount = DiscountFactory.CreateDiscount(list, type);
            discount.DiscountMethod();

            int Result = list.Sum(x => x.subtotal);
            Display.ShowPanel(Result, list);

        }


    }
}
