using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    public class BraisedPordBlackTea : ADiscount
    {
        //排骨飯加紅茶打8折
        public BraisedPordBlackTea(List<CheckDetail> checkDetail) : base(checkDetail)
        { }
        public override void DiscountMethod()
        {

            CheckDetail BraisedPork = checkDetail.FirstOrDefault(t => t.product == "排骨飯");
            CheckDetail BlackTea = checkDetail.FirstOrDefault(t => t.product == "紅茶");

            if(BraisedPork == null || BlackTea == null)
            {

                return;
            }
            int set = Math.Min(BraisedPork.quality, BlackTea.quality);



            int price = -22;
            int quality = set;
            string product = "(折扣)排骨飯紅茶8折";
            CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
            checkDetail.Add(checkDetail12);
        }

    }


}

