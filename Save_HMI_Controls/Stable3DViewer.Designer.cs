namespace Save_HMI_Controls
{
    partial class Stable3DViewer
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            smoothScrollPanel1 = new SmoothScrollPanel();
            smoothScrollPanel2 = new SmoothScrollPanel();
            panel3 = new Panel();
            stable3dViewer2 = new LYHControls.Stable3DViewer();
            label8 = new Label();
            label5 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            label14 = new Label();
            label11 = new Label();
            label2 = new Label();
            smoothScrollPanel1.SuspendLayout();
            smoothScrollPanel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // smoothScrollPanel1
            // 
            smoothScrollPanel1.AutoScroll = true;
            smoothScrollPanel1.AutoScrollMinSize = new Size(0, 733);
            smoothScrollPanel1.BackColor = Color.White;
            smoothScrollPanel1.BorderColor = Color.FromArgb(200, 200, 200);
            smoothScrollPanel1.BorderRadius = 0;
            smoothScrollPanel1.BorderWidth = 1;
            smoothScrollPanel1.BottomPadding = 50;
            smoothScrollPanel1.Controls.Add(smoothScrollPanel2);
            smoothScrollPanel1.EndBackColor = Color.FromArgb(240, 240, 240);
            smoothScrollPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            smoothScrollPanel1.Location = new Point(0, 0);
            smoothScrollPanel1.Name = "smoothScrollPanel1";
            smoothScrollPanel1.Padding = new Padding(1);
            smoothScrollPanel1.ScrollBarColor = Color.FromArgb(120, 0, 0, 0);
            smoothScrollPanel1.ScrollBarWidth = 6;
            smoothScrollPanel1.ShowCustomScrollbar = true;
            smoothScrollPanel1.Size = new Size(1700, 990);
            smoothScrollPanel1.StartBackColor = Color.White;
            smoothScrollPanel1.TabIndex = 18;
            smoothScrollPanel1.UseGradient = false;
            // 
            // smoothScrollPanel2
            // 
            smoothScrollPanel2.AutoScroll = true;
            smoothScrollPanel2.AutoScrollMinSize = new Size(0, 552);
            smoothScrollPanel2.BackColor = Color.White;
            smoothScrollPanel2.BorderColor = Color.FromArgb(200, 200, 200);
            smoothScrollPanel2.BorderRadius = 0;
            smoothScrollPanel2.BorderWidth = 2;
            smoothScrollPanel2.BottomPadding = 0;
            smoothScrollPanel2.Controls.Add(panel3);
            smoothScrollPanel2.Controls.Add(label8);
            smoothScrollPanel2.Controls.Add(label5);
            smoothScrollPanel2.Controls.Add(label1);
            smoothScrollPanel2.Controls.Add(panel1);
            smoothScrollPanel2.EndBackColor = Color.FromArgb(240, 240, 240);
            smoothScrollPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            smoothScrollPanel2.Location = new Point(34, 24);
            smoothScrollPanel2.Name = "smoothScrollPanel2";
            smoothScrollPanel2.Padding = new Padding(1);
            smoothScrollPanel2.ScrollBarColor = Color.FromArgb(120, 0, 0, 0);
            smoothScrollPanel2.ScrollBarWidth = 6;
            smoothScrollPanel2.ShowCustomScrollbar = true;
            smoothScrollPanel2.Size = new Size(1631, 659);
            smoothScrollPanel2.StartBackColor = Color.White;
            smoothScrollPanel2.TabIndex = 1;
            smoothScrollPanel2.UseGradient = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(stable3dViewer2);
            panel3.Location = new Point(610, 191);
            panel3.Name = "panel3";
            panel3.Size = new Size(589, 361);
            panel3.TabIndex = 72;
            // 
            // stable3dViewer2
            // 
            stable3dViewer2.AutoFitOnLoad = true;
            stable3dViewer2.AutoRotate = false;
            stable3dViewer2.BackColor = Color.Black;
            stable3dViewer2.BackgroundColor = Color.FromArgb(30, 30, 35);
            stable3dViewer2.BackgroundImagePath = "";
            stable3dViewer2.BackgroundMode = LYHControls.BackgroundMode.Color;
            stable3dViewer2.Dock = DockStyle.Fill;
            stable3dViewer2.LightX = -20F;
            stable3dViewer2.LightY = 20F;
            stable3dViewer2.LightZ = 20F;
            stable3dViewer2.Location = new Point(0, 0);
            stable3dViewer2.Margin = new Padding(4, 4, 4, 4);
            stable3dViewer2.ModelDefaultColor = Color.DeepSkyBlue;
            stable3dViewer2.ModelPath = "D:\\wpf_code\\Save_HMI_Controls\\Save_HMI_Controls\\3D\\che.fbx";
            stable3dViewer2.Name = "stable3dViewer2";
            stable3dViewer2.RotateSpeed = 1F;
            stable3dViewer2.ShowAxes = false;
            stable3dViewer2.Size = new Size(589, 361);
            stable3dViewer2.TabIndex = 0;
            stable3dViewer2.UseModelMaterial = true;
            stable3dViewer2.VSync = true;
            stable3dViewer2.ZoomDistance = -10F;
            stable3dViewer2.ZoomSpeed = 0.05F;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("HarmonyOS Sans SC", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label8.ForeColor = Color.FromArgb(98, 116, 142);
            label8.Location = new Point(1358, 147);
            label8.Name = "label8";
            label8.Size = new Size(13, 19);
            label8.TabIndex = 70;
            label8.Text = " ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("HarmonyOS Sans SC", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label5.ForeColor = Color.FromArgb(98, 116, 142);
            label5.Location = new Point(39, 147);
            label5.Name = "label5";
            label5.Size = new Size(121, 19);
            label5.TabIndex = 59;
            label5.Text = "蓝色渐变（默认）";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("HarmonyOS Sans SC", 20F, FontStyle.Bold, GraphicsUnit.Pixel, 134);
            label1.ForeColor = Color.FromArgb(30, 41, 57);
            label1.Location = new Point(35, 100);
            label1.Name = "label1";
            label1.Size = new Size(299, 26);
            label1.TabIndex = 5;
            label1.Text = "背景颜色（BackgroundColor）";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(243, 244, 246);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1628, 79);
            panel1.TabIndex = 0;
            // 
            // label14
            // 
            label14.Font = new Font("HarmonyOS Sans SC", 18F, FontStyle.Regular, GraphicsUnit.Pixel, 134);
            label14.ForeColor = Color.FromArgb(74, 85, 101);
            label14.Location = new Point(38, 43);
            label14.Name = "label14";
            label14.Size = new Size(653, 25);
            label14.TabIndex = 7;
            label14.Text = "基于 OpenGL 的 3D 模型查看器，支持鼠标拖动旋转、滚轮缩放、自动旋转、坐标轴、光源调节、背景色/图";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("HarmonyOS Sans SC", 26F, FontStyle.Bold, GraphicsUnit.Pixel, 134);
            label11.ForeColor = Color.FromArgb(30, 41, 57);
            label11.Location = new Point(37, 8);
            label11.Name = "label11";
            label11.Size = new Size(349, 34);
            label11.TabIndex = 6;
            label11.Text = "Stable3DViewer 三维查看器";
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(209, 213, 220);
            label2.Location = new Point(0, 78);
            label2.Name = "label2";
            label2.Size = new Size(1628, 2);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // Stable3DViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(smoothScrollPanel1);
            Name = "Stable3DViewer";
            Size = new Size(1700, 990);
            smoothScrollPanel1.ResumeLayout(false);
            smoothScrollPanel2.ResumeLayout(false);
            smoothScrollPanel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SmoothScrollPanel smoothScrollPanel1;
        private SmoothScrollPanel smoothScrollPanel2;
        private Label label8;
        private Label label5;
        private Label label1;
        private Panel panel1;
        private Label label14;
        private Label label11;
        private Label label2;
        private Panel panel3;
        private LYHControls.Stable3DViewer stable3dViewer2;
    }
}
