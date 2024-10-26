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
        public int price;
        public int quality;
        public string product;

        public abstract void DiscountChoice(List<CheckDetail> list, string stategy);


    }
}
