using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    public class BuyMFreeM:AStrategy
    {
        //雞腿飯買二送一
        public string item;
        public int Count;
        public string FreeItem;

        public BuyMFreeM(string item,int Count, string FreeItem)
        {

            this.item = item;
            this.Count = Count;
            this.FreeItem = FreeItem;

        }

        public override void DiscountChoice(List<CheckDetail> list, string stategy)
        {
            var product1 = list.FirstOrDefault(x => x.product == item);
            var count = list.FirstOrDefault(x =>x.quality == Count);

            if(product1 != null && count != null) {


                price = 0;
                quality = 1;
                product = stategy;
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                list.Add(checkDetail12);

            }


        }

    }
}
