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
    public partial class frmMainUserQ : Form
    {
        public frmMainUserQ()
        {
            InitializeComponent();
        }

        private void frmMainUserQ1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'settriviaDataSet.questions' table. You can move, or remove it, as needed.
            this.questionsTableAdapter.Fill(this.settriviaDataSet.questions);

        }
    }
}
