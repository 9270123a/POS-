using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐系統.Strategies
{
    public abstract class AStrategy
    {

        public POS點餐系統.Models.MenuModel.Discount type;
        public abstract void DiscountChoice(List<CheckDetail> list);
        public AStrategy(POS點餐系統.Models.MenuModel.Discount type) {

            this.type = type;
        }


    }
}
