using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    public class TotalPayDiscount:ADiscount
    {


        public TotalPayDiscount(List<CheckDetail> checkDetail) : base(checkDetail)
        { }
        public override void DiscountMethod()
        {
            //全場消費打85折

            int totalpay = checkDetail.Sum(t => t.quality * t.price);


            int discount = -(int)Math.Floor(totalpay * 0.15);
            

            int price = discount;
            int quality = 1;
            string product = "(折扣)消費300元85折";
            CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
            checkDetail.Add(checkDetail12);

            


        }
    }
}
