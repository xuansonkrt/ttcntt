namespace TTCNTT
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.btnXuLy = new System.Windows.Forms.Button();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoCanh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoDinh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoTrinh = new System.Windows.Forms.TextBox();
            this.txtDoDai = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxGhiChu = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.groupBoxInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.checkBox);
            this.groupBoxInfo.Controls.Add(this.btnXuLy);
            this.groupBoxInfo.Controls.Add(this.txtEnd);
            this.groupBoxInfo.Controls.Add(this.label3);
            this.groupBoxInfo.Controls.Add(this.txtStart);
            this.groupBoxInfo.Controls.Add(this.label4);
            this.groupBoxInfo.Controls.Add(this.txtSoCanh);
            this.groupBoxInfo.Controls.Add(this.label2);
            this.groupBoxInfo.Controls.Add(this.txtSoDinh);
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Location = new System.Drawing.Point(13, 13);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(844, 132);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Nhập thông tin";
            // 
            // btnXuLy
            // 
            this.btnXuLy.Location = new System.Drawing.Point(699, 30);
            this.btnXuLy.Name = "btnXuLy";
            this.btnXuLy.Size = new System.Drawing.Size(134, 66);
            this.btnXuLy.TabIndex = 8;
            this.btnXuLy.Text = "Kết quả";
            this.btnXuLy.UseVisualStyleBackColor = true;
            this.btnXuLy.Click += new System.EventHandler(this.btnXuLy_Click);
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(475, 74);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(218, 22);
            this.txtEnd.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đỉnh kết thúc";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(117, 72);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(218, 22);
            this.txtStart.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Điểm bắt đầu";
            // 
            // txtSoCanh
            // 
            this.txtSoCanh.Location = new System.Drawing.Point(475, 30);
            this.txtSoCanh.Name = "txtSoCanh";
            this.txtSoCanh.Size = new System.Drawing.Size(218, 22);
            this.txtSoCanh.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số cạnh";
            // 
            // txtSoDinh
            // 
            this.txtSoDinh.Location = new System.Drawing.Point(117, 30);
            this.txtSoDinh.Name = "txtSoDinh";
            this.txtSoDinh.Size = new System.Drawing.Size(218, 22);
            this.txtSoDinh.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số đỉnh";
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBoxResult.Location = new System.Drawing.Point(12, 151);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(1579, 611);
            this.groupBoxResult.TabIndex = 1;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Đồ thị";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoTrinh);
            this.groupBox1.Controls.Add(this.txtDoDai);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(863, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 132);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết quả";
            // 
            // txtLoTrinh
            // 
            this.txtLoTrinh.Location = new System.Drawing.Point(72, 30);
            this.txtLoTrinh.Name = "txtLoTrinh";
            this.txtLoTrinh.ReadOnly = true;
            this.txtLoTrinh.Size = new System.Drawing.Size(410, 22);
            this.txtLoTrinh.TabIndex = 11;
            // 
            // txtDoDai
            // 
            this.txtDoDai.Location = new System.Drawing.Point(192, 70);
            this.txtDoDai.Name = "txtDoDai";
            this.txtDoDai.ReadOnly = true;
            this.txtDoDai.Size = new System.Drawing.Size(290, 22);
            this.txtDoDai.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Độ dài đường đi ngắn nhất:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Lộ trình:";
            // 
            // groupBoxGhiChu
            // 
            this.groupBoxGhiChu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBoxGhiChu.BackgroundImage")));
            this.groupBoxGhiChu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBoxGhiChu.Location = new System.Drawing.Point(1357, 13);
            this.groupBoxGhiChu.Name = "groupBoxGhiChu";
            this.groupBoxGhiChu.Size = new System.Drawing.Size(234, 132);
            this.groupBoxGhiChu.TabIndex = 3;
            this.groupBoxGhiChu.TabStop = false;
            this.groupBoxGhiChu.Text = "Ghi chú";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(117, 105);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(156, 21);
            this.checkBox.TabIndex = 9;
            this.checkBox.Text = "Hiển thị độ dài cạnh";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1603, 774);
            this.Controls.Add(this.groupBoxGhiChu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBoxInfo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thuật toán tìm đường đi ngắn nhất trên đồ thị";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBoxInfo;
        public System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.Button btnXuLy;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoCanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoDinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxGhiChu;
        private System.Windows.Forms.TextBox txtLoTrinh;
        private System.Windows.Forms.TextBox txtDoDai;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkBox;
    }
}

