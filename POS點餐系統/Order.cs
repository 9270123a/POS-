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
  

        public static void Add(CheckDetail checkDetail)
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
            int Result = CheckPriceList.Sum(x => x.subtotal);

            Display.ShowPanel(Result, CheckPriceList);
            

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
