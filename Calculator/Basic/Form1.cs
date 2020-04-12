using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        private decimal M1 { get; set; }//Left side value

        private decimal M2 { get; set; }//Right side value


        private bool _m1Set = false;//is m1 set
        private bool _m2Set = false;//is m2 set
        private bool _isOperator = false;//to check if operator is pressed again and again
        private bool _isNumber = false;//to check if previously number was pressed

        private string _opSet = "";//to store the previous operator

        private void OpClick(string mathOperator)
        {
            _isNumber = false;
            if (_isOperator)
            {
                return;
            }
            else
            {
                _isOperator = true;
            }
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
                mem_lbl.Text = Display_lbl.Text +_opSet;
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
                Display_lbl.Text = Convert.ToString(result);
                mem_lbl.Text= Convert.ToString(result);
                if (mathOperator=="=")
                {
                    mem_lbl.Text ="";
                    _opSet = "";
                    M1 = 0;
                    M2 = 0;
                    _m1Set = false;
                    _m2Set = false;
                    _isOperator = false;
                }
                else
                {
                    mem_lbl.Text += mathOperator;
                    M1 = result;
                    _m1Set = true;
                    _opSet = mathOperator;
                    _m2Set = true;
                }                
            }
            else
            {
                M2 = Convert.ToDecimal(Display_lbl.Text);

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
                Display_lbl.Text = Convert.ToString(result);
                mem_lbl.Text= Convert.ToString(result);
                if (mathOperator == "=")
                {
                    mem_lbl.Text = "";
                    _opSet = "";
                    M1 = 0;
                    M2 = 0;
                    _m1Set = false;
                    _m2Set = false;
                    _isOperator = false;
                }
                else
                {
                    mem_lbl.Text +=  mathOperator;
                    M1 = result;
                    _m1Set = true;
                    _opSet = mathOperator;
                    M2 = 0;
                    _m2Set = true;
                }
            }
        }

        private void NumClick(int num)
        {
            _isOperator = false;
            if (_m1Set==false)
            {
                mem_lbl.Text = "";
            }
            if (_m1Set && _m2Set)
            {
                M2 = Convert.ToDecimal(Display_lbl.Text);
                if (_isNumber==false)
                {
                    Display_lbl.Text = "0";
                }                
            }
            _isNumber = true;
            string dispVal = Display_lbl.Text;
            decimal result = 0;
            if (dispVal.Split('.').Length>0)
            {
                int intPart = Convert.ToInt32(dispVal.Split('.')[0]);
                decimal decPart = Convert.ToDecimal(dispVal);
                decimal realDecimal = Convert.ToDecimal(intPart)-decPart;
                result = intPart * 10 + num+realDecimal;
            }
            else
            {
                int dispNum = Convert.ToInt32(Display_lbl.Text);
                result = dispNum * 10 + num;
            }

            string dispResult = Convert.ToString(result.ToString());
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

        private void C_btn_Click(object sender, EventArgs e)
        {
            Display_lbl.Text = "0";
            mem_lbl.Text = "";
            _opSet = "";
            M1 = 0;
            M2 = 0;
            _m1Set = false;
            _m2Set = false;
            _isOperator = false;
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            string originalNum = Display_lbl.Text;
            int requisiteLength = originalNum.Length - 1;
            string resultNum = "";
            if (requisiteLength<=0)
            {
                Display_lbl.Text = "0";
            }
            else
            {
                resultNum = originalNum.Substring(0, requisiteLength);
                Display_lbl.Text = resultNum;
            }

        }
    }
}
