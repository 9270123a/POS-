using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    public class BraisePork:ADiscount
    {
        ///買控肉販送滷豆腐
        public BraisePork(List<CheckDetail> checkDetail) :base(checkDetail) { }

        public override void DiscountMethod()
        {

            CheckDetail set = checkDetail.FirstOrDefault(t => t.product == "控肉飯");

            if(set == null)
            {
                return;
            }
            
            int price = 0;
            int quality = set.quality;
            string product = "(折扣)滷豆腐";
            CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
            checkDetail.Add(checkDetail12);

        }


    }
}
