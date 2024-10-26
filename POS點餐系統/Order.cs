using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統
{
    public static class Order
    {
        static List<CheckDetail> CheckPriceList = new List<CheckDetail>();
  

        public static void Add(CheckDetail checkDetail, POS點餐系統.Models.MenuModel.Discount type)
        {
            CheckDetail precheckdetail = CheckPriceList.FirstOrDefault(x => x.product == checkDetail.product);
            if (precheckdetail == null)
            {
               CheckPriceList.Add(checkDetail);
            }else if(checkDetail.quality==0)
            {
                CheckPriceList.Remove(precheckdetail);
                
            }
            else
            {
                precheckdetail.quality = checkDetail.quality;
            }

            //int Result = ResultCal();
            DisCountOrders(type);

        }

        public static void DisCountOrders(POS點餐系統.Models.MenuModel.Discount type)
        {
            DisCount.DisCountOrders(CheckPriceList, type);
        }

    }
}
