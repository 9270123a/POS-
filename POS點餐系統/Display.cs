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
           


            FlowLayoutPanel flow = new FlowLayoutPanel();
            FlowLayoutPanel flow1 = new FlowLayoutPanel();

            for (int i = 0; i < checkPrice.Count; i++)
            {
                Label price = new Label();
                Label quality = new Label();
                Label product = new Label();
                Label totalPrice = new Label();


                flow.Size = new Size(425, 400);
                product.Text = checkPrice[i].product;
                quality.Text = checkPrice[i].quality.ToString();
                price.Text = checkPrice[i].price.ToString();
                totalPrice.Text = checkPrice[i].subtotal.ToString();



                flow.Controls.Add(product);
                flow.Controls.Add(quality);
                flow.Controls.Add(price);
                flow.Controls.Add(totalPrice);


                flow1.AutoSize = true;
                flow1.Controls.Add(flow);
            }

            Eventhandlers.NotifyDisplayEvent(flow1);
            Eventhandlers.NotifyEvent(result.ToString());



        }

    }
}
