using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    internal class Ribs_cake:ADiscount
    {
        //排骨飯搭蛋糕150元
        public Ribs_cake(List<CheckDetail> checkDetail) : base(checkDetail) { }

        public override void DiscountMethod()
        {
            CheckDetail blacktea = checkDetail.FirstOrDefault(t => t.product == "蛋糕");
            CheckDetail Ribs = checkDetail.FirstOrDefault(t => t.product == "排骨飯");

            if(blacktea == null||Ribs==null) {
                return;
            }

            int set = Math.Min(blacktea.quality, Ribs.quality);


            int price = -20;
            int quality = set;
            string product = "(折扣)排骨蛋糕";
            CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
            checkDetail.Add(checkDetail12);

        }


    }
}
