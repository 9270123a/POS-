using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using POS點餐系統.Models;
using static System.Windows.Forms.LinkLabel;
using static POS點餐系統.Models.MenuModel;

namespace POS點餐系統
{
    public partial class Form1 : Form
    {

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
            string menuPath = ConfigurationManager.AppSettings["MenuPath"];
            using (StreamReader reader = new StreamReader(menuPath))
            {
                string content = reader.ReadToEnd();
                MenuModel menumodel = JsonConvert.DeserializeObject<MenuModel>(content);

                for (int i = 0; i < menumodel.Menus.Length; i++)
                {
                    FlowLayoutPanel MealPanel = new FlowLayoutPanel();
                    FlowLayoutPanel MenuTypePanel = new FlowLayoutPanel();


                    Label label = new Label();
                    label.Text = menumodel.Menus[i].MenuType;

                    MenuTypePanel.Controls.Add(label);
                    MenuTypePanel.Height = 20;
                    MealPanel.Controls.Add(MenuTypePanel);


                    List<string> menu = menumodel.Menus[i].Meal.Select(x => x.Name + "$" + x.Price).ToList();
                    MealPanel.Height = 350;
                    MealPanel.Width = 250;
                    GenerateCheckBox(menu.ToArray(), MealPanel);


                }

                List<KeyValueModel> strategies = menumodel.Discounts.Select(x => new KeyValueModel()
                {
                    Name = x.Name,
                    Strategy = x
                }).ToList();

                comboBox1.DataSource = strategies;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Strategy";

            }

            Eventhandlers.ResultEvent += EventHandlers_ResultEvent;
            Eventhandlers.DisplayEvent += EventHandlers_DisplayEvent;
            comboBox1.SelectedIndex = 0;

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

            for (int i = 0; i < foods.Count(); i++)
            {
                FlowLayoutPanel Childflow = new FlowLayoutPanel();
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
                flowLayoutPanel5.Controls.Add(flow);

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
            Order.Add(checkDetail, (Discount)comboBox1.SelectedValue);


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

            if (checkBox.Checked == false)
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
                Order.Add(checkDetail, (Discount)comboBox1.SelectedValue);

            }




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue is Discount discount)
            {
                Order.DisCountOrders(discount);

            }
        }


    }
}
