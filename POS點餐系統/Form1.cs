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
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            var flow = numericUpDown.Parent;
            var check = (CheckBox)flow.Controls[0];
            string[] price = check.Text.Split('$');
            int foodPrice = int.Parse(price[1]);

            
            

            //if (numericupdown.value > 0 )
            //{
            //    check.checked = true;
            //}
            //else
            //{
            //    check.checked = false;
            //}
            //if (check.checked == true)
            //{
            //    result += (int)numericupdown.value * foodprice;
            //}
            //else
            //{
            //    result -= 1 * foodprice;
            //}
            //foodresultlb.text = result.tostring();
        }
        private void CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            var flow = checkBox.Parent;
            var c = (NumericUpDown)flow.Controls[1];
            var d = c.Value;
            int quality = (int)d;

            string[] price = checkBox.Text.Split('$');
            int foodPrice = int.Parse(price[1]);

            if (checkBox.Checked)
            {
                quality = 1;
                c.Value = quality;
                Result += foodPrice* quality;
            }
            else
            {
                quality = (int)c.Value;
                c.Value = 0;
                Result -= foodPrice * quality;
            }

            foodresultLB.Text = Result.ToString();
        }

        private void ResultCalculate()
        {

        }


        // 

    }
}
