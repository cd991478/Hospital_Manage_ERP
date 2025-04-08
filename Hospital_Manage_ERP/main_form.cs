using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Hospital_Manage_ERP;
using System.Xml.Linq;
namespace Hospital_Manage_ERP
{
    public partial class main_form : Form // 메인 화면
    {
        private string server; 
        private string database;
        private string id;
        private string pw;
        private string connectionString;
        public static string SearchFirst { get; set; } // 검색 text 값 1
        public static string SearchSecond { get; set; } // 검색 text 값 2

        private MySqlConnection conn;
        private ProgressForm progressform;
        

        public main_form(string login_server, string login_database, string login_id, string login_pw)
        {
            InitializeComponent();
            server = login_server;
            database = login_database;
            id = login_id;
            pw = login_pw;
            connectionString = $"Server={server};Database={database};Uid={id};Pwd={pw};";
            conn = new MySqlConnection(connectionString);
            
            try
            {
                conn.Open();
                //MessageBox.Show("MySQL 연결 성공!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            // ProgressForm의 인스턴스를 생성
            progressform = new ProgressForm();
        }

        private async void main_form_Load(object sender, EventArgs e)
        {
            progressform.Show();
            // 전체 데이터를 비동기로 로드
            await LoadDataAsync();
            progressform.Close();
        }

        // FormClosing 이벤트 (프로그램 종료 시 자원 정리)
        private void main_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("정말 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
                // MySQL 연결 닫기
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            Environment.Exit(0);
        }

        private async Task LoadDataAsync()
        {
            // 데이터 로드를 비동기로 처리
            await Task.Run(() =>
            {
                LoadPatientInfo();
                LoadAppointmentInfo();
                LoadHospitalList();
                LoadUserInfo();
            });
            
        }

        // 공통 데이터 로딩 메서드
        private void LoadData(string query, DataGridView dataGrid, Action<DataTable> customizeColumns = null)
        {
            try
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // 데이터 바인딩
                dataGrid.Invoke(new Action(() => { dataGrid.DataSource = dataTable; }));

                // 컬럼 크기 조정 또는 커스터마이징
                customizeColumns?.Invoke(dataTable); // 선택적으로 컬럼을 커스터마이즈

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // 환자 정보 로드
        private void LoadPatientInfo()
        {
            string query = "SELECT p_id AS '환자번호', " +
                "p_user_id AS '등록 아이디', " +
                "p_name AS '이름', " +
                "CASE WHEN p_gender = 0 THEN '남자' WHEN p_gender = 1 THEN '여자' ELSE '알 수 없음' END AS '성별', " +
                "p_reg_num AS '주민번호 앞 6자리', " +
                "p_age AS '나이', " +
                "p_phone AS '전화번호', " +
                "p_address1 AS '주소', " +
                "p_address2 AS '주소상세', " +
                "p_insert_date_time AS '등록일시', " +
                "CASE WHEN p_taking_pill = 0 THEN '무' WHEN p_taking_pill = 1 THEN '유' ELSE '알 수 없음' END AS '약 복용 유무', " +
                "CASE WHEN p_nose = 0 THEN '무' WHEN p_nose = 1 THEN '유' ELSE '알 수 없음' END AS '콧물 혹은 코막힘', " +
                "CASE WHEN p_cough = 0 THEN '무' WHEN p_cough = 1 THEN '유' ELSE '알 수 없음' END AS '기침 또는 거래', " +
                "CASE WHEN p_pain = 0 THEN '무' WHEN p_pain = 1 THEN '유' ELSE '알 수 없음' END AS '통증', " +
                "CASE WHEN p_diarrhea = 0 THEN '무' WHEN p_diarrhea = 1 THEN '유' ELSE '알 수 없음' END AS '설사', " +
                "CASE WHEN p_covid19 = 0 THEN '무' WHEN p_covid19 = 1 THEN '유' WHEN p_covid19 = 2 THEN '모름' ELSE '알 수 없음' END AS 'Covid-19 감염 유무', " +
                "CASE WHEN p_high_risk_group = 0 THEN '59개월 이하의 소아' " +
                "WHEN p_high_risk_group = 1 THEN '임산부' " +
                "WHEN p_high_risk_group = 2 THEN '만성 폐질환' " +
                "WHEN p_high_risk_group = 3 THEN '당뇨' " +
                "WHEN p_high_risk_group = 4 THEN '암환자' " +
                "WHEN p_high_risk_group = 5 THEN '해당없음' " +
                "ELSE '알 수 없음' END AS '고위험군 분류', " +
                "p_vas AS '시각통증수치 (VAS)' " +
                "FROM patient";

            LoadData(query, patient_list, (dataTable) =>
            {
                patient_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                patient_list.Columns["주소"].Width = 400;
            });
        }

        // 예약 정보 로드
        private void LoadAppointmentInfo()
        {
            string query = "SELECT a.id AS '예약번호', a.h_id AS '병원 번호', a.user_id AS '회원아이디', " +
                "a.patient_name AS '예약자명', h.h_name AS '병원명', a.appointment_time AS '예약 시간', " +
                "a.created_time AS '등록 시간', " +
                "u.user_phone AS '예약자 전화번호' " +
                "FROM appointment a " +
                "JOIN d_hospital_v1 h ON a.h_id = h.h_id " +
                "JOIN user u ON a.user_id = u.user_id";

            LoadData(query, appointment_list, (dataTable) =>
            {
                appointment_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                appointment_list.Columns["병원명"].Width = 200;
                appointment_list.Columns["예약 시간"].Width = 150;
                appointment_list.Columns["등록 시간"].Width = 150;
            });
        }

        // 병원 목록 로드
        private void LoadHospitalList()
        {
            string query = "SELECT h_id AS '병원번호', h_name AS '병원명', h_department AS '분류1', h_categorie AS '분류2', " +
                "h_region AS '지역', h_address AS '주소', h_latitude AS '위도', h_longitude AS '경도', " +
                "Bed_Total AS '총 병상', Bed_General AS '일반병상', Bed_Psy AS '정신과병상', Bed_Nursing AS '요양병상', " +
                "Bed_Intensive AS '중환자실병상', Bed_Isolation AS '격리병상', Bed_Clean AS '무균병상' FROM d_hospital_v1";

            LoadData(query, hospital_list, (dataTable) =>
            {
                hospital_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                hospital_list.Columns["주소"].Width = 400;
            });
        }

        // 사용자 정보 로드
        private void LoadUserInfo()
        {
            string query = "SELECT user_id AS '아이디', user_name AS '이름', CASE WHEN user_gender = 0 THEN '남성' WHEN user_gender = 1 THEN '여성' ELSE '알 수 없음'  END AS '성별', " +
                "user_reg_num AS '주민번호 앞 6자리', user_phone AS '전화번호', user_address1 AS '주소', " +
                "user_address2 AS '주소 상세', insert_date_time AS '가입일시' FROM user";

            LoadData(query, user_list, (dataTable) =>
            {
                user_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                user_list.Columns["주소"].Width = 400;
                user_list.Columns["가입일시"].Width = 150;
            });
        }



        private void patientedit_Click(object sender, EventArgs e)
        {
            if (patient_list.SelectedRows.Count > 0)
            {
                // 환자 ID 가져옴
                int selectedPatientId = Convert.ToInt32(patient_list.SelectedRows[0].Cells["환자번호"].Value);
                patient_edit_form p_edit = new patient_edit_form(selectedPatientId, server, database, id, pw);
                DialogResult result = p_edit.ShowDialog();
                if(result == DialogResult.OK)
                {
                    LoadPatientInfo();
                }
            }
            else
            {
                MessageBox.Show("수정할 환자를 선택하세요.");
            }
        }

        private void appointment_edit_Click(object sender, EventArgs e)
        {
            if(appointment_list.SelectedRows.Count > 0)
            {
                int selectedAppointmentId = Convert.ToInt32(appointment_list.SelectedRows[0].Cells["예약번호"].Value);
                appointment_edit_form appointmenteditform = new appointment_edit_form(selectedAppointmentId, server, database, id, pw);
                DialogResult result = appointmenteditform.ShowDialog();
                if(result == DialogResult.OK)
                {
                    LoadAppointmentInfo();
                }
            }
            else
            {
                MessageBox.Show("수정할 예약을 선택해주세요.");
            }
        }

        private void hospital_edit_Click(object sender, EventArgs e)
        {
            if (hospital_list.SelectedRows.Count > 0)
            {
                int selectedHospitalId = Convert.ToInt32(hospital_list.SelectedRows[0].Cells["병원번호"].Value);
                hospital_edit_form hospitaleditform = new hospital_edit_form(selectedHospitalId, server, database, id, pw);
                DialogResult result = hospitaleditform.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadHospitalList();
                }
            }
            else
            {
                MessageBox.Show("수정할 병원을 선택해주세요.");
            }

        }

        private void hospital_create_Click(object sender, EventArgs e)
        {
            hospital_create_form hospitalcreateform = new hospital_create_form(server, database ,id ,pw);
            DialogResult result = hospitalcreateform.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadHospitalList();
            }

        }
        // 삭제기능 개선 전 코드
        //private void patientdelete_Click(object sender, EventArgs e)
        //{
        //    if (patient_list.SelectedRows.Count > 0)
        //    {

