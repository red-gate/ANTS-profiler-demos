namespace WSClient
{
    partial class ShovellSubmitterForm
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
            this.m_labelUsername = new System.Windows.Forms.Label();
            this.m_username = new System.Windows.Forms.TextBox();
            this.m_contents = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_labelTitle = new System.Windows.Forms.Label();
            this.m_labelPassword = new System.Windows.Forms.Label();
            this.m_title = new System.Windows.Forms.TextBox();
            this.m_password = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_submit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labelUsername
            // 
            this.m_labelUsername.AutoSize = true;
            this.m_labelUsername.Location = new System.Drawing.Point(14, 6);
            this.m_labelUsername.Name = "m_labelUsername";
            this.m_labelUsername.Size = new System.Drawing.Size(55, 13);
            this.m_labelUsername.TabIndex = 0;
            this.m_labelUsername.Text = "&Username";
            // 
            // m_username
            // 
            this.m_username.Location = new System.Drawing.Point(73, 6);
            this.m_username.Name = "m_username";
            this.m_username.Size = new System.Drawing.Size(75, 20);
            this.m_username.TabIndex = 1;
            // 
            // m_contents
            // 
            this.m_contents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_contents.Location = new System.Drawing.Point(0, 81);
            this.m_contents.Multiline = true;
            this.m_contents.Name = "m_contents";
            this.m_contents.Size = new System.Drawing.Size(360, 170);
            this.m_contents.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_labelTitle);
            this.panel1.Controls.Add(this.m_labelPassword);
            this.panel1.Controls.Add(this.m_labelUsername);
            this.panel1.Controls.Add(this.m_title);
            this.panel1.Controls.Add(this.m_password);
            this.panel1.Controls.Add(this.m_username);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 81);
            this.panel1.TabIndex = 0;
            // 
            // m_labelTitle
            // 
            this.m_labelTitle.AutoSize = true;
            this.m_labelTitle.Location = new System.Drawing.Point(38, 55);
            this.m_labelTitle.Name = "m_labelTitle";
            this.m_labelTitle.Size = new System.Drawing.Size(27, 13);
            this.m_labelTitle.TabIndex = 4;
            this.m_labelTitle.Text = "&Title";
            // 
            // m_labelPassword
            // 
            this.m_labelPassword.AutoSize = true;
            this.m_labelPassword.Location = new System.Drawing.Point(14, 32);
            this.m_labelPassword.Name = "m_labelPassword";
            this.m_labelPassword.Size = new System.Drawing.Size(53, 13);
            this.m_labelPassword.TabIndex = 2;
            this.m_labelPassword.Text = "&Password";
            // 
            // m_title
            // 
            this.m_title.Location = new System.Drawing.Point(73, 55);
            this.m_title.Name = "m_title";
            this.m_title.Size = new System.Drawing.Size(184, 20);
            this.m_title.TabIndex = 5;
            // 
            // m_password
            // 
            this.m_password.Location = new System.Drawing.Point(73, 29);
            this.m_password.Name = "m_password";
            this.m_password.Size = new System.Drawing.Size(75, 20);
            this.m_password.TabIndex = 3;
            this.m_password.UseSystemPasswordChar = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_submit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 251);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 29);
            this.panel2.TabIndex = 2;
            // 
            // m_submit
            // 
            this.m_submit.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_submit.Location = new System.Drawing.Point(285, 0);
            this.m_submit.Name = "m_submit";
            this.m_submit.Size = new System.Drawing.Size(75, 29);
            this.m_submit.TabIndex = 0;
            this.m_submit.Text = "&Submit Story";
            this.m_submit.UseVisualStyleBackColor = true;
            this.m_submit.Click += new System.EventHandler(this.m_submit_Click);
            // 
            // ShovellSubmitterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 280);
            this.Controls.Add(this.m_contents);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ShovellSubmitterForm";
            this.Text = "Quick Shovell Submitter";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_labelUsername;
        private System.Windows.Forms.TextBox m_username;
        private System.Windows.Forms.TextBox m_contents;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button m_submit;
        private System.Windows.Forms.Label m_labelTitle;
        private System.Windows.Forms.Label m_labelPassword;
        private System.Windows.Forms.TextBox m_title;
        private System.Windows.Forms.TextBox m_password;
    }
}

