using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統
{
    internal class DisCount
    {
        public static void DisCountOrders(List<CheckDetail> list,string type)
        {

            int price;
            int quality;
            string product;

            switch (type)
            {
                case "雞腿飯買二送一" :


                    //int count = list.Count(t => t.product == "雞腿飯");
                    //if (count >= 2)
                    //{
                    //    int number = count % 2;
                        
                    //    price = 0;
                    //    quality = number;
                    //    product = "雞腿飯";
                    //    CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                    //    list.Add(checkDetail12);
                    //}
                    break;

                case "雞腿飯買三個200元":

                    break;

                case "排骨飯搭紅茶100元":

                    //int blacktea = list.Count(t => t.product == "紅茶");
                    //int Ribs = list.Count(t => t.product == "排骨");

                    //int set = Math.Min(blacktea, Ribs);

                    //price = -20;
                    //quality = set;
                    //product = "(折扣)排骨飯";
                    //CheckDetail checkDetail12 = new CheckDetail(price, quality, product);
                    //list.Add(checkDetail12);

                    break;

                case "買控肉販送滷豆腐":

                    break;

                case "排骨飯搭蛋糕150元":

                    break;


                case "買控肉飯加茶碗蒸就送奶茶":

                    break;

                case "雞腿飯買三個79折":

                    break;

                case "排骨飯加紅茶打8折":

                    break;

                case "全場消費300元折40":

                    break;

                case "全場消費打85折":

                    break;

            }





            int Result = list.Sum(x => x.subtotal);
            Display.ShowPanel(Result, list);

        }


    }
}
