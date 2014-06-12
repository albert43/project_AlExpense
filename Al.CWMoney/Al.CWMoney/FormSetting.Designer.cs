namespace Al.CWMoney
{
    partial class FormSetting
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
            this.label_DbDir = new System.Windows.Forms.Label();
            this.textBox_DbDir = new System.Windows.Forms.TextBox();
            this.button_DbDir = new System.Windows.Forms.Button();
            this.label_DropboxDir = new System.Windows.Forms.Label();
            this.textBox_DropboxDir = new System.Windows.Forms.TextBox();
            this.button_DropboxDir = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_DbDir
            // 
            this.label_DbDir.AutoSize = true;
            this.label_DbDir.Location = new System.Drawing.Point(26, 25);
            this.label_DbDir.Name = "label_DbDir";
            this.label_DbDir.Size = new System.Drawing.Size(54, 12);
            this.label_DbDir.TabIndex = 0;
            this.label_DbDir.Text = "DB Folder";
            // 
            // textBox_DbDir
            // 
            this.textBox_DbDir.Location = new System.Drawing.Point(155, 14);
            this.textBox_DbDir.Name = "textBox_DbDir";
            this.textBox_DbDir.Size = new System.Drawing.Size(631, 22);
            this.textBox_DbDir.TabIndex = 1;
            // 
            // button_DbDir
            // 
            this.button_DbDir.Location = new System.Drawing.Point(792, 12);
            this.button_DbDir.Name = "button_DbDir";
            this.button_DbDir.Size = new System.Drawing.Size(75, 23);
            this.button_DbDir.TabIndex = 2;
            this.button_DbDir.Text = "Browse";
            this.button_DbDir.UseVisualStyleBackColor = true;
            // 
            // label_DropboxDir
            // 
            this.label_DropboxDir.AutoSize = true;
            this.label_DropboxDir.Location = new System.Drawing.Point(26, 64);
            this.label_DropboxDir.Name = "label_DropboxDir";
            this.label_DropboxDir.Size = new System.Drawing.Size(80, 12);
            this.label_DropboxDir.TabIndex = 3;
            this.label_DropboxDir.Text = "Dropbox Folder";
            // 
            // textBox_DropboxDir
            // 
            this.textBox_DropboxDir.Location = new System.Drawing.Point(155, 64);
            this.textBox_DropboxDir.Name = "textBox_DropboxDir";
            this.textBox_DropboxDir.Size = new System.Drawing.Size(631, 22);
            this.textBox_DropboxDir.TabIndex = 4;
            // 
            // button_DropboxDir
            // 
            this.button_DropboxDir.Location = new System.Drawing.Point(792, 64);
            this.button_DropboxDir.Name = "button_DropboxDir";
            this.button_DropboxDir.Size = new System.Drawing.Size(75, 23);
            this.button_DropboxDir.TabIndex = 5;
            this.button_DropboxDir.Text = "Browse";
            this.button_DropboxDir.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(792, 419);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 6;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 454);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_DropboxDir);
            this.Controls.Add(this.textBox_DropboxDir);
            this.Controls.Add(this.label_DropboxDir);
            this.Controls.Add(this.button_DbDir);
            this.Controls.Add(this.textBox_DbDir);
            this.Controls.Add(this.label_DbDir);
            this.Name = "FormSetting";
            this.Text = "FormSetting";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_DbDir;
        private System.Windows.Forms.TextBox textBox_DbDir;
        private System.Windows.Forms.Button button_DbDir;
        private System.Windows.Forms.Label label_DropboxDir;
        private System.Windows.Forms.TextBox textBox_DropboxDir;
        private System.Windows.Forms.Button button_DropboxDir;
        private System.Windows.Forms.Button button_Save;
    }
}