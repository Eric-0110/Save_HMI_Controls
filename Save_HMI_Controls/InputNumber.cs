using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Save_HMI_Controls
{
    public partial class InputNumber : UserControl
    {
        public InputNumber()
        {
            InitializeComponent();
        }

        private void inputNumber1_ValueChanged(object sender, decimal e)
        {

        }

        private void smoothScrollPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void inputNumber16_ValueChanged(object sender, decimal e)
        {
            label32.Text = " ¥" + inputNumber16.Value * 99 + ".00";
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void smoothScrollPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
