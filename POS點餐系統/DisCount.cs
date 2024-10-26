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


        public static void DisCountOrders(List<CheckDetail> list, POS點餐系統.Models.MenuModel.Discount type)
        {


            AStrategy aStrategy = null;




            switch (type.Name)
            {
                case "雞腿飯買二送一" :

                    aStrategy = new BuyMFreeM(type.MultipleDiscount.ItemName, type.MultipleDiscount.Amount, type.MultipleDiscount.Discount.FreeItem);
                    break;

                case "雞腿飯買三個200元":
                    aStrategy = new BuyNTotalM(type.MultipleDiscount.ItemName, type.MultipleDiscount.Amount, type.MultipleDiscount.Discount.TotalPrice);
                    break;

                case "排骨飯搭紅茶100元":

                    aStrategy = new BuyNAndBTotal(type.SetsItems.Item1Name, type.SetsItems.Item2Name, type.SetsItems.Discount.TotalPrice);


                    break;

                case "買控肉販送滷豆腐":

                    aStrategy = new BuyNGetMFree(type.MultipleDiscount.ItemName, type.MultipleDiscount.Discount.FreeItem);

                    break;

                case "排骨飯搭蛋糕150元":

                    aStrategy = new BuyNAndBTotal(type.SetsItems.Item1Name, type.SetsItems.Item2Name, type.SetsItems.Discount.TotalPrice);

                    break;


                case "買控肉飯加茶碗蒸就送奶茶":

                    aStrategy = new BuyNAndMFreeZ(type.SetsItems.ItemName[0].ToString(), type.SetsItems.ItemName[1].ToString(), type.SetsItems.Discount.FreeItem);

                    break;

                case "雞腿飯買三個79折":

                    aStrategy = new BuyNDisocunt(type.MultipleDiscount.ItemName, type.MultipleDiscount.Amount, type.MultipleDiscount.Discount.Percentage);
                    break;

                case "排骨飯加紅茶打8折":

                    aStrategy = new BuyNAndMDiscount(type.SetsItems.Item1Name, type.SetsItems.Item2Name, type.SetsItems.Discount.Percentage);

                    break;

                case "全場消費300元折40":
                    aStrategy = new TotalMMinusN(type.TotalCheck.TotalPay, type.TotalCheck.Discount.TotalPrice);

                    break;

                case "全場消費打85折":

                    aStrategy = new TotalDiscount(type.TotalCheck.TotalPay, type.TotalCheck.Discount.Percentage);
                    aStrategy.DiscountChoice(list, type.Strategy);
                    break;
                default: 

                    break;
            }
            if(aStrategy != null)
            {
                aStrategy.DiscountChoice(list, type.Name);

            }




            int Result = list.Sum(x => x.subtotal);
            Display.ShowPanel(Result, list);

        }


    }
}
