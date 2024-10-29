using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    internal class BuyNAndMFreeZ:AStrategy
    {
        //買控肉飯加茶碗蒸就送奶茶
        public string item1;
        public string item2;
        public string FreeItem;

        public BuyNAndMFreeZ(POS點餐系統.Models.MenuModel.Discount type) : base(type)
        {

            this.item1 = type.SetsItems.ItemName[0].ToString();
            this.item2 = type.SetsItems.ItemName[1].ToString();
            this.FreeItem = type.SetsItems.Discount.FreeItem;

        }

        public override void DiscountChoice(List<CheckDetail> list)
        {
            var product1 = list.FirstOrDefault(x => x.product == item1);
            var product2 = list.FirstOrDefault(x => x.product == item2);
            

            if (product1 != null && product2 != null)
            {
                int set = Math.Min(product1.quality, product2.quality);

                CheckDetail checkDetail12 = new CheckDetail(0, set, "(贈送)" + type.Name);
                list.Add(checkDetail12);
                


            }





        }

    }
}
