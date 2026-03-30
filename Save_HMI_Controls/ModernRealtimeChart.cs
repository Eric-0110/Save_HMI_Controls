using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Save_HMI_Controls
{
    public partial class ModernRealtimeChart : UserControl
    {
        // ---------------------------------------------------------
        // 字段定义
        // ---------------------------------------------------------
        private int _tickCount = 0;
        private int _a = 0;
        private Random _random1 = new Random();

        // 随机名称池
        private string[] _namePool = { "压力测试", "温度监控", "电压波动", "转速反馈", "流量统计", "湿度感应" };

        public ModernRealtimeChart()
        {
            InitializeComponent();
            multi_funcButton1_Click(multi_funcButton1, EventArgs.Empty);
        }

        // ---------------------------------------------------------
        // 示例 1: 单曲线定时更新 (Sine波形)
        // ---------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            _tickCount++;
            double yValue = Math.Sin(_tickCount * 0.1) * 50 + 50 + (_random1.NextDouble() * 2);

            // 传入固定名称 "速度位移"
            modernRealtimeChart1.AddValue("速度位移", _tickCount, (float)yValue, Color.DodgerBlue);
        }

        // ---------------------------------------------------------
        // 示例 2: 多曲线同时定时更新
        // ---------------------------------------------------------
        private void timer2_Tick(object sender, EventArgs e)
        {
            float y = (float)(_random1.NextDouble() * 40 + 20);
            float x = (float)(_random1.NextDouble() * 50 + 10);
            float z = (float)(_random1.NextDouble() * 80 + 10);

            modernRealtimeChart2.AddValue("机器1", _a, y, Color.FromArgb(255, 0, 192, 255));
            modernRealtimeChart2.AddValue("机器2", _a, x, Color.FromArgb(255, 255, 214, 0));
            modernRealtimeChart2.AddValue("机器3", _a, z, Color.FromArgb(255, 175, 80, 1));
            _a++;
        }

        // ---------------------------------------------------------
        // 示例 3: 随机名称、随机颜色、批量导入 (核心请求部分)
        // ---------------------------------------------------------
        private void multi_funcButton1_Click(object sender, EventArgs e)
        {
            // 1. 生成真正随机的名字 (例如: "温度监控_42")
            string randomName = _namePool[_random1.Next(_namePool.Length)] + "_" + _random1.Next(1, 100);

            // 2. 生成随机颜色
            Color randomColor = Color.FromArgb(
                _random1.Next(100, 255),
                _random1.Next(100, 255),
                _random1.Next(100, 255)
            );

            // 3. 设置控件当前的全局颜色（SetDataDirectly 会为该新序列采用此颜色）
            modernRealtimeChart3.LineColor = randomColor;
            modernRealtimeChart3.FillColor = Color.FromArgb(50, randomColor);

            // 4. 构建一组随机数据点列表 (模拟历史数据)
            List<PointF> randomPoints = new List<PointF>();
            int count = 200;
            float lastY = 50f;

            for (int i = 0; i < count; i++)
            {
                float delta = (float)(_random1.NextDouble() * 10 - 5);
                lastY += delta;
                randomPoints.Add(new PointF(i, lastY));
            }

            // 5. 调用核心函数：传入【随机名称】
            // 每次点击如果 randomName 不同，图表上就会多出一条线
            modernRealtimeChart3.SetDataDirectly(randomName, randomPoints, 0.1f);
        }

        // ---------------------------------------------------------
        // 4. 清除数据
        // ---------------------------------------------------------
        private void multi_funcButton2_Click(object sender, EventArgs e)
        {
            // 清除 chart3 上的所有序列
            modernRealtimeChart3.Clear();
        }
    }
}