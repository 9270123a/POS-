using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    internal class BuyNAndMFreeZ:AStrategy
    {
        //買控肉飯加茶碗蒸就送奶茶
        public string item1;
        public string item2;
        public string FreeItem;

        public BuyNAndMFreeZ(string item1, string item2, string FreeItem)
        {

            this.item1 = item1;
            this.item2 = item2;
            this.FreeItem = FreeItem;

        }

        public override void DiscountChoice(List<CheckDetail> list, string stategy)
        {
            var product1 = list.FirstOrDefault(x => x.product == item1);
            var product2 = list.FirstOrDefault(x => x.product == item2);

            if (item1 != null && item2 != null)
            {

                price = 0;
                quality = 1;
                product = FreeItem;
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                list.Add(checkDetail12);
            }





        }

    }
}