        //        List<int> selectedPatientId = new List<int>();
        //        if (patient_list.SelectedRows.Count == 1)
        //        {
        //            var result = MessageBox.Show("해당 환자 정보가 삭제됩니다.\n계속하시겠습니까?", "환자 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //            if (result == DialogResult.No)
        //            {
        //                return; // 사용자가 'No'를 선택하면 삭제를 취소
        //            }
        //            selectedPatientId.Add(Convert.ToInt32(patient_list.SelectedRows[0].Cells["환자번호"].Value));
        //        }
        //        else
        //        {
        //            var result = MessageBox.Show($"{patient_list.SelectedRows.Count}명의 환자 정보가 삭제됩니다.\n계속하시겠습니까?", "환자 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //            if (result == DialogResult.No)
        //            {
        //                return; // 사용자가 'No'를 선택하면 삭제를 취소
        //            }

        //            for(int i = 0; i<patient_list.SelectedRows.Count; i++){
        //                selectedPatientId.Add(Convert.ToInt32(patient_list.SelectedRows[i].Cells["환자번호"].Value));
        //            }
        //        }


        //        try
        //        {
        //            conn.Open();
        //            for (int i = 0; i < selectedPatientId.Count; i++)
        //            {
        //                string query = "DELETE FROM patient WHERE p_id = @p_id";
        //                MySqlCommand cmd = new MySqlCommand(query, conn);
        //                cmd.Parameters.AddWithValue("@p_id", selectedPatientId[i]);
        //                cmd.ExecuteNonQuery();
        //            }
        //            MessageBox.Show("환자 정보가 삭제되었습니다.");
        //            conn.Close();
        //            LoadPatientInfo();  // 데이터 새로고침
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("오류: " + ex.Message);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("삭제할 데이터를 선택해주세요.");
        //    }
        //}


