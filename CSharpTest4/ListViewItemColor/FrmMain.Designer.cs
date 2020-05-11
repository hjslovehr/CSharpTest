namespace ListViewItemColor
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
            this.lvMsg = new ListViewItemColor.ListViewExtend();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.DateTimeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MessageCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MessageTypeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvMsg
            // 
            this.lvMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMsg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DateTimeCol,
            this.MessageTypeCol,
            this.MessageCol});
            this.lvMsg.HideSelection = false;
            this.lvMsg.Location = new System.Drawing.Point(13, 40);
            this.lvMsg.Name = "lvMsg";
            this.lvMsg.Size = new System.Drawing.Size(599, 389);
            this.lvMsg.TabIndex = 0;
            this.lvMsg.UseCompatibleStateImageBehavior = false;
            this.lvMsg.View = System.Windows.Forms.View.Details;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(13, 12);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 21);
            this.txtCount.TabIndex = 1;
            this.txtCount.Text = "1000";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(120, 11);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // DateTimeCol
            // 
            this.DateTimeCol.Text = "时间";
            this.DateTimeCol.Width = 160;
            // 
            // MessageCol
            // 
            this.MessageCol.Text = "信息";
            this.MessageCol.Width = 280;
            // 
            // MessageTypeCol
            // 
            this.MessageTypeCol.Text = "信息类型";
            this.MessageTypeCol.Width = 100;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.lvMsg);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewExtend lvMsg;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ColumnHeader DateTimeCol;
        private System.Windows.Forms.ColumnHeader MessageTypeCol;
        private System.Windows.Forms.ColumnHeader MessageCol;
    }
}

