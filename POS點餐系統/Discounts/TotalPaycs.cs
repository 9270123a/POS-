using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    public class TotalPaycs : ADiscount
    {

        public TotalPaycs(List<CheckDetail> checkDetail) : base(checkDetail)
        { }
        public override void DiscountMethod()
        {
            //全場消費300元折40

            int totalpay = checkDetail.Sum(t => t.quality *t.price);


            if (totalpay > 300)
            {

                int price = -40;
                int quality = 1;
                string product = "(折扣)消費300元折40";
                CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                checkDetail.Add(checkDetail12);

            }


        }

    }
}
