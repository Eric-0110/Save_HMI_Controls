using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection; // 必须引用这个命名空间

namespace Save_HMI_Controls
{
    public partial class CircularGauge : UserControl
    {
        public CircularGauge()
        {
            InitializeComponent();
        }

        private Random _random = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 遍历 1 到 9
            for (int i = 1; i <= 16; i++)
            {
                // 1. 跳过 2 号仪表盘
                if (i == 2) continue;

                // 2. 根据 ID 分配不同的随机范围（实现“不要都是 15-100”）
                float randomVal;
                switch (i)
                {
                    case 1: randomVal = _random.Next(85, 98); break;   // 高位运行
                    case 3: randomVal = _random.Next(5, 75); break;    // 低位待机
                    case 4: randomVal = (float)(_random.NextDouble() * 100); break; // 全量程随机
                    case 5: randomVal = _random.Next(45, 55); break;   // 极小范围中心波动
                    case 6: randomVal = _random.Next(60, 95); break;   // 中高位
                    case 7: randomVal = _random.Next(30, 70); break;   // 中段波动
                    case 8: randomVal = _random.Next(10, 50); break;   // 低位波动
                    case 9: randomVal = _random.Next(50, 100); break;  // 中高位波动
                    case 12: randomVal = _random.Next(10, 90); break;   // 大范围随机
                    case 13: randomVal = _random.Next(20, 80); break;   // 中范围随机
                    case 14: randomVal = _random.Next(0, 100); break;    // 全范围随机
                    case 15: randomVal = _random.Next(40, 60); break;    // 中心小范围
                    case 16: randomVal = _random.Next(70, 100); break;   // 高位小范围
                    default: continue; // 默认范围
                }

                // 3. 动态寻找控件名 (例如 "circularGauge1")
                Control[] found = this.Controls.Find("circularGauge" + i, true);

                if (found.Length > 0)
                {
                    var gauge = found[0];

                    // 4. 【核心】使用反射强行写入 private 的 Value 属性
                    // 这样你就不需要去改 CircularGauge.cs 里的代码了
                    PropertyInfo prop = gauge.GetType().GetProperty("Value",
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                    if (prop != null)
                    {
                        // 强行把随机值塞进去
                        prop.SetValue(gauge, randomVal, null);
                    }
                }
            }
        }

        private void multi_funcButton1_Click(object sender, EventArgs e)
        {
            circularGauge2.Value = circularGauge2.Value - 10;
        }

        private void multi_funcButton2_Click(object sender, EventArgs e)
        {
            circularGauge2.Value = circularGauge2.Value + 10;
        }

        private void circularGauge12_ValueChanged(object sender, EventArgs e)
        {
            if (circularGauge12.Value > 80)
            {
                circularGauge12.DescriptionText = "危险";
            }
            else
            {
                circularGauge12.DescriptionText = "正常";
            }
        }
    }
}
