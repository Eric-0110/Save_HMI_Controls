using LYHControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Save_HMI_Controls
{
    public partial class CheckBox : UserControl
    {
        // 存储子选项的列表
        private List<LYHControls.CheckBox> subItems = new List<LYHControls.CheckBox>();
        private bool _isUpdatingLogic = false; // 状态锁，防止死循环

        public CheckBox()
        {
            InitializeComponent();

            // 建议在 HandleCreated 或 Load 中初始化逻辑，确保 smoothscrollpanel4 已加载
            this.Load += CheckBoxGroup_Load;
        }

        private void CheckBoxGroup_Load(object sender, EventArgs e)
        {
            InitLogic();
        }

        private void InitLogic()
        {
            // 1. 自动从平滑滚动面板中抓取子 CheckBox (假设 c1 是全选，c2,c3,c4 是子项)
            // 如果你在设计器里已经有名称，可以直接用 c2, c3, c4
            // 这里我们采用更灵活的写法：找出面板内除了 c1 以外的所有 CheckBox
            subItems = smoothScrollPanel4.Controls.OfType<LYHControls.CheckBox>()
                                        .Where(x => x.Name != "c1")
                                        .ToList();

            // 2. 绑定全选框 c1 的事件
            if (c1 != null)
            {
                c1.CheckedChanged += c1_CheckedChanged;
            }

            // 3. 循环绑定每个子项的事件
            foreach (var item in subItems)
            {
                item.CheckedChanged += SubItem_CheckedChanged;
            }
        }

        #region --- 核心联动逻辑 ---

        // 维度一：由上至下 (全选控制子项)
        private void c1_CheckedChanged(object sender, EventArgs e)
        {
            if (_isUpdatingLogic) return;

            _isUpdatingLogic = true;

            // 将全选框的状态同步给所有子项
            foreach (var item in subItems)
            {
                // 注意：这里同步的是 Checked 属性
                item.Checked = c1.Checked;
            }

            _isUpdatingLogic = false;
        }

        // 维度二：由下至上 (子项联动全选框的状态)
        private void SubItem_CheckedChanged(object sender, EventArgs e)
        {
            if (_isUpdatingLogic) return;

            _isUpdatingLogic = true;

            // 统计子项选中数量
            int checkedCount = subItems.Count(x => x.Checked);

            if (checkedCount == 0)
            {
                // 全不选
                c1.CheckState = CheckState.Unchecked;
            }
            else if (checkedCount == subItems.Count)
            {
                // 全选
                c1.CheckState = CheckState.Checked;
            }
            else
            {
                // 部分选中：进入 Ant Design 风格的“半选态”
                c1.CheckState = CheckState.Indeterminate;
            }

            _isUpdatingLogic = false;
        }

        #endregion

        /// <summary>
        /// 外部辅助方法：获取当前所有选中的子项名称
        /// </summary>
        public List<string> GetCheckedItems()
        {
            return subItems.Where(x => x.Checked).Select(x => x.Text).ToList();
        }
    }
}