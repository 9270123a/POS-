using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    public class Drumstick379:ADiscount
    {
        //雞腿飯買三個79折
        public Drumstick379(List<CheckDetail> checkDetail) : base(checkDetail)
        { }
        public override void DiscountMethod()
        {

            int drumstick_count = checkDetail.Count(t => t.product == "雞腿飯");

            if(drumstick_count == null)
            {
                return;
            }

            if (drumstick_count > 3)
            {

                int count = drumstick_count / 3;
                int price = -44;
                int quality = count;
                string product = "(折扣)雞腿飯79折";
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                checkDetail.Add(checkDetail12);

            }


        }


    }
}
