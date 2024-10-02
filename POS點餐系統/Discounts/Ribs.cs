using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    public class Ribs:ADiscount
    {
        ///排骨飯搭紅茶100元

        public Ribs(List<CheckDetail> checkDetail):base(checkDetail) { 
        
        
        
        }

        public override void DiscountMethod()
        {

            CheckDetail blacktea = checkDetail.FirstOrDefault(t => t.product == "紅茶");
            CheckDetail Ribs = checkDetail.FirstOrDefault(t => t.product == "排骨飯");

            if(blacktea == null || Ribs == null)
            {
                return;
            }

            int set = Math.Min(blacktea.quality, Ribs.quality);

            
            int price = -10;
            int quality = set;
            string product = "(折扣)排骨飯";
            CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
            checkDetail.Add(checkDetail12);
        }
    }
}
