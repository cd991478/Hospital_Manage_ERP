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

                if (reader.Read())  // 예약자 정보, 병원 정보, 예약 시간 정보 표시
                {
                    appointment_id_value.Text = reader["id"].ToString();
                    patient_name_value.Text = reader["patient_name"].ToString();
                    h_id_value.Text = reader["h_id"].ToString();
                    user_id_value.Text = reader["user_id"].ToString();
                    created_time_value.Text = reader["created_time"].ToString();
                    hospital_name_value.Text = reader["hospital_name"].ToString();

                    // 날짜 변환
                    string appointmentTimeString = reader["appointment_time"].ToString();
                    DateTime appointmentTime = DateTime.Parse(appointmentTimeString);
                    appointment_year_value.Text = appointmentTime.Year.ToString();
                    appointment_month_value.Text = appointmentTime.Month.ToString("D2");  // 2자리 단위로 끊어서 표시
                    appointment_day_value.Text = appointmentTime.Day.ToString("D2");
                    appointment_hour_value.Text = appointmentTime.Hour.ToString("D2");
                    appointment_minute_value.Text = appointmentTime.Minute.ToString("D2");

                    int gender = Convert.ToInt32(reader["user_gender"]);
                    if(gender == 0) {user_gender_value.Text = "남성";}
                    else            {user_gender_value.Text = "여성";}

                    user_name_value.Text = reader["user_name"].ToString();
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
            {   // 예약 정보 수정
                conn.Open();
                int year = Convert.ToInt32(appointment_year_value.Text);
                int month = Convert.ToInt32(appointment_month_value.Text);
                int day = Convert.ToInt32(appointment_day_value.Text);
                int hour = Convert.ToInt32(appointment_hour_value.Text);
                int minute = Convert.ToInt32(appointment_minute_value.Text);

                DateTime appointmentTime = new DateTime(year, month, day, hour, minute, 0);
                string appointmentTimeString = appointmentTime.ToString("yyyy-MM-dd HH:mm:ss"); // MySQL 형식 날짜로 변환

                string query = "UPDATE appointment SET patient_name = @patient_name, appointment_time = @appointment_time WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(appointment_id_value.Text));
                cmd.Parameters.AddWithValue("@patient_name", patient_name_value.Text);
                cmd.Parameters.AddWithValue("@appointment_time", appointmentTimeString);
                cmd.ExecuteNonQuery();

                MessageBox.Show("예약 정보가 수정되었습니다.");
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
        private void appointment_cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
