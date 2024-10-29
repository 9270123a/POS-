using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    public class BuyMFreeM:AStrategy
    {
        //雞腿飯買二送一
        public string item;
        public int Count;
        public string FreeItem;



        public BuyMFreeM(POS點餐系統.Models.MenuModel.Discount type):base(type)
        {
            this.item = type.MultipleDiscount.ItemName;
            this.Count = type.MultipleDiscount.Amount;
            this.FreeItem = type.MultipleDiscount.Discount.FreeItem;

        }

        public override void DiscountChoice(List<CheckDetail> list)
        {
            var product1 = list.FirstOrDefault(x => x.product == item);
            var Existproduct = list.FirstOrDefault(x => x.product == type.Name);
            if (product1 != null && product1.quality >=2) {

                int number = product1.quality / 2;

                CheckDetail checkDetail12 = new CheckDetail(0, number, "(贈送)" + type.Name);
                list.Add(checkDetail12);
                


            }


        }

    }
}
