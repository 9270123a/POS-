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



        public int Discount;
        public int Total;
        //全場消費打85折
        public TotalMMinusN(int Total, int Discount)
        {

            this.Total = Total;
            this.Discount = Discount;

        }

        public override void DiscountChoice(List<CheckDetail> list, string stategy)
        {



            price = -Discount;
            quality = 1;
            product = "11";
            CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
            list.Add(checkDetail12);






        }
    }
}

