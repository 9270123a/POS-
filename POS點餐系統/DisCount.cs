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



            Type strategyType = Type.GetType(type.Strategy);
            //取得類別
            
            var strategy = (AStrategy)Activator.CreateInstance(strategyType,new object[] {type});
            AStrategy aStrategy = strategy;

            

            if(aStrategy != null)
            {
                aStrategy.DiscountChoice(list);

            }




            int Result = list.Sum(x => x.subtotal);
            Display.ShowPanel(Result, list);

        }


    }
}
