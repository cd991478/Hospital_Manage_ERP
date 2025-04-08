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
    public partial class hospital_search_form : Form
    {
        public static string SearchFirst { get; set; }
        public static string SearchSecond { get; set; }

        public hospital_search_form()
        {
            InitializeComponent();
        }

        public void hospital_search_Click(object sender, EventArgs e)
        {
            SearchFirst = hospital_search_address_value.Text;
            SearchSecond = hospital_search_categorie_value.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        public void hospital_search_Cancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
