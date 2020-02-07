using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calculation
{
    public partial class Calculator : Form
    {
        Control ActiveControl;

        string input = string.Empty;
        string firstN = string.Empty;
        string secondN = string.Empty;
        double result = 0.0;
        string operation = string.Empty;

        public Calculator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Display.Text = Display.Text + btn.Text;
            input += btn.Text; 
        }

        private void Display_Enter(object sender, EventArgs e)
        {
            ActiveControl = (Control)sender;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            if (Display.Text.Length > 0)
            {
                Display.Text = Display.Text.Remove(Display.Text.Length - 1);
            }
            else {
                Display.Text = "";
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            Display.Text = "";
            input = string.Empty;
            firstN = string.Empty;
            secondN = string.Empty;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            firstN = input;
            operation = btn.Text;
            input = string.Empty;
            Display.Text = "";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (operation != "")
            {
                secondN = input;
                double num1, num2;
                double.TryParse(firstN, out num1);
                double.TryParse(secondN, out num2);
                switch (operation)
                {
                    case "*":
                        result = num1 * num2;
                        Display.Text = result.ToString();
                        input = result.ToString();
                        operation = string.Empty;
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                            Display.Text = result.ToString();
                            input = result.ToString();
                            operation = string.Empty;
                        }
                        else
                        {
                            SecondDisplay.Text = "Error: division by zero";
                        }
                        break;
                    case "+":
                        result = num1 + num2;
                        Display.Text = result.ToString();
                        input = result.ToString();
                        operation = string.Empty;
                        break;
                    case "-":
                        result = num1 - num2;
                        Display.Text = result.ToString();
                        input = result.ToString();
                        operation = string.Empty;
                        break;
                }
                operation = "";
            }
            else {
                SecondDisplay.Text = "Error: no operation chosen";
            }
        }
    }
}
