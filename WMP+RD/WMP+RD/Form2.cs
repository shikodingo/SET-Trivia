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

        private void tmr20_Tick(object sender, EventArgs e)
        {
            int timeLeft = 20;
            while (timeLeft != 0)
            {
                if (timeLeft > 0)
                {
                    // Display the new time left
                    // by updating the Time Left label.
                    timeLeft = timeLeft - 1;
                    lblTime.Text = timeLeft + " seconds";
                }
                else
                {
                    // If the user ran out of time, stop the timer
                    tmr20.Stop();
                    lblTime.Text = "Time's up!";
                }
            }
        }
    }
}
