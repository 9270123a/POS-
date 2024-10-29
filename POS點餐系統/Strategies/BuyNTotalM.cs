using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    internal class BuyNTotalM : AStrategy
    {
        public string item;
        public int itemCount;
        public int Total;
        //雞腿飯買三個200元
        public BuyNTotalM(POS點餐系統.Models.MenuModel.Discount type) : base(type)
        {

            this.item = type.MultipleDiscount.ItemName;
            this.itemCount = type.MultipleDiscount.Amount;
            this.Total = type.MultipleDiscount.Discount.TotalPrice;


        }

        public override void DiscountChoice(List<CheckDetail> list)
        {
            var product1 = list.FirstOrDefault(x => x.product == item);

           

            if (product1 != null)
            {
                var Existproduct = list.FirstOrDefault(x => x.product == type.Name);

                Total = Total - product1.price * itemCount;

                if (product1.quality>=3)
                {
                    int number = product1.quality / itemCount;
                    CheckDetail checkDetail12 = new CheckDetail(Total, 1, "(贈送)" + type.Name);
                    list.Add(checkDetail12);
                }



          



            }








        }


    }
}
