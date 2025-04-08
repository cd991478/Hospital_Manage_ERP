namespace Hospital_Manage_ERP
{
    partial class setting_form
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
            this.label2 = new System.Windows.Forms.Label();
            this.server_value = new System.Windows.Forms.TextBox();
            this.db_value = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.id_value = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pw_value = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.setting_apply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.setting_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "서버";
            // 
            // server_value
            // 
            this.server_value.Location = new System.Drawing.Point(79, 22);
            this.server_value.Name = "server_value";
            this.server_value.Size = new System.Drawing.Size(100, 21);
            this.server_value.TabIndex = 2;
            // 
            // db_value
            // 
            this.db_value.Location = new System.Drawing.Point(79, 49);
            this.db_value.Name = "db_value";
            this.db_value.Size = new System.Drawing.Size(100, 21);
            this.db_value.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "DB명";
            // 
            // id_value
            // 
            this.id_value.Location = new System.Drawing.Point(79, 76);
            this.id_value.Name = "id_value";
            this.id_value.Size = new System.Drawing.Size(100, 21);
            this.id_value.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "아이디";
            // 
            // pw_value
            // 
            this.pw_value.Location = new System.Drawing.Point(79, 103);
            this.pw_value.Name = "pw_value";
            this.pw_value.PasswordChar = '*';
            this.pw_value.Size = new System.Drawing.Size(100, 21);
            this.pw_value.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "비밀번호";
            // 
            // setting_apply
            // 
            this.setting_apply.Location = new System.Drawing.Point(30, 158);
            this.setting_apply.Name = "setting_apply";
            this.setting_apply.Size = new System.Drawing.Size(75, 23);
            this.setting_apply.TabIndex = 9;
            this.setting_apply.Text = "적용";
            this.setting_apply.UseVisualStyleBackColor = true;
            this.setting_apply.Click += new System.EventHandler(this.setting_Save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pw_value);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.id_value);
            this.groupBox1.Controls.Add(this.server_value);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.db_value);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 137);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MySQL DB 연결 설정";
            // 
            // setting_cancel
            // 
            this.setting_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.setting_cancel.Location = new System.Drawing.Point(121, 158);
            this.setting_cancel.Name = "setting_cancel";
            this.setting_cancel.Size = new System.Drawing.Size(75, 23);
            this.setting_cancel.TabIndex = 10;
            this.setting_cancel.Text = "취소";
            this.setting_cancel.UseVisualStyleBackColor = true;
            this.setting_cancel.Click += new System.EventHandler(this.setting_cancel_Click);
            // 
            // setting_form
            // 
            this.AcceptButton = this.setting_apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.setting_cancel;
            this.ClientSize = new System.Drawing.Size(222, 191);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.setting_cancel);
            this.Controls.Add(this.setting_apply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setting_form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "환경설정";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.setting_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox server_value;
        private System.Windows.Forms.TextBox db_value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox id_value;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pw_value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button setting_apply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button setting_cancel;
    }
}