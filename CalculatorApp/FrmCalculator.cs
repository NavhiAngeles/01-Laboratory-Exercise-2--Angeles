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
        public FrmCalculator()
        {
            InitializeComponent();
            comboBox1.Items.Add(" + ");
            comboBox1.Items.Add(" - ");
            comboBox1.Items.Add(" * ");
            comboBox1.Items.Add(" / ");
        }

        public delegate T Information<T>(T arg1);

        public class CalculatorClass
        {
            public Information<double> formula;

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

            public event EventHandler CalculatorEvent
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
}
