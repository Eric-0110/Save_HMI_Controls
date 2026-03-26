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

        private static readonly Random _timer1Rng = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 同样定义一个随机更新函数：p 为触发概率 (0.0 到 1.0)
            void ShuffleUpdate(LYHControls.SmoothProgressBar bar, double p)
            {
                if (_timer1Rng.NextDouble() < p) bar.SetRandomValue();
            }

            // --- 顺序完全错位，模拟不同轴的负载波动 ---

            ShuffleUpdate(smoothProgressBar7, 0.75);  // 高频波动
            ShuffleUpdate(smoothProgressBar3, 0.40);  // 中低频
            ShuffleUpdate(smoothProgressBar11, 0.65);

            ShuffleUpdate(smoothProgressBar5, 0.20);  // 极低频（模拟慢速变化的参数）
            ShuffleUpdate(smoothProgressBar9, 0.85);  // 极高频（模拟主切削力）
            ShuffleUpdate(smoothProgressBar4, 0.55);

            ShuffleUpdate(smoothProgressBar12, 0.35);
            ShuffleUpdate(smoothProgressBar6, 0.70);
            ShuffleUpdate(smoothProgressBar10, 0.45);
            ShuffleUpdate(smoothProgressBar8, 0.60);
        }
    }
}
