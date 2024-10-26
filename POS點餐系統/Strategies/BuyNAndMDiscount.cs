using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{

    //排骨飯加紅茶打8折
    internal class BuyNAndMDiscount : AStrategy
    {
        public string item1;
        public string item2;
        public float discount;

        public BuyNAndMDiscount(string item1, string item2, float discount)
        {

            this.item1 = item1;
            this.item2 = item2;
            this.discount = discount;

        }

        public override void DiscountChoice(List<CheckDetail> list, string stategy)
        {
            var product1 = list.FirstOrDefault(x => x.product == "item1");
            var product2 = list.FirstOrDefault(x => x.product == "item2");

            if (item1 != null && item2 != null)
            {
                int total = product1.price + product2.price;
                total = (int)(total * discount) - total;
                price = total;
                quality = 1;
                product = "排骨飯加紅茶打8折";
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                list.Add(checkDetail12);
            }





        }
    }
}
