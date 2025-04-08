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
    public partial class user_search_form : Form
    {
        public static string SearchFirst { get; set; }
        public static string SearchSecond { get; set; }

        public user_search_form()
        {
            InitializeComponent();
        }

        public void user_search_Click(object sender, EventArgs e)
        {
            SearchFirst = user_search_name_value.Text;
            SearchSecond = user_search_regnum_value.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        public void user_search_Cancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void user_search_form_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
