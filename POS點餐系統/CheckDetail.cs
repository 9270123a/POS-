using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統
{
    public class CheckDetail
    {

        public int price;
        public int quality;
        public string product;
        public int subtotal
        {
            get { return price * quality; }
        }
        public CheckDetail(int price, int quality, string product)
        {
            this.price = price;
            this.quality = quality;
            this.product = product;
            

        }

    }
}
