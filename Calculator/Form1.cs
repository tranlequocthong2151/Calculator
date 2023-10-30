using System;
using System.Windows.Forms;
namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var kq = CreateCalculator()?.Execute("+");
            textBox3.Text = kq.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var kq = CreateCalculator()?.Execute("-");
            textBox3.Text = kq.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var kq = CreateCalculator()?.Execute("*");
            textBox3.Text = kq.ToString();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var kq = CreateCalculator()?.Execute("/");
                textBox3.Text = kq.ToString();

            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Lỗi chia 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Calculation CreateCalculator()
        {
            int a, b;
            if (int.TryParse(textBox1.Text, out a) || int.TryParse(textBox2.Text, out b))
            {
                MessageBox.Show("a va b phai la so", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new Calculation(a, b); 
        }

    }
}
