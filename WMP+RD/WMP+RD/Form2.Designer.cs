namespace WMP_RD
{
    partial class frmMainUserQ
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
            this.components = new System.ComponentModel.Container();
            this.lblQuestion1 = new System.Windows.Forms.Label();
            this.questionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.settriviaDataSet = new WMP_RD.settriviaDataSet();
            this.questionsTableAdapter = new WMP_RD.settriviaDataSetTableAdapters.questionsTableAdapter();
            this.tmr20 = new System.Windows.Forms.Timer(this.components);
            this.rdbd = new System.Windows.Forms.RadioButton();
            this.rdbc = new System.Windows.Forms.RadioButton();
            this.rdbb = new System.Windows.Forms.RadioButton();
            this.rdba = new System.Windows.Forms.RadioButton();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.grbox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settriviaDataSet)).BeginInit();
            this.grbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuestion1
            // 
            this.lblQuestion1.AutoSize = true;
            this.lblQuestion1.Location = new System.Drawing.Point(26, 26);
            this.lblQuestion1.Name = "lblQuestion1";
            this.lblQuestion1.Size = new System.Drawing.Size(52, 13);
            this.lblQuestion1.TabIndex = 0;
            this.lblQuestion1.Text = "Question ";
            // 
            // questionsBindingSource
            // 
            this.questionsBindingSource.DataMember = "questions";
            this.questionsBindingSource.DataSource = this.settriviaDataSet;
            // 
            // settriviaDataSet
            // 
            this.settriviaDataSet.DataSetName = "settriviaDataSet";
            this.settriviaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // questionsTableAdapter
            // 
            this.questionsTableAdapter.ClearBeforeFill = true;
            // 
            // tmr20
            // 
            this.tmr20.Enabled = true;
            this.tmr20.Tick += new System.EventHandler(this.tmr20_Tick);
            // 
            // rdbd
            // 
            this.rdbd.AutoSize = true;
            this.rdbd.Location = new System.Drawing.Point(0, 99);
            this.rdbd.Name = "rdbd";
            this.rdbd.Size = new System.Drawing.Size(14, 13);
            this.rdbd.TabIndex = 2;
            this.rdbd.TabStop = true;
            this.rdbd.UseVisualStyleBackColor = true;
            // 
            // rdbc
            // 
            this.rdbc.AutoSize = true;
            this.rdbc.Location = new System.Drawing.Point(0, 75);
            this.rdbc.Name = "rdbc";
            this.rdbc.Size = new System.Drawing.Size(14, 13);
            this.rdbc.TabIndex = 3;
            this.rdbc.TabStop = true;
            this.rdbc.UseVisualStyleBackColor = true;
            // 
            // rdbb
            // 
            this.rdbb.AutoSize = true;
            this.rdbb.Location = new System.Drawing.Point(0, 42);
            this.rdbb.Name = "rdbb";
            this.rdbb.Size = new System.Drawing.Size(14, 13);
            this.rdbb.TabIndex = 4;
            this.rdbb.TabStop = true;
            this.rdbb.UseVisualStyleBackColor = true;
            // 
            // rdba
            // 
            this.rdba.AutoSize = true;
            this.rdba.Location = new System.Drawing.Point(0, 19);
            this.rdba.Name = "rdba";
            this.rdba.Size = new System.Drawing.Size(14, 13);
            this.rdba.TabIndex = 5;
            this.rdba.TabStop = true;
            this.rdba.UseVisualStyleBackColor = true;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(29, 222);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 13);
            this.lblTime.TabIndex = 6;
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(29, 43);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuestion.Size = new System.Drawing.Size(220, 78);
            this.txtQuestion.TabIndex = 7;
            // 
            // grbox
            // 
            this.grbox.Controls.Add(this.rdba);
            this.grbox.Controls.Add(this.rdbb);
            this.grbox.Controls.Add(this.rdbc);
            this.grbox.Controls.Add(this.rdbd);
            this.grbox.Location = new System.Drawing.Point(29, 127);
            this.grbox.Name = "grbox";
            this.grbox.Size = new System.Drawing.Size(142, 128);
            this.grbox.TabIndex = 8;
            this.grbox.TabStop = false;
            // 
            // frmMainUserQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.grbox);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblQuestion1);
            this.Name = "frmMainUserQ";
            this.Text = "Question ";
            this.Load += new System.EventHandler(this.frmMainUserQ1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settriviaDataSet)).EndInit();
            this.grbox.ResumeLayout(false);
            this.grbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion1;
        private settriviaDataSet settriviaDataSet;
        private System.Windows.Forms.BindingSource questionsBindingSource;
        private settriviaDataSetTableAdapters.questionsTableAdapter questionsTableAdapter;
        private System.Windows.Forms.Timer tmr20;
        private System.Windows.Forms.RadioButton rdbd;
        private System.Windows.Forms.RadioButton rdbc;
        private System.Windows.Forms.RadioButton rdbb;
        private System.Windows.Forms.RadioButton rdba;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.GroupBox grbox;
    }
}