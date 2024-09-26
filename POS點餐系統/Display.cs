using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace POS點餐系統
{
    static class Display
    {

        


        public static void ShowPanel(int Result, List<CheckDetail> checkPrice)
        {
            int result = Result;
            List<CheckDetail> checkPrice1 = checkPrice;


            FlowLayoutPanel flow = new FlowLayoutPanel();
            FlowLayoutPanel flow1 = new FlowLayoutPanel();

            for (int i = 0; i < checkPrice1.Count; i++)
            {
                Label price = new Label();
                Label quality = new Label();
                Label product = new Label();
                Label totalPrice = new Label();

                product.Text = checkPrice1[i].product;
                quality.Text = checkPrice1[i].quality.ToString();
                price.Text = checkPrice1[i].price.ToString();
                int totalprice = checkPrice1[i].quality * checkPrice1[i].price;
                totalPrice.Text = totalprice.ToString();



                flow.Controls.Add(product);
                flow.Controls.Add(quality);
                flow.Controls.Add(price);
                flow.Controls.Add(totalPrice);

                flow.Size = new Size(425, 1000);
                flow.FlowDirection = FlowDirection.LeftToRight;
                flow1.Controls.Add(flow);
            }

            Eventhandlers.NotifyDisplayEvent(flow1);
            Eventhandlers.NotifyEvent(result.ToString());

        }

    }
}
