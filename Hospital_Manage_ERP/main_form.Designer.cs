namespace Hospital_Manage_ERP
{
    partial class main_form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.main_form_tab = new System.Windows.Forms.TabControl();
            this.patient_page = new System.Windows.Forms.TabPage();
            this.patient_search_button = new System.Windows.Forms.Button();
            this.patient_refresh = new System.Windows.Forms.Button();
            this.patient_delete = new System.Windows.Forms.Button();
            this.patient_edit = new System.Windows.Forms.Button();
            this.patient_list = new System.Windows.Forms.DataGridView();
            this.appointment_page = new System.Windows.Forms.TabPage();
            this.appointment_search_button = new System.Windows.Forms.Button();
            this.appointment_refresh = new System.Windows.Forms.Button();
            this.appointment_delete = new System.Windows.Forms.Button();
            this.appointment_edit = new System.Windows.Forms.Button();
            this.appointment_list = new System.Windows.Forms.DataGridView();
            this.hospital_page = new System.Windows.Forms.TabPage();
            this.hospital_search_button = new System.Windows.Forms.Button();
            this.hospital_refresh = new System.Windows.Forms.Button();
            this.hospital_create = new System.Windows.Forms.Button();
            this.hospital_delete = new System.Windows.Forms.Button();
            this.hospital_edit = new System.Windows.Forms.Button();
            this.hospital_list = new System.Windows.Forms.DataGridView();
            this.user_page = new System.Windows.Forms.TabPage();
            this.user_search_button = new System.Windows.Forms.Button();
            this.user_refresh = new System.Windows.Forms.Button();
            this.user_delete = new System.Windows.Forms.Button();
            this.user_list = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setting_button = new System.Windows.Forms.Button();
            this.infomation_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.main_form_tab.SuspendLayout();
            this.patient_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patient_list)).BeginInit();
            this.appointment_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointment_list)).BeginInit();
            this.hospital_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hospital_list)).BeginInit();
            this.user_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // main_form_tab
            // 
            this.main_form_tab.Controls.Add(this.patient_page);
            this.main_form_tab.Controls.Add(this.appointment_page);
            this.main_form_tab.Controls.Add(this.hospital_page);
            this.main_form_tab.Controls.Add(this.user_page);
            this.main_form_tab.Location = new System.Drawing.Point(12, 58);
            this.main_form_tab.Name = "main_form_tab";
            this.main_form_tab.SelectedIndex = 0;
            this.main_form_tab.Size = new System.Drawing.Size(1300, 792);
            this.main_form_tab.TabIndex = 0;
            // 
            // patient_page
            // 
            this.patient_page.Controls.Add(this.patient_search_button);
            this.patient_page.Controls.Add(this.patient_refresh);
            this.patient_page.Controls.Add(this.patient_delete);
            this.patient_page.Controls.Add(this.patient_edit);
            this.patient_page.Controls.Add(this.patient_list);
            this.patient_page.Location = new System.Drawing.Point(4, 22);
            this.patient_page.Name = "patient_page";
            this.patient_page.Padding = new System.Windows.Forms.Padding(3);
            this.patient_page.Size = new System.Drawing.Size(1292, 766);
            this.patient_page.TabIndex = 0;
            this.patient_page.Text = "환자";
            this.patient_page.UseVisualStyleBackColor = true;
            // 
            // patient_search_button
            // 
            this.patient_search_button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.patient_search_button.Location = new System.Drawing.Point(1128, 705);
            this.patient_search_button.Name = "patient_search_button";
            this.patient_search_button.Size = new System.Drawing.Size(150, 50);
            this.patient_search_button.TabIndex = 19;
            this.patient_search_button.Text = "환자 검색";
            this.patient_search_button.UseVisualStyleBackColor = true;
            this.patient_search_button.Click += new System.EventHandler(this.patient_search_Click);
            // 
            // patient_refresh
            // 
            this.patient_refresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.patient_refresh.Location = new System.Drawing.Point(12, 705);
            this.patient_refresh.Name = "patient_refresh";
            this.patient_refresh.Size = new System.Drawing.Size(150, 50);
            this.patient_refresh.TabIndex = 15;
            this.patient_refresh.Text = "환자 목록 새로고침";
            this.patient_refresh.UseVisualStyleBackColor = true;
            this.patient_refresh.Click += new System.EventHandler(this.patient_refresh_Click);
            // 
            // patient_delete
            // 
            this.patient_delete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.patient_delete.Location = new System.Drawing.Point(336, 705);
            this.patient_delete.Name = "patient_delete";
            this.patient_delete.Size = new System.Drawing.Size(150, 50);
            this.patient_delete.TabIndex = 14;
            this.patient_delete.Text = "환자 정보 삭제";
            this.patient_delete.UseVisualStyleBackColor = true;
            this.patient_delete.Click += new System.EventHandler(this.patientdelete_Click);
            // 
            // patient_edit
            // 
            this.patient_edit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.patient_edit.Location = new System.Drawing.Point(174, 705);
            this.patient_edit.Name = "patient_edit";
            this.patient_edit.Size = new System.Drawing.Size(150, 50);
            this.patient_edit.TabIndex = 13;
            this.patient_edit.Text = "환자 정보 수정";
            this.patient_edit.UseVisualStyleBackColor = true;
            this.patient_edit.Click += new System.EventHandler(this.patientedit_Click);
            // 
            // patient_list
            // 
            this.patient_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patient_list.Location = new System.Drawing.Point(6, 6);
            this.patient_list.Name = "patient_list";
            this.patient_list.RowTemplate.Height = 23;
            this.patient_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.patient_list.Size = new System.Drawing.Size(1280, 690);
            this.patient_list.TabIndex = 0;
            // 
            // appointment_page
            // 
            this.appointment_page.Controls.Add(this.appointment_search_button);
            this.appointment_page.Controls.Add(this.appointment_refresh);
            this.appointment_page.Controls.Add(this.appointment_delete);
            this.appointment_page.Controls.Add(this.appointment_edit);
            this.appointment_page.Controls.Add(this.appointment_list);
            this.appointment_page.Location = new System.Drawing.Point(4, 22);
            this.appointment_page.Name = "appointment_page";
            this.appointment_page.Padding = new System.Windows.Forms.Padding(3);
            this.appointment_page.Size = new System.Drawing.Size(1292, 766);
            this.appointment_page.TabIndex = 1;
            this.appointment_page.Text = "예약";
            this.appointment_page.UseVisualStyleBackColor = true;
            // 
            // appointment_search_button
            // 
            this.appointment_search_button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.appointment_search_button.Location = new System.Drawing.Point(1128, 705);
            this.appointment_search_button.Name = "appointment_search_button";
            this.appointment_search_button.Size = new System.Drawing.Size(150, 50);
            this.appointment_search_button.TabIndex = 19;
            this.appointment_search_button.Text = "예약 검색";
            this.appointment_search_button.UseVisualStyleBackColor = true;
            this.appointment_search_button.Click += new System.EventHandler(this.appointment_search_Click);
            // 
            // appointment_refresh
            // 
            this.appointment_refresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.appointment_refresh.Location = new System.Drawing.Point(12, 705);
            this.appointment_refresh.Name = "appointment_refresh";
            this.appointment_refresh.Size = new System.Drawing.Size(150, 50);
            this.appointment_refresh.TabIndex = 16;
            this.appointment_refresh.Text = "예약 목록 새로고침";
            this.appointment_refresh.UseVisualStyleBackColor = true;
            this.appointment_refresh.Click += new System.EventHandler(this.appointment_refresh_Click);
            // 
            // appointment_delete
            // 
            this.appointment_delete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.appointment_delete.Location = new System.Drawing.Point(336, 705);
            this.appointment_delete.Name = "appointment_delete";
            this.appointment_delete.Size = new System.Drawing.Size(150, 50);
            this.appointment_delete.TabIndex = 15;
            this.appointment_delete.Text = "예약 정보 삭제";
            this.appointment_delete.UseVisualStyleBackColor = true;
            this.appointment_delete.Click += new System.EventHandler(this.appointment_delete_Click);
            // 
            // appointment_edit
            // 
            this.appointment_edit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.appointment_edit.Location = new System.Drawing.Point(174, 705);
            this.appointment_edit.Name = "appointment_edit";
            this.appointment_edit.Size = new System.Drawing.Size(150, 50);
            this.appointment_edit.TabIndex = 14;
            this.appointment_edit.Text = "예약 정보 수정";
            this.appointment_edit.UseVisualStyleBackColor = true;
            this.appointment_edit.Click += new System.EventHandler(this.appointment_edit_Click);
            // 
            // appointment_list
            // 
            this.appointment_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointment_list.Location = new System.Drawing.Point(6, 6);
            this.appointment_list.Name = "appointment_list";
            this.appointment_list.RowTemplate.Height = 23;
            this.appointment_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointment_list.Size = new System.Drawing.Size(1277, 690);
            this.appointment_list.TabIndex = 2;
            // 
            // hospital_page
            // 
            this.hospital_page.Controls.Add(this.hospital_search_button);
            this.hospital_page.Controls.Add(this.hospital_refresh);
            this.hospital_page.Controls.Add(this.hospital_create);
            this.hospital_page.Controls.Add(this.hospital_delete);
            this.hospital_page.Controls.Add(this.hospital_edit);
            this.hospital_page.Controls.Add(this.hospital_list);
            this.hospital_page.Location = new System.Drawing.Point(4, 22);
            this.hospital_page.Name = "hospital_page";
            this.hospital_page.Padding = new System.Windows.Forms.Padding(3);
            this.hospital_page.Size = new System.Drawing.Size(1292, 766);
            this.hospital_page.TabIndex = 2;
            this.hospital_page.Text = "병원";
            this.hospital_page.UseVisualStyleBackColor = true;
            // 
            // hospital_search_button
            // 
            this.hospital_search_button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hospital_search_button.Location = new System.Drawing.Point(1128, 705);
            this.hospital_search_button.Name = "hospital_search_button";
            this.hospital_search_button.Size = new System.Drawing.Size(150, 50);
            this.hospital_search_button.TabIndex = 18;
            this.hospital_search_button.Text = "병원 검색";
            this.hospital_search_button.UseVisualStyleBackColor = true;
            this.hospital_search_button.Click += new System.EventHandler(this.hospital_search_Click);
            // 
            // hospital_refresh
            // 
            this.hospital_refresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hospital_refresh.Location = new System.Drawing.Point(12, 705);
            this.hospital_refresh.Name = "hospital_refresh";
            this.hospital_refresh.Size = new System.Drawing.Size(150, 50);
            this.hospital_refresh.TabIndex = 17;
            this.hospital_refresh.Text = "병원 목록 새로고침";
            this.hospital_refresh.UseVisualStyleBackColor = true;
            this.hospital_refresh.Click += new System.EventHandler(this.hospital_refresh_Click);
            // 
            // hospital_create
            // 
            this.hospital_create.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hospital_create.Location = new System.Drawing.Point(498, 705);
            this.hospital_create.Name = "hospital_create";
            this.hospital_create.Size = new System.Drawing.Size(150, 50);
            this.hospital_create.TabIndex = 16;
            this.hospital_create.Text = "병원 정보 등록";
            this.hospital_create.UseVisualStyleBackColor = true;
            this.hospital_create.Click += new System.EventHandler(this.hospital_create_Click);
            // 
            // hospital_delete
            // 
            this.hospital_delete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hospital_delete.Location = new System.Drawing.Point(336, 705);
            this.hospital_delete.Name = "hospital_delete";
            this.hospital_delete.Size = new System.Drawing.Size(150, 50);
            this.hospital_delete.TabIndex = 15;
            this.hospital_delete.Text = "병원 정보 삭제";
            this.hospital_delete.UseVisualStyleBackColor = true;
            this.hospital_delete.Click += new System.EventHandler(this.hospital_delete_Click);
            // 
            // hospital_edit
            // 
            this.hospital_edit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hospital_edit.Location = new System.Drawing.Point(174, 705);
            this.hospital_edit.Name = "hospital_edit";
            this.hospital_edit.Size = new System.Drawing.Size(150, 50);
            this.hospital_edit.TabIndex = 14;
            this.hospital_edit.Text = "병원 정보 수정";
            this.hospital_edit.UseVisualStyleBackColor = true;
            this.hospital_edit.Click += new System.EventHandler(this.hospital_edit_Click);
            // 
            // hospital_list
            // 
            this.hospital_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hospital_list.Location = new System.Drawing.Point(6, 6);
            this.hospital_list.Name = "hospital_list";
            this.hospital_list.RowTemplate.Height = 23;
            this.hospital_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hospital_list.Size = new System.Drawing.Size(1280, 690);
            this.hospital_list.TabIndex = 1;
            // 
            // user_page
            // 
            this.user_page.Controls.Add(this.user_search_button);
            this.user_page.Controls.Add(this.user_refresh);
            this.user_page.Controls.Add(this.user_delete);
            this.user_page.Controls.Add(this.user_list);
            this.user_page.Location = new System.Drawing.Point(4, 22);
            this.user_page.Name = "user_page";
            this.user_page.Padding = new System.Windows.Forms.Padding(3);
            this.user_page.Size = new System.Drawing.Size(1292, 766);
            this.user_page.TabIndex = 3;
            this.user_page.Text = "회원";
            this.user_page.UseVisualStyleBackColor = true;
            // 
            // user_search_button
            // 
            this.user_search_button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.user_search_button.Location = new System.Drawing.Point(1128, 705);
            this.user_search_button.Name = "user_search_button";
            this.user_search_button.Size = new System.Drawing.Size(150, 50);
            this.user_search_button.TabIndex = 19;
            this.user_search_button.Text = "회원 검색";
            this.user_search_button.UseVisualStyleBackColor = true;
            this.user_search_button.Click += new System.EventHandler(this.user_search_Click);
            // 
            // user_refresh
            // 
            this.user_refresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.user_refresh.Location = new System.Drawing.Point(12, 705);
            this.user_refresh.Name = "user_refresh";
            this.user_refresh.Size = new System.Drawing.Size(150, 50);
            this.user_refresh.TabIndex = 16;
            this.user_refresh.Text = "회원 목록 새로고침";
            this.user_refresh.UseVisualStyleBackColor = true;
            this.user_refresh.Click += new System.EventHandler(this.user_refresh_Click);
            // 
            // user_delete
            // 
            this.user_delete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.user_delete.Location = new System.Drawing.Point(336, 705);
            this.user_delete.Name = "user_delete";
            this.user_delete.Size = new System.Drawing.Size(150, 50);
            this.user_delete.TabIndex = 14;
            this.user_delete.Text = "회원 정보 삭제";
            this.user_delete.UseVisualStyleBackColor = true;
            this.user_delete.Click += new System.EventHandler(this.user_delete_Click);
            // 
            // user_list
            // 
            this.user_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.user_list.Location = new System.Drawing.Point(6, 6);
            this.user_list.Name = "user_list";
            this.user_list.RowTemplate.Height = 23;
            this.user_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.user_list.Size = new System.Drawing.Size(1280, 690);
            this.user_list.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(554, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "의료 사이트 관리 ERP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1183, 854);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "제작자 : 백성진 김중섭";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 854);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ver 1.0";
            // 
            // setting_button
            // 
            this.setting_button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.setting_button.Location = new System.Drawing.Point(1156, 18);
            this.setting_button.Name = "setting_button";
            this.setting_button.Size = new System.Drawing.Size(73, 36);
            this.setting_button.TabIndex = 5;
            this.setting_button.Text = "환경설정";
            this.setting_button.UseVisualStyleBackColor = true;
            this.setting_button.Click += new System.EventHandler(this.setting_Click);
            // 
            // infomation_button
            // 
            this.infomation_button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.infomation_button.Location = new System.Drawing.Point(1235, 18);
            this.infomation_button.Name = "infomation_button";
            this.infomation_button.Size = new System.Drawing.Size(73, 36);
            this.infomation_button.TabIndex = 6;
            this.infomation_button.Text = "정보";
            this.infomation_button.UseVisualStyleBackColor = true;
            this.infomation_button.Click += new System.EventHandler(this.infomation_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hospital_Manage_ERP.Properties.Resources.병원_이미지_투명_48x48;
            this.pictureBox1.Location = new System.Drawing.Point(500, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1319, 875);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.infomation_button);
            this.Controls.Add(this.setting_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.main_form_tab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "의료 사이트 관리 ERP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_form_FormClosing);
            this.Load += new System.EventHandler(this.main_form_Load);
            this.main_form_tab.ResumeLayout(false);
            this.patient_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patient_list)).EndInit();
            this.appointment_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appointment_list)).EndInit();
            this.hospital_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hospital_list)).EndInit();
            this.user_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.user_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl main_form_tab;
        private System.Windows.Forms.TabPage patient_page;
        private System.Windows.Forms.TabPage appointment_page;
        private System.Windows.Forms.TabPage user_page;
        private System.Windows.Forms.DataGridView patient_list;
        private System.Windows.Forms.Button patient_delete;
        private System.Windows.Forms.Button patient_edit;
        private System.Windows.Forms.TabPage hospital_page;
        private System.Windows.Forms.DataGridView hospital_list;
        private System.Windows.Forms.DataGridView appointment_list;
        private System.Windows.Forms.DataGridView user_list;
        private System.Windows.Forms.Button hospital_delete;
        private System.Windows.Forms.Button hospital_edit;
        private System.Windows.Forms.Button appointment_delete;
        private System.Windows.Forms.Button appointment_edit;
        private System.Windows.Forms.Button hospital_create;
        private System.Windows.Forms.Button user_delete;
        private System.Windows.Forms.Button patient_refresh;
        private System.Windows.Forms.Button appointment_refresh;
        private System.Windows.Forms.Button hospital_refresh;
        private System.Windows.Forms.Button user_refresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button setting_button;
        private System.Windows.Forms.Button infomation_button;
        private System.Windows.Forms.Button patient_search_button;
        private System.Windows.Forms.Button hospital_search_button;
        private System.Windows.Forms.Button appointment_search_button;
        private System.Windows.Forms.Button user_search_button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

