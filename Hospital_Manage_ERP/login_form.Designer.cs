namespace Hospital_Manage_ERP
{
    partial class login_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login_form));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.login_server_value = new System.Windows.Forms.TextBox();
            this.login_db_value = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.login_id_value = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.login_pw_value = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.login_cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(83, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "의료 서비스 관리 ERP";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hospital_Manage_ERP.Properties.Resources.병원_이미지_투명_48x48;
            this.pictureBox1.Location = new System.Drawing.Point(27, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ver 1.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "서버";
            // 
            // login_server_value
            // 
            this.login_server_value.Location = new System.Drawing.Point(103, 22);
            this.login_server_value.Name = "login_server_value";
            this.login_server_value.Size = new System.Drawing.Size(122, 21);
            this.login_server_value.TabIndex = 4;
            this.login_server_value.Text = "localhost";
            // 
            // login_db_value
            // 
            this.login_db_value.Location = new System.Drawing.Point(103, 49);
            this.login_db_value.Name = "login_db_value";
            this.login_db_value.Size = new System.Drawing.Size(122, 21);
            this.login_db_value.TabIndex = 6;
            this.login_db_value.Text = "test_db";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "DB";
            // 
            // login_id_value
            // 
            this.login_id_value.Location = new System.Drawing.Point(103, 76);
            this.login_id_value.Name = "login_id_value";
            this.login_id_value.Size = new System.Drawing.Size(122, 21);
            this.login_id_value.TabIndex = 8;
            this.login_id_value.Text = "admin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "아이디";
            // 
            // login_pw_value
            // 
            this.login_pw_value.Location = new System.Drawing.Point(103, 103);
            this.login_pw_value.Name = "login_pw_value";
            this.login_pw_value.PasswordChar = '*';
            this.login_pw_value.Size = new System.Drawing.Size(122, 21);
            this.login_pw_value.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "비밀번호";
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(77, 234);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(84, 29);
            this.login_button.TabIndex = 11;
            this.login_button.Text = "로그인";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // login_cancel
            // 
            this.login_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.login_cancel.Location = new System.Drawing.Point(167, 234);
            this.login_cancel.Name = "login_cancel";
            this.login_cancel.Size = new System.Drawing.Size(84, 29);
            this.login_cancel.TabIndex = 12;
            this.login_cancel.Text = "종료";
            this.login_cancel.UseVisualStyleBackColor = true;
            this.login_cancel.Click += new System.EventHandler(this.login_cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.login_id_value);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.login_pw_value);
            this.groupBox1.Controls.Add(this.login_server_value);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.login_db_value);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(23, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 134);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MySQL 데이터베이스 연결";
            // 
            // login_form
            // 
            this.AcceptButton = this.login_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.login_cancel;
            this.ClientSize = new System.Drawing.Size(327, 286);
            this.Controls.Add(this.login_cancel);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "의료 서비스 관리 ERP";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.login_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox login_server_value;
        private System.Windows.Forms.TextBox login_db_value;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox login_id_value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox login_pw_value;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button login_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}