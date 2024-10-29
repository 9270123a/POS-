using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    internal class BuyNDisocunt : AStrategy
    {

        public string item;
        public int itemCount;
        public double discount;
        //雞腿飯買三個79折
        public BuyNDisocunt(POS點餐系統.Models.MenuModel.Discount type) : base(type)
        {

            this.item = type.MultipleDiscount.ItemName;
            this.itemCount = type.MultipleDiscount.Amount;
            this.discount = type.MultipleDiscount.Discount.Percentage;

        }

        public override void DiscountChoice(List<CheckDetail> list)
        {
            var product1 = list.FirstOrDefault(x => x.product == item);
            var Existproduct = list.FirstOrDefault(x => x.product == type.Name);


            if (product1 != null && product1.quality>= itemCount)
            {
                int total = product1.price * itemCount;
                total = (int)(total * discount) - total;



                CheckDetail checkDetail12 = new CheckDetail(total, 1, "(贈送))" + type.Name);
                list.Add(checkDetail12);
                

            }





        }
    }
}
