namespace MercyBot_Translator
{
    partial class MultiEditForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dgvLangs = new System.Windows.Forms.DataGridView();
            this.selectLangsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLangs)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectLangsFolderToolStripMenuItem,
            this.saveAllFilesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1033, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dgvLangs
            // 
            this.dgvLangs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLangs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLangs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLangs.Location = new System.Drawing.Point(0, 24);
            this.dgvLangs.Name = "dgvLangs";
            this.dgvLangs.Size = new System.Drawing.Size(1033, 658);
            this.dgvLangs.TabIndex = 1;
            // 
            // selectLangsFolderToolStripMenuItem
            // 
            this.selectLangsFolderToolStripMenuItem.Image = global::MercyBot_Translator.Properties.Resources.folder_32;
            this.selectLangsFolderToolStripMenuItem.Name = "selectLangsFolderToolStripMenuItem";
            this.selectLangsFolderToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.selectLangsFolderToolStripMenuItem.Text = "Select langs folder";
            this.selectLangsFolderToolStripMenuItem.Click += new System.EventHandler(this.selectLangsFolderToolStripMenuItem_Click);
            // 
            // saveAllFilesToolStripMenuItem
            // 
            this.saveAllFilesToolStripMenuItem.Image = global::MercyBot_Translator.Properties.Resources.floppy_32;
            this.saveAllFilesToolStripMenuItem.Name = "saveAllFilesToolStripMenuItem";
            this.saveAllFilesToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.saveAllFilesToolStripMenuItem.Text = "Save all files";
            this.saveAllFilesToolStripMenuItem.Click += new System.EventHandler(this.saveAllFilesToolStripMenuItem_Click);
            // 
            // MultiEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 682);
            this.Controls.Add(this.dgvLangs);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MultiEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MultiEditForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLangs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectLangsFolderToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvLangs;
        private System.Windows.Forms.ToolStripMenuItem saveAllFilesToolStripMenuItem;
    }
}