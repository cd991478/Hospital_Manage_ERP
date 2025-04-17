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
    public partial class login_form : Form
    {
        private string server;
        private string database;
        private string id;
        private string pw;
        private string connectionString;
        private MySqlConnection conn;

        public login_form()
        {
            InitializeComponent();
        }
        private void login_form_Load(object sender, EventArgs e)
        {
            login_pw_value.Focus();
        }
        private void login_button_Click(object sender, EventArgs e)
        {
            server = login_server_value.Text;
            database = login_db_value.Text;
            id = login_id_value.Text;
            pw = login_pw_value.Text;
            bool tf = false;    // 로그인 결과를 저장할 변수
            
            if (unlogin_box.Checked)    // 강제 실행 체크된경우
            {
                server = "unlogined";
                database = "unlogined";
                id = "unlogined";
                pw = "";
                tf = true;
            }
            else
            {
                connectionString = $"Server={server};Database={database};Uid={id};Pwd={pw};";
                conn = new MySqlConnection(connectionString);
                try
                {
                    conn.Open();
                    MessageBox.Show("접속에 성공 하였습니다.");
                    tf = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("접속에 실패 하였습니다.\n" + ex.Message);

                }
                finally
                {
                    conn.Close();
                }
            }
            
            if (tf == true)     // 로그인 성공시 혹은 강제 실행 한 경우
            {
                main_form main_form = new main_form(this, server, database, id, pw);
                this.Hide();    // 닫으면 프로그램이 종료되므로 숨겨야함
                main_form.Show();
            }
        }
        private void login_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void unlogin_Checked(object sender, EventArgs e)
        {
            if (unlogin_box.Checked == true)
            {
                MessageBox.Show("로그인 버튼을 누르면 입력된 로그인 정보를 무시하고 강제 실행합니다.\n실행 후 데이터를 불러오려면 환경설정에서 DB에 연결해주세요.", "주의", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
