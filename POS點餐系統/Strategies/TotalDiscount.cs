using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    internal class TotalDiscount : AStrategy
    {

        public float Discount;
        public int Total;
        //全場消費打85折
        public TotalDiscount(int Total, float Discount)
        {

            this.Total = Total;
            this.Discount = Discount;

        }

        public override void DiscountChoice(List<CheckDetail> list, string stategy)
        {




            double discountedTotal = Total * Discount;  // 先計算折扣後金額
            int difference = (int)(discountedTotal - Total);
            price = difference;
            quality = 1;
            product = stategy;
            CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
            list.Add(checkDetail12);






        }
    }
}