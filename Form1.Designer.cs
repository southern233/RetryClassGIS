namespace RetryClassGIS
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mPnlDrawArea = new System.Windows.Forms.Panel();
            this.mPnlControls = new System.Windows.Forms.Panel();
            this.mBtnAddPoint = new System.Windows.Forms.Button();
            this.mLblX = new System.Windows.Forms.Label();
            this.mLblY = new System.Windows.Forms.Label();
            this.mTxbX = new System.Windows.Forms.TextBox();
            this.mLblAttribute = new System.Windows.Forms.Label();
            this.mTxbAttribute = new System.Windows.Forms.TextBox();
            this.mTxbY = new System.Windows.Forms.TextBox();
            this.mPnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // mPnlDrawArea
            // 
            this.mPnlDrawArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mPnlDrawArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPnlDrawArea.Location = new System.Drawing.Point(200, 0);
            this.mPnlDrawArea.Name = "mPnlDrawArea";
            this.mPnlDrawArea.Size = new System.Drawing.Size(600, 450);
            this.mPnlDrawArea.TabIndex = 0;
            this.mPnlDrawArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mPnlDrawArea_MouseClick);
            // 
            // mPnlControls
            // 
            this.mPnlControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mPnlControls.Controls.Add(this.mTxbY);
            this.mPnlControls.Controls.Add(this.mTxbAttribute);
            this.mPnlControls.Controls.Add(this.mLblAttribute);
            this.mPnlControls.Controls.Add(this.mTxbX);
            this.mPnlControls.Controls.Add(this.mLblY);
            this.mPnlControls.Controls.Add(this.mLblX);
            this.mPnlControls.Controls.Add(this.mBtnAddPoint);
            this.mPnlControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.mPnlControls.Location = new System.Drawing.Point(0, 0);
            this.mPnlControls.Name = "mPnlControls";
            this.mPnlControls.Size = new System.Drawing.Size(200, 450);
            this.mPnlControls.TabIndex = 1;
            // 
            // mBtnAddPoint
            // 
            this.mBtnAddPoint.Location = new System.Drawing.Point(51, 116);
            this.mBtnAddPoint.Name = "mBtnAddPoint";
            this.mBtnAddPoint.Size = new System.Drawing.Size(85, 33);
            this.mBtnAddPoint.TabIndex = 0;
            this.mBtnAddPoint.Text = "添加点";
            this.mBtnAddPoint.UseVisualStyleBackColor = true;
            this.mBtnAddPoint.Click += new System.EventHandler(this.mBtnAddPoint_Click);
            // 
            // mLblX
            // 
            this.mLblX.AutoSize = true;
            this.mLblX.Location = new System.Drawing.Point(22, 22);
            this.mLblX.Name = "mLblX";
            this.mLblX.Size = new System.Drawing.Size(23, 15);
            this.mLblX.TabIndex = 1;
            this.mLblX.Text = "X:";
            // 
            // mLblY
            // 
            this.mLblY.AutoSize = true;
            this.mLblY.Location = new System.Drawing.Point(22, 53);
            this.mLblY.Name = "mLblY";
            this.mLblY.Size = new System.Drawing.Size(23, 15);
            this.mLblY.TabIndex = 2;
            this.mLblY.Text = "Y:";
            // 
            // mTxbX
            // 
            this.mTxbX.Location = new System.Drawing.Point(70, 12);
            this.mTxbX.Name = "mTxbX";
            this.mTxbX.Size = new System.Drawing.Size(100, 25);
            this.mTxbX.TabIndex = 3;
            // 
            // mLblAttribute
            // 
            this.mLblAttribute.AutoSize = true;
            this.mLblAttribute.Location = new System.Drawing.Point(19, 84);
            this.mLblAttribute.Name = "mLblAttribute";
            this.mLblAttribute.Size = new System.Drawing.Size(45, 15);
            this.mLblAttribute.TabIndex = 4;
            this.mLblAttribute.Text = "属性:";
            // 
            // mTxbAttribute
            // 
            this.mTxbAttribute.Location = new System.Drawing.Point(70, 74);
            this.mTxbAttribute.Name = "mTxbAttribute";
            this.mTxbAttribute.Size = new System.Drawing.Size(100, 25);
            this.mTxbAttribute.TabIndex = 5;
            // 
            // mTxbY
            // 
            this.mTxbY.Location = new System.Drawing.Point(70, 43);
            this.mTxbY.Name = "mTxbY";
            this.mTxbY.Size = new System.Drawing.Size(100, 25);
            this.mTxbY.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mPnlDrawArea);
            this.Controls.Add(this.mPnlControls);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mPnlControls.ResumeLayout(false);
            this.mPnlControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mPnlDrawArea;
        private System.Windows.Forms.Panel mPnlControls;
        private System.Windows.Forms.Button mBtnAddPoint;
        private System.Windows.Forms.Label mLblAttribute;
        private System.Windows.Forms.TextBox mTxbX;
        private System.Windows.Forms.Label mLblY;
        private System.Windows.Forms.Label mLblX;
        private System.Windows.Forms.TextBox mTxbY;
        private System.Windows.Forms.TextBox mTxbAttribute;
    }
}

