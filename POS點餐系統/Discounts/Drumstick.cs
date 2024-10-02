using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    public class Drumstick:ADiscount
    {

        public Drumstick(List<CheckDetail> checkDetail):base(checkDetail) {

        }
        public override void DiscountMethod()
        {
            CheckDetail count = checkDetail.FirstOrDefault(t => t.product == "雞腿飯");

            if (count == null)
            {
                return;
            }    
            if (count.quality >= 2)
            {
                int number = count.quality / 2;

                int price = 0;

                int quality = number;
                string product = "(折扣)雞腿飯";
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                checkDetail.Add(checkDetail12);
            }
            
            
        }


    }





}