        //private void appointment_delete_Click(object sender, EventArgs e)
        //{
        //    if (appointment_list.SelectedRows.Count > 0)
        //    {
        //        List<int> selectedAppointmentId = new List<int>();
        //        if (appointment_list.SelectedRows.Count == 1)
        //        {
        //            var result = MessageBox.Show("해당 예약 정보가 삭제됩니다.\n계속하시겠습니까?", "예약 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //            if (result == DialogResult.No)
        //            {
        //                return; // 사용자가 'No'를 선택하면 삭제를 취소
        //            }
        //            selectedAppointmentId.Add(Convert.ToInt32(appointment_list.SelectedRows[0].Cells["예약번호"].Value));
        //        }
        //        else
        //        {
        //            var result = MessageBox.Show($"{appointment_list.SelectedRows.Count}개의 예약 정보가 삭제됩니다.\n계속하시겠습니까?", "예약 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //            if (result == DialogResult.No)
        //            {
        //                return; // 사용자가 'No'를 선택하면 삭제를 취소
        //            }
        //            for (int i = 0; i < appointment_list.SelectedRows.Count; i++)
        //            {
        //                selectedAppointmentId.Add(Convert.ToInt32(appointment_list.SelectedRows[i].Cells["예약번호"].Value));
        //            }
        //        }
        //        try
        //        {
        //            conn.Open();
        //            for (int i = 0; i < selectedAppointmentId.Count; i++)
        //            {
        //                string query = "DELETE FROM appointment WHERE id = @id";
        //                MySqlCommand cmd = new MySqlCommand(query, conn);
        //                cmd.Parameters.AddWithValue("@id", selectedAppointmentId[i]);
        //                cmd.ExecuteNonQuery();
        //            }
        //            MessageBox.Show("예약 정보가 삭제되었습니다.");
        //            conn.Close();
        //            LoadAppointmentInfo();  // 데이터 새로고침
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("오류: " + ex.Message);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("삭제할 데이터를 선택해주세요.");
        //    }
        //}


