namespace Save_HMI_Controls
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LYHControls.LYHMenuItem lyhMenuItem1 = new LYHControls.LYHMenuItem();
            LYHControls.LYHMenuItem lyhMenuItem2 = new LYHControls.LYHMenuItem();
            LYHControls.LYHMenuItem lyhMenuItem3 = new LYHControls.LYHMenuItem();
            LYHControls.LYHMenuItem lyhMenuItem4 = new LYHControls.LYHMenuItem();
            LYHControls.LYHMenuItem lyhMenuItem5 = new LYHControls.LYHMenuItem();
            LYHControls.LYHMenuItem lyhMenuItem6 = new LYHControls.LYHMenuItem();
            LYHControls.LYHMenuItem lyhMenuItem7 = new LYHControls.LYHMenuItem();
            LYHControls.LYHMenuItem lyhMenuItem8 = new LYHControls.LYHMenuItem();
            LYHControls.LYHMenuItem lyhMenuItem9 = new LYHControls.LYHMenuItem();
            LYHControls.LYHMenuItem lyhMenuItem10 = new LYHControls.LYHMenuItem();
            treeMenu1 = new LYHControls.TreeMenu();
            mainwindow = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // treeMenu1
            // 
            treeMenu1.BackColor = Color.FromArgb(0, 62, 164);
            treeMenu1.DefaultSelectedIndex = 0;
            treeMenu1.Font = new Font("HarmonyOS Sans SC", 15F, FontStyle.Bold, GraphicsUnit.Pixel, 134);
            treeMenu1.ForeColor = Color.Silver;
            treeMenu1.IconLeftMargin = 30;
            treeMenu1.IconSize = 32;
            treeMenu1.IconTextSpacing = 0;
            treeMenu1.IsDarkTheme = false;
            lyhMenuItem1.BadgeText = "";
            lyhMenuItem1.Enabled = true;
            lyhMenuItem1.Icon = null;
            lyhMenuItem1.IsExpanded = false;
            lyhMenuItem1.ItemBackColor = Color.Empty;
            lyhMenuItem1.ItemFont = new Font("HarmonyOS Sans SC", 15F, FontStyle.Bold, GraphicsUnit.Pixel, 134);
            lyhMenuItem1.ItemForeColor = Color.White;
            lyhMenuItem1.TargetPageName = "Introduction";
            lyhMenuItem1.Text = "介绍";
            lyhMenuItem2.BadgeText = "";
            lyhMenuItem2.Enabled = true;
            lyhMenuItem2.Icon = null;
            lyhMenuItem2.IsExpanded = false;
            lyhMenuItem2.ItemBackColor = Color.Empty;
            lyhMenuItem2.ItemForeColor = Color.White;
            lyhMenuItem3.BadgeText = "3";
            lyhMenuItem3.Enabled = true;
            lyhMenuItem3.Icon = null;
            lyhMenuItem3.IsExpanded = false;
            lyhMenuItem3.ItemBackColor = Color.Empty;
            lyhMenuItem3.ItemForeColor = Color.White;
            lyhMenuItem4.BadgeText = "";
            lyhMenuItem4.Enabled = true;
            lyhMenuItem4.Icon = null;
            lyhMenuItem4.IsExpanded = false;
            lyhMenuItem4.ItemBackColor = Color.Empty;
            lyhMenuItem4.ItemForeColor = Color.White;
            lyhMenuItem4.TargetPageName = "Button_Group";
            lyhMenuItem4.Text = "按钮组";
            lyhMenuItem5.BadgeText = "";
            lyhMenuItem5.Enabled = true;
            lyhMenuItem5.Icon = null;
            lyhMenuItem5.IsExpanded = false;
            lyhMenuItem5.ItemBackColor = Color.Empty;
            lyhMenuItem5.ItemForeColor = Color.White;
            lyhMenuItem5.TargetPageName = "DropDowm_button";
            lyhMenuItem5.Text = "下拉菜单按钮";
            lyhMenuItem6.BadgeText = "";
            lyhMenuItem6.Enabled = true;
            lyhMenuItem6.Icon = null;
            lyhMenuItem6.IsExpanded = false;
            lyhMenuItem6.ItemBackColor = Color.Empty;
            lyhMenuItem6.ItemForeColor = Color.White;
            lyhMenuItem6.TargetPageName = "Muti_func_button";
            lyhMenuItem6.Text = "多功能按钮";
            lyhMenuItem7.BadgeText = "";
            lyhMenuItem7.Enabled = true;
            lyhMenuItem7.Icon = null;
            lyhMenuItem7.IsExpanded = false;
            lyhMenuItem7.ItemBackColor = Color.Empty;
            lyhMenuItem7.ItemForeColor = Color.White;
            lyhMenuItem7.TargetPageName = "Switch_button";
            lyhMenuItem7.Text = "开关切换按钮";
            lyhMenuItem3.SubItems.Add(lyhMenuItem4);
            lyhMenuItem3.SubItems.Add(lyhMenuItem5);
            lyhMenuItem3.SubItems.Add(lyhMenuItem6);
            lyhMenuItem3.SubItems.Add(lyhMenuItem7);
            lyhMenuItem3.TargetPageName = "";
            lyhMenuItem3.Text = "按钮家族";
            lyhMenuItem8.BadgeText = "";
            lyhMenuItem8.Enabled = true;
            lyhMenuItem8.Icon = null;
            lyhMenuItem8.IsExpanded = false;
            lyhMenuItem8.ItemBackColor = Color.Empty;
            lyhMenuItem8.ItemForeColor = Color.White;
            lyhMenuItem8.TargetPageName = "";
            lyhMenuItem8.Text = "基础反馈";
            lyhMenuItem2.SubItems.Add(lyhMenuItem3);
            lyhMenuItem2.SubItems.Add(lyhMenuItem8);
            lyhMenuItem2.TargetPageName = "";
            lyhMenuItem2.Text = "基础组件与按钮";
            lyhMenuItem9.BadgeText = "";
            lyhMenuItem9.Enabled = true;
            lyhMenuItem9.Icon = null;
            lyhMenuItem9.IsExpanded = false;
            lyhMenuItem9.ItemBackColor = Color.Empty;
            lyhMenuItem9.ItemForeColor = Color.White;
            lyhMenuItem9.TargetPageName = "";
            lyhMenuItem9.Text = "仪表盘";
            lyhMenuItem10.BadgeText = "";
            lyhMenuItem10.Enabled = true;
            lyhMenuItem10.Icon = null;
            lyhMenuItem10.IsExpanded = false;
            lyhMenuItem10.ItemBackColor = Color.Empty;
            lyhMenuItem10.ItemForeColor = Color.White;
            lyhMenuItem10.TargetPageName = "About";
            lyhMenuItem10.Text = "关于授权";
            treeMenu1.Items.Add(lyhMenuItem1);
            treeMenu1.Items.Add(lyhMenuItem2);
            treeMenu1.Items.Add(lyhMenuItem9);
            treeMenu1.Items.Add(lyhMenuItem10);
            treeMenu1.Location = new Point(0, 90);
            treeMenu1.Margin = new Padding(2);
            treeMenu1.Name = "treeMenu1";
            treeMenu1.RootItemBackColor = SystemColors.HotTrack;
            treeMenu1.SeparatorColor = Color.WhiteSmoke;
            treeMenu1.Size = new Size(220, 990);
            treeMenu1.SubItemBackColor = SystemColors.HotTrack;
            treeMenu1.TabIndex = 0;
            treeMenu1.TargetStackedWidget = mainwindow;
            treeMenu1.Text = "treeMenu1";
            treeMenu1.ThemeColor = Color.FromArgb(22, 119, 255);
            // 
            // mainwindow
            // 
            mainwindow.Location = new Point(220, 90);
            mainwindow.Name = "mainwindow";
            mainwindow.Size = new Size(1700, 990);
            mainwindow.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(251, 252, 253);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1920, 90);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(209, 213, 220);
            label2.Location = new Point(0, 88);
            label2.Name = "label2";
            label2.Size = new Size(1920, 2);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.Font = new Font("HarmonyOS Sans SC", 30F, FontStyle.Bold, GraphicsUnit.Pixel, 134);
            label1.Location = new Point(765, 23);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(611, 45);
            label1.TabIndex = 1;
            label1.Text = "基于.NET 8打造的 C#(Winform) 控件库";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.savehmi;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(220, 88);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 250);
            ClientSize = new Size(1920, 1080);
            Controls.Add(mainwindow);
            Controls.Add(panel1);
            Controls.Add(treeMenu1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private LYHControls.TreeMenu treeMenu1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel mainwindow;
        private Label label2;
    }
}
