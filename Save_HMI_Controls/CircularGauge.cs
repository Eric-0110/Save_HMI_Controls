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
        // 缓存：避免每次 Tick 都做 Controls.Find 和多次反射查询
        private List<(Control Gauge, PropertyInfo ValueProp)> _gaugeCache = new List<(Control, PropertyInfo)>();
        private Random _random = new Random();

        public CircularGauge()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // 在组件初始化后缓存子控件和它们的 Value 属性信息
            InitializeGaugeCache();
        }

        private void InitializeGaugeCache()
        {
            _gaugeCache.Clear();

            // designer 中已有 circularGauge1..16 字段，直接使用反射获取 Value 属性并缓存
            for (int i = 1; i <= 16; i++)
            {
                string name = "circularGauge" + i;

                //通过字段或 Controls 集合查找控件（优先字段）
                Control found = null;
                try
                {
                    var field = this.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    if (field != null)
                    {
                        found = field.GetValue(this) as Control;
                    }
                }
                catch
                {
                    // 忽略反射异常，后面尝试 Controls.Find
                }

                if (found == null)
                {
                    var arr = this.Controls.Find(name, true);
                    if (arr != null && arr.Length > 0) found = arr[0];
                }

                if (found != null)
                {
                    var prop = found.GetType().GetProperty("Value", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (prop != null)
                    {
                        _gaugeCache.Add((found, prop));
                    }
                }
            }
        }

        private bool TryGetRandomForId(int id, out float value)
        {
            value = 0f;
            switch (id)
            {
                case 1: value = _random.Next(85, 98); return true;   // 高位运行
                case 3: value = _random.Next(5, 75); return true;    // 低位待机
                case 4: value = (float)(_random.NextDouble() * 100); return true; // 全量程随机
                case 5: value = _random.Next(45, 55); return true;   // 极小范围中心波动
                case 6: value = _random.Next(60, 95); return true;   // 中高位
                case 7: value = _random.Next(30, 70); return true;   // 中段波动
                case 8: value = _random.Next(10, 50); return true;   // 低位波动
                case 9: value = _random.Next(50, 100); return true;  // 中高位波动
                case 12: value = _random.Next(10, 90); return true;   // 大范围随机
                case 13: value = _random.Next(20, 80); return true;   // 中范围随机
                case 14: value = _random.Next(0, 100); return true;    // 全范围随机
                case 15: value = _random.Next(40, 60); return true;    // 中心小范围
                case 16: value = _random.Next(70, 100); return true;   // 高位小范围
                default: return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 遍历缓存，避免每次都通过 Controls.Find
            foreach (var entry in _gaugeCache)
            {
                var gauge = entry.Gauge;
                var prop = entry.ValueProp;

                // 跳过已释放或不可见的控件，减少 UI线程开销
                if (gauge == null || gauge.IsDisposed || gauge.Disposing) continue;
                if (!gauge.Visible) continue;

                // 从控件名解析 id，例如 "circularGauge3" ->3
                int id = 0;
                if (!int.TryParse(gauge.Name?.Replace("circularGauge", ""), out id)) continue;

                if (!TryGetRandomForId(id, out float randomVal)) continue;

                try
                {
                    //仅在属性存在且控件仍然有效时设置值
                    prop.SetValue(gauge, randomVal, null);
                }
                catch
                {
                    // 忽略设置过程中可能发生的异常（控件正在被销毁/反射失败等）
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

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            // 页面切换时停止或启动 timer，防止在不可见时继续触发导致切换卡顿或访问已销毁控件
            try
            {
                if (timer1 != null)
                {
                    if (this.Visible)
                    {
                        timer1.Enabled = true;
                        timer1.Start();
                    }
                    else
                    {
                        timer1.Stop();
                        timer1.Enabled = false;
                    }
                }
            }
            catch
            {
                // 忽略异常
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            //先停止 timer，避免在控件销毁过程中被 Tick访问
            try
            {
                if (timer1 != null)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                }
            }
            catch
            {
                // 忽略
            }

            // 清理缓存，释放对子控件的引用，避免野指针
            _gaugeCache.Clear();

            base.OnHandleDestroyed(e);
        }
    }
}
