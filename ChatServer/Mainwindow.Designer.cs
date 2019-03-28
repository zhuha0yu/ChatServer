namespace ChatServer
{
    partial class Mainwindow
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务器管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开启关闭监听ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.端口设定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintextbox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.服务器管理ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 服务器管理ToolStripMenuItem
            // 
            this.服务器管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启关闭监听ToolStripMenuItem,
            this.端口设定ToolStripMenuItem});
            this.服务器管理ToolStripMenuItem.Name = "服务器管理ToolStripMenuItem";
            this.服务器管理ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.服务器管理ToolStripMenuItem.Text = "服务器管理";
            // 
            // 开启关闭监听ToolStripMenuItem
            // 
            this.开启关闭监听ToolStripMenuItem.Name = "开启关闭监听ToolStripMenuItem";
            this.开启关闭监听ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.开启关闭监听ToolStripMenuItem.Text = "开启/关闭监听";
            this.开启关闭监听ToolStripMenuItem.Click += new System.EventHandler(this.开启关闭监听ToolStripMenuItem_Click);
            // 
            // 端口设定ToolStripMenuItem
            // 
            this.端口设定ToolStripMenuItem.Name = "端口设定ToolStripMenuItem";
            this.端口设定ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.端口设定ToolStripMenuItem.Text = "端口设定";
            this.端口设定ToolStripMenuItem.Click += new System.EventHandler(this.端口设定ToolStripMenuItem_Click);
            // 
            // maintextbox
            // 
            this.maintextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maintextbox.Location = new System.Drawing.Point(12, 28);
            this.maintextbox.Multiline = true;
            this.maintextbox.Name = "maintextbox";
            this.maintextbox.ReadOnly = true;
            this.maintextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.maintextbox.Size = new System.Drawing.Size(318, 410);
            this.maintextbox.TabIndex = 1;
            // 
            // Mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.maintextbox);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Mainwindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 服务器管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开启关闭监听ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 端口设定ToolStripMenuItem;
        private System.Windows.Forms.TextBox maintextbox;
    }
}

