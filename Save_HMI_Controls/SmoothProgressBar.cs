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
    public partial class SmoothProgressBar : UserControl
    {
        public SmoothProgressBar()
        {
            InitializeComponent();
        }

        private void multi_funcButton1_Click(object sender, EventArgs e)
        {
            smoothProgressBar1.Value = 200;
            smoothProgressBar2.Value = 200;
        }

        private void multi_funcButton2_Click(object sender, EventArgs e)
        {
            smoothProgressBar1.Value = 625;
            smoothProgressBar2.Value = 625;
        }

        private void multi_funcButton3_Click(object sender, EventArgs e)
        {
            smoothProgressBar1.Value = 1000;
            smoothProgressBar2.Value = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            smoothProgressBar3.SetRandomValue();
            smoothProgressBar4.SetRandomValue();
            smoothProgressBar5.SetRandomValue();
            smoothProgressBar6.SetRandomValue();
            smoothProgressBar7.SetRandomValue();
            smoothProgressBar8.SetRandomValue();
            smoothProgressBar9.SetRandomValue();
            smoothProgressBar10.SetRandomValue();
            smoothProgressBar11.SetRandomValue();
            smoothProgressBar12.SetRandomValue();
        }
    }
}
