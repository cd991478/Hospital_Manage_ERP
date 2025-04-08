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
    public partial class setting_form : Form
    {
        // 수정할 값들을 저장할 필드 변수들
        public string Server { get; private set; }
        public string Database { get; private set; }
        public string Id { get; private set; }
        public string Pw { get; private set; }

        private MySqlConnection conn;


        // 생성자에서 기존의 값들을 전달받음
        public setting_form(string server, string database, string id, string pw)
        {
            InitializeComponent();
            this.Server = server;
            this.Database = database;
            this.Id = id;
            this.Pw = pw;
        }

        // 폼 로드 시 텍스트박스에 기존 값 채우기
        private void setting_Form_Load(object sender, EventArgs e)
        {
            server_value.Text = this.Server;
            db_value.Text = this.Database;
            id_value.Text = this.Id;
            pw_value.Text = this.Pw;
        }
        // 저장 버튼 클릭 시 수정된 값 저장
        private void setting_Save_Click(object sender, EventArgs e)
        {
            // 수정된 값들 가져오기
            this.Server = server_value.Text;
            this.Database = db_value.Text;
            this.Id = id_value.Text;
            this.Pw = pw_value.Text;

            // MySQL 서버와 연결을 시도
            string connString = $"Server={this.Server};Database={this.Database};Uid={this.Id};Pwd={this.Pw}";
            try
            {
                // MySqlConnection 객체를 생성
                conn = new MySqlConnection(connString);
                conn.Open(); // DB 연결 시도

                // 연결이 성공하면, 설정을 저장하고 창을 닫음
                MessageBox.Show("DB서버 연결에 성공했습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // 연결 실패 시 오류 메시지를 띄우고 창은 닫지 않음
                MessageBox.Show($"DB서버 연결 실패: {ex.Message}");
            }
            finally
            {
                    conn.Close();
            }
        }

        private void setting_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
