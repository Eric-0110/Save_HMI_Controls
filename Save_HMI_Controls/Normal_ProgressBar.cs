using LYHControls;
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
    public partial class Normal_ProgressBar : UserControl
    {
        public Normal_ProgressBar()
        {
            InitializeComponent();
        }

        private void multi_funcButton1_Click(object sender, EventArgs e)
        {
            normal_ProgressBar9.Value = 30;
            normal_ProgressBar10.Value = 30;
            normal_ProgressBar11.Value = 30;
            normal_ProgressBar12.Value = 30;
        }

        private void multi_funcButton2_Click(object sender, EventArgs e)
        {
            normal_ProgressBar9.Value = 65;
            normal_ProgressBar10.Value = 65;
            normal_ProgressBar11.Value = 65;
            normal_ProgressBar12.Value = 65;
        }

        private void multi_funcButton3_Click(object sender, EventArgs e)
        {
            normal_ProgressBar9.Value = 90;
            normal_ProgressBar10.Value = 90;
            normal_ProgressBar11.Value = 90;
            normal_ProgressBar12.Value = 90;
        }


        private int _demoValue = 100;
        private bool _isDescending = true; // 初始状态：递减
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1. 根据当前方向计算数值
            if (_isDescending)
            {
                _demoValue -= 1; // 递减步长
                if (_demoValue <= 0)
                {
                    _demoValue = 0;
                    _isDescending = false; // 触底，转向递增
                }
            }
            else
            {
                _demoValue += 1; // 递增步长
                if (_demoValue >= 100)
                {
                    _demoValue = 100;
                    _isDescending = true; // 达顶，转向递减
                }
            }
            normal_ProgressBar21.Value = _demoValue;
        }

        private static readonly Random _updateRng = new Random();
        private void timer2_Tick(object sender, EventArgs e)
        {
            // 定义一个灵活的触发函数：p 为触发概率 (0.0 到 1.0)
            void TryUpdate(LYHControls.Normal_ProgressBar bar, double p)
            {
                if (_updateRng.NextDouble() < p) bar.SetRandomValue();
            }

            // --- 完全打乱顺序调用 ---

  
            TryUpdate(normal_ProgressBar5, 0.5);  // 概率低：模拟油温
            TryUpdate(normal_ProgressBar18, 0.6);

            TryUpdate(normal_ProgressBar8, 0.5);
            TryUpdate(normal_ProgressBar15, 0.8); // 极高频跳动
            TryUpdate(normal_ProgressBar6, 0.4);

            TryUpdate(normal_ProgressBar20, 0.2); // 极低频

            TryUpdate(normal_ProgressBar7, 0.5);

            TryUpdate(normal_ProgressBar14, 0.7);

            TryUpdate(normal_ProgressBar17, 0.6);


            TryUpdate(normal_ProgressBar16, 0.5);
            TryUpdate(normal_ProgressBar13, 0.8);
            TryUpdate(normal_ProgressBar19, 0.4);
        }
    }
}
