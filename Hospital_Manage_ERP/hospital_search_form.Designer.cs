namespace Hospital_Manage_ERP
{
    partial class hospital_search_form
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
            this.label3 = new System.Windows.Forms.Label();
            this.hospital_search_categorie_value = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.hospital_search_address_value = new System.Windows.Forms.TextBox();
            this.search_cancel = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(63, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 30);
            this.label3.TabIndex = 24;
            this.label3.Text = "병원 정보 검색";
            // 
            // hospital_search_categorie_value
            // 
            this.hospital_search_categorie_value.Location = new System.Drawing.Point(117, 55);
            this.hospital_search_categorie_value.Name = "hospital_search_categorie_value";
            this.hospital_search_categorie_value.Size = new System.Drawing.Size(112, 21);
            this.hospital_search_categorie_value.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "주소";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "진료과목";
            // 
            // hospital_search_address_value
            // 
            this.hospital_search_address_value.Location = new System.Drawing.Point(117, 27);
            this.hospital_search_address_value.Name = "hospital_search_address_value";
            this.hospital_search_address_value.Size = new System.Drawing.Size(112, 21);
            this.hospital_search_address_value.TabIndex = 11;
            // 
            // search_cancel
            // 
            this.search_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.search_cancel.Location = new System.Drawing.Point(142, 161);
            this.search_cancel.Name = "search_cancel";
            this.search_cancel.Size = new System.Drawing.Size(101, 40);
            this.search_cancel.TabIndex = 26;
            this.search_cancel.Text = "취소";
            this.search_cancel.UseVisualStyleBackColor = true;
            this.search_cancel.Click += new System.EventHandler(this.hospital_search_Cancel);
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(27, 161);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(101, 40);
            this.search_button.TabIndex = 25;
            this.search_button.Text = "검색";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.hospital_search_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hospital_search_categorie_value);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.hospital_search_address_value);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 99);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "조회할 정보 입력";
            // 
            // hospital_search_form
            // 
            this.AcceptButton = this.search_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.search_cancel;
            this.ClientSize = new System.Drawing.Size(269, 211);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.search_cancel);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "hospital_search_form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "병원 정보 검색";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hospital_search_categorie_value;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox hospital_search_address_value;
        private System.Windows.Forms.Button search_cancel;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}