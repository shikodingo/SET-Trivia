namespace WMP_RD
{
    partial class frmAdmin
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnLive = new System.Windows.Forms.Button();
            this.btnLeader = new System.Windows.Forms.Button();
            this.btnExHis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(137, 23);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit questions/answers";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnLive
            // 
            this.btnLive.Location = new System.Drawing.Point(13, 55);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(111, 23);
            this.btnLive.TabIndex = 1;
            this.btnLive.Text = "See live status!";
            this.btnLive.UseVisualStyleBackColor = true;
            this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
            // 
            // btnLeader
            // 
            this.btnLeader.Location = new System.Drawing.Point(13, 98);
            this.btnLeader.Name = "btnLeader";
            this.btnLeader.Size = new System.Drawing.Size(111, 23);
            this.btnLeader.TabIndex = 2;
            this.btnLeader.Text = "View leaderboard!";
            this.btnLeader.UseVisualStyleBackColor = true;
            // 
            // btnExHis
            // 
            this.btnExHis.Location = new System.Drawing.Point(12, 143);
            this.btnExHis.Name = "btnExHis";
            this.btnExHis.Size = new System.Drawing.Size(190, 23);
            this.btnExHis.TabIndex = 3;
            this.btnExHis.Text = "Create spreadsheet and histogram";
            this.btnExHis.UseVisualStyleBackColor = true;
            this.btnExHis.Click += new System.EventHandler(this.btnExHis_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnExHis);
            this.Controls.Add(this.btnLeader);
            this.Controls.Add(this.btnLive);
            this.Controls.Add(this.btnEdit);
            this.Name = "frmAdmin";
            this.Text = "Admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.Button btnLeader;
        private System.Windows.Forms.Button btnExHis;
    }
}