namespace Save_HMI_Controls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.DoubleBuffered = true;

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // 开启 WS_EX_COMPOSITED 样式，让 Windows 把整个窗口当作一个层来绘制
                // 这能解决几乎所有 WinForms 控件在动画时的闪烁和残留问题
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}
