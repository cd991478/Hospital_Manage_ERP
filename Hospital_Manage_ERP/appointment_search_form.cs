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
    public partial class appointment_search_form : Form
    {
        public static string SearchFirst { get; set; }
        public static string SearchSecond { get; set; }

        public appointment_search_form()
        {
            InitializeComponent();
        }
        public void appointment_search_Click(object sender, EventArgs e)
        {
            SearchFirst = appointment_search_name_value.Text;
            SearchSecond = appointment_search_regnum_value.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        public void appointment_search_Cancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
