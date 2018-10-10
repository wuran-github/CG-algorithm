namespace ExampleForm
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
            this.DDABtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LineSXBox = new System.Windows.Forms.TextBox();
            this.LineSYBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LineEYBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LineEXBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CenterBtn = new System.Windows.Forms.Button();
            this.BresenhamBtn = new System.Windows.Forms.Button();
            this.ScanBtn = new System.Windows.Forms.Button();
            this.ImprScanBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DDABtn
            // 
            this.DDABtn.Location = new System.Drawing.Point(20, 375);
            this.DDABtn.Name = "DDABtn";
            this.DDABtn.Size = new System.Drawing.Size(75, 23);
            this.DDABtn.TabIndex = 0;
            this.DDABtn.Text = "DDA";
            this.DDABtn.UseVisualStyleBackColor = true;
            this.DDABtn.Click += new System.EventHandler(this.DDABtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "line Start X:";
            // 
            // LineSXBox
            // 
            this.LineSXBox.Location = new System.Drawing.Point(101, 293);
            this.LineSXBox.Name = "LineSXBox";
            this.LineSXBox.Size = new System.Drawing.Size(100, 21);
            this.LineSXBox.TabIndex = 2;
            // 
            // LineSYBox
            // 
            this.LineSYBox.Location = new System.Drawing.Point(319, 293);
            this.LineSYBox.Name = "LineSYBox";
            this.LineSYBox.Size = new System.Drawing.Size(100, 21);
            this.LineSYBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "line Start Y:";
            // 
            // LineEYBox
            // 
            this.LineEYBox.Location = new System.Drawing.Point(319, 331);
            this.LineEYBox.Name = "LineEYBox";
            this.LineEYBox.Size = new System.Drawing.Size(100, 21);
            this.LineEYBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "line End Y:";
            // 
            // LineEXBox
            // 
            this.LineEXBox.Location = new System.Drawing.Point(101, 331);
            this.LineEXBox.Name = "LineEXBox";
            this.LineEXBox.Size = new System.Drawing.Size(100, 21);
            this.LineEXBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "line End X:";
            // 
            // CenterBtn
            // 
            this.CenterBtn.Location = new System.Drawing.Point(115, 375);
            this.CenterBtn.Name = "CenterBtn";
            this.CenterBtn.Size = new System.Drawing.Size(75, 23);
            this.CenterBtn.TabIndex = 9;
            this.CenterBtn.Text = "Center";
            this.CenterBtn.UseVisualStyleBackColor = true;
            this.CenterBtn.Click += new System.EventHandler(this.CenterBtn_Click);
            // 
            // BresenhamBtn
            // 
            this.BresenhamBtn.Location = new System.Drawing.Point(214, 375);
            this.BresenhamBtn.Name = "BresenhamBtn";
            this.BresenhamBtn.Size = new System.Drawing.Size(75, 23);
            this.BresenhamBtn.TabIndex = 10;
            this.BresenhamBtn.Text = "Bresenham";
            this.BresenhamBtn.UseVisualStyleBackColor = true;
            this.BresenhamBtn.Click += new System.EventHandler(this.BresenhamBtn_Click);
            // 
            // ScanBtn
            // 
            this.ScanBtn.Location = new System.Drawing.Point(307, 375);
            this.ScanBtn.Name = "ScanBtn";
            this.ScanBtn.Size = new System.Drawing.Size(75, 23);
            this.ScanBtn.TabIndex = 11;
            this.ScanBtn.Text = "Scan";
            this.ScanBtn.UseVisualStyleBackColor = true;
            this.ScanBtn.Click += new System.EventHandler(this.ScanBtn_Click);
            // 
            // ImprScanBtn
            // 
            this.ImprScanBtn.Location = new System.Drawing.Point(400, 375);
            this.ImprScanBtn.Name = "ImprScanBtn";
            this.ImprScanBtn.Size = new System.Drawing.Size(75, 23);
            this.ImprScanBtn.TabIndex = 12;
            this.ImprScanBtn.Text = "ImprScan";
            this.ImprScanBtn.UseVisualStyleBackColor = true;
            this.ImprScanBtn.Click += new System.EventHandler(this.ImprScanBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 410);
            this.Controls.Add(this.ImprScanBtn);
            this.Controls.Add(this.ScanBtn);
            this.Controls.Add(this.BresenhamBtn);
            this.Controls.Add(this.CenterBtn);
            this.Controls.Add(this.LineEYBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LineEXBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LineSYBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LineSXBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DDABtn);
            this.Name = "Form1";
            this.Text = "ExampleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DDABtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LineSXBox;
        private System.Windows.Forms.TextBox LineSYBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LineEYBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LineEXBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CenterBtn;
        private System.Windows.Forms.Button BresenhamBtn;
        private System.Windows.Forms.Button ScanBtn;
        private System.Windows.Forms.Button ImprScanBtn;
    }
}

