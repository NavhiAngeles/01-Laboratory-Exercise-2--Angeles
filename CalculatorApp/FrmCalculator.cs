using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class FrmCalculator : Form
    {
        public delegate T Formula<T>(T num1, T num2);

        CalculatorClass cal = new CalculatorClass();
        double num1, num2;
       
        public FrmCalculator()
        {
            InitializeComponent();
            comboBox1.Items.Add(" + ");
            comboBox1.Items.Add(" - ");
            comboBox1.Items.Add(" * ");
            comboBox1.Items.Add(" / ");
        }

        public delegate T Formula<T>(T num1, T num2);

        public class CalculatorClass
        {
            public Formula<double> formula;

            public double GetSum(double num1, double num2)
            {
                return num1 + num2;
            }
            public double GetDiff(double num1, double num2)
            {
                return num1 - num2;
            }
            public double GetProd(double num1, double num2)
            {
                return num1 * num2;
            }
            public double GetQuo(double num1, double num2)
            {
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
                return num1 / num2;
            }

            public static event Formula<double> CalculatorEvent
            {
                add
                {
                    Console.WriteLine("Added the Delegate");
                }
                remove
                {
                    Console.WriteLine("Removed the Delegate");
                }

            }

            private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);
           

            if (comboBox1.Text == "+")
            {
                CalculatorClass.CalculatorEvent += new Formula<double>(cal.GetSum);
                textBox3.Text = cal.GetSum(num1, num2).ToString();
            }else if (comboBox1.Text == "-")
            {
                CalculatorClass.CalculatorEvent += new Formula<double>(cal.GetDiff);
                textBox3.Text = cal.GetDiff(num1, num2).ToString();
            }
            else if (comboBox1.Text == "*")
            {
                CalculatorClass.CalculatorEvent += new Formula<double>(cal.GetProd);
                textBox3.Text = cal.GetProd(num1, num2).ToString();
            }
            else if (comboBox1.Text == "/")
            {
                try
                {
                    CalculatorClass.CalculatorEvent += new Formula<double>(cal.GetQuo);
                    textBox3.Text = cal.GetQuo(num1, num2).ToString();
                }
                catch (DivideByZeroException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid operation.");

            }
        }
    }
}
