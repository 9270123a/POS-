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
        //全場消費打85折
        public TotalDiscount(POS點餐系統.Models.MenuModel.Discount type) : base(type)
        {

            this.Discount = type.TotalCheck.Discount.Percentage;

        }

        public override void DiscountChoice(List<CheckDetail> list)
        {

            int Total = list.Sum(x => x.product!= type.Name?x.subtotal:0);
            double discountedTotal = Total * Discount;  // 先計算折扣後金額
            int difference = (int)(discountedTotal - Total);
            



            CheckDetail checkDetail12 = new CheckDetail(difference, 1, "(贈送)" + type.Name);
            list.Add(checkDetail12);
            



        }
    }
}