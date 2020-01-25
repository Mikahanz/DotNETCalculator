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

        public delegate decimal calculator(decimal firstNum, decimal secondNum);

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
                    tbxMain.Text += b.Text;
                    tbxDisplay.Text += b.Text;
                }
            }
        }

        decimal fNumber = 0;
        decimal sNumber = 0;
        decimal totalResult = 0;
        int btnCounter = 0;
        string opeRator = "";
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            
            bool toggle = true;

            if (toggle & btnCounter == 0)
            {
                fNumber = Convert.ToDecimal(tbxMain.Text);
                toggle = false;
            }            
            
            btnCounter++;

            if (sender is Button)
            {
                Button b = sender as Button;
                if (b != null)
                {
//                    tbxDisplay.Text += tbxMain.Text;
                    tbxDisplay.Text += b.Text ;

                    
                    
                    if(btnCounter == 2)
                    {
                        sNumber = Convert.ToDecimal(tbxMain.Text);

                        switch(b.Text)
                        {
                            case "*":
                                totalResult = Multiplication(fNumber, sNumber);
                                break;
                            case "/":
                                totalResult = Division(fNumber, sNumber);
                                break;
                            case "+":
                                totalResult = Addition(fNumber, sNumber);
                                break;
                            case "-":
                                totalResult = Subtraction(fNumber, sNumber);
                                break;

                        }

                        tbxSecondary.Text = Convert.ToString(totalResult);
                        fNumber = totalResult;
                        btnCounter = 1;
                        sNumber = 0;
                    }
                }
                opeRator = b.Text;
            }

            tbxMain.Clear();
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fNumber = 0;
            sNumber = 0;
            tbxMain.Clear();
            tbxSecondary.Clear();
            tbxDisplay.Clear();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            decimal num1 = Convert.ToDecimal(tbxSecondary.Text);
            decimal num2 = Convert.ToDecimal(tbxMain.Text);

            tbxSecondary.Text = Convert.ToString(getResult(num1, opeRator, num2));
        }
    }
}
