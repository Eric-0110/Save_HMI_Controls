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
    public partial class Alert : UserControl
    {
        public Alert()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 检查控件是否存在
            if (this.alertManager1 == null || this.alertManager2 == null) return;

            string[] titles = { "同步成功", "温馨提示", "安全警告", "系统错误" };

            string[] descs = {
        "所有数据已成功同步至云端。",
        "跑马灯模式开启时，高度将保持固定。",
        "检测到异常登录，请核实您的账户安全。",
        "无法连接到远程服务器，错误代码：0x8004210B。"
    };

            Image[] icons = {
        Properties.Resources._22, // 成功
        Properties.Resources._23, // 信息
        Properties.Resources._24, // 警告
        Properties.Resources._26  // 错误
    };

            Random rnd = new Random();

            // 给 alertManager1 生成一个随机通知
            int idx1 = rnd.Next(0, 4);
            this.alertManager1.Show(
                text: titles[idx1],
                description: descs[idx1],
                type: (AlertType)idx1,
                duration: 3000,
                icon: icons[idx1]
            );

            // 给 alertManager2 生成一个随机通知
            int idx2 = rnd.Next(0, 4);
            this.alertManager2.Show(
                text: titles[idx2],
                description: descs[idx2],
                type: (AlertType)idx2,
                duration: 5000,
                icon: icons[idx2]
            );
        }

        // alert13 -> 对应图片1：文件上传成功 (成功/图片22)
        private void alert13_ActionClick(object sender, EventArgs e)
        {
            // 模拟点击“查看”
            MessageBox.Show("正在跳转至文件管理器，查看已上传的文件详情...", "系统提示",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        } 

        // alert14 -> 对应图片2：您有3条新消息 (信息/图片23)
        private void alert14_ActionClick(object sender, EventArgs e)
        {
            // 模拟点击“立即查看”
            MessageBox.Show("正在打开消息中心...\n1. 系统升级通知\n2. 收到一份新邮件\n3. 任务分配提醒",
                "消息提醒", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        // alert15 -> 对应图片3：账号存在安全风险 (警告/图片24)
        private void alert15_ActionClick(object sender, EventArgs e)
        {
            // 模拟点击“去修改”
            DialogResult result = MessageBox.Show("为了您的账号安全，建议立即修改密码。是否现在跳转到安全设置页面？",
                "安全警示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // 模拟跳转逻辑
                Console.WriteLine("跳转至：AccountSettings/ChangePassword");
            }
        }

        // alert16 -> 对应图片4：支付失败 (错误/图片26)
        private void alert16_ActionClick(object sender, EventArgs e)
        {
            // 模拟点击“重试”
            DialogResult result = MessageBox.Show("网络请求超时，支付未完成。是否重新发起请求？",
                "支付失败", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            if (result == DialogResult.Retry)
            {
                // 模拟重新调用 alertManager 显示支付中的状态
                this.alertManager1.Show("重新提交中", "正在尝试重新连接支付网关...", AlertType.Info, 3000, Properties.Resources._23);
            }
        }
    }
}
