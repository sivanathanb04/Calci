using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private decimal M1 { get; set; }

        private decimal M2 { get; set; }


        private bool _m1Set = false;
        private bool _m2Set = false;

        private string _opSet = "";

        private void OpClick(string mathOperator)
        {
            decimal result = 0;
            if (_m1Set==false)
            {
                if (mathOperator=="=")
                {
                    return;
                }
                M1 = Convert.ToDecimal(Display_lbl.Text);
                _m1Set = true;
                _opSet = mathOperator;
                Display_lbl.Text = "0";
                _m2Set = false;
                M2 = 0;
            }
            else if (_m2Set==false)
            {
                M2= Convert.ToDecimal(Display_lbl.Text);
                _m2Set = true;
                switch (_opSet)
                {
                    case "+":
                        result = M1 + M2;
                        break;
                    case "-":
                        result = M1 - M2;
                        break;
                    case "/":
                        result = M1 / M2;
                        break;
                    case "*":
                        result = M1 * M2;
                        break;
                }
                Display_lbl.Text =Convert.ToString(result);
                if (mathOperator=="=")
                {
                    _opSet = "";
                    M1 = 0;
                    M2 = 0;
                    _m1Set = false;
                    _m2Set = false;
                }
                else
                {
                    M1 = result;
                    _m1Set = true;
                    _opSet = mathOperator;
                    M2 = 0;
                    _m2Set = false;
                }
            }
        }

        private void NumClick(int num)
        {
            string dispVal = Display_lbl.Text;
            int dispNum = Convert.ToInt32(dispVal);
            int result = dispNum * 10 + num;
            string dispResult = Convert.ToString(result);
            Display_lbl.Text = dispResult;
        }

        private void zero_btn_Click(object sender, EventArgs e)
        {
            NumClick(0);
        }

        private void one_btn_Click(object sender, EventArgs e)
        {
            NumClick(1);
        }

        private void two_btn_Click(object sender, EventArgs e)
        {
            NumClick(2);
        }

        private void three_btn_Click(object sender, EventArgs e)
        {
            NumClick(3);
        }

        private void four_btn_Click(object sender, EventArgs e)
        {
            NumClick(4);
        }

        private void five_btn_Click(object sender, EventArgs e)
        {
            NumClick(5);
        }

        private void six_btn_Click(object sender, EventArgs e)
        {
            NumClick(6);
        }

        private void seven_btn_Click(object sender, EventArgs e)
        {
            NumClick(7);
        }

        private void eight_btn_Click(object sender, EventArgs e)
        {
            NumClick(8);
        }

        private void nine_btn_Click(object sender, EventArgs e)
        {
            NumClick(9);
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            OpClick("+");
        }

        private void multiply_btn_Click(object sender, EventArgs e)
        {
            OpClick("*");
        }

        private void minus_btn_Click(object sender, EventArgs e)
        {
            OpClick("-");
        }

        private void div_btn_Click(object sender, EventArgs e)
        {
            OpClick("/");
        }

        private void equal_btn_Click(object sender, EventArgs e)
        {
            OpClick("=");
        }
    }
}
