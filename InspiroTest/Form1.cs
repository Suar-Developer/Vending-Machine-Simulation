using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using InspiroTest;

namespace InspiroTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> prices;
        List<object> names;
        List<int> moneys;
        int price;
        int currTotal;

        //Stocks
        int sBiskuit = 10;
        int sChips = 9;
        int sOreo = 8;
        int sTango = 7;
        int sCoklat = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            prices = new List<int>();
            names = new List<object>();
            moneys = new List<int>();

            //Get Products & Prices
            Jobs.GetProducts(prices, names);
            foreach (var item in names)
            {
                comboBox1.Items.Add(item);
            }
            //Get Moneys
            Jobs.GetMoneys(moneys);
            foreach (var item in moneys)
            {
                comboBox2.Items.Add(item);
            }
            reset();
        }

        private void reset()
        {
            label8.Visible = false;
            button2.Enabled = false;
            btn_inputcash.Enabled = false;

            price = 0;
            currTotal = 0;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            btn_buy.Enabled = true;
            button1.Enabled = false;
            label8.Text = "Not Enough Cash!";
        }

        private void comboBox1_SelectedIndexChanged(object sender,
        System.EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                //object item = names[comboBox1.SelectedIndex];
                int result = prices[comboBox1.SelectedIndex];
                lbl_price.Text = result.ToString();
                price = 0;
                price = result;

                switch (comboBox1.SelectedIndex+1)
                {
                    case 1:
                        textBox4.Text = sBiskuit.ToString();
                        break;
                    case 2:
                        textBox4.Text = sChips.ToString();
                        break;
                    case 3:
                        textBox4.Text = sOreo.ToString();
                        break;
                    case 4:
                        textBox4.Text = sTango.ToString();
                        break;
                    case 5:
                        textBox4.Text = sCoklat.ToString();
                        break;
                    default:
                        textBox4.Text = "0";
                        break;
                }

                switch (textBox4.Text)
                {
                    case "0":
                        label8.Visible = true;
                        label8.Text = "Out Of Stock";
                        btn_buy.Enabled = false;
                        break;
                    default:
                        btn_buy.Enabled = true;
                        break;
                }
            }
            else
            {
                label8.Show();
                label8.Text = "ERROR";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender,
        System.EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                button2.Enabled = true;
                btn_inputcash.Enabled = true;
            }
            else 
            {
                button2.Enabled = false;
                btn_inputcash.Enabled = false;
            }
                
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_buy_Click(object sender, EventArgs e)
        {
            //int totalPrice = int.Parse(lbl_price.Text);

            if (currTotal < price)
                label8.Visible = true;

            if (currTotal >= price)
            {
                switch (comboBox1.SelectedIndex + 1)
                {
                    case 1:
                        sBiskuit = sBiskuit - 1;
                        break;
                    case 2:
                        sChips = sChips - 1;
                        break;
                    case 3:
                        sOreo = sOreo - 1;
                        break;
                    case 4:
                        sTango = sTango - 1;
                        break;
                    case 5:
                        sCoklat = sCoklat - 1;
                        break;
                    default:
                        break;
                }

                int exchange = currTotal - price;
                textBox3.Text = exchange.ToString();
                label8.Text = "Thank You For Buying";
                button1.Enabled = true;
                btn_buy.Enabled = false;
            }
        }

        private void Buy() {

        }

        private void btn_inputcash_Click(object sender, EventArgs e)
        {
            int total = int.Parse(comboBox2.SelectedItem.ToString());
            Jobs.Total(total, currTotal);
            currTotal = total + currTotal;
            textBox2.Text = currTotal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
