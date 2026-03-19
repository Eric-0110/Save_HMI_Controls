namespace Save_HMI_Controls
{
    partial class SmoothScrollPanel
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
            if (disposing)
            {
                // 1. 停止并释放动画计时器 (非常重要，防止后台线程继续触发 Tick)
                if (_fadeTimer != null)
                {
                    _fadeTimer.Stop();
                    _fadeTimer.Dispose();
                    _fadeTimer = null;
                }

                // 2. 释放自定义的 Region (Region 是 GDI 对象，必须手动释放)
                if (this.Region != null)
                {
                    this.Region.Dispose();
                }

                // 3. 如果有其他需要释放的组件（如组件容器）
                // if (components != null) components.Dispose();
            }

            // 4. 调用基类的 Dispose
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
    }
}
