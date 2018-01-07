namespace MBugsReader
{
    partial class Form1
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BtnLoadMbug = new System.Windows.Forms.Button();
            this.LblMapPos = new System.Windows.Forms.Label();
            this.LblMapId = new System.Windows.Forms.Label();
            this.LblWeight = new System.Windows.Forms.Label();
            this.LblLevel = new System.Windows.Forms.Label();
            this.LbLogs = new System.Windows.Forms.ListBox();
            this.DgvMessages = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DgvMessages);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(783, 508);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Messages";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LbLogs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(783, 508);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Logs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnLoadMbug);
            this.tabPage1.Controls.Add(this.LblMapPos);
            this.tabPage1.Controls.Add(this.LblMapId);
            this.tabPage1.Controls.Add(this.LblWeight);
            this.tabPage1.Controls.Add(this.LblLevel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(783, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Informations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(791, 534);
            this.tabControl1.TabIndex = 0;
            // 
            // BtnLoadMbug
            // 
            this.BtnLoadMbug.Location = new System.Drawing.Point(672, 15);
            this.BtnLoadMbug.Name = "BtnLoadMbug";
            this.BtnLoadMbug.Size = new System.Drawing.Size(97, 31);
            this.BtnLoadMbug.TabIndex = 9;
            this.BtnLoadMbug.Text = "Load .mbug";
            this.BtnLoadMbug.UseVisualStyleBackColor = true;
            this.BtnLoadMbug.Click += new System.EventHandler(this.BtnLoadMbug_Click);
            // 
            // LblMapPos
            // 
            this.LblMapPos.AutoSize = true;
            this.LblMapPos.Location = new System.Drawing.Point(22, 178);
            this.LblMapPos.Name = "LblMapPos";
            this.LblMapPos.Size = new System.Drawing.Size(56, 13);
            this.LblMapPos.TabIndex = 8;
            this.LblMapPos.Text = "Position: ?";
            // 
            // LblMapId
            // 
            this.LblMapId.AutoSize = true;
            this.LblMapId.Location = new System.Drawing.Point(22, 150);
            this.LblMapId.Name = "LblMapId";
            this.LblMapId.Size = new System.Drawing.Size(52, 13);
            this.LblMapId.TabIndex = 7;
            this.LblMapId.Text = "MapId : ?";
            // 
            // LblWeight
            // 
            this.LblWeight.AutoSize = true;
            this.LblWeight.Location = new System.Drawing.Point(22, 125);
            this.LblWeight.Name = "LblWeight";
            this.LblWeight.Size = new System.Drawing.Size(56, 13);
            this.LblWeight.TabIndex = 6;
            this.LblWeight.Text = "Weight : ?";
            // 
            // LblLevel
            // 
            this.LblLevel.AutoSize = true;
            this.LblLevel.Location = new System.Drawing.Point(22, 98);
            this.LblLevel.Name = "LblLevel";
            this.LblLevel.Size = new System.Drawing.Size(48, 13);
            this.LblLevel.TabIndex = 5;
            this.LblLevel.Text = "Level : ?";
            // 
            // LbLogs
            // 
            this.LbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbLogs.FormattingEnabled = true;
            this.LbLogs.Location = new System.Drawing.Point(3, 3);
            this.LbLogs.Name = "LbLogs";
            this.LbLogs.Size = new System.Drawing.Size(777, 502);
            this.LbLogs.TabIndex = 0;
            // 
            // DgvMessages
            // 
            this.DgvMessages.AllowUserToAddRows = false;
            this.DgvMessages.AllowUserToDeleteRows = false;
            this.DgvMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.DgvMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMessages.Location = new System.Drawing.Point(3, 3);
            this.DgvMessages.Name = "DgvMessages";
            this.DgvMessages.ReadOnly = true;
            this.DgvMessages.Size = new System.Drawing.Size(777, 502);
            this.DgvMessages.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Time";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 55;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Message";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 75;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 534);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "MBugs Reader";
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BtnLoadMbug;
        private System.Windows.Forms.Label LblMapPos;
        private System.Windows.Forms.Label LblMapId;
        private System.Windows.Forms.Label LblWeight;
        private System.Windows.Forms.Label LblLevel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListBox LbLogs;
        private System.Windows.Forms.DataGridView DgvMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

