using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    public class TotalMMinusN: AStrategy
    {


        int TotalPay;
        int Discount;
        //全場消費折40
        public TotalMMinusN(POS點餐系統.Models.MenuModel.Discount type) : base(type)
        {

            this.Discount = type.TotalCheck.Discount.TotalPrice;
            this.TotalPay = type.TotalCheck.TotalPay;
        }

        public override void DiscountChoice(List<CheckDetail> list)
        {

            int Total = list.Sum(x => x.product != type.Name ? x.subtotal : 0);

            if (Total >= TotalPay)
            {


                CheckDetail checkDetail12 = new CheckDetail(Discount, 1, "(贈送)" + type.Name);
                list.Add(checkDetail12);
                


            }


        }
    }
}

