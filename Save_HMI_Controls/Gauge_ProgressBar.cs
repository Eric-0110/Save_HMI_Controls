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
    public partial class Gauge_ProgressBar : UserControl
    {
        public Gauge_ProgressBar()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        private static readonly Random _gaugeRng = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 定义局部随机触发函数：p 为触发概率 (0.0 到 1.0)
            void ShuffleGauge(LYHControls.Gauge_ProgressBar bar, double p)
            {
                if (_gaugeRng.NextDouble() < p) bar.SetRandomValue();
            }

            // --- 完全混编顺序，模拟多路传感器数据的不规则变动 ---

            ShuffleGauge(gauge_ProgressBar15, 0.75);
            ShuffleGauge(gauge_ProgressBar5, 0.30);
            ShuffleGauge(gauge_ProgressBar22, 0.60);
            ShuffleGauge(gauge_ProgressBar9, 0.45);

            ShuffleGauge(gauge_ProgressBar18, 0.80); // 高频更新
            ShuffleGauge(gauge_ProgressBar12, 0.25); // 低频更新
            ShuffleGauge(gauge_ProgressBar6, 0.55);
            ShuffleGauge(gauge_ProgressBar20, 0.40);

            ShuffleGauge(gauge_ProgressBar10, 0.65);
            ShuffleGauge(gauge_ProgressBar23, 0.35);
            ShuffleGauge(gauge_ProgressBar7, 0.50);
            ShuffleGauge(gauge_ProgressBar14, 0.70);

            ShuffleGauge(gauge_ProgressBar19, 0.45);
            ShuffleGauge(gauge_ProgressBar11, 0.55);
            ShuffleGauge(gauge_ProgressBar16, 0.85); // 极高频
            ShuffleGauge(gauge_ProgressBar8, 0.20);  // 极低频

            ShuffleGauge(gauge_ProgressBar21, 0.50);
            ShuffleGauge(gauge_ProgressBar13, 0.60);
            ShuffleGauge(gauge_ProgressBar17, 0.40);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            // 当用户切换页面，这个容器被销毁时，必须手动关掉所有子控件的定时器
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is UserControl userCtrl)
                {
                    // 尝试通过反射或直接访问关掉定时器（如果能改代码最好，不能改就强制 Dispose）
                    ctrl.Dispose();
                }
            }

            // 关掉你那个 SetRandomValue 的外部 timer1
            timer1.Stop();
            timer1.Enabled = false;

            base.OnHandleDestroyed(e);
        }
    }
}
