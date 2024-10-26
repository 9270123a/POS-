using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS點餐系統.Models;

namespace POS點餐系統.Strategies
{
    public class BuyNAndBTotal : AStrategy
    {
        //排骨飯搭蛋糕150元

        public string item1;
        public string item2;
        public int total;

        public BuyNAndBTotal(string item1, string item2, int total) { 
        
            this.item1 = item1;
            this.item2 = item2;
            this.total = total;

        }

        public override void DiscountChoice(List<CheckDetail> list, string stategy)
        {
            var item1 = list.FirstOrDefault(x => x.product == "item1");
            var item2 = list.FirstOrDefault(x => x.product == "item2");

            if (item1 != null && item2 != null)
            {

                int SetTotalPrice = item1.price + item2.price;
                total = total - SetTotalPrice;
                price = total;
                quality = 1;
                product = stategy;
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                list.Add(checkDetail12);
            }





        }
    }
}
