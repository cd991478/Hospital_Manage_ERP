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
            bool tf = false;
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


            if (tf == true)
            {
                main_form main_form = new main_form(server, database, id, pw);
                this.Hide();
                main_form.Show();
                main_form.FormClosed += (s, args) => this.Close();
            }
            
            
        }
        private void login_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
