using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hospital_Manage_ERP
{
    public partial class patient_edit_form : Form
    {
        private MySqlConnection conn;
        private int patientId;
        private string server;
        private string database;
        private string id;
        private string pw;
        public patient_edit_form(int patientId, string server, string database, string id, string pw)
        {
            InitializeComponent();
            this.patientId = patientId;
            this.server = server;
            this.database = database;
            this.id = id;
            this.pw = pw;
            conn = new MySqlConnection($"Server={server};Database={database};Uid={id};Pwd={pw}");
        }

        private void patient_edit_form_Load(object sender, EventArgs e)
        {
            LoadPatientInfo();
        }

        private void LoadPatientInfo()  // 선택한 환자의 데이터를 불러와 출력
        {
            try
            {
                conn.Open();
                string query = "SELECT p_id, p_user_id, p_name, p_gender, p_reg_num, p_phone, p_address1, p_address2, " +
                               "p_age, p_nose, p_cough, p_diarrhea, p_pain, p_high_risk_group, p_taking_pill, p_vas, p_covid19 " +
                               "FROM patient WHERE p_id = @p_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@p_id", patientId);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {   
                    // 환자의 인적사항 정보 가져와 출력
                    p_id_value.Text = reader["p_id"].ToString();
                    p_user_id_value.Text = reader["p_user_id"].ToString();
                    p_name_value.Text = reader["p_name"].ToString();
                    p_regnum_value.Text = reader["p_reg_num"].ToString();
                    p_phone_value.Text = reader["p_phone"].ToString();
                    p_address1_value.Text = reader["p_address1"].ToString();
                    p_address2_value.Text = reader["p_address2"].ToString();
                    p_age_value.Text = reader["p_age"].ToString();

                    int gender = Convert.ToInt32(reader["p_gender"]);
                    if      (gender == 0) { p_gender_male.Checked = true; }
                    else if (gender == 1) { p_gender_female.Checked = true; }

                    // 환자의 증상 정보 가져와 체크 적용
                    int p_nose = Convert.ToInt32(reader["p_nose"]);
                    int p_cough = Convert.ToInt32(reader["p_cough"]);
                    int p_diarrhea = Convert.ToInt32(reader["p_diarrhea"]);
                    int p_pain = Convert.ToInt32(reader["p_pain"]);
                    int p_high_risk_group = Convert.ToInt32(reader["p_high_risk_group"]);
                    int p_taking_pill = Convert.ToInt32(reader["p_taking_pill"]);
                    int p_vas = Convert.ToInt32(reader["p_vas"]);
                    int p_covid19 = Convert.ToInt32(reader["p_covid19"]);

                    if (p_nose == 1)     { p_nose_box.Checked = true; }
                    if (p_cough == 1)    { p_cough_box.Checked = true; }
                    if (p_diarrhea == 1) { p_diarrhea_box.Checked = true; }
                    if (p_pain == 1)     { p_pain_box.Checked = true; }

                    if      (p_high_risk_group == 0) { under59.Checked = true; }
                    else if (p_high_risk_group == 1) { pragnants.Checked = true; }
                    else if (p_high_risk_group == 2) { lung.Checked = true; }
                    else if (p_high_risk_group == 3) { diabetes.Checked = true; }
                    else if (p_high_risk_group == 4) { cancer.Checked = true; }
                    else                             { none.Checked = true; }

                    if (p_taking_pill == 0) { p_taking_pill_no.Checked = true; }
                    else                    { p_taking_pill_yes.Checked = true; }

                    if      (p_covid19 == 0) { covid19no.Checked = true; }
                    else if (p_covid19 == 1) { covid19yes.Checked = true; }
                    else                     { covid19none.Checked = true; }

                    p_vas_range.Value = p_vas;  // range bar에 적용
                    p_vas_value.Text = p_vas_range.Value.ToString(); // range bar값을 숫자로도 출력

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void save_button_Click(object sender, EventArgs e)
        {
            try
            {   // 저장 버튼을 누르면 입력된 값들을 가져와 DB에 저장 및 적용
                int gender = 0;
                int p_taking_pill = 0;
                int p_nose = 0;
                int p_cough = 0;
                int p_diarrhea = 0;
                int p_pain = 0;
                int p_high_risk_group = 0;
                int p_covid19 = 0;

                if      (p_gender_male.Checked)   { gender = 0; }
                else if (p_gender_female.Checked) { gender = 1; }

                if      (p_taking_pill_no.Checked)  { p_taking_pill = 0; }
                else if (p_taking_pill_yes.Checked) { p_taking_pill = 1; }

                if (p_nose_box.Checked)     { p_nose = 1; }
                if (p_cough_box.Checked)    { p_cough = 1; }
                if (p_diarrhea_box.Checked) { p_diarrhea = 1; }
                if (p_pain_box.Checked)     { p_pain = 1; }

                if      (under59.Checked)   { p_high_risk_group = 0; }
                else if (pragnants.Checked) { p_high_risk_group = 1; }
                else if (lung.Checked)      { p_high_risk_group = 2; }
                else if (diabetes.Checked)  { p_high_risk_group = 3; }
                else if (cancer.Checked)    { p_high_risk_group = 4; }
                else if (none.Checked)      { p_high_risk_group = 5; }

                if      (covid19no.Checked)   { p_covid19 = 0; }
                else if (covid19yes.Checked)  { p_covid19 = 1; }
                else if (covid19none.Checked) { p_covid19 = 2; }
                
                conn.Open();
                string query = "UPDATE patient SET p_name = @p_name, p_gender = @p_gender, p_reg_num = @p_reg_num, " +
                               "p_phone = @p_phone, p_address1 = @p_address1, p_address2 = @p_address2, p_age = @p_age, "+
                               "p_taking_pill = @p_taking_pill, p_nose = @p_nose, p_cough = @p_cough, p_diarrhea = @p_diarrhea, "+
                               "p_pain = @p_pain, p_high_risk_group = @p_high_risk_group, p_vas = @p_vas, p_covid19 = @p_covid19 "+ 
                               "WHERE p_id = @p_id"; // 수정된 환자 정보 DB 업데이트 쿼리문

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@p_id", patientId);
                cmd.Parameters.AddWithValue("@p_name", p_name_value.Text);
                cmd.Parameters.AddWithValue("@p_age", p_age_value.Text);
                cmd.Parameters.AddWithValue("@p_gender", gender);
                cmd.Parameters.AddWithValue("@p_reg_num", p_regnum_value.Text);
                cmd.Parameters.AddWithValue("@p_phone", p_phone_value.Text);
                cmd.Parameters.AddWithValue("@p_address1", p_address1_value.Text);
                cmd.Parameters.AddWithValue("@p_address2", p_address2_value.Text);
                cmd.Parameters.AddWithValue("@p_taking_pill", p_taking_pill);
                cmd.Parameters.AddWithValue("@p_nose", p_nose);
                cmd.Parameters.AddWithValue("@p_cough", p_cough);
                cmd.Parameters.AddWithValue("@p_diarrhea", p_diarrhea);
                cmd.Parameters.AddWithValue("@p_pain", p_pain);
                cmd.Parameters.AddWithValue("@p_high_risk_group", p_high_risk_group);
                cmd.Parameters.AddWithValue("@p_vas", p_vas_value.Text);
                cmd.Parameters.AddWithValue("@p_covid19", p_covid19);
                cmd.ExecuteNonQuery();

                MessageBox.Show("환자 정보가 수정되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bar_Scroll(object sender, EventArgs e)
        {
            // range bar가 움직이면 실시간으로 해당 값을 표시
            p_vas_value.Text = p_vas_range.Value.ToString();
        }

        private void box_Changed(object sender, EventArgs e)
        {
            // range bar와 text박스 입력값을 연동
            if(int.TryParse(p_vas_value.Text, out int result))
            {
                if(result >= 0 && result <= 10) // range bar 범위에 타당한 값이 입력되면 range bar 위치 조정
                {
                    p_vas_range.Value = result;
                }
                else
                {
                    MessageBox.Show("0에서 10 사이의 값을 입력해주세요.");
                    p_vas_range.Value = 0;  // 잘못된 값 입력 시 저장되는것을 방지하기 위해 0으로 강제 초기화
                    p_vas_value.Text = "0";
                }
            }
            else
            {
                MessageBox.Show("숫자를 입력해주세요.");
                p_vas_range.Value = 0;
                p_vas_value.Text = "0";
            }
        }
    }
}
