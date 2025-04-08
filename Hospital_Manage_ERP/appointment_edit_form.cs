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
    public partial class appointment_edit_form : Form
    {
        private MySqlConnection conn;
        private int appointmentId;
        private string server;
        private string database;
        private string id;
        private string pw;

        public appointment_edit_form(int appointmentId, string server, string database, string id, string pw)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;
            this.server = server;
            this.database = database;
            this.id = id;
            this.pw = pw;
            conn = new MySqlConnection($"Server={server};Database={database};Uid={id};Pwd={pw}");
            this.Load += new EventHandler(appointment_edit_form_Load);
        }
        private void appointment_edit_form_Load(object sender, EventArgs e)
        {
            LoadAppointmentInfo();
        }


        private void LoadAppointmentInfo()
        {
            try
            {
                conn.Open();
                string query = "SELECT a.id, a.appointment_time, a.created_time, " +
               "a.patient_name, a.h_id, a.user_id, " +
               "h.h_name AS hospital_name, h.h_department, h.h_categorie, h.h_phone_number, h.h_region, h.h_address, " +
               "u.user_name, u.user_reg_num, u.user_gender, u.user_phone, u.user_address1, u.user_address2 " +
               "FROM appointment a " +
               "JOIN d_hospital_v1 h ON a.h_id = h.h_id " +
               "JOIN user u ON a.user_id = u.user_id " +
               "WHERE a.id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", appointmentId);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    appointment_id_value.Text = reader["id"].ToString();
                    patient_name_value.Text = reader["patient_name"].ToString();
                    h_id_value.Text = reader["h_id"].ToString();
                    user_id_value.Text = reader["user_id"].ToString();
                    created_time_value.Text = reader["created_time"].ToString();
                    hospital_name_value.Text = reader["hospital_name"].ToString();

                    // appointment_time 필드에서 날짜와 시간을 가져오기
                    string appointmentTimeString = reader["appointment_time"].ToString();
                    // 문자열을 DateTime으로 변환
                    DateTime appointmentTime = DateTime.Parse(appointmentTimeString);
                    // 연도, 월, 일, 시, 분을 각각 텍스트 박스에 넣기
                    appointment_year_value.Text = appointmentTime.Year.ToString();
                    appointment_month_value.Text = appointmentTime.Month.ToString("D2");  // 두 자릿수로 표시 (예: 03)
                    appointment_day_value.Text = appointmentTime.Day.ToString("D2");    // 두 자릿수로 표시 (예: 09)
                    appointment_hour_value.Text = appointmentTime.Hour.ToString("D2");  // 두 자릿수로 표시 (예: 02)
                    appointment_minute_value.Text = appointmentTime.Minute.ToString("D2");  // 두 자릿수로 표시 (예: 09)

                    user_name_value.Text = reader["user_name"].ToString();
                    int gender = Convert.ToInt32(reader["user_gender"]);
                    if(gender == 0)
                    {
                        user_gender_value.Text = "남성";
                    }
                    else
                    {
                        user_gender_value.Text = "여성";
                    }
                    user_regnum_value.Text = reader["user_reg_num"].ToString();
                    user_address1_value.Text = reader["user_address1"].ToString();
                    user_address2_value.Text = reader["user_address2"].ToString();
                    user_phone_value.Text = reader["user_phone"].ToString();
                   
                    hospital_department_value.Text = reader["h_department"].ToString();
                    hospital_categorie_value.Text = reader["h_categorie"].ToString();
                    hospital_phone_value.Text = reader["h_phone_number"].ToString();
                    hospital_region_value.Text = reader["h_region"].ToString();
                    hospital_address1_value.Text = reader["h_address"].ToString();


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


        private void appointment_edit_save_button_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                // 사용자가 입력한 연도, 월, 일, 시, 분 값을 가져옴
                int year = Convert.ToInt32(appointment_year_value.Text);
                int month = Convert.ToInt32(appointment_month_value.Text);
                int day = Convert.ToInt32(appointment_day_value.Text);
                int hour = Convert.ToInt32(appointment_hour_value.Text);
                int minute = Convert.ToInt32(appointment_minute_value.Text);

                // 새로운 DateTime 객체를 만듬
                DateTime appointmentTime = new DateTime(year, month, day, hour, minute, 0);
                // 새롭게 만든 DateTime 객체를 MySQL에 맞는 형식으로 변환
                string appointmentTimeString = appointmentTime.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "UPDATE appointment SET patient_name = @patient_name, appointment_time = @appointment_time WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);


                // 사용자 입력값을 파라미터로 추가
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(appointment_id_value.Text));
                cmd.Parameters.AddWithValue("@patient_name", patient_name_value.Text);
                cmd.Parameters.AddWithValue("@appointment_time", appointmentTimeString);


                cmd.ExecuteNonQuery();
                MessageBox.Show("예약 정보가 수정되었습니다.");
                this.DialogResult = DialogResult.OK; // OK로 설정하여 병원 생성이 완료되었음을 알림
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
        private void appointment_cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
