using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Save_HMI_Controls
{
    [ToolboxItem(true)]
    [Description("LYH 终极滚动面板：支持底部留白、滚轮联动、抗锯齿圆角、自动隐藏滚动条")]
    public partial class SmoothScrollPanel : Panel
    {
        #region --- 字段与属性 ---
        private Point _mouseDownPos;
        private int _startScrollVal;
        private bool _isMouseDown = false;

        private int _borderRadius = 10;
        private int _borderWidth = 1;
        private Color _borderColor = Color.FromArgb(200, 200, 200);
        private Color _scrollBarColor = Color.FromArgb(120, 0, 0, 0);
        private int _scrollBarWidth = 6;
        private bool _showCustomScrollbar = true;

        private int _bottomPadding = 50; // 默认留白 50 像素

        private System.Windows.Forms.Timer _fadeTimer;
        private float _scrollBarOpacity = 0f;
        private bool _isMouseIn = false;

        [Category("LYH 外观")] public int BorderRadius { get => _borderRadius; set { _borderRadius = value; Invalidate(); } }
        [Category("LYH 外观")] public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }
        [Category("LYH 外观")] public int BorderWidth { get => _borderWidth; set { _borderWidth = value; Invalidate(); } }
        [Category("LYH 外观")] public Color ScrollBarColor { get => _scrollBarColor; set { _scrollBarColor = value; Invalidate(); } }
        [Category("LYH 外观")] public int ScrollBarWidth { get => _scrollBarWidth; set { _scrollBarWidth = value; Invalidate(); } }
        [Category("LYH 外观")] public bool ShowCustomScrollbar { get => _showCustomScrollbar; set { _showCustomScrollbar = value; Invalidate(); } }
        private Color _startBackColor = Color.White;
        private Color _endBackColor = Color.FromArgb(240, 240, 240);
        private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;
        private bool _useGradient = false;

        [Category("LYH 外观")]
        [Description("是否启用背景渐变")]
        public bool UseGradient { get => _useGradient; set { _useGradient = value; Invalidate(); } }

        [Category("LYH 外观")]
        [Description("渐变起始颜色")]
        public Color StartBackColor { get => _startBackColor; set { _startBackColor = value; Invalidate(); } }

        [Category("LYH 外观")]
        [Description("渐变结束颜色")]
        public Color EndBackColor { get => _endBackColor; set { _endBackColor = value; Invalidate(); } }

        [Category("LYH 外观")]
        [Description("渐变方向")]
        public LinearGradientMode GradientMode { get => _gradientMode; set { _gradientMode = value; Invalidate(); } }



        [Category("LYH 布局")]
        [Description("滚动到底部时额外的留白高度")]
        public int BottomPadding
        {
            get => _bottomPadding;
            set
            {
                _bottomPadding = value;
                this.PerformLayout(); // 修改留白后强制重新布局
                Invalidate();
            }
        }

        public override Image BackgroundImage { get => base.BackgroundImage; set { base.BackgroundImage = value; Invalidate(); } }

        // 依然保留这个重写，作为基础布局参考
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height + _bottomPadding);
            }
        }
        #endregion

        public SmoothScrollPanel()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.SupportsTransparentBackColor, true);

            this.AutoScroll = true;
            this.BackColor = Color.White;
            this.Padding = new Padding(1);

            _fadeTimer = new System.Windows.Forms.Timer { Interval = 20 };
            _fadeTimer.Tick += (s, e) => {
                float target = (_isMouseIn || _isMouseDown) ? 1.0f : 0.0f;
                if (Math.Abs(_scrollBarOpacity - target) > 0.05f)
                {
                    _scrollBarOpacity += (target - _scrollBarOpacity) * 0.2f;
                    Invalidate();
                }
                else if (_scrollBarOpacity != target)
                {
                    _scrollBarOpacity = target;
                    if (_scrollBarOpacity == 0) _fadeTimer.Stop();
                    Invalidate();
                }
            };
        }

        #region --- 强制留白逻辑 ---
        /// <summary>
        /// 关键：在布局时，手动告诉 AutoScroll 滚动范围需要多大
        /// </summary>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (this.AutoScroll && this.Controls.Count > 0)
            {
                int maxY = 0;
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl.Visible)
                    {
                        maxY = Math.Max(maxY, ctrl.Bottom);
                    }
                }
                // 手动设置 AutoScrollMinSize，这是决定滚动条长度的最核心参数
                this.AutoScrollMinSize = new Size(0, maxY + _bottomPadding);
            }
        }
        #endregion

        #region --- 核心交互逻辑 (无删减) ---
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (!_fadeTimer.Enabled) _fadeTimer.Start();
            if (this.AutoScroll)
            {
                // 解决 Windows 默认滚动和自定义逻辑冲突：直接让基类先跑，或者自己控制
                int scrollStep = e.Delta;
                int oldVal = this.VerticalScroll.Value;
                int newVal = oldVal - (scrollStep / 1); // 调整灵敏度
                newVal = Math.Max(this.VerticalScroll.Minimum, Math.Min(this.VerticalScroll.Maximum, newVal));
                this.VerticalScroll.Value = newVal;

                this.Invalidate();
            }
            base.OnMouseWheel(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = true;
                _mouseDownPos = e.Location;
                _startScrollVal = this.VerticalScroll.Value;
                this.Cursor = Cursors.Hand;
                _fadeTimer.Start();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                int deltaY = _mouseDownPos.Y - e.Y;
                int targetVal = _startScrollVal + deltaY;
                targetVal = Math.Max(this.VerticalScroll.Minimum, Math.Min(this.VerticalScroll.Maximum, targetVal));
                this.VerticalScroll.Value = targetVal;
                Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isMouseDown = false;
            this.Cursor = Cursors.Default;
            base.OnMouseUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isMouseIn = true;
            _fadeTimer.Start();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
            {
                _isMouseIn = false;
                _fadeTimer.Start();
            }
            base.OnMouseLeave(e);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            if (!_fadeTimer.Enabled) _fadeTimer.Start();
            Invalidate();
        }
        #endregion

        #region --- 绘图引擎 (无删减) ---
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (GraphicsPath path = GetRoundedRectPath(rect, _borderRadius))
            {
                if (this.Parent != null)
                {
                    using (SolidBrush parentBrush = new SolidBrush(this.Parent.BackColor))
                        g.FillRectangle(parentBrush, this.ClientRectangle);
                }

                g.SetClip(path);

                if (this.BackgroundImage != null)
                {
                    if (this.BackgroundImageLayout == ImageLayout.Stretch)
                        g.DrawImage(this.BackgroundImage, rect);
                    else
                        using (TextureBrush tb = new TextureBrush(this.BackgroundImage))
                            g.FillPath(tb, path);
                }
                else if (_useGradient)
                {
                    // 绘制渐变背景
                    using (LinearGradientBrush lgb = new LinearGradientBrush(rect, _startBackColor, _endBackColor, _gradientMode))
                    {
                        g.FillPath(lgb, path);
                    }
                }
                else
                {
                    // 绘制纯色背景
                    using (SolidBrush sb = new SolidBrush(this.BackColor))
                        g.FillPath(sb, path);
                }

                if (_showCustomScrollbar && this.VerticalScroll.Visible && _scrollBarOpacity > 0)
                {
                    DrawCustomVerticalScrollbar(g);
                }

                g.ResetClip();
                if (_borderWidth > 0)
                {
                    float offset = _borderWidth / 2f;
                    RectangleF borderRect = new RectangleF(offset, offset, this.Width - _borderWidth - 1, this.Height - _borderWidth - 1);
                    using (GraphicsPath borderPath = GetRoundedRectPath(borderRect, _borderRadius))
                    using (Pen pen = new Pen(_borderColor, _borderWidth))
                    {
                        g.DrawPath(pen, borderPath);
                    }
                }
            }
        }

        private void DrawCustomVerticalScrollbar(Graphics g)
        {
            float viewHeight = this.Height;
            // 关键：使用 AutoScrollMinSize.Height 作为内容高度，确保留白被计算进去
            float totalHeight = this.AutoScrollMinSize.Height;
            if (totalHeight <= viewHeight) return;

            float thumbHeight = Math.Max(30, (viewHeight / totalHeight) * viewHeight);
            float scrollRatio = (float)this.VerticalScroll.Value / (totalHeight - viewHeight);
            float thumbY = scrollRatio * (viewHeight - thumbHeight);

            int alpha = (int)(_scrollBarColor.A * _scrollBarOpacity);
            Color animatedColor = Color.FromArgb(alpha, _scrollBarColor.R, _scrollBarColor.G, _scrollBarColor.B);

            RectangleF thumbRect = new RectangleF(
                this.Width - _scrollBarWidth - 5,
                thumbY + 5,
                _scrollBarWidth,
                thumbHeight - 10
            );

            using (SolidBrush sb = new SolidBrush(animatedColor))
            {
                SmoothScrollGraphicsExtensions.FillSmoothRoundedRect(g, sb, thumbRect, _scrollBarWidth / 2f);
            }
        }
        #endregion

        private GraphicsPath GetRoundedRectPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Max(1, radius * 2);
            if (radius <= 0) { path.AddRectangle(rect); return path; }

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }

    internal static class SmoothScrollGraphicsExtensions
    {
        public static void FillSmoothRoundedRect(Graphics g, Brush brush, RectangleF rect, float radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                float d = Math.Max(1, radius * 2);
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
        }
    }
}