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
using MySqlX.XDevAPI.Common;
namespace Hospital_Manage_ERP
{
    public partial class main_form : Form // 메인 화면
    {
        private Form loginform;
        private string server; 
        private string database;
        private string id;
        private string pw;
        private string connectionString;
        public static string SearchFirst { get; set; } // 검색 text 값 1
        public static string SearchSecond { get; set; } // 검색 text 값 2

        private MySqlConnection conn;
        private ProgressForm progressform;
        
        public main_form(Form login_form, string login_server, string login_database, string login_id, string login_pw)
        {
            InitializeComponent();
            loginform = login_form;
            server = login_server; // 로그인 폼에서 입력한 값을 전달 받음
            database = login_database;
            id = login_id;
            pw = login_pw;
            connectionString = $"Server={server};Database={database};Uid={id};Pwd={pw};";
            conn = new MySqlConnection(connectionString);
            progressform = new ProgressForm(); // 데이터 로딩중 문구를 띄울 폼
        }

        private async void main_form_Load(object sender, EventArgs e) // 비동기를 사용하지 않으면 progressform이 정상 작동하지 않고 멈추므로 비동기 작업 사용
        {
            if (server != "unlogined" && database != "unlogined" && id != "unlogined" && pw != "")   // 강제 접속 하지않고 정상 로그인 한경우
            {
                progressform.Show();
                await LoadDataAsync(); // 전체 데이터를 비동기로 로드
                progressform.Close();
            }
        }
        private async Task all_data_Load()
        {
            patient_list.Columns.Clear();
            appointment_list.Columns.Clear();
            hospital_list.Columns.Clear();
            user_list.Columns.Clear();

            progressform = new ProgressForm();
            progressform.Show();
            await LoadDataAsync();
            progressform.Close();
        }

        private async Task LoadDataAsync()
        {
            await Task.Run(() =>
            {
                LoadPatientInfo();
                LoadAppointmentInfo();
                LoadHospitalList();
                LoadUserInfo();
            });
        }

        //private void LoadData(string query, DataGridView dataGrid, Action<DataTable> customizeColumns = null)
        //{
        //    try
        //    {
        //        conn.Open();
        //        MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
        //        DataTable dataTable = new DataTable();
        //        adapter.Fill(dataTable);

        //        // 데이터 바인딩
        //        dataGrid.Invoke(new Action(() => { 
        //               dataGrid.DataSource = dataTable;
        //        }));

        //        // 컬럼 크기 조정
        //        customizeColumns?.Invoke(dataTable);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        // 환자 정보 로드
        
        private void LoadPatientInfo()
        {
            try
            {
                conn.Open();
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
                    "FROM patient"; // 출력할 데이터를 가져올 쿼리문

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                patient_list.Invoke(new Action(() => { patient_list.DataSource = dataTable; }));

                patient_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                patient_list.Columns["주소"].Width = 400;
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

        // 예약 정보 로드
        private void LoadAppointmentInfo()
        {
            try
            {
                string query = "SELECT a.id AS '예약번호', a.h_id AS '병원 번호', a.user_id AS '회원아이디', " +
                    "a.patient_name AS '예약자명', h.h_name AS '병원명', a.appointment_time AS '예약 시간', " +
                    "a.created_time AS '등록 시간', " +
                    "u.user_phone AS '예약자 전화번호' " +
                    "FROM appointment a " +
                    "JOIN d_hospital_v1 h ON a.h_id = h.h_id " +
                    "JOIN user u ON a.user_id = u.user_id";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                appointment_list.Invoke(new Action(() => { appointment_list.DataSource = dataTable; }));
                appointment_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                appointment_list.Columns["병원명"].Width = 200;
                appointment_list.Columns["예약 시간"].Width = 150;
                appointment_list.Columns["등록 시간"].Width = 150;
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

        // 병원 목록 로드
        private void LoadHospitalList()
        {
            try
            {
                string query = "SELECT h_id AS '병원번호', h_name AS '병원명', h_department AS '분류1', h_categorie AS '분류2', " +
                    "h_region AS '지역', h_address AS '주소', h_latitude AS '위도', h_longitude AS '경도', " +
                    "Bed_Total AS '총 병상', Bed_General AS '일반병상', Bed_Psy AS '정신과병상', Bed_Nursing AS '요양병상', " +
                    "Bed_Intensive AS '중환자실병상', Bed_Isolation AS '격리병상', Bed_Clean AS '무균병상' FROM d_hospital_v1";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                hospital_list.Invoke(new Action(() => { hospital_list.DataSource = dataTable; }));
                hospital_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                hospital_list.Columns["주소"].Width = 400;
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

        // 회원 정보 로드
        private void LoadUserInfo()
        {
            try
            {
                string query = "SELECT user_id AS '아이디', user_name AS '이름', CASE WHEN user_gender = 0 THEN '남성' WHEN user_gender = 1 THEN '여성' ELSE '알 수 없음'  END AS '성별', " +
                    "user_reg_num AS '주민번호 앞 6자리', user_phone AS '전화번호', user_address1 AS '주소', " +
                    "user_address2 AS '주소 상세', insert_date_time AS '가입일시' FROM user";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                user_list.Invoke(new Action(() => { user_list.DataSource = dataTable; }));
                user_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                user_list.Columns["주소"].Width = 400;
                user_list.Columns["가입일시"].Width = 150;

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



        private void patientedit_Click(object sender, EventArgs e)
        {
            if (patient_list.SelectedRows.Count > 0)    // 데이터 행을 선택한 경우
            {
                int selectedPatientId = Convert.ToInt32(patient_list.SelectedRows[0].Cells["환자번호"].Value);  // 선택된 행의 id를 가져옴
                patient_edit_form p_edit = new patient_edit_form(selectedPatientId, server, database, id, pw); // id와 DB로그인 정보를 수정 폼을 생성하며 전달
                DialogResult result = p_edit.ShowDialog();
                if(result == DialogResult.OK)   // 수정이 진행되었다면, 갱신을 위해 데이터 다시 로드
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

        //private void patientdelete_Click(object sender, EventArgs e)
        //{
        //    if (patient_list.SelectedRows.Count > 0) // 데이터가 선택 됬는데,
        //    {
        //        List<int> selectedPatientId = new List<int>();
        //        if (patient_list.SelectedRows.Count == 1) // 1개의 데이터인 경우
        //        {
        //            var result = MessageBox.Show("해당 환자 정보가 삭제됩니다.\n계속하시겠습니까?", "환자 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //            if (result == DialogResult.No) { return; }
        //            selectedPatientId.Add(Convert.ToInt32(patient_list.SelectedRows[0].Cells["환자번호"].Value));
        //        }
        //        else    // 여러개의 데이터인 경우
        //        {
        //            var result = MessageBox.Show($"{patient_list.SelectedRows.Count}명의 환자 정보가 삭제됩니다.\n계속하시겠습니까?", "환자 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //            if (result == DialogResult.No) { return; }

        //            for (int i = 0; i < patient_list.SelectedRows.Count; i++)
        //            {
        //                selectedPatientId.Add(Convert.ToInt32(patient_list.SelectedRows[i].Cells["환자번호"].Value)); // 리스트에 모두 추가
        //            }
        //        }

        //        try
        //        {
        //            conn.Open();
        //            for (int i = 0; i < selectedPatientId.Count; i++) // 삭제
        //            {
        //                string query = "DELETE FROM patient WHERE p_id = @p_id";
        //                MySqlCommand cmd = new MySqlCommand(query, conn);
        //                cmd.Parameters.AddWithValue("@p_id", selectedPatientId[i]);
        //                cmd.ExecuteNonQuery();
        //            }
        //            MessageBox.Show("환자 정보가 삭제되었습니다.");
        //            conn.Close();
        //            LoadPatientInfo();
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
        //                return;
        //            }
        //            selectedAppointmentId.Add(Convert.ToInt32(appointment_list.SelectedRows[0].Cells["예약번호"].Value));
        //        }
        //        else
        //        {
        //            var result = MessageBox.Show($"{appointment_list.SelectedRows.Count}개의 예약 정보가 삭제됩니다.\n계속하시겠습니까?", "예약 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //            if (result == DialogResult.No)
        //            {
        //                return;
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
        //            LoadAppointmentInfo();
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
        //                return;
        //            }
        //            selectedHospitalId.Add(Convert.ToInt32(hospital_list.SelectedRows[0].Cells["병원번호"].Value));
        //        }
        //        else
        //        {
        //            var result = MessageBox.Show($"{hospital_list.SelectedRows.Count}개의 병원 정보가 삭제됩니다.\n계속하시겠습니까?", "병원 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //            if (result == DialogResult.No)
        //            {
        //                return;
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
        //            LoadHospitalList();
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


       
        private void user_delete_Click(object sender, EventArgs e)
        {
            if (user_list.SelectedRows.Count > 0)   // 데이터를 선택하고 삭제 버튼을 눌렀는데
            {
                List<string> selectedUserId = new List<string>();
                if (user_list.SelectedRows.Count == 1)  // 데이터가 1개인경우
                {
                    var result = MessageBox.Show("해당 회원 정보 및 관련된 모든 예약 정보가 삭제됩니다.\n계속하시겠습니까?", "회원 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) { return; }
                    selectedUserId.Add(Convert.ToString(user_list.SelectedRows[0].Cells["아이디"].Value));
                }
                else    // 데이터가 여러개인경우
                {
                    var result = MessageBox.Show($"{user_list.SelectedRows.Count}명의 회원 정보 및 관련된 모든 예약 정보가 삭제됩니다.\n계속하시겠습니까?", "회원 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) { return; }
                    for (int i = 0; i < user_list.SelectedRows.Count; i++)  // 리스트에 여러개의 아이디를 담음
                    {
                        selectedUserId.Add(Convert.ToString(user_list.SelectedRows[i].Cells["아이디"].Value));
                    }
                }
                for (int i = 0; i < selectedUserId.Count; i++) {
                    if (selectedUserId[i] == "admin")   // 관리자 계정이 선택 된 경우 작업 강제 중단
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
                        string query1 = "DELETE FROM appointment WHERE user_id = @user_id"; // 회원과 예약은 참조 관계이기 때문에 예약을 먼저 삭제하지 않으면 회원 삭제가 불가능
                        MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                        cmd1.Parameters.AddWithValue("@user_id", selectedUserId[i]);
                        cmd1.ExecuteNonQuery();
                    }
                    for (int i = 0; i < selectedUserId.Count; i++)
                    {
                        string query2 = "DELETE FROM user WHERE user_id = @user_id";    // 회원 삭제
                        MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                        cmd2.Parameters.AddWithValue("@user_id", selectedUserId[i]);
                        cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show("회원 정보 및 예약 정보가 삭제되었습니다.");
                    conn.Close();
                    LoadAppointmentInfo();
                    LoadUserInfo();
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

        // 삭제 통합
        private bool DeleteData(DataGridView dataGridView, string idColumnName, string tableName, string primaryKeyName)
        {
            if (dataGridView.SelectedRows.Count == 0) // 데이터를 선택 하지 않고 삭제를 누른 경우
            {
                MessageBox.Show("삭제할 데이터를 선택해주세요.");
                return false;
            }

            List<int> selectedId = new List<int>();
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                selectedId.Add(Convert.ToInt32(row.Cells[idColumnName].Value)); // 선택된 행들의 id를 리스트에 추가
            }
            string table = "";
            if      (tableName == "patient")     { table = "환자"; }
            else if (tableName == "appointment")  { table = "예약"; }
            else if (tableName == "v_hospital_v1") { table = "병원"; }

            var result = MessageBox.Show($"{selectedId.Count}개의 {table} 정보를 삭제합니다.\n계속하시겠습니까?",
                                         $"{table} 삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return false;
            }

            conn.Open();
            try
            {
                foreach (int id in selectedId)  // 리스트에 저장된 id에 해당하는 데이터 삭제
                {
                    string query = $"DELETE FROM {tableName} WHERE {primaryKeyName} = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show($"{table} 정보가 삭제되었습니다.");
                conn.Close();
                return true;    // 정상 삭제

            }
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
                conn.Close();
            }
            return false;
        }

        private void patientdelete_Click(object sender, EventArgs e)
        {
            bool result = DeleteData(patient_list, "환자번호", "patient", "p_id"); // DataGridView, DataGridView의 id 표기칼럼명, 테이블 이름, primary key명
            if (result == true) { LoadPatientInfo(); }  // 정상 삭제한 경우 데이터 갱신
        }

        private void appointment_delete_Click(object sender, EventArgs e)
        {
            bool result = DeleteData(appointment_list, "예약번호", "appointment", "id");
            if (result == true) { LoadAppointmentInfo(); }
        }

        private void hospital_delete_Click(object sender, EventArgs e)
        {
            bool result = DeleteData(hospital_list, "병원번호", "d_hospital_v1", "h_id");
            if (result == true) { LoadHospitalList(); }
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
            if(patientsearchform.DialogResult == DialogResult.OK)   // 검색창에서 검색 버튼을 누른 경우
            {
                try
                {
                    conn.Open();
                    string firstinput = patient_search_form.SearchFirst;    // 검색폼에 설정된 값을 가져옴
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
                               "WHERE p_name LIKE @p_name AND p_reg_num LIKE @p_reg_num";   // LIKE %_%를 사용하여, 값이 포함된 모든 데이터 검색
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@p_name", "%" + firstinput + "%");
                    cmd.Parameters.AddWithValue("@p_reg_num", "%" + secondinput + "%");
                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    patient_list.DataSource = dataTable;    // 데이터 출력

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

                    // 데이터 가져오기
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // 데이터 로드
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    appointment_list.DataSource = dataTable; // 데이터 표시

                    // 카운트
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

                    MySqlDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    hospital_list.DataSource = dataTable;

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

                    MySqlDataReader reader = cmd.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    user_list.DataSource = dataTable;

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
        private async void setting_Click(object sender, EventArgs e)
        {
            setting_form settingsForm = new setting_form(server, database, id, pw); // 환경 설정 창 생성하며 현재 DB접속 정보 전달
            if (settingsForm.ShowDialog() == DialogResult.OK)   // DB접속 정보가 변경된 경우
            {
                server = settingsForm.Server;   // 변경된 값 저장
                database = settingsForm.Database;
                id = settingsForm.Id;
                pw = settingsForm.Pw;
                connectionString = $"Server={server};Database={database};Uid={id};Pwd={pw};";
                conn.ConnectionString = connectionString;
                await all_data_Load();
            }
        }

        private void infomation_Click(object sender, EventArgs e)
        {
            infomation_form infoForm = new infomation_form();
            infoForm.ShowDialog();
        }

        private void main_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("정말 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            if (conn != null && conn.State == ConnectionState.Open) // DB 연결이 남아있는경우 연결 해제
            {
                conn.Close();
            }
            loginform.Close();      // Hide된 로그인 폼 제거
            Environment.Exit(0);    // 프로그램 종료
        }
    }
}
