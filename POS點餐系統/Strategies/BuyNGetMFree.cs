using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.Strategies
{
    internal class BuyNGetMFree:AStrategy
    {

        public string item1;
        public string freeitem;
        //買控肉販送滷豆腐
        public BuyNGetMFree(POS點餐系統.Models.MenuModel.Discount type) : base(type)
        {

            this.item1 = type.MultipleDiscount.ItemName;
            this.freeitem = type.MultipleDiscount.Discount.FreeItem;

        }

        public override void DiscountChoice(List<CheckDetail> list)
        {
            var product1 = list.FirstOrDefault(x => x.product == item1);


            if (product1 != null)
            {
                var Existproduct = list.FirstOrDefault(x => x.product == type.Name);



                CheckDetail checkDetail12 = new CheckDetail(0, product1.quality, "(贈送)" + type.Name);
                list.Add(checkDetail12);
                


            }





        }

    }
}
