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
    public partial class DropDowm_button : UserControl
    {
        public DropDowm_button()
        {
            InitializeComponent();
        }





        private async void btn_Click(object sender, EventArgs e)
        {
            // 1. 进入等待状态
            btn.IsWaiting = true;
            btn.Text = "正在处理..."; // 可选：修改文字

            try
            {
                // 2. 模拟耗时任务（如请求服务器），不会阻塞 UI 界面
                await Task.Delay(3000);
            }
            finally
            {
                // 3. 恢复正常状态
                btn.IsWaiting = false;
                btn.Text = "处理完成";
            }
        }
    }
}
