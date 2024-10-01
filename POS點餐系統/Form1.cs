using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            comboBox1.SelectedIndex = 0;

            Eventhandlers.ResultEvent += EventHandlers_ResultEvent;
            Eventhandlers.DisplayEvent += EventHandlers_DisplayEvent;

        }

        private void EventHandlers_ResultEvent(object sender, string e)
        {

            foodresultLB.Text = e.ToString();
        }

        private void EventHandlers_DisplayEvent(object sender, FlowLayoutPanel e)
        {
            flowLayoutPanel6.Controls.Clear();
            flowLayoutPanel6.Controls.Add(e);

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
                numericUpDown.Width = 50;
                Childflow.Height = 50;
                
                Childflow.Controls.Add(checkBox);
                Childflow.Controls.Add(numericUpDown);
                flow.Controls.Add(Childflow);


            }

        }

        private void numericUpdown_ValueChanged(object sender, EventArgs e)
        {

            NumericUpDown numericUpDown = (NumericUpDown)sender;
            var flow = numericUpDown.Parent;
            var MainFlow = flow.Parent.Parent;
            var checkBox = (CheckBox)flow.Controls[0];
            int quality = (int)numericUpDown.Value;



            if (checkBox.Checked == false && numericUpDown.Value == 1)
            {
                checkBox.Checked = true;
            }

            if (checkBox.Checked == true && numericUpDown.Value == 0)
            {
                checkBox.Checked = false;
            }



            string[] price = checkBox.Text.Split('$');
            string Product = price[0];
            int foodPrice = int.Parse(price[1]);

            CheckDetail checkDetail = new CheckDetail(foodPrice, quality, Product);
            Order.Add(checkDetail,comboBox1.Text);
            

        }



        private void CheckBox_Click(object sender, EventArgs e)
        {
            ///建物件
            CheckBox checkBox = (CheckBox)sender;
            var flow = checkBox.Parent;
            var MainFlow = flow.Parent.Parent;
            var numericUpDown = (NumericUpDown)flow.Controls[1];



            if (checkBox.Checked == true && numericUpDown.Value == 0)
            {
                numericUpDown.Value = 1;
            }
            
            if(checkBox.Checked == false)
            {
              
                numericUpDown.Value = 0;
            }

            int quality = (int)numericUpDown.Value;
            string[] price = checkBox.Text.Split('$');
            string Product = price[0];
            int foodPrice = int.Parse(price[1]);

            if (quality != 0)
            {
                CheckDetail checkDetail = new CheckDetail(foodPrice, quality, Product);
                Order.Add(checkDetail, comboBox1.Text);

            }




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order.DisCountOrders(comboBox1.Text);
        }
    }
}
