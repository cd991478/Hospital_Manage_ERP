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
    public partial class infomation_form : Form
    {
        public infomation_form()
        {
            InitializeComponent();
        }

        public void close_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
