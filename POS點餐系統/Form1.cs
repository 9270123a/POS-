using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace POS點餐系統
{
    public partial class Form1 : Form
    {
        string[] foods = { "雞腿飯$70", "排骨飯$90", "控肉飯$100" };
        string[] sidemeal = { "茶碗蒸$30", "滷豆腐$10", "滷蛋$10" };
        string[] drink = { "奶茶$30", "紅茶$20", "可樂$40" };
        string[] dessert = { "蛋糕$80", "布丁$90", "麵包$40" };



        int Result;
        public Form1()
        {
            InitializeComponent();
            Label l1 = new Label();
            Label l2 = new Label();
            Label l3 = new Label();
            Label l4 = new Label();

            l1.Text = "品名";
            l2.Text = "單價";
            l3.Text = "數量";
            l4.Text = "小計";
            flowLayoutPanel7.Size = new Size(425, 50);
            flowLayoutPanel7.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel7.Controls.Add(l1);
            flowLayoutPanel7.Controls.Add(l2);
            flowLayoutPanel7.Controls.Add(l3);
            flowLayoutPanel7.Controls.Add(l4);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateCheckBox(foods, flowLayoutPanel1);
            GenerateCheckBox(sidemeal, flowLayoutPanel2);
            GenerateCheckBox(drink, flowLayoutPanel3);
            GenerateCheckBox(dessert, flowLayoutPanel4);

        }


        private void GenerateCheckBox(string[] foods, FlowLayoutPanel flow)
        {
     
            for(int i = 0; i < foods.Count(); i++)
            {
                FlowLayoutPanel Childflow  = new FlowLayoutPanel();
                CheckBox checkBox = new CheckBox();
                NumericUpDown numericUpDown = new NumericUpDown();
                checkBox.Text = foods[i];
                checkBox.Click += CheckBox_Click;
                numericUpDown.ValueChanged += numericUpdown_ValueChanged;
                //checkBox.Tag = numericUpDown;
                //numericUpDown.Tag = checkBox;
                Childflow.Controls.Add(checkBox);
                Childflow.Controls.Add(numericUpDown);
                flow.Controls.Add(Childflow);


            }

        }

        private void numericUpdown_ValueChanged(object sender, EventArgs e)
        {
            Result = 0;
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            var flow = numericUpDown.Parent;
            var MainFlow = flow.Parent.Parent;
            var check = (CheckBox)flow.Controls[0];


            
            
            if(check.Checked==false && numericUpDown.Value > 0)
            {
                check.Checked = true;
            }
            else if(check.Checked ==true && numericUpDown.Value ==0)
            {
                check.Checked=false;
            }

            List<CheckDetail> checklist = ResultCalculate(MainFlow);
            CalculatorResult(checklist);
            DisplayDetail(checklist);
        }

        
        private void CalculatorResult(List<CheckDetail> checklist)
        {
            int foodQuality;
            int foodPrice;
            for (int i = 0; i < checklist.Count; i++)
            {

                foodPrice = checklist[i].price;
                foodQuality = checklist[i].quality;
                Result += foodPrice * foodQuality;
            }

            foodresultLB.Text = Result.ToString();
        }
        private void CheckBox_Click(object sender, EventArgs e)
        {
            Result = 0;
            CheckBox checkBox = (CheckBox)sender;
            var flow = checkBox.Parent;
            var MainFlow = flow.Parent.Parent;
            var numericUpDown = (NumericUpDown)flow.Controls[1];
            var d = numericUpDown.Value;
            int quality = (int)d;


            if(checkBox.Checked == true && numericUpDown.Value == 0)
            {
                numericUpDown.Value = 1;
            }
            else
            {
                checkBox.Checked = false;
                numericUpDown.Value = 0;
            }

        }



        public class CheckDetail
        {
            public int price;
            public int quality;
            public string product;
            public CheckDetail(int price,int quality, string product )
            {
                this.price = price;
                this.quality = quality;
                this.product = product;

            }

        }
        private void DisplayDetail(List<CheckDetail> checkList)
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();

            flowLayoutPanel6.Controls.Clear();
            for (int i = 0; i < checkList.Count; i++)
            {

                Label price = new Label();
                Label quality = new Label();
                Label product = new Label();
                Label totalPrice = new Label();

                product.Text = checkList[i].product;
                quality.Text = checkList[i].quality.ToString();
                price.Text = checkList[i].price.ToString();
                int totalprice = checkList[i].quality * checkList[i].price;
                totalPrice.Text = totalprice.ToString();

                
              
                flow.Controls.Add(product);
                flow.Controls.Add(quality);
                flow.Controls.Add(price);
                flow.Controls.Add(totalPrice);

                flow.Size = new Size(425, 1000);
                flow.FlowDirection = FlowDirection.LeftToRight;
                
                
            }
            flowLayoutPanel6.Controls.Add(flow);
            

        }

        private List<CheckDetail> ResultCalculate(Control flow)
        {
            List<CheckDetail> CheckPriceList = new List<CheckDetail>();
            CheckDetail checkdetail;

            for (int i = 0; i < 4; i++)
            {
                 FlowLayoutPanel flow1234 = (FlowLayoutPanel)flow.Controls[i];

                for(int j = 1;j<4;j++) {

                    FlowLayoutPanel flow12 = (FlowLayoutPanel)flow1234.Controls[j];
                    CheckBox Check = (CheckBox)flow12.Controls[0];
                    var numericUpDown = (NumericUpDown)flow12.Controls[1];

                    if(Check.Checked){

                        string[] price = Check.Text.Split('$');
                        string Product = price[0];
                        int foodPrice = int.Parse(price[1]);
                        int quality = (int)numericUpDown.Value;

                        checkdetail = new CheckDetail(foodPrice, quality, Product);
                        CheckPriceList.Add(checkdetail);
                     }
                    

                }

            }



            return CheckPriceList;
        }


    }
}
