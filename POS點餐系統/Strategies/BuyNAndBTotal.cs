using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS點餐系統.Models;

namespace POS點餐系統.Strategies
{
    public class BuyNAndBTotal : AStrategy
    {
        //排骨飯搭蛋糕150元

        public string item1;
        public string item2;
        public int total;

        public BuyNAndBTotal(POS點餐系統.Models.MenuModel.Discount type) : base(type)
        {

            this.item1 = type.SetsItems.ItemName[0].ToString();
            this.item2 = type.SetsItems.ItemName[1].ToString();
            this.total = type.SetsItems.Discount.TotalPrice;

        }

        public override void DiscountChoice(List<CheckDetail> list)
        {
            var product1 = list.FirstOrDefault(x => x.product == item1);
            var product2 = list.FirstOrDefault(x => x.product == item2);

            if (product1 != null && product2 != null)
            {
                int set = Math.Min(product1.quality, product2.quality);
                int SetTotalPrice = product1.price + product2.price;
                total = total - SetTotalPrice;
 
                CheckDetail checkDetail12 = new CheckDetail(total, set, "(贈送)" + type.Name);
                list.Add(checkDetail12);
                

            }





        }
    }
}
