using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using POS點餐系統.Strategies;

namespace POS點餐系統
{
    internal class DisCount
    {

        static string[] discountWord = { "優惠","折扣","送","打折","()"};

        public static void DisCountOrders(List<CheckDetail> list, POS點餐系統.Models.MenuModel.Discount type)
        {

            list.RemoveAll(x => discountWord.Any(word => x.product.Contains(word)));



            AStrategy aStrategy = null;

            


            switch (type.Strategy)
            {
                case "POS點餐系統.Strategies.BuyMFreeM":

                    aStrategy = new BuyMFreeM(type);
                    break;

                case "POS點餐系統.Strategies.BuyNTotalM":
                    aStrategy = new BuyNTotalM(type);
                    break;

                case "POS點餐系統.Strategies.BuyNAndBTotal":

                    aStrategy = new BuyNAndBTotal(type);


                    break;

                case "POS點餐系統.Strategies.BuyNGetMFree":

                    aStrategy = new BuyNGetMFree(type);

                    break;




                case "POS點餐系統.Strategies.BuyNAndMFreeZ":

                    aStrategy = new BuyNAndMFreeZ(type);

                    break;

                case "POS點餐系統.Strategies.BuyNDisocunt":

                    aStrategy = new BuyNDisocunt(type);
                    break;

                case "POS點餐系統.Strategies.BuyNAndMDiscount":

                    aStrategy = new BuyNAndMDiscount(type);

                    break;

                case "POS點餐系統.Strategies.TotalMMinusN":
                    aStrategy = new TotalMMinusN(type);

                    break;

                case "POS點餐系統.Strategies.TotalDiscount":

                    aStrategy = new TotalDiscount(type);
                    break;
                default: 

                    break;
            }
            if(aStrategy != null)
            {
                aStrategy.DiscountChoice(list);

            }




            int Result = list.Sum(x => x.subtotal);
            Display.ShowPanel(Result, list);

        }


    }
}
