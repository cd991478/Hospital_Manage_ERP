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
        public string Server { get; private set; }
        public string Database { get; private set; }
        public string Id { get; private set; }
        public string Pw { get; private set; }
        private MySqlConnection conn;

        public setting_form(string server, string database, string id, string pw)
        {
            InitializeComponent();
            this.Server = server;   // 현재 연결된 DB 정보를 설정
            this.Database = database;
            this.Id = id;
            this.Pw = pw;
        }

        private void setting_Form_Load(object sender, EventArgs e)
        {
            server_value.Text = this.Server;    // 현재 값을 출력
            db_value.Text = this.Database;
            id_value.Text = this.Id;
            pw_value.Text = this.Pw;
        }
        private void setting_Save_Click(object sender, EventArgs e)
        {
            this.Server = server_value.Text;    // 입력 된 값을 가져와 저장
            this.Database = db_value.Text;
            this.Id = id_value.Text;
            this.Pw = pw_value.Text;

            string connString = $"Server={this.Server};Database={this.Database};Uid={this.Id};Pwd={this.Pw}";   // 입력된 값으로 연결 시도하여 유효한지 체크
            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                MessageBox.Show("DB서버 연결에 성공했습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
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
