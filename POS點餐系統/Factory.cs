using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS點餐系統.Discounts;

namespace POS點餐系統
{
    public static class DiscountFactory
    {
        public static ADiscount CreateDiscount(List<CheckDetail> list, string type)
        {


            

            ADiscount discount = null;

            switch (type)
            {

                case "雞腿飯買二送一":

                    discount = new Drumstick(list);
                    break;

                case "雞腿飯買三個200元":

                    discount = new _3Drumstick(list);

                    break;

                case "排骨飯搭紅茶100元":

                    discount = new Ribs(list);
                    break;

                case "買控肉販送滷豆腐":
                    discount = new BraisePork(list);
                    break;

                case "排骨飯搭蛋糕150元":
                    discount = new Ribs_cake(list);
                    break;


                case "買控肉飯加茶碗蒸就送奶茶":
                    discount = new BraisedPorkTeaEgg(list);

                    break;

                case "雞腿飯買三個79折":
                    discount = new Drumstick379(list);

                    break;

                case "排骨飯加紅茶打8折":

                    discount = new BraisedPordBlackTea(list);

                    break;

                case "全場消費300元折40":
                    discount = new TotalPaycs(list);
                    break;

                case "全場消費打85折":
                    discount = new TotalPayDiscount(list);
                    break;

                default:
                    discount = new NoDiscount(list);
                    break;
            }


            return discount;



        }



    }
}
