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
    public partial class frmEdit : Form
    {
        string directory = @"C:\Users\Nathan\OneDrive\Windows and Mobile Programming\Assign 6\main\";
        const string watchExt = @"Admin\";
        const string writeExt = @"Service\";
        public frmEdit()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void cmbQuestionNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qNum = cmbQuestionNum.SelectedItem.ToString();
            string question = txtQuestionDesc.Text;
            string answerA = txtA.Text;
            string answerB = txtB.Text;
            string answerC = txtC.Text;
            string answerD = txtD.Text;
            string extension = writeExt;
            string questionPlusAnswers = "";
            if (question == "")
            {
                question = "*";
            }
            if (answerA == "")
            {
                answerA = "*";
            }
            if (answerB == "")
            {
                answerB = "*";
            }
            if (answerC == "")
            {
                answerC = "*";
            }
            if (answerD == "")
            {
                answerD = "*";
            }
            IPCFileProducer createNewMessage = new IPCFileProducer();
                questionPlusAnswers = qNum + "|" + question + "|";
                questionPlusAnswers += answerA + "|" + answerB + "|" + answerC + "|" + answerD;
                createNewMessage.WriteData(questionPlusAnswers, "changeQuestionAnswer", directory + extension);//write question into file
        }
    }
}
