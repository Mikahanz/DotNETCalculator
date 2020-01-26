using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {

        //public delegate decimal calculator(decimal firstNum, decimal secondNum);

        static decimal Addition(decimal fNum, decimal sNum)
        {
            return fNum + sNum;
        }

        static decimal Subtraction(decimal fNum, decimal sNum)
        {
            return fNum - sNum;
        }

        static decimal Multiplication(decimal fNum, decimal sNum)
        {
            return fNum * sNum;
        }

        static decimal Division(decimal fNum, decimal sNum)
        {
            return fNum / sNum;
        }

        static decimal getResult(decimal fNum, string str, decimal sNum)
        {
            switch (str)
            {
                case "*":
                    return Multiplication(fNum, sNum);                    
                case "/":
                    return Division(fNum, sNum);                    
                case "+":
                    return Addition(fNum, sNum);                   
                case "-":
                    return Subtraction(fNum, sNum);
                default:
                    return -1;
                   


            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            
            if (sender is Button)
            {
                Button b = sender as Button;
                if (b != null)
                {
                    if(tbxMain.Text == "0" || isOperatorPressed)
                    {
                        tbxMain.Clear();
                    }

                    isOperatorPressed = false;

                    if(b.Text == ".")
                    {
                        if (!tbxMain.Text.Contains("."))
                        {
                            tbxMain.Text += b.Text;
                            tbxDisplay.Text += b.Text;
                        }
                    }
                    else
                    {
                        tbxMain.Text += b.Text;
                        tbxDisplay.Text += b.Text;
                    }

                    
                    
                }
            }

            // Another way to the get the button sender
            //Button button = (Button)sender;
            //tbxMain.Text = button.Text;
        }

        
        decimal totalResult = 0;        
        string opeRator = "";
        bool isOperatorPressed = false;

        private void btnMultiply_Click(object sender, EventArgs e)
        {
           
            if (sender is Button)
            {
                Button b = sender as Button;
                if (b != null)
                {

                    if(totalResult != 0)
                    {
                        btnEqual.PerformClick();
                        opeRator = b.Text;
                        tbxDisplay.Text += b.Text;
                        isOperatorPressed = true;
                        //tbxMain.Clear();

                    }
                    else
                    {
                        opeRator = b.Text;

                        totalResult = Convert.ToDecimal(tbxMain.Text);
                        tbxDisplay.Text += b.Text;
                        isOperatorPressed = true;
                        tbxMain.Clear();

                    }


                }
                
            }

            
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            totalResult = 0;
            tbxMain.Clear();            
            tbxDisplay.Clear();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {

            tbxMain.Text = Convert.ToString(getResult(totalResult, opeRator, Convert.ToDecimal(tbxMain.Text)));

            totalResult = Convert.ToDecimal(tbxMain.Text);
            
        }
    }
}
