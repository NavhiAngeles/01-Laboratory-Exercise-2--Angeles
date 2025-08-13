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
            public Information<double> info;



        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
