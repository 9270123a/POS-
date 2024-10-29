using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{

    //排骨飯加紅茶打8折
    internal class BuyNAndMDiscount : AStrategy
    {
        public string item1;
        public string item2;
        public float discount;

        public  BuyNAndMDiscount(POS點餐系統.Models.MenuModel.Discount type) : base(type)
        {

            this.item1 = type.SetsItems.ItemName[0].ToString();
            this.item2 = type.SetsItems.ItemName[1].ToString();
            this.discount = type.SetsItems.Percentage;

        }

        public override void DiscountChoice(List<CheckDetail> list)
        {
            var product1 = list.FirstOrDefault(x => x.product == item1);
            var product2 = list.FirstOrDefault(x => x.product == item2);

            if (product1 != null && product2 != null)
             {
                int set = Math.Min(product1.quality, product2.quality);


                int total = product1.price + product2.price;
                total = (int)(total * discount) - total;

                CheckDetail checkDetail12 = new CheckDetail(total, 1, "(贈送)" + type.Name);
                list.Add(checkDetail12);

                


            }





        }
    }
}
