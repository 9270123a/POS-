using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    public class NoDiscount:ADiscount
    {
        public NoDiscount(List<CheckDetail> checkDetail) : base(checkDetail) { }
        public override void DiscountMethod()
        {



        }
    }
}
