namespace ByteAndImage
{
    partial class FrmMain
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
            this.btnImageToBytesTest = new System.Windows.Forms.Button();
            this.btnBytesToImageTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImageToBytesTest
            // 
            this.btnImageToBytesTest.Location = new System.Drawing.Point(92, 89);
            this.btnImageToBytesTest.Name = "btnImageToBytesTest";
            this.btnImageToBytesTest.Size = new System.Drawing.Size(200, 30);
            this.btnImageToBytesTest.TabIndex = 0;
            this.btnImageToBytesTest.Text = "Image To Byte Array Test";
            this.btnImageToBytesTest.UseVisualStyleBackColor = true;
            this.btnImageToBytesTest.Click += new System.EventHandler(this.btnImageToBytesTest_Click);
            // 
            // btnBytesToImageTest
            // 
            this.btnBytesToImageTest.Location = new System.Drawing.Point(92, 142);
            this.btnBytesToImageTest.Name = "btnBytesToImageTest";
            this.btnBytesToImageTest.Size = new System.Drawing.Size(200, 30);
            this.btnBytesToImageTest.TabIndex = 1;
            this.btnBytesToImageTest.Text = "Byte Array To  Image Test";
            this.btnBytesToImageTest.UseVisualStyleBackColor = true;
            this.btnBytesToImageTest.Click += new System.EventHandler(this.btnBytesToImageTest_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btnBytesToImageTest);
            this.Controls.Add(this.btnImageToBytesTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Byte Array And Image";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImageToBytesTest;
        private System.Windows.Forms.Button btnBytesToImageTest;
    }
}

