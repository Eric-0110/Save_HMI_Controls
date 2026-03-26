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
    public partial class IndustrialTank : UserControl
    {
        public IndustrialTank()
        {
            InitializeComponent();

        }

        private static readonly Random _tankRng = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 定义一个局部函数，用于在指定范围内生成随机水位
            // min, max 为水位范围，p 为跳动概率
            void RandomFill(LYHControls.IndustrialTank tank, float min, float max, double p)
            {
                if (_tankRng.NextDouble() < p)
                {
                    // 生成指定范围内的随机浮点数
                    float newValue = (float)(_tankRng.NextDouble() * (max - min) + min);
                    tank.Value = newValue;
                }
            }
            // --- 第一组：全量程(0-100) 大幅波动组 ---
            RandomFill(industrialTank15, 0f, 100f, 0.7); // 频繁变动
            RandomFill(industrialTank14, 0f, 100f, 0.5);
            RandomFill(industrialTank16, 0f, 100f, 0.6);

            // --- 第二组：全量程(0-100) 稳定波动组 ---
            RandomFill(industrialTank8, 0f, 100f, 0.4);
            RandomFill(industrialTank5, 0f, 100f, 0.3); // 变动最慢，模拟大容量储罐
            RandomFill(industrialTank10, 0f, 100f, 0.8); // 极其活跃

            // --- 第三组：全量程(0-100) 中速波动组 ---
            RandomFill(industrialTank6, 0f, 100f, 0.5);
            RandomFill(industrialTank9, 0f, 100f, 0.6);
            RandomFill(industrialTank7, 0f, 100f, 0.4);
        }

    }
}
