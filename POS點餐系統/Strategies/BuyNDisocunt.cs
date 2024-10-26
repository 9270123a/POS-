using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    internal class BuyNDisocunt : AStrategy
    {

        public string item;
        public int itemCount;
        public double discount;
        //雞腿飯買三個79折
        public BuyNDisocunt(string item, int itemCount, double discount)
        {

            this.item = item;
            this.itemCount = itemCount;
            this.discount = discount;

        }

        public override void DiscountChoice(List<CheckDetail> list, string stategy)
        {
            var product1 = list.FirstOrDefault(x => x.product == "item");


            if (product1 != null && product1.quality == itemCount)
            { 
                int total = product1.price * itemCount;
                total = (int)(total* discount) -total;
                price = total;
                quality = 1;
                product = stategy;
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                list.Add(checkDetail12);
            }





        }
    }
}
