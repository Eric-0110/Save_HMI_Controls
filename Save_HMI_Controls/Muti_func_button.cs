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
    public partial class Muti_func_button : UserControl
    {
        public Muti_func_button()
        {
            InitializeComponent();
        }

        private async void multi_funcButton49_Click(object sender, EventArgs e)
        {
            //multi_funcButton49.Text = "已喜欢";
            var btn = (LYHControls.Multi_funcButton)sender;
            if (btn.Checked)
            {
                btn.Text = "已喜欢"; // 变为状态B的文字
            }
            else
            {
                btn.Text = "点击喜欢"; // 恢复状态A的文字
            }
        }

        private void multi_funcButton50_Click(object sender, EventArgs e)
        {
            var btn = (LYHControls.Multi_funcButton)sender;
            if (btn.Checked)
            {
                btn.Text = "已收藏"; // 变为状态B的文字
            }
            else
            {
                btn.Text = "点击收藏"; // 恢复状态A的文字
            }
        }

        private void multi_funcButton51_Click(object sender, EventArgs e)
        {
            var btn = (LYHControls.Multi_funcButton)sender;
            if (btn.Checked)
            {
                btn.Text = "已启用"; // 变为状态B的文字
            }
            else
            {
                btn.Text = "点击启用"; // 恢复状态A的文字
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
    }
}
