using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    internal class BuyNTotalM : AStrategy   
    {
        public string item;
        public int itemCount;
        public int Total;
        //雞腿飯買三個200元
        public BuyNTotalM(string item, int itemCount, int Total)
        {

            this.item = item;
            this.itemCount = itemCount;
            this.Total = Total;


        }

        public override void DiscountChoice(List<CheckDetail> list, string stategy)
        {
            var product1 = list.FirstOrDefault(x => x.product == item);


            if (product1 != null && product1.quality == itemCount)
            {
                
                Total = Total - product1.price * product1.quality;
                price = Total;
                quality = 1;
                product = item;
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                list.Add(checkDetail12);
            }





        }


    }
}
