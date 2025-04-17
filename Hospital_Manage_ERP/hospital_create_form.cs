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
    public partial class hospital_create_form : Form
    {
        private string server;
        private string db;
        private string id;
        private string pw;
        private MySqlConnection conn;

        public hospital_create_form(string server, string db, string id, string pw)
        {
            InitializeComponent();
            conn = new MySqlConnection($"Server={server};Database={db};Uid={id};Pwd={pw}");
            this.server = server;
            this.db = db;
            this.id = id;
            this.pw = pw;
        }

        private void hospital_create_form_Load(object sender, EventArgs e)
        {
            LoadHospitalNumber();
        }

        private void LoadHospitalNumber()   // h_id (primary key) 값 설정을 위한 메서드
        {
            try
            {
                conn.Open();
                string query = "SELECT MAX(h_id) FROM d_hospital_v1"; // 가장 마지막 (높은) pk값을 불러옴
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() && reader[0] != DBNull.Value) // DB가 있을경우
                {
                    h_id_value.Text = (Convert.ToInt32(reader[0]) + 1).ToString();  // 불러온 가장 마지막 pk값에 1을 더하여 pk값 지정
                }
                else    // DB가 비어있을경우
                {
                    h_id_value.Text = "1"; // 첫번째 데이터 이므로 1로 지정
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
        private void hospital_create_button_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO d_hospital_v1 (h_id, h_name, h_region, h_address, h_department, h_categorie, " +
                                   "h_phone_number, bed_total, bed_general, bed_nursing, bed_intensive, bed_isolation, bed_psy, bed_clean, " +
                                   "h_latitude, h_longitude) VALUES (@h_id, @h_name, @h_region, @h_address, @h_department, @h_categorie, " +
                                   "@h_phone_number, @bed_total, @bed_general, @bed_nursing, @bed_intensive, @bed_isolation, @bed_psy, @bed_clean, " +
                                   "@h_latitude, @h_longitude)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@h_id", h_id_value.Text);  // 상단에서 지정된 pk 값으로 설정하며 이는 사용자가 임의로 수정할 수 없음
                cmd.Parameters.AddWithValue("@h_name", h_name_value.Text);  // 각종 병원 정보 삽입
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
                cmd.Parameters.AddWithValue("@h_latitude", 36.12345678);    // 위도 경도는 별도의 주소 변환 과정이 필요해 예시 값으로 설정
                cmd.Parameters.AddWithValue("@h_longitude", 128.12345678);
                cmd.ExecuteNonQuery();
                MessageBox.Show("병원 정보가 추가되었습니다.");
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
        private void hospital_cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
