namespace WindowsFormsApplication4
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnGetPara = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCloseCamera = new System.Windows.Forms.Button();
            this.btnLoop = new System.Windows.Forms.Button();
            this.btnExitLoop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hSmartWindowControl1 = new HalconDotNet.HWindowControl();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(541, 388);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(96, 54);
            this.btnReg.TabIndex = 1;
            this.btnReg.Text = "注册回调";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnGetPara
            // 
            this.btnGetPara.Location = new System.Drawing.Point(783, 388);
            this.btnGetPara.Name = "btnGetPara";
            this.btnGetPara.Size = new System.Drawing.Size(96, 54);
            this.btnGetPara.TabIndex = 2;
            this.btnGetPara.Text = "获得参数";
            this.btnGetPara.UseVisualStyleBackColor = true;
            this.btnGetPara.Click += new System.EventHandler(this.btnGetPara_Click);
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(538, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(356, 340);
            this.listBox1.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // btnCloseCamera
            // 
            this.btnCloseCamera.Location = new System.Drawing.Point(798, 586);
            this.btnCloseCamera.Name = "btnCloseCamera";
            this.btnCloseCamera.Size = new System.Drawing.Size(96, 54);
            this.btnCloseCamera.TabIndex = 4;
            this.btnCloseCamera.Text = "关闭相机";
            this.btnCloseCamera.UseVisualStyleBackColor = true;
            this.btnCloseCamera.Click += new System.EventHandler(this.btnCloseCamera_Click);
            // 
            // btnLoop
            // 
            this.btnLoop.Location = new System.Drawing.Point(541, 513);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(96, 54);
            this.btnLoop.TabIndex = 5;
            this.btnLoop.Text = "循环开始";
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.btnLoop_Click);
            // 
            // btnExitLoop
            // 
            this.btnExitLoop.Location = new System.Drawing.Point(798, 513);
            this.btnExitLoop.Name = "btnExitLoop";
            this.btnExitLoop.Size = new System.Drawing.Size(96, 54);
            this.btnExitLoop.TabIndex = 6;
            this.btnExitLoop.Text = "循环结束";
            this.btnExitLoop.UseVisualStyleBackColor = true;
            this.btnExitLoop.Click += new System.EventHandler(this.btnExitLoop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "相机支持参数列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(539, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "下面是循环方式取外触发的图像";
            // 
            // hSmartWindowControl1
            // 
            this.hSmartWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hSmartWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hSmartWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 4096, 2168);
            this.hSmartWindowControl1.Location = new System.Drawing.Point(8, 150);
            this.hSmartWindowControl1.Name = "hSmartWindowControl1";
            this.hSmartWindowControl1.Size = new System.Drawing.Size(524, 366);
            this.hSmartWindowControl1.TabIndex = 72;
            this.hSmartWindowControl1.WindowSize = new System.Drawing.Size(524, 366);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 671);
            this.Controls.Add(this.hSmartWindowControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExitLoop);
            this.Controls.Add(this.btnLoop);
            this.Controls.Add(this.btnCloseCamera);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnGetPara);
            this.Controls.Add(this.btnReg);
            this.Name = "Form1";
            this.Text = "海康外触发测试";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnGetPara;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnCloseCamera;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Button btnExitLoop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private HalconDotNet.HWindowControl hSmartWindowControl1;
    }
}

