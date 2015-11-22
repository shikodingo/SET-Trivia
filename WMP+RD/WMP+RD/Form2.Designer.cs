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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.qIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.settriviaDataSet = new WMP_RD.settriviaDataSet();
            this.questionsTableAdapter = new WMP_RD.settriviaDataSetTableAdapters.questionsTableAdapter();
            this.tmr20 = new System.Windows.Forms.Timer(this.components);
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.lblTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settriviaDataSet)).BeginInit();
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
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qIDDataGridViewTextBoxColumn,
            this.qDescriptionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.questionsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(29, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 64);
            this.dataGridView1.TabIndex = 1;
            // 
            // qIDDataGridViewTextBoxColumn
            // 
            this.qIDDataGridViewTextBoxColumn.DataPropertyName = "Q_ID";
            this.qIDDataGridViewTextBoxColumn.HeaderText = "Q_ID";
            this.qIDDataGridViewTextBoxColumn.Name = "qIDDataGridViewTextBoxColumn";
            // 
            // qDescriptionDataGridViewTextBoxColumn
            // 
            this.qDescriptionDataGridViewTextBoxColumn.DataPropertyName = "QDescription";
            this.qDescriptionDataGridViewTextBoxColumn.HeaderText = "QDescription";
            this.qDescriptionDataGridViewTextBoxColumn.Name = "qDescriptionDataGridViewTextBoxColumn";
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
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(52, 127);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(52, 151);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(52, 175);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(52, 199);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(85, 17);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(29, 222);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 13);
            this.lblTime.TabIndex = 6;
            // 
            // frmMainUserQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblQuestion1);
            this.Name = "frmMainUserQ";
            this.Text = "Question ";
            this.Load += new System.EventHandler(this.frmMainUserQ1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settriviaDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private settriviaDataSet settriviaDataSet;
        private System.Windows.Forms.BindingSource questionsBindingSource;
        private settriviaDataSetTableAdapters.questionsTableAdapter questionsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn qIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Timer tmr20;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label lblTime;
    }
}