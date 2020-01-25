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
                }
            }
        }
    }
}
