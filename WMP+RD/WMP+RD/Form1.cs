using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMP_RD
{
    public partial class frmMainUser : Form
    {
        frmMainUserQ user = new frmMainUserQ();
        frmAdmin admin = new frmAdmin();
        string uName;
        int uServer; //temp int (probably should be a float
        public frmMainUser()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "admin")
            {
                uServer = int.Parse(txtServer.Text);
                admin.Show();
            }
            else
            {
                uName = txtName.Text;
                uServer = int.Parse(txtServer.Text);
                user.Show();
            }
        }
    }
}
