using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS點餐系統.Discounts;

namespace POS點餐系統
{
    public static class Order
    {
        static List<CheckDetail> CheckPriceList = new List<CheckDetail>();
  

        public static void Add(CheckDetail checkDetail,string type)
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

            
            DisCountOrders(type);

        }

        public static void DisCountOrders(string type)
        {
            
            DisCount.DisCountOrders(CheckPriceList, type);
        }

        //public int ResultCal()
        //{
        //    int Result = 0;
        //    for(int i = 0; i < CheckPriceList.Count; i++)
        //    {
        //        Result += CheckPriceList[i].subtotal;
        //    }

        //    return Result;
        //}
    }
}