        //private void hospital_delete_Click(object sender, EventArgs e)
        //{
        //    if (hospital_list.SelectedRows.Count > 0)
        //    {
        //        List<int> selectedHospitalId = new List<int>();
        //        if (hospital_list.SelectedRows.Count == 1)
        //        {
        //            var result = MessageBox.Show("해당 병원 정보가 삭제됩니다.\n계속하시겠습니까?", "병원 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //            if (result == DialogResult.No)
        //            {
        //                return; // 사용자가 'No'를 선택하면 삭제를 취소
        //            }
        //            selectedHospitalId.Add(Convert.ToInt32(hospital_list.SelectedRows[0].Cells["병원번호"].Value));
        //        }
        //        else {
        //            var result = MessageBox.Show($"{hospital_list.SelectedRows.Count}개의 병원 정보가 삭제됩니다.\n계속하시겠습니까?", "병원 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //            if (result == DialogResult.No)
        //            {
        //                return; // 사용자가 'No'를 선택하면 삭제를 취소
        //            }
        //            for (int i = 0; i < hospital_list.SelectedRows.Count; i++)
        //            {
        //                selectedHospitalId.Add(Convert.ToInt32(hospital_list.SelectedRows[i].Cells["병원번호"].Value));
        //            }
        //        }
        //        try
        //        {
        //            conn.Open();
        //            for (int i = 0; i < selectedHospitalId.Count; i++)
        //            {
        //                string query = "DELETE FROM d_hospital_v1 WHERE h_id = @h_id";
        //                MySqlCommand cmd = new MySqlCommand(query, conn);
        //                cmd.Parameters.AddWithValue("@h_id", selectedHospitalId[i]);
        //                cmd.ExecuteNonQuery();
        //            }
        //            MessageBox.Show("병원 정보가 삭제되었습니다.");
        //            conn.Close();
        //            LoadHospitalList();  // 데이터 새로고침
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("오류: " + ex.Message);
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("삭제할 데이터를 선택해주세요.");
        //    }
        //}

        private void DeleteData(DataGridView dataGridView, string tableNameKor, string tableName, string idStyle)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 데이터를 선택해주세요.");
                return;
            }

