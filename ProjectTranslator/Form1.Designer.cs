namespace ProjectTranslator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnTranslate = new System.Windows.Forms.Button();
            this.BtnSelectResourcesFilePath = new System.Windows.Forms.Button();
            this.TxtResourcesFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSelectProjectFolder = new System.Windows.Forms.Button();
            this.TxtProjectFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RtbLogs = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnTranslate);
            this.groupBox1.Controls.Add(this.BtnSelectResourcesFilePath);
            this.groupBox1.Controls.Add(this.TxtResourcesFilePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BtnSelectProjectFolder);
            this.groupBox1.Controls.Add(this.TxtProjectFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(574, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration ";
            // 
            // BtnTranslate
            // 
            this.BtnTranslate.Location = new System.Drawing.Point(447, 91);
            this.BtnTranslate.Name = "BtnTranslate";
            this.BtnTranslate.Size = new System.Drawing.Size(107, 36);
            this.BtnTranslate.TabIndex = 6;
            this.BtnTranslate.Text = "Translate !";
            this.BtnTranslate.UseVisualStyleBackColor = true;
            this.BtnTranslate.Click += new System.EventHandler(this.BtnTranslate_Click);
            // 
            // BtnSelectResourcesFilePath
            // 
            this.BtnSelectResourcesFilePath.Location = new System.Drawing.Point(523, 59);
            this.BtnSelectResourcesFilePath.Name = "BtnSelectResourcesFilePath";
            this.BtnSelectResourcesFilePath.Size = new System.Drawing.Size(31, 26);
            this.BtnSelectResourcesFilePath.TabIndex = 5;
            this.BtnSelectResourcesFilePath.Text = "...";
            this.BtnSelectResourcesFilePath.UseVisualStyleBackColor = true;
            this.BtnSelectResourcesFilePath.Click += new System.EventHandler(this.BtnSelectResourcesFilePath_Click);
            // 
            // TxtResourcesFilePath
            // 
            this.TxtResourcesFilePath.Location = new System.Drawing.Point(147, 60);
            this.TxtResourcesFilePath.Name = "TxtResourcesFilePath";
            this.TxtResourcesFilePath.Size = new System.Drawing.Size(370, 25);
            this.TxtResourcesFilePath.TabIndex = 4;
            this.TxtResourcesFilePath.Text = "D:\\Programmation\\MercyBotCore\\MercyBot\\MercyBot.WPF\\Properties\\_.resx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resources file path:";
            // 
            // BtnSelectProjectFolder
            // 
            this.BtnSelectProjectFolder.Location = new System.Drawing.Point(523, 28);
            this.BtnSelectProjectFolder.Name = "BtnSelectProjectFolder";
            this.BtnSelectProjectFolder.Size = new System.Drawing.Size(31, 26);
            this.BtnSelectProjectFolder.TabIndex = 2;
            this.BtnSelectProjectFolder.Text = "...";
            this.BtnSelectProjectFolder.UseVisualStyleBackColor = true;
            this.BtnSelectProjectFolder.Click += new System.EventHandler(this.BtnSelectProjectFolder_Click);
            // 
            // TxtProjectFolder
            // 
            this.TxtProjectFolder.Location = new System.Drawing.Point(119, 29);
            this.TxtProjectFolder.Name = "TxtProjectFolder";
            this.TxtProjectFolder.Size = new System.Drawing.Size(398, 25);
            this.TxtProjectFolder.TabIndex = 1;
            this.TxtProjectFolder.Text = "D:\\Programmation\\MercyBotCore\\MercyBot\\MercyBot.WPF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project folder: ";
            // 
            // RtbLogs
            // 
            this.RtbLogs.Location = new System.Drawing.Point(14, 168);
            this.RtbLogs.Name = "RtbLogs";
            this.RtbLogs.Size = new System.Drawing.Size(574, 155);
            this.RtbLogs.TabIndex = 1;
            this.RtbLogs.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 337);
            this.Controls.Add(this.RtbLogs);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Translator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtProjectFolder;
        private System.Windows.Forms.Button BtnSelectProjectFolder;
        private System.Windows.Forms.Button BtnSelectResourcesFilePath;
        private System.Windows.Forms.TextBox TxtResourcesFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnTranslate;
        private System.Windows.Forms.RichTextBox RtbLogs;
    }
}

