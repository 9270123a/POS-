using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    internal class BuyNGetMFree:AStrategy
    {

        public string item1;
        public string freeitem;
        //買控肉販送滷豆腐
        public BuyNGetMFree(string item1, string freeitem)
        {

            this.item1 = item1;
            this.freeitem = freeitem;

        }

        public override void DiscountChoice(List<CheckDetail> list, string stategy)
        {
            var product1 = list.FirstOrDefault(x => x.product == "item1");


            if (product1 != null)
            {

                price = 0;
                quality = 1;
                product = freeitem;
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                list.Add(checkDetail12);
            }





        }

    }
}
