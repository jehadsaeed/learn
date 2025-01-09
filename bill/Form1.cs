using bill;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bill
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillComboBoxes();
           tax.ReadOnly = true;
            totale.ReadOnly = true;
            price.ReadOnly = true;
            this.Size=new Size(350, 450);
            this.Text="Bill";
        }
        double total2 = 0;


        private readonly (string Name, double Price)[] beverages = {
            ("Soda", 1.95), ("Tea", 1.50), ("Coffee", 1.25),
            ("Mineral Water", 2.95), ("Juice", 2.50), ("Milk", 1.50)
        };

        private readonly (string Name, double Price)[] appetizers = {
            ("Buffalo Wings", 5.95), ("Buffalo Fingers", 6.95),
            ("Potato Skins", 8.95), ("Nachos", 8.95),
            ("Mushroom Caps", 10.95), ("Shrimp Cocktail", 12.95),
            ("Chips and Salsa", 6.95)
        };

        private readonly (string Name, double Price)[] mainCourses = {
            ("Seafood Alfredo", 15.95), ("Chicken Alfredo", 13.95),
            ("Chicken Piccata", 13.95), ("Turkey Club", 11.95),
            ("Lobster Pie", 19.95), ("Prime Rib", 20.95),
            ("Shrimp Scampi", 18.95), ("Turkey Dinner", 13.95),
            ("Stuffed Chicken", 14.95)
        };

        private readonly (string Name, double Price)[] desserts = {
            ("Apple Pie", 5.95), ("Sundae", 3.95),
            ("Carrot Cake", 5.95), ("Mud Pie", 4.95),
            ("Apple Crisp", 5.95)
        };



        private void FillComboBoxes()
        {

            // تعبئة قائمة المشروبات
            foreach (var item in beverages)
            {
                comboBox1.Items.Add($"{item.Name}");
            }
            // تعبئة قائمة المقبلات
            foreach (var item in appetizers)
            {
                comboBox2.Items.Add($"{item.Name}");
            }

            // تعبئة قائمة الأطباق الرئيسية
            foreach (var item in mainCourses)
            {
                comboBox3.Items.Add($"{item.Name}");
            }
            // تعبئة قائمة الحلويات
            foreach (var item in desserts)
            {
                comboBox4.Items.Add($"{item.Name}");
            }
        }

        private void CalculateTotal()
        {
            string info=comboBox1.Text;
            foreach(var i in beverages)
            {
                if (info==i.Name)
                {
                    total2 += i.Price;
                }
            }
             info = comboBox2.Text;
            foreach (var i in appetizers)
            {
                if (info==i.Name)
                {
                    total2 += i.Price;
                }
            }
            info = comboBox3.Text;
            foreach (var i in mainCourses)
            {
                if (info==i.Name)
                {
                    total2 += i.Price;
                }
            }
            info = comboBox4.Text;
            foreach (var i in desserts)
            {
                if (info==i.Name)
                {
                    total2 += i.Price;
                }
            }



            double total3 = 0;
            total3+=total2;
            total3+=(total2*16)/100;
            tax.Text="16%";
            price.Text=$"${total3:f2}";
            totale.Text = $"${total2:f2}";
        }

        private double GetSelectedItemPrice(object selectedItem)
        {
            if (selectedItem == null)
                return 0;

            string item = selectedItem.ToString();
            string pricePart = item.Substring(item.LastIndexOf('$') + 1);
            return double.Parse(pricePart);
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            totale.Text = "$0.00";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_Leave(object sender, EventArgs e)
        {
            CalculateTotal();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text=null;
            totale.Text=null;
            textBox2.Text = null;
            tax.Text = null;
            price.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = null;

        }
    }
}
