namespace WMP_RD
{
    partial class frmEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblQuestionNum = new System.Windows.Forms.Label();
            this.cmbQuestionNum = new System.Windows.Forms.ComboBox();
            this.lblQuestionDesc = new System.Windows.Forms.Label();
            this.txtQuestionDesc = new System.Windows.Forms.TextBox();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestionNum
            // 
            this.lblQuestionNum.AutoSize = true;
            this.lblQuestionNum.Location = new System.Drawing.Point(13, 13);
            this.lblQuestionNum.Name = "lblQuestionNum";
            this.lblQuestionNum.Size = new System.Drawing.Size(133, 13);
            this.lblQuestionNum.TabIndex = 0;
            this.lblQuestionNum.Text = "Choose a question number";
            // 
            // cmbQuestionNum
            // 
            this.cmbQuestionNum.FormattingEnabled = true;
            this.cmbQuestionNum.Location = new System.Drawing.Point(152, 13);
            this.cmbQuestionNum.Name = "cmbQuestionNum";
            this.cmbQuestionNum.Size = new System.Drawing.Size(51, 21);
            this.cmbQuestionNum.TabIndex = 1;
            // 
            // lblQuestionDesc
            // 
            this.lblQuestionDesc.AutoSize = true;
            this.lblQuestionDesc.Location = new System.Drawing.Point(12, 61);
            this.lblQuestionDesc.Name = "lblQuestionDesc";
            this.lblQuestionDesc.Size = new System.Drawing.Size(52, 13);
            this.lblQuestionDesc.TabIndex = 2;
            this.lblQuestionDesc.Text = "Question:";
            // 
            // txtQuestionDesc
            // 
            this.txtQuestionDesc.Location = new System.Drawing.Point(72, 61);
            this.txtQuestionDesc.Multiline = true;
            this.txtQuestionDesc.Name = "txtQuestionDesc";
            this.txtQuestionDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuestionDesc.Size = new System.Drawing.Size(350, 61);
            this.txtQuestionDesc.TabIndex = 3;
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(13, 145);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(16, 13);
            this.lblA.TabIndex = 4;
            this.lblA.Text = "a)";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(12, 181);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(16, 13);
            this.lblB.TabIndex = 5;
            this.lblB.Text = "b)";
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(11, 212);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(16, 13);
            this.lblC.TabIndex = 6;
            this.lblC.Text = "c)";
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Location = new System.Drawing.Point(11, 239);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(16, 13);
            this.lblD.TabIndex = 7;
            this.lblD.Text = "d)";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(35, 145);
            this.txtA.Multiline = true;
            this.txtA.Name = "txtA";
            this.txtA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtA.Size = new System.Drawing.Size(387, 20);
            this.txtA.TabIndex = 8;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(34, 178);
            this.txtB.Multiline = true;
            this.txtB.Name = "txtB";
            this.txtB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtB.Size = new System.Drawing.Size(387, 20);
            this.txtB.TabIndex = 9;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(34, 209);
            this.txtC.Multiline = true;
            this.txtC.Name = "txtC";
            this.txtC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtC.Size = new System.Drawing.Size(387, 20);
            this.txtC.TabIndex = 10;
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(33, 239);
            this.txtD.Multiline = true;
            this.txtD.Name = "txtD";
            this.txtD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtD.Size = new System.Drawing.Size(387, 20);
            this.txtD.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(288, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 335);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.txtQuestionDesc);
            this.Controls.Add(this.lblQuestionDesc);
            this.Controls.Add(this.cmbQuestionNum);
            this.Controls.Add(this.lblQuestionNum);
            this.Name = "frmEdit";
            this.Text = "Edit Questions + Answers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestionNum;
        private System.Windows.Forms.ComboBox cmbQuestionNum;
        private System.Windows.Forms.Label lblQuestionDesc;
        private System.Windows.Forms.TextBox txtQuestionDesc;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Button btnSave;
    }
}