using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    public class _3Drumstick:ADiscount
    {
        ///雞腿飯買三個200元

        public _3Drumstick(List<CheckDetail> checkDetail) : base(checkDetail)
        {

        }
        public override void DiscountMethod()
        {
          
            CheckDetail count = checkDetail.FirstOrDefault(t => t.product == "雞腿飯");


            if (count == null)
            {
                return;
            }

            if (count.quality >= 3)
            {
                int set = count.quality / 3;
                int price = -10;
                int quality = set;
                string product = "(折扣)雞腿飯";
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                checkDetail.Add(checkDetail12);


            }
        }

    }
}