            List<int> selectedId = new List<int>();
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                selectedId.Add(Convert.ToInt32(row.Cells[tableNameKor].Value));
            }
            string table;
            if(tableName == "patient") { table = "환자"; }
            else if(tableName == "appointment") { table = "예약"; }
            else if(tableName == "v_hospital_v1") { table = "병원"; }
            else { table = ""; }
            var result = MessageBox.Show($"{selectedId.Count}개의 {table} 정보를 삭제합니다.\n계속하시겠습니까?",
                                         $"{table} 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            conn.Open();
            try
            {
                foreach (int id in selectedId)
                {
                    string query = $"DELETE FROM {tableName} WHERE {idStyle} = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show($"{table} 정보가 삭제되었습니다.");
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

        private void patientdelete_Click(object sender, EventArgs e)
        {
            DeleteData(patient_list, "환자번호", "patient", "p_id");
        }

        private void appointment_delete_Click(object sender, EventArgs e)
        {
            DeleteData(appointment_list, "예약번호", "appointment", "id");
        }

        private void hospital_delete_Click(object sender, EventArgs e)
        {
            DeleteData(hospital_list, "병원번호", "d_hospital_v1", "h_id");
        }

        private void user_delete_Click(object sender, EventArgs e)
        {
            if (user_list.SelectedRows.Count > 0)
            {
                List<string> selectedUserId = new List<string>();
                if (user_list.SelectedRows.Count == 1)
                {
                    var result = MessageBox.Show("해당 회원 정보 및 관련된 모든 예약 정보가 삭제됩니다.\n계속하시겠습니까?", "회원 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return; // 사용자가 'No'를 선택하면 삭제를 취소
                    }
                    selectedUserId.Add(Convert.ToString(user_list.SelectedRows[0].Cells["아이디"].Value));
                }
                else
                {
                    var result = MessageBox.Show($"{user_list.SelectedRows.Count}명의 회원 정보 및 관련된 모든 예약 정보가 삭제됩니다.\n계속하시겠습니까?", "회원 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return; // 사용자가 'No'를 선택하면 삭제를 취소
                    }
                    for (int i = 0; i < user_list.SelectedRows.Count; i++)
                    {
                        selectedUserId.Add(Convert.ToString(user_list.SelectedRows[i].Cells["아이디"].Value));
                    }
                }
                for (int i = 0; i < selectedUserId.Count; i++) {
                    if (selectedUserId[i] == "admin")
                    {
                        MessageBox.Show("관리자 계정은 삭제 할 수 없습니다.");
                        return;
                    }
                }
                try
                {
                    conn.Open();
                    for (int i = 0; i < selectedUserId.Count; i++)
                    {
                        string query1 = "DELETE FROM appointment WHERE user_id = @user_id";
                        MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                        cmd1.Parameters.AddWithValue("@user_id", selectedUserId[i]);
                        cmd1.ExecuteNonQuery();
                    }
                    for (int i = 0; i < selectedUserId.Count; i++)
                    {
                        string query2 = "DELETE FROM user WHERE user_id = @user_id";
                        MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                        cmd2.Parameters.AddWithValue("@user_id", selectedUserId[i]);
                        cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show("회원 정보 및 예약 정보가 삭제되었습니다.");
                    conn.Close();
                    LoadAppointmentInfo();
                    LoadUserInfo();  // 데이터 새로고침
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
            else
            {
                MessageBox.Show("삭제할 데이터를 선택해주세요.");
            }
        }

        private void patient_refresh_Click(object sender, EventArgs e)
        {
            patient_list.Columns.Clear();
            LoadPatientInfo();
        }

        private void appointment_refresh_Click(object sender, EventArgs e)
        {
            appointment_list.Columns.Clear();
            LoadAppointmentInfo();
        }

        private void hospital_refresh_Click(object sender, EventArgs e)
        {
            hospital_list.Columns.Clear();
            LoadHospitalList();
        }

        private void user_refresh_Click(object sender, EventArgs e)
        {
            user_list.Columns.Clear();
            LoadUserInfo();
        }
        
        private void patient_search_Click(object sender, EventArgs e)
        {
            patient_search_form patientsearchform = new patient_search_form();
            patientsearchform.ShowDialog();
            if(patientsearchform.DialogResult == DialogResult.OK)
            {
                try
                {
                    conn.Open();
                    string firstinput = patient_search_form.SearchFirst;
                    string secondinput = patient_search_form.SearchSecond;
                    string query = "SELECT p_id AS '환자번호', " +
                               "p_user_id AS '등록 아이디', " +
                               "p_name AS '이름', " +
                               "CASE WHEN p_gender = 0 THEN '남자' WHEN p_gender = 1 THEN '여자' ELSE '알 수 없음' END AS '성별', " +
                               "p_reg_num AS '주민번호 앞 6자리', " +
                               "p_age AS '나이', " +
                               "p_phone AS '전화번호', " +
                               "p_address1 AS '주소', " +
                               "p_address2 AS '주소상세', " +
                               "p_insert_date_time AS '등록일시', " +
                               "CASE WHEN p_taking_pill = 0 THEN '무' WHEN p_taking_pill = 1 THEN '유' ELSE '알 수 없음' END AS '약 복용 유무', " +
                               "CASE WHEN p_nose = 0 THEN '무' WHEN p_nose = 1 THEN '유' ELSE '알 수 없음' END AS '콧물 혹은 코막힘', " +
                               "CASE WHEN p_cough = 0 THEN '무' WHEN p_cough = 1 THEN '유' ELSE '알 수 없음' END AS '기침', " +
                               "CASE WHEN p_pain = 0 THEN '무' WHEN p_pain = 1 THEN '유' ELSE '알 수 없음' END AS '통증', " +
                               "CASE WHEN p_diarrhea = 0 THEN '무' WHEN p_diarrhea = 1 THEN '유' ELSE '알 수 없음' END AS '설사', " +
                               "CASE WHEN p_covid19 = 0 THEN '무' WHEN p_covid19 = 1 THEN '유' WHEN p_covid19 = 2 THEN '모름' ELSE '알 수 없음' END AS 'Covid-19 감염 유무', " +
                               "CASE WHEN p_high_risk_group = 0 THEN '59개월 이하의 소아' " +
                               "WHEN p_high_risk_group = 1 THEN '임산부' " +
                               "WHEN p_high_risk_group = 2 THEN '만성 폐질환' " +
                               "WHEN p_high_risk_group = 3 THEN '당뇨' " +
                               "WHEN p_high_risk_group = 4 THEN '암환자' " +
                               "WHEN p_high_risk_group = 5 THEN '해당없음' " +
                               "ELSE '알 수 없음' END AS '고위험군 분류', " +
                               "p_vas AS '시각통증수치 (VAS)' " +
                               "FROM patient " +
                               "WHERE p_name LIKE @p_name AND p_reg_num LIKE @p_reg_num";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@p_name", "%" + firstinput + "%");
                    cmd.Parameters.AddWithValue("@p_reg_num", "%" + secondinput + "%");

                    // MySqlDataReader로 데이터 가져오기
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // DataTable에 데이터를 로드
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    patient_list.DataSource = dataTable; // DataGridView에 데이터 표시
                    // 출력된 결과 개수 카운트
                    int resultCount = dataTable.Rows.Count;
                    if (resultCount > 0)
                    {
                        MessageBox.Show($"총 {resultCount}개의 데이터가 검색 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("검색된 데이터가 없습니다.");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void appointment_search_Click(object sender, EventArgs e)
        {
            appointment_search_form appointmentsearchform = new appointment_search_form();
            appointmentsearchform.ShowDialog();
            if (appointmentsearchform.DialogResult == DialogResult.OK)
            {
                try
                {
                    conn.Open();
                    string firstinput = appointment_search_form.SearchFirst;
                    string secondinput = appointment_search_form.SearchSecond;
                    string query = "SELECT a.id AS '예약번호', " +
                    "a.patient_name AS '예약자 이름', " +
                    "u.user_reg_num AS '주민번호 앞 6자리', "+
                    "a.user_id AS '예약자 아이디', " +
                    "a.h_id AS '예약 병원 번호', " +
                    "a.appointment_time AS '예약 시간', " +
                    "a.created_time AS '등록 시간' " +
                    "FROM appointment a JOIN user u ON a.user_id = u.user_id " +
                    "WHERE patient_name LIKE @patient_name AND user_reg_num LIKE @user_reg_num";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@patient_name", "%" + firstinput + "%");
                    cmd.Parameters.AddWithValue("@user_reg_num", "%" + secondinput + "%");

                    // MySqlDataReader로 데이터 가져오기
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // DataTable에 데이터를 로드
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    appointment_list.DataSource = dataTable; // DataGridView에 데이터 표시
                    // 출력된 결과 개수 카운트
                    int resultCount = dataTable.Rows.Count;
                    if (resultCount > 0)
                    {
                        MessageBox.Show($"총 {resultCount}개의 데이터가 검색 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("검색된 데이터가 없습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void hospital_search_Click(object sender, EventArgs e)
        {
            hospital_search_form hospitalsearchform = new hospital_search_form();
            hospitalsearchform.ShowDialog();
            if (hospitalsearchform.DialogResult == DialogResult.OK)
            {
                try
                {
                    conn.Open();
                    string firstinput = hospital_search_form.SearchFirst;
                    string secondinput = hospital_search_form.SearchSecond;
                    string query = "SELECT h_id AS '병원번호', h_name AS '병원명', h_department AS '분류1', h_categorie AS '분류2', "+ 
                        "h_region AS '지역', h_address AS '주소', h_latitude AS '위도', h_longitude AS '경도', Bed_Total AS '총 병상', "+
                        "Bed_General AS '일반병상', Bed_Psy AS '정신과병상', Bed_Nursing AS '요양병상', Bed_Intensive AS '중환자실병상', "+
                        "Bed_Isolation AS '격리병상', Bed_Clean AS '무균병상' FROM d_hospital_v1 "+
                        "WHERE h_address LIKE @h_address AND h_categorie LIKE @h_categorie";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@h_address", "%" + firstinput + "%");
                    cmd.Parameters.AddWithValue("@h_categorie", "%" + secondinput + "%");

                    // MySqlDataReader로 데이터 가져오기
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // DataTable에 데이터를 로드
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    hospital_list.DataSource = dataTable; // DataGridView에 데이터 표시
                    // 출력된 결과 개수 카운트
                    int resultCount = dataTable.Rows.Count;
                    if (resultCount > 0)
                    {
                        MessageBox.Show($"총 {resultCount}개의 데이터가 검색 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("검색된 데이터가 없습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void user_search_Click(object sender, EventArgs e)
        {
            user_search_form usersearchform = new user_search_form();
            usersearchform.ShowDialog();
            if (usersearchform.DialogResult == DialogResult.OK)
            {
                try
                {
                    conn.Open();
                    string firstinput = user_search_form.SearchFirst;
                    string secondinput = user_search_form.SearchSecond;
                    string query = "SELECT user_id AS '아이디', user_name AS '이름', CASE WHEN user_gender = 0 THEN '남성' "+
                        "WHEN user_gender = 1 THEN '여성' ELSE '알 수 없음'  END AS '성별', user_reg_num AS '주민번호 앞 6자리', "+
                        "user_phone AS '전화번호', user_address1 AS '주소', user_address2 AS '주소 상세', "+
                        "insert_date_time AS '가입일시' FROM user "+
                        "WHERE user_name LIKE @user_name AND user_reg_num LIKE @user_reg_num";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user_name", "%" + firstinput + "%");
                    cmd.Parameters.AddWithValue("@user_reg_num", "%" + secondinput + "%");

                    // MySqlDataReader로 데이터 가져오기
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // DataTable에 데이터를 로드
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    user_list.DataSource = dataTable; // DataGridView에 데이터 표시

                    // 출력된 결과 개수 카운트
                    int resultCount = dataTable.Rows.Count;
                    if (resultCount > 0)
                    {
                        MessageBox.Show($"총 {resultCount}개의 데이터가 검색 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("검색된 데이터가 없습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void setting_Click(object sender, EventArgs e)
        {
            // setting_form을 모달로 띄우고 값 수정 후 반영
            setting_form settingsForm = new setting_form(server, database, id, pw);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                // 수정된 값 반영
                server = settingsForm.Server;
                database = settingsForm.Database;
                id = settingsForm.Id;
                pw = settingsForm.Pw;

                // connectionString도 업데이트
                connectionString = $"Server={server};Database={database};Uid={id};Pwd={pw};";
                conn.ConnectionString = connectionString;
            }
        }

        private void infomation_Click(object sender, EventArgs e)
        {
            infomation_form infoForm = new infomation_form();
            infoForm.ShowDialog();
        }
    }
}
