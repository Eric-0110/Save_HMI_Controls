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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.SuspendLayout();
            gauge_ProgressBar5.SetRandomValue();
            gauge_ProgressBar6.SetRandomValue();
            gauge_ProgressBar7.SetRandomValue();
            gauge_ProgressBar8.SetRandomValue();
            gauge_ProgressBar9.SetRandomValue();
            gauge_ProgressBar10.SetRandomValue();
            gauge_ProgressBar11.SetRandomValue();
            gauge_ProgressBar12.SetRandomValue();
            gauge_ProgressBar13.SetRandomValue();
            gauge_ProgressBar14.SetRandomValue();
            gauge_ProgressBar15.SetRandomValue();
            gauge_ProgressBar16.SetRandomValue();
            gauge_ProgressBar17.SetRandomValue();
            gauge_ProgressBar18.SetRandomValue();
            gauge_ProgressBar19.SetRandomValue();
            gauge_ProgressBar20.SetRandomValue();
            gauge_ProgressBar21.SetRandomValue();
            gauge_ProgressBar22.SetRandomValue();
            gauge_ProgressBar23.SetRandomValue();
            //this.ResumeLayout(false);
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
