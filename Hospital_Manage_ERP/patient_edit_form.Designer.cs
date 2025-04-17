namespace Hospital_Manage_ERP
{
    partial class patient_edit_form
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
            this.patienteditsave = new System.Windows.Forms.Button();
            this.patienteditcancel = new System.Windows.Forms.Button();
            this.p_name_value = new System.Windows.Forms.TextBox();
            this.p_name_label = new System.Windows.Forms.Label();
            this.p_regnum_label = new System.Windows.Forms.Label();
            this.p_regnum_value = new System.Windows.Forms.TextBox();
            this.p_gender_label = new System.Windows.Forms.Label();
            this.p_phone_label = new System.Windows.Forms.Label();
            this.p_phone_value = new System.Windows.Forms.TextBox();
            this.p_address1_label = new System.Windows.Forms.Label();
            this.p_address1_value = new System.Windows.Forms.TextBox();
            this.p_address2_label = new System.Windows.Forms.Label();
            this.p_address2_value = new System.Windows.Forms.TextBox();
            this.p_user_id_label = new System.Windows.Forms.Label();
            this.p_user_id_value = new System.Windows.Forms.TextBox();
            this.p_nose_box = new System.Windows.Forms.CheckBox();
            this.p_cough_box = new System.Windows.Forms.CheckBox();
            this.p_pain_box = new System.Windows.Forms.CheckBox();
            this.p_diarrhea_box = new System.Windows.Forms.CheckBox();
            this.covid19yes = new System.Windows.Forms.RadioButton();
            this.covid19no = new System.Windows.Forms.RadioButton();
            this.covid19none = new System.Windows.Forms.RadioButton();
            this.p_vas_value = new System.Windows.Forms.TextBox();
            this.patientedit = new System.Windows.Forms.Label();
            this.p_taking_pill_no = new System.Windows.Forms.RadioButton();
            this.p_taking_pill_yes = new System.Windows.Forms.RadioButton();
            this.lung = new System.Windows.Forms.RadioButton();
            this.pragnants = new System.Windows.Forms.RadioButton();
            this.under59 = new System.Windows.Forms.RadioButton();
            this.none = new System.Windows.Forms.RadioButton();
            this.cancer = new System.Windows.Forms.RadioButton();
            this.diabetes = new System.Windows.Forms.RadioButton();
            this.p_gender_male = new System.Windows.Forms.RadioButton();
            this.p_gender_female = new System.Windows.Forms.RadioButton();
            this.p_id_label = new System.Windows.Forms.Label();
            this.p_id_value = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.p_vas_range = new System.Windows.Forms.TrackBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.p_age_value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_vas_range)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // patienteditsave
            // 
            this.patienteditsave.Location = new System.Drawing.Point(86, 353);
            this.patienteditsave.Name = "patienteditsave";
            this.patienteditsave.Size = new System.Drawing.Size(110, 50);
            this.patienteditsave.TabIndex = 0;
            this.patienteditsave.Text = "저장";
            this.patienteditsave.UseVisualStyleBackColor = true;
            this.patienteditsave.Click += new System.EventHandler(this.save_button_Click);
            // 
            // patienteditcancel
            // 
            this.patienteditcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.patienteditcancel.Location = new System.Drawing.Point(221, 353);
            this.patienteditcancel.Name = "patienteditcancel";
            this.patienteditcancel.Size = new System.Drawing.Size(104, 50);
            this.patienteditcancel.TabIndex = 1;
            this.patienteditcancel.Text = "취소";
            this.patienteditcancel.UseVisualStyleBackColor = true;
            this.patienteditcancel.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // p_name_value
            // 
            this.p_name_value.Location = new System.Drawing.Point(108, 75);
            this.p_name_value.Name = "p_name_value";
            this.p_name_value.Size = new System.Drawing.Size(218, 21);
            this.p_name_value.TabIndex = 2;
            // 
            // p_name_label
            // 
            this.p_name_label.AutoSize = true;
            this.p_name_label.Location = new System.Drawing.Point(39, 78);
            this.p_name_label.Name = "p_name_label";
            this.p_name_label.Size = new System.Drawing.Size(29, 12);
            this.p_name_label.TabIndex = 3;
            this.p_name_label.Text = "이름";
            // 
            // p_regnum_label
            // 
            this.p_regnum_label.AutoSize = true;
            this.p_regnum_label.Location = new System.Drawing.Point(9, 105);
            this.p_regnum_label.Name = "p_regnum_label";
            this.p_regnum_label.Size = new System.Drawing.Size(93, 12);
            this.p_regnum_label.TabIndex = 5;
            this.p_regnum_label.Text = "주민번호 앞자리";
            // 
            // p_regnum_value
            // 
            this.p_regnum_value.Location = new System.Drawing.Point(108, 102);
            this.p_regnum_value.Name = "p_regnum_value";
            this.p_regnum_value.Size = new System.Drawing.Size(218, 21);
            this.p_regnum_value.TabIndex = 4;
            // 
            // p_gender_label
            // 
            this.p_gender_label.AutoSize = true;
            this.p_gender_label.Location = new System.Drawing.Point(39, 156);
            this.p_gender_label.Name = "p_gender_label";
            this.p_gender_label.Size = new System.Drawing.Size(29, 12);
            this.p_gender_label.TabIndex = 7;
            this.p_gender_label.Text = "성별";
            // 
            // p_phone_label
            // 
            this.p_phone_label.AutoSize = true;
            this.p_phone_label.Location = new System.Drawing.Point(31, 181);
            this.p_phone_label.Name = "p_phone_label";
            this.p_phone_label.Size = new System.Drawing.Size(53, 12);
            this.p_phone_label.TabIndex = 9;
            this.p_phone_label.Text = "전화번호";
            // 
            // p_phone_value
            // 
            this.p_phone_value.Location = new System.Drawing.Point(108, 178);
            this.p_phone_value.Name = "p_phone_value";
            this.p_phone_value.Size = new System.Drawing.Size(218, 21);
            this.p_phone_value.TabIndex = 8;
            // 
            // p_address1_label
            // 
            this.p_address1_label.AutoSize = true;
            this.p_address1_label.Location = new System.Drawing.Point(39, 208);
            this.p_address1_label.Name = "p_address1_label";
            this.p_address1_label.Size = new System.Drawing.Size(35, 12);
            this.p_address1_label.TabIndex = 11;
            this.p_address1_label.Text = "주소1";
            // 
            // p_address1_value
            // 
            this.p_address1_value.Location = new System.Drawing.Point(108, 205);
            this.p_address1_value.Name = "p_address1_value";
            this.p_address1_value.Size = new System.Drawing.Size(218, 21);
            this.p_address1_value.TabIndex = 10;
            // 
            // p_address2_label
            // 
            this.p_address2_label.AutoSize = true;
            this.p_address2_label.Location = new System.Drawing.Point(39, 235);
            this.p_address2_label.Name = "p_address2_label";
            this.p_address2_label.Size = new System.Drawing.Size(35, 12);
            this.p_address2_label.TabIndex = 13;
            this.p_address2_label.Text = "주소2";
            // 
            // p_address2_value
            // 
            this.p_address2_value.Location = new System.Drawing.Point(108, 232);
            this.p_address2_value.Name = "p_address2_value";
            this.p_address2_value.Size = new System.Drawing.Size(218, 21);
            this.p_address2_value.TabIndex = 12;
            // 
            // p_user_id_label
            // 
            this.p_user_id_label.AutoSize = true;
            this.p_user_id_label.Location = new System.Drawing.Point(33, 51);
            this.p_user_id_label.Name = "p_user_id_label";
            this.p_user_id_label.Size = new System.Drawing.Size(41, 12);
            this.p_user_id_label.TabIndex = 15;
            this.p_user_id_label.Text = "아이디";
            // 
            // p_user_id_value
            // 
            this.p_user_id_value.Location = new System.Drawing.Point(108, 48);
            this.p_user_id_value.Name = "p_user_id_value";
            this.p_user_id_value.ReadOnly = true;
            this.p_user_id_value.Size = new System.Drawing.Size(218, 21);
            this.p_user_id_value.TabIndex = 14;
            // 
            // p_nose_box
            // 
            this.p_nose_box.AutoSize = true;
            this.p_nose_box.Location = new System.Drawing.Point(30, 15);
            this.p_nose_box.Name = "p_nose_box";
            this.p_nose_box.Size = new System.Drawing.Size(116, 16);
            this.p_nose_box.TabIndex = 17;
            this.p_nose_box.Text = "콧물 또는 코막힘";
            this.p_nose_box.UseVisualStyleBackColor = true;
            // 
            // p_cough_box
            // 
            this.p_cough_box.AutoSize = true;
            this.p_cough_box.Location = new System.Drawing.Point(175, 14);
            this.p_cough_box.Name = "p_cough_box";
            this.p_cough_box.Size = new System.Drawing.Size(104, 16);
            this.p_cough_box.TabIndex = 18;
            this.p_cough_box.Text = "기침 또는 가래";
            this.p_cough_box.UseVisualStyleBackColor = true;
            // 
            // p_pain_box
            // 
            this.p_pain_box.AutoSize = true;
            this.p_pain_box.Location = new System.Drawing.Point(30, 37);
            this.p_pain_box.Name = "p_pain_box";
            this.p_pain_box.Size = new System.Drawing.Size(48, 16);
            this.p_pain_box.TabIndex = 19;
            this.p_pain_box.Text = "통증";
            this.p_pain_box.UseVisualStyleBackColor = true;
            // 
            // p_diarrhea_box
            // 
            this.p_diarrhea_box.AutoSize = true;
            this.p_diarrhea_box.Location = new System.Drawing.Point(175, 36);
            this.p_diarrhea_box.Name = "p_diarrhea_box";
            this.p_diarrhea_box.Size = new System.Drawing.Size(48, 16);
            this.p_diarrhea_box.TabIndex = 20;
            this.p_diarrhea_box.Text = "설사";
            this.p_diarrhea_box.UseVisualStyleBackColor = true;
            // 
            // covid19yes
            // 
            this.covid19yes.AutoSize = true;
            this.covid19yes.Location = new System.Drawing.Point(30, 20);
            this.covid19yes.Name = "covid19yes";
            this.covid19yes.Size = new System.Drawing.Size(35, 16);
            this.covid19yes.TabIndex = 21;
            this.covid19yes.TabStop = true;
            this.covid19yes.Text = "유";
            this.covid19yes.UseVisualStyleBackColor = true;
            // 
            // covid19no
            // 
            this.covid19no.AutoSize = true;
            this.covid19no.Location = new System.Drawing.Point(107, 20);
            this.covid19no.Name = "covid19no";
            this.covid19no.Size = new System.Drawing.Size(35, 16);
            this.covid19no.TabIndex = 22;
            this.covid19no.TabStop = true;
            this.covid19no.Text = "무";
            this.covid19no.UseVisualStyleBackColor = true;
            // 
            // covid19none
            // 
            this.covid19none.AutoSize = true;
            this.covid19none.Location = new System.Drawing.Point(176, 20);
            this.covid19none.Name = "covid19none";
            this.covid19none.Size = new System.Drawing.Size(47, 16);
            this.covid19none.TabIndex = 23;
            this.covid19none.TabStop = true;
            this.covid19none.Text = "모름";
            this.covid19none.UseVisualStyleBackColor = true;
            // 
            // p_vas_value
            // 
            this.p_vas_value.Location = new System.Drawing.Point(126, 63);
            this.p_vas_value.Name = "p_vas_value";
            this.p_vas_value.Size = new System.Drawing.Size(35, 21);
            this.p_vas_value.TabIndex = 28;
            this.p_vas_value.TextChanged += new System.EventHandler(this.box_Changed);
            // 
            // patientedit
            // 
            this.patientedit.AutoSize = true;
            this.patientedit.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.patientedit.Location = new System.Drawing.Point(335, 19);
            this.patientedit.Name = "patientedit";
            this.patientedit.Size = new System.Drawing.Size(153, 30);
            this.patientedit.TabIndex = 29;
            this.patientedit.Text = "환자 정보 수정";
            // 
            // p_taking_pill_no
            // 
            this.p_taking_pill_no.AutoSize = true;
            this.p_taking_pill_no.Location = new System.Drawing.Point(175, 18);
            this.p_taking_pill_no.Name = "p_taking_pill_no";
            this.p_taking_pill_no.Size = new System.Drawing.Size(35, 16);
            this.p_taking_pill_no.TabIndex = 31;
            this.p_taking_pill_no.TabStop = true;
            this.p_taking_pill_no.Text = "무";
            this.p_taking_pill_no.UseVisualStyleBackColor = true;
            // 
            // p_taking_pill_yes
            // 
            this.p_taking_pill_yes.AutoSize = true;
            this.p_taking_pill_yes.Location = new System.Drawing.Point(30, 18);
            this.p_taking_pill_yes.Name = "p_taking_pill_yes";
            this.p_taking_pill_yes.Size = new System.Drawing.Size(35, 16);
            this.p_taking_pill_yes.TabIndex = 30;
            this.p_taking_pill_yes.TabStop = true;
            this.p_taking_pill_yes.Text = "유";
            this.p_taking_pill_yes.UseVisualStyleBackColor = true;
            // 
            // lung
            // 
            this.lung.AutoSize = true;
            this.lung.Location = new System.Drawing.Point(176, 15);
            this.lung.Name = "lung";
            this.lung.Size = new System.Drawing.Size(87, 16);
            this.lung.TabIndex = 35;
            this.lung.TabStop = true;
            this.lung.Text = "만성 폐질환";
            this.lung.UseVisualStyleBackColor = true;
            // 
            // pragnants
            // 
            this.pragnants.AutoSize = true;
            this.pragnants.Location = new System.Drawing.Point(99, 15);
            this.pragnants.Name = "pragnants";
            this.pragnants.Size = new System.Drawing.Size(59, 16);
            this.pragnants.TabIndex = 34;
            this.pragnants.TabStop = true;
            this.pragnants.Text = "임산부";
            this.pragnants.UseVisualStyleBackColor = true;
            // 
            // under59
            // 
            this.under59.AutoSize = true;
            this.under59.Location = new System.Drawing.Point(31, 15);
            this.under59.Name = "under59";
            this.under59.Size = new System.Drawing.Size(47, 16);
            this.under59.TabIndex = 33;
            this.under59.TabStop = true;
            this.under59.Text = "소아";
            this.under59.UseVisualStyleBackColor = true;
            // 
            // none
            // 
            this.none.AutoSize = true;
            this.none.Location = new System.Drawing.Point(176, 37);
            this.none.Name = "none";
            this.none.Size = new System.Drawing.Size(75, 16);
            this.none.TabIndex = 39;
            this.none.TabStop = true;
            this.none.Text = "해당 없음";
            this.none.UseVisualStyleBackColor = true;
            // 
            // cancer
            // 
            this.cancer.AutoSize = true;
            this.cancer.Location = new System.Drawing.Point(99, 37);
            this.cancer.Name = "cancer";
            this.cancer.Size = new System.Drawing.Size(59, 16);
            this.cancer.TabIndex = 38;
            this.cancer.TabStop = true;
            this.cancer.Text = "암환자";
            this.cancer.UseVisualStyleBackColor = true;
            // 
            // diabetes
            // 
            this.diabetes.AutoSize = true;
            this.diabetes.Location = new System.Drawing.Point(30, 37);
            this.diabetes.Name = "diabetes";
            this.diabetes.Size = new System.Drawing.Size(47, 16);
            this.diabetes.TabIndex = 37;
            this.diabetes.TabStop = true;
            this.diabetes.Text = "당뇨";
            this.diabetes.UseVisualStyleBackColor = true;
            // 
            // p_gender_male
            // 
            this.p_gender_male.AutoSize = true;
            this.p_gender_male.Location = new System.Drawing.Point(187, 156);
            this.p_gender_male.Name = "p_gender_male";
            this.p_gender_male.Size = new System.Drawing.Size(47, 16);
            this.p_gender_male.TabIndex = 41;
            this.p_gender_male.TabStop = true;
            this.p_gender_male.Text = "남성";
            this.p_gender_male.UseVisualStyleBackColor = true;
            // 
            // p_gender_female
            // 
            this.p_gender_female.AutoSize = true;
            this.p_gender_female.Location = new System.Drawing.Point(108, 156);
            this.p_gender_female.Name = "p_gender_female";
            this.p_gender_female.Size = new System.Drawing.Size(47, 16);
            this.p_gender_female.TabIndex = 40;
            this.p_gender_female.TabStop = true;
            this.p_gender_female.Text = "여성";
            this.p_gender_female.UseVisualStyleBackColor = true;
            // 
            // p_id_label
            // 
            this.p_id_label.AutoSize = true;
            this.p_id_label.Location = new System.Drawing.Point(31, 24);
            this.p_id_label.Name = "p_id_label";
            this.p_id_label.Size = new System.Drawing.Size(53, 12);
            this.p_id_label.TabIndex = 43;
            this.p_id_label.Text = "환자번호";
            // 
            // p_id_value
            // 
            this.p_id_value.Location = new System.Drawing.Point(133, 92);
            this.p_id_value.Name = "p_id_value";
            this.p_id_value.ReadOnly = true;
            this.p_id_value.Size = new System.Drawing.Size(218, 21);
            this.p_id_value.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.p_taking_pill_yes);
            this.groupBox1.Controls.Add(this.p_taking_pill_no);
            this.groupBox1.Location = new System.Drawing.Point(31, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 45);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "약 복용 유무";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.p_nose_box);
            this.groupBox2.Controls.Add(this.p_pain_box);
            this.groupBox2.Controls.Add(this.p_cough_box);
            this.groupBox2.Controls.Add(this.p_diarrhea_box);
            this.groupBox2.Location = new System.Drawing.Point(31, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 60);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "증상";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.covid19yes);
            this.groupBox3.Controls.Add(this.covid19no);
            this.groupBox3.Controls.Add(this.covid19none);
            this.groupBox3.Location = new System.Drawing.Point(31, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 45);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Covid-19 감염 유무";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.under59);
            this.groupBox4.Controls.Add(this.diabetes);
            this.groupBox4.Controls.Add(this.pragnants);
            this.groupBox4.Controls.Add(this.cancer);
            this.groupBox4.Controls.Add(this.none);
            this.groupBox4.Controls.Add(this.lung);
            this.groupBox4.Location = new System.Drawing.Point(31, 188);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(285, 60);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "고위험군 분류";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.p_vas_range);
            this.groupBox5.Controls.Add(this.p_vas_value);
            this.groupBox5.Location = new System.Drawing.Point(31, 254);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(285, 90);
            this.groupBox5.TabIndex = 47;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "통증 수치 (VAS)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(234, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 51;
            this.label12.Text = "9";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(210, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 51;
            this.label11.Text = "8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(185, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 51;
            this.label10.Text = "7";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(161, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 51;
            this.label9.Text = "6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(137, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 51;
            this.label8.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 51;
            this.label7.Text = "4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 51;
            this.label6.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 51;
            this.label5.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 51;
            this.label4.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 51;
            this.label3.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "0";
            // 
            // p_vas_range
            // 
            this.p_vas_range.BackColor = System.Drawing.SystemColors.Control;
            this.p_vas_range.LargeChange = 1;
            this.p_vas_range.Location = new System.Drawing.Point(8, 14);
            this.p_vas_range.Name = "p_vas_range";
            this.p_vas_range.Size = new System.Drawing.Size(269, 45);
            this.p_vas_range.TabIndex = 26;
            this.p_vas_range.Scroll += new System.EventHandler(this.bar_Scroll);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox1);
            this.groupBox6.Controls.Add(this.groupBox2);
            this.groupBox6.Controls.Add(this.groupBox3);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Location = new System.Drawing.Point(419, 65);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(348, 350);
            this.groupBox6.TabIndex = 48;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "증상";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.p_age_value);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.p_id_label);
            this.groupBox7.Controls.Add(this.p_user_id_value);
            this.groupBox7.Controls.Add(this.p_user_id_label);
            this.groupBox7.Controls.Add(this.p_gender_male);
            this.groupBox7.Controls.Add(this.p_address2_label);
            this.groupBox7.Controls.Add(this.p_name_value);
            this.groupBox7.Controls.Add(this.p_address2_value);
            this.groupBox7.Controls.Add(this.p_gender_female);
            this.groupBox7.Controls.Add(this.p_address1_label);
            this.groupBox7.Controls.Add(this.p_name_label);
            this.groupBox7.Controls.Add(this.p_address1_value);
            this.groupBox7.Controls.Add(this.p_regnum_value);
            this.groupBox7.Controls.Add(this.p_phone_label);
            this.groupBox7.Controls.Add(this.p_regnum_label);
            this.groupBox7.Controls.Add(this.p_phone_value);
            this.groupBox7.Controls.Add(this.p_gender_label);
            this.groupBox7.Location = new System.Drawing.Point(25, 71);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(348, 272);
            this.groupBox7.TabIndex = 49;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "정보";
            // 
            // p_age_value
            // 
            this.p_age_value.Location = new System.Drawing.Point(108, 129);
            this.p_age_value.Name = "p_age_value";
            this.p_age_value.Size = new System.Drawing.Size(218, 21);
            this.p_age_value.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "나이";
            // 
            // patient_edit_form
            // 
            this.AcceptButton = this.patienteditsave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.patienteditcancel;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this.p_id_value);
            this.Controls.Add(this.patientedit);
            this.Controls.Add(this.patienteditcancel);
            this.Controls.Add(this.patienteditsave);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "patient_edit_form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "환자 정보 수정";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.patient_edit_form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_vas_range)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button patienteditsave;
        private System.Windows.Forms.Button patienteditcancel;
        private System.Windows.Forms.TextBox p_name_value;
        private System.Windows.Forms.Label p_name_label;
        private System.Windows.Forms.Label p_regnum_label;
        private System.Windows.Forms.TextBox p_regnum_value;
        private System.Windows.Forms.Label p_gender_label;
        private System.Windows.Forms.Label p_phone_label;
        private System.Windows.Forms.TextBox p_phone_value;
        private System.Windows.Forms.Label p_address1_label;
        private System.Windows.Forms.TextBox p_address1_value;
        private System.Windows.Forms.Label p_address2_label;
        private System.Windows.Forms.TextBox p_address2_value;
        private System.Windows.Forms.Label p_user_id_label;
        private System.Windows.Forms.TextBox p_user_id_value;
        private System.Windows.Forms.CheckBox p_nose_box;
        private System.Windows.Forms.CheckBox p_cough_box;
        private System.Windows.Forms.CheckBox p_pain_box;
        private System.Windows.Forms.CheckBox p_diarrhea_box;
        private System.Windows.Forms.RadioButton covid19yes;
        private System.Windows.Forms.RadioButton covid19no;
        private System.Windows.Forms.RadioButton covid19none;
        private System.Windows.Forms.TextBox p_vas_value;
        private System.Windows.Forms.Label patientedit;
        private System.Windows.Forms.RadioButton p_taking_pill_no;
        private System.Windows.Forms.RadioButton p_taking_pill_yes;
        private System.Windows.Forms.RadioButton lung;
        private System.Windows.Forms.RadioButton pragnants;
        private System.Windows.Forms.RadioButton under59;
        private System.Windows.Forms.RadioButton none;
        private System.Windows.Forms.RadioButton cancer;
        private System.Windows.Forms.RadioButton diabetes;
        private System.Windows.Forms.RadioButton p_gender_male;
        private System.Windows.Forms.RadioButton p_gender_female;
        private System.Windows.Forms.Label p_id_label;
        private System.Windows.Forms.TextBox p_id_value;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox p_age_value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar p_vas_range;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}