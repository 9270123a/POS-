using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Discounts
{
    abstract public class ADiscount
    {
        protected List<CheckDetail> checkDetail;

        protected ADiscount(List<CheckDetail> checkDetail) {
            this.checkDetail = checkDetail;
        }


        abstract public void DiscountMethod();


    }
}
