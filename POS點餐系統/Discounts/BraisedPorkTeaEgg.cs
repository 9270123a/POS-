using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    public class BraisedPorkTeaEgg: ADiscount
    {
        //買控肉飯加茶碗蒸就送奶茶
        public BraisedPorkTeaEgg(List<CheckDetail> checkDetail) : base(checkDetail)
        {     }
        public override void DiscountMethod()
        {

            CheckDetail BraisedPork = checkDetail.FirstOrDefault(t => t.product == "控肉飯");
            CheckDetail TeaEgg = checkDetail.FirstOrDefault(t => t.product == "茶碗蒸");


            if(BraisedPork == null || TeaEgg == null)
            {
                return;
            }
            int set = Math.Min(BraisedPork.quality, TeaEgg.quality);


            int price = 0;
            int quality = set;
            string product = "(折扣)奶茶";
            CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
            checkDetail.Add(checkDetail12);
        }

    }
}
