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
            this.mBtnRefreshMap = new System.Windows.Forms.Button();
            this.mLblMinY = new System.Windows.Forms.Label();
            this.mLblMinX = new System.Windows.Forms.Label();
            this.mLblMaxY = new System.Windows.Forms.Label();
            this.mLblMaxX = new System.Windows.Forms.Label();
            this.mTxbMaxX = new System.Windows.Forms.TextBox();
            this.mTxbMinY = new System.Windows.Forms.TextBox();
            this.mTxbMinX = new System.Windows.Forms.TextBox();
            this.mTxbMaxY = new System.Windows.Forms.TextBox();
            this.mTxbY = new System.Windows.Forms.TextBox();
            this.mTxbAttribute = new System.Windows.Forms.TextBox();
            this.mLblAttribute = new System.Windows.Forms.Label();
            this.mTxbX = new System.Windows.Forms.TextBox();
            this.mLblY = new System.Windows.Forms.Label();
            this.mLblX = new System.Windows.Forms.Label();
            this.mBtnAddPoint = new System.Windows.Forms.Button();
            this.mBtnZoomIn = new System.Windows.Forms.Button();
            this.mBtnZoomOut = new System.Windows.Forms.Button();
            this.mBtnMoveRight = new System.Windows.Forms.Button();
            this.mBtnMoveLeft = new System.Windows.Forms.Button();
            this.mBtnMoveDown = new System.Windows.Forms.Button();
            this.mBtnMoveUp = new System.Windows.Forms.Button();
            this.mPnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // mPnlDrawArea
            // 
            this.mPnlDrawArea.BackColor = System.Drawing.Color.White;
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
            this.mPnlControls.Controls.Add(this.mBtnMoveDown);
            this.mPnlControls.Controls.Add(this.mBtnMoveUp);
            this.mPnlControls.Controls.Add(this.mBtnMoveRight);
            this.mPnlControls.Controls.Add(this.mBtnMoveLeft);
            this.mPnlControls.Controls.Add(this.mBtnZoomOut);
            this.mPnlControls.Controls.Add(this.mBtnZoomIn);
            this.mPnlControls.Controls.Add(this.mBtnRefreshMap);
            this.mPnlControls.Controls.Add(this.mLblMinY);
            this.mPnlControls.Controls.Add(this.mLblMinX);
            this.mPnlControls.Controls.Add(this.mLblMaxY);
            this.mPnlControls.Controls.Add(this.mLblMaxX);
            this.mPnlControls.Controls.Add(this.mTxbMaxX);
            this.mPnlControls.Controls.Add(this.mTxbMinY);
            this.mPnlControls.Controls.Add(this.mTxbMinX);
            this.mPnlControls.Controls.Add(this.mTxbMaxY);
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
            // mBtnRefreshMap
            // 
            this.mBtnRefreshMap.Location = new System.Drawing.Point(22, 262);
            this.mBtnRefreshMap.Name = "mBtnRefreshMap";
            this.mBtnRefreshMap.Size = new System.Drawing.Size(148, 27);
            this.mBtnRefreshMap.TabIndex = 15;
            this.mBtnRefreshMap.Text = "更新地图";
            this.mBtnRefreshMap.UseVisualStyleBackColor = true;
            this.mBtnRefreshMap.Click += new System.EventHandler(this.mBtnRefreshMap_Click);
            // 
            // mLblMinY
            // 
            this.mLblMinY.AutoSize = true;
            this.mLblMinY.Location = new System.Drawing.Point(19, 241);
            this.mLblMinY.Name = "mLblMinY";
            this.mLblMinY.Size = new System.Drawing.Size(47, 15);
            this.mLblMinY.TabIndex = 14;
            this.mLblMinY.Text = "MinY:";
            // 
            // mLblMinX
            // 
            this.mLblMinX.AutoSize = true;
            this.mLblMinX.Location = new System.Drawing.Point(19, 210);
            this.mLblMinX.Name = "mLblMinX";
            this.mLblMinX.Size = new System.Drawing.Size(47, 15);
            this.mLblMinX.TabIndex = 13;
            this.mLblMinX.Text = "MinX:";
            // 
            // mLblMaxY
            // 
            this.mLblMaxY.AutoSize = true;
            this.mLblMaxY.Location = new System.Drawing.Point(19, 179);
            this.mLblMaxY.Name = "mLblMaxY";
            this.mLblMaxY.Size = new System.Drawing.Size(47, 15);
            this.mLblMaxY.TabIndex = 12;
            this.mLblMaxY.Text = "MaxY:";
            // 
            // mLblMaxX
            // 
            this.mLblMaxX.AutoSize = true;
            this.mLblMaxX.Location = new System.Drawing.Point(19, 148);
            this.mLblMaxX.Name = "mLblMaxX";
            this.mLblMaxX.Size = new System.Drawing.Size(47, 15);
            this.mLblMaxX.TabIndex = 11;
            this.mLblMaxX.Text = "MaxX:";
            // 
            // mTxbMaxX
            // 
            this.mTxbMaxX.Location = new System.Drawing.Point(70, 138);
            this.mTxbMaxX.Name = "mTxbMaxX";
            this.mTxbMaxX.Size = new System.Drawing.Size(100, 25);
            this.mTxbMaxX.TabIndex = 10;
            // 
            // mTxbMinY
            // 
            this.mTxbMinY.Location = new System.Drawing.Point(70, 231);
            this.mTxbMinY.Name = "mTxbMinY";
            this.mTxbMinY.Size = new System.Drawing.Size(100, 25);
            this.mTxbMinY.TabIndex = 9;
            // 
            // mTxbMinX
            // 
            this.mTxbMinX.Location = new System.Drawing.Point(70, 200);
            this.mTxbMinX.Name = "mTxbMinX";
            this.mTxbMinX.Size = new System.Drawing.Size(100, 25);
            this.mTxbMinX.TabIndex = 8;
            // 
            // mTxbMaxY
            // 
            this.mTxbMaxY.Location = new System.Drawing.Point(70, 169);
            this.mTxbMaxY.Name = "mTxbMaxY";
            this.mTxbMaxY.Size = new System.Drawing.Size(100, 25);
            this.mTxbMaxY.TabIndex = 7;
            // 
            // mTxbY
            // 
            this.mTxbY.Location = new System.Drawing.Point(70, 43);
            this.mTxbY.Name = "mTxbY";
            this.mTxbY.Size = new System.Drawing.Size(100, 25);
            this.mTxbY.TabIndex = 6;
            // 
            // mTxbAttribute
            // 
            this.mTxbAttribute.Location = new System.Drawing.Point(70, 74);
            this.mTxbAttribute.Name = "mTxbAttribute";
            this.mTxbAttribute.Size = new System.Drawing.Size(100, 25);
            this.mTxbAttribute.TabIndex = 5;
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
            // mTxbX
            // 
            this.mTxbX.Location = new System.Drawing.Point(70, 12);
            this.mTxbX.Name = "mTxbX";
            this.mTxbX.Size = new System.Drawing.Size(100, 25);
            this.mTxbX.TabIndex = 3;
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
            // mLblX
            // 
            this.mLblX.AutoSize = true;
            this.mLblX.Location = new System.Drawing.Point(22, 22);
            this.mLblX.Name = "mLblX";
            this.mLblX.Size = new System.Drawing.Size(23, 15);
            this.mLblX.TabIndex = 1;
            this.mLblX.Text = "X:";
            // 
            // mBtnAddPoint
            // 
            this.mBtnAddPoint.Location = new System.Drawing.Point(22, 105);
            this.mBtnAddPoint.Name = "mBtnAddPoint";
            this.mBtnAddPoint.Size = new System.Drawing.Size(148, 27);
            this.mBtnAddPoint.TabIndex = 0;
            this.mBtnAddPoint.Text = "添加点";
            this.mBtnAddPoint.UseVisualStyleBackColor = true;
            this.mBtnAddPoint.Click += new System.EventHandler(this.mBtnAddPoint_Click);
            // 
            // mBtnZoomIn
            // 
            this.mBtnZoomIn.Location = new System.Drawing.Point(22, 296);
            this.mBtnZoomIn.Name = "mBtnZoomIn";
            this.mBtnZoomIn.Size = new System.Drawing.Size(67, 23);
            this.mBtnZoomIn.TabIndex = 16;
            this.mBtnZoomIn.Tag = "mBtnZoomIn";
            this.mBtnZoomIn.Text = "放大";
            this.mBtnZoomIn.UseVisualStyleBackColor = true;
            this.mBtnZoomIn.Click += new System.EventHandler(this.mBtnActions_Click);
            // 
            // mBtnZoomOut
            // 
            this.mBtnZoomOut.Location = new System.Drawing.Point(103, 296);
            this.mBtnZoomOut.Name = "mBtnZoomOut";
            this.mBtnZoomOut.Size = new System.Drawing.Size(67, 23);
            this.mBtnZoomOut.TabIndex = 17;
            this.mBtnZoomOut.Tag = "mBtnZoomOut";
            this.mBtnZoomOut.Text = "缩小";
            this.mBtnZoomOut.UseVisualStyleBackColor = true;
            this.mBtnZoomOut.Click += new System.EventHandler(this.mBtnActions_Click);
            // 
            // mBtnMoveRight
            // 
            this.mBtnMoveRight.Location = new System.Drawing.Point(103, 325);
            this.mBtnMoveRight.Name = "mBtnMoveRight";
            this.mBtnMoveRight.Size = new System.Drawing.Size(67, 23);
            this.mBtnMoveRight.TabIndex = 19;
            this.mBtnMoveRight.Tag = "mBtnMoveRight";
            this.mBtnMoveRight.Text = "右移";
            this.mBtnMoveRight.UseVisualStyleBackColor = true;
            this.mBtnMoveRight.Click += new System.EventHandler(this.mBtnActions_Click);
            // 
            // mBtnMoveLeft
            // 
            this.mBtnMoveLeft.Location = new System.Drawing.Point(22, 325);
            this.mBtnMoveLeft.Name = "mBtnMoveLeft";
            this.mBtnMoveLeft.Size = new System.Drawing.Size(67, 23);
            this.mBtnMoveLeft.TabIndex = 18;
            this.mBtnMoveLeft.Tag = "mBtnMoveLeft";
            this.mBtnMoveLeft.Text = "左移";
            this.mBtnMoveLeft.UseVisualStyleBackColor = true;
            this.mBtnMoveLeft.Click += new System.EventHandler(this.mBtnActions_Click);
            // 
            // mBtnMoveDown
            // 
            this.mBtnMoveDown.Location = new System.Drawing.Point(103, 354);
            this.mBtnMoveDown.Name = "mBtnMoveDown";
            this.mBtnMoveDown.Size = new System.Drawing.Size(67, 23);
            this.mBtnMoveDown.TabIndex = 21;
            this.mBtnMoveDown.Tag = "mBtnMoveDown";
            this.mBtnMoveDown.Text = "下移";
            this.mBtnMoveDown.UseVisualStyleBackColor = true;
            this.mBtnMoveDown.Click += new System.EventHandler(this.mBtnActions_Click);
            // 
            // mBtnMoveUp
            // 
            this.mBtnMoveUp.Location = new System.Drawing.Point(22, 354);
            this.mBtnMoveUp.Name = "mBtnMoveUp";
            this.mBtnMoveUp.Size = new System.Drawing.Size(67, 23);
            this.mBtnMoveUp.TabIndex = 20;
            this.mBtnMoveUp.Tag = "mBtnMoveUp";
            this.mBtnMoveUp.Text = "上移";
            this.mBtnMoveUp.UseVisualStyleBackColor = true;
            this.mBtnMoveUp.Click += new System.EventHandler(this.mBtnActions_Click);
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
        private System.Windows.Forms.Button mBtnRefreshMap;
        private System.Windows.Forms.Label mLblMinY;
        private System.Windows.Forms.Label mLblMinX;
        private System.Windows.Forms.Label mLblMaxY;
        private System.Windows.Forms.Label mLblMaxX;
        private System.Windows.Forms.TextBox mTxbMaxX;
        private System.Windows.Forms.TextBox mTxbMinY;
        private System.Windows.Forms.TextBox mTxbMinX;
        private System.Windows.Forms.TextBox mTxbMaxY;
        private System.Windows.Forms.Button mBtnZoomIn;
        private System.Windows.Forms.Button mBtnMoveDown;
        private System.Windows.Forms.Button mBtnMoveUp;
        private System.Windows.Forms.Button mBtnMoveRight;
        private System.Windows.Forms.Button mBtnMoveLeft;
        private System.Windows.Forms.Button mBtnZoomOut;
    }
}

