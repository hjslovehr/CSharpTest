namespace MD5Creator
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
            this.txtSrcString = new System.Windows.Forms.TextBox();
            this.txtMD5String = new System.Windows.Forms.TextBox();
            this.btnCreate_32_Bit = new System.Windows.Forms.Button();
            this.btnCreate_16_Bit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSrcString
            // 
            this.txtSrcString.Location = new System.Drawing.Point(12, 12);
            this.txtSrcString.MaxLength = 0;
            this.txtSrcString.Multiline = true;
            this.txtSrcString.Name = "txtSrcString";
            this.txtSrcString.Size = new System.Drawing.Size(360, 130);
            this.txtSrcString.TabIndex = 0;
            // 
            // txtMD5String
            // 
            this.txtMD5String.Location = new System.Drawing.Point(12, 219);
            this.txtMD5String.MaxLength = 0;
            this.txtMD5String.Multiline = true;
            this.txtMD5String.Name = "txtMD5String";
            this.txtMD5String.Size = new System.Drawing.Size(360, 130);
            this.txtMD5String.TabIndex = 3;
            // 
            // btnCreate_32_Bit
            // 
            this.btnCreate_32_Bit.Location = new System.Drawing.Point(222, 165);
            this.btnCreate_32_Bit.Name = "btnCreate_32_Bit";
            this.btnCreate_32_Bit.Size = new System.Drawing.Size(150, 30);
            this.btnCreate_32_Bit.TabIndex = 1;
            this.btnCreate_32_Bit.Text = "生成32位MD5字符串";
            this.btnCreate_32_Bit.UseVisualStyleBackColor = true;
            this.btnCreate_32_Bit.Click += new System.EventHandler(this.btnCreate_32_Bit_Click);
            // 
            // btnCreate_16_Bit
            // 
            this.btnCreate_16_Bit.Location = new System.Drawing.Point(12, 165);
            this.btnCreate_16_Bit.Name = "btnCreate_16_Bit";
            this.btnCreate_16_Bit.Size = new System.Drawing.Size(150, 30);
            this.btnCreate_16_Bit.TabIndex = 2;
            this.btnCreate_16_Bit.Text = "生成16位MD5字符串";
            this.btnCreate_16_Bit.UseVisualStyleBackColor = true;
            this.btnCreate_16_Bit.Click += new System.EventHandler(this.btnCreate_16_Bit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnCreate_16_Bit);
            this.Controls.Add(this.btnCreate_32_Bit);
            this.Controls.Add(this.txtMD5String);
            this.Controls.Add(this.txtSrcString);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MD5 字符串生成工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSrcString;
        private System.Windows.Forms.TextBox txtMD5String;
        private System.Windows.Forms.Button btnCreate_32_Bit;
        private System.Windows.Forms.Button btnCreate_16_Bit;
    }
}

