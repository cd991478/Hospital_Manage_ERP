using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Manage_ERP
{
    public partial class hospital_edit_form : Form
    {
        private MySqlConnection conn;
        private int hospitalId;
        private string server;
        private string database;
        private string id;
        private string pw;

        public hospital_edit_form(int hospitalId, string server, string database, string id, string pw)
        {
            InitializeComponent();
            this.hospitalId = hospitalId;
            this.server = server;
            this.database = database;
            this.id = id;
            this.pw = pw;
            conn = new MySqlConnection($"Server={server};Database={database};Uid={id};Pwd={pw}");
            this.Load += new EventHandler(hospital_edit_form_Load);
            
        }

        private void hospital_edit_form_Load(object sender, EventArgs e)
        {
            LoadHospitalInfo();
        }

        private void LoadHospitalInfo()
        {
            try
            {
                conn.Open();
                string query = "SELECT h_id, h_name, h_region, h_address, h_categorie, " +
                    "h_department, h_phone_number, bed_total, bed_general, bed_psy, bed_nursing, bed_intensive, bed_isolation, bed_clean, " +
                    "h_latitude, h_longitude FROM d_hospital_v1 WHERE h_id = @h_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@h_id", hospitalId);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    h_id_value.Text = reader["h_id"].ToString();
                    h_name_value.Text = reader["h_name"].ToString();
                    h_region_value.Text = reader["h_region"].ToString();
                    h_address_value.Text = reader["h_address"].ToString();
                    h_department_value.Text = reader["h_department"].ToString();
                    h_categorie_value.Text = reader["h_categorie"].ToString();
                    h_phone_number_value.Text = reader["h_phone_number"].ToString();

                    bed_total_value.Text = reader["bed_total"].ToString();
                    bed_general_value.Text = reader["bed_general"].ToString();
                    bed_psy_value.Text = reader["bed_psy"].ToString();
                    bed_nursing_value.Text = reader["bed_nursing"].ToString();
                    bed_intensive_value.Text = reader["bed_intensive"].ToString();
                    bed_isolation_value.Text = reader["bed_isolation"].ToString();
                    bed_clean_value.Text = reader["bed_clean"].ToString();

                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void hospital_edit_save_button_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "UPDATE d_hospital_v1 SET h_name = @h_name, h_region = @h_region, h_address = @h_address, h_phone_number = @h_phone_number, h_department = @h_department, h_categorie = @h_categorie, " +
                    "bed_total = @bed_total, bed_general = @bed_general, bed_psy = @bed_psy, bed_nursing = @bed_nursing, bed_intensive = @bed_intensive, " +
                    "bed_isolation = @bed_isolation, bed_clean = @bed_clean WHERE h_id = @h_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // 사용자 입력값을 파라미터로 추가
                cmd.Parameters.AddWithValue("@h_id", Convert.ToInt32(h_id_value.Text));
                cmd.Parameters.AddWithValue("@h_name", h_name_value.Text);
                cmd.Parameters.AddWithValue("@h_region", h_region_value.Text);
                cmd.Parameters.AddWithValue("@h_address", h_address_value.Text);
                cmd.Parameters.AddWithValue("@h_department", h_department_value.Text);
                cmd.Parameters.AddWithValue("@h_categorie", h_categorie_value.Text);
                cmd.Parameters.AddWithValue("@h_phone_number", h_phone_number_value.Text);
                cmd.Parameters.AddWithValue("@bed_total", Convert.ToInt32(bed_total_value.Text));
                cmd.Parameters.AddWithValue("@bed_general", Convert.ToInt32(bed_general_value.Text));
                cmd.Parameters.AddWithValue("@bed_nursing", Convert.ToInt32(bed_nursing_value.Text));
                cmd.Parameters.AddWithValue("@bed_intensive", Convert.ToInt32(bed_intensive_value.Text));
                cmd.Parameters.AddWithValue("@bed_isolation", Convert.ToInt32(bed_isolation_value.Text));
                cmd.Parameters.AddWithValue("@bed_psy", Convert.ToInt32(bed_psy_value.Text));
                cmd.Parameters.AddWithValue("@bed_clean", Convert.ToInt32(bed_clean_value.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("병원 정보가 수정되었습니다.");
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
        private void hospital_cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
