using System;

namespace QueryBee
{
    partial class ConnectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.m_comboServer = new System.Windows.Forms.ComboBox();
            this.m_labelServer = new System.Windows.Forms.Label();
            this.m_ComboDatabase = new System.Windows.Forms.ComboBox();
            this.m_labelDatabase = new System.Windows.Forms.Label();
            this.m_trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_traymenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_trayMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.m_trayMenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.m_connectButton = new System.Windows.Forms.Button();
            this.m_connectProgress = new System.Windows.Forms.ProgressBar();
            this.m_labelError = new System.Windows.Forms.Label();
            this.m_traymenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_comboServer
            // 
            this.m_comboServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_comboServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.m_comboServer.FormattingEnabled = true;
            this.m_comboServer.Location = new System.Drawing.Point(75, 12);
            this.m_comboServer.Name = "m_comboServer";
            this.m_comboServer.Size = new System.Drawing.Size(165, 21);
            this.m_comboServer.TabIndex = 1;
            this.m_comboServer.Text = "localhost";
            // 
            // m_labelServer
            // 
            this.m_labelServer.AutoSize = true;
            this.m_labelServer.Location = new System.Drawing.Point(31, 12);
            this.m_labelServer.Name = "m_labelServer";
            this.m_labelServer.Size = new System.Drawing.Size(38, 13);
            this.m_labelServer.TabIndex = 0;
            this.m_labelServer.Text = "&Server";
            // 
            // m_ComboDatabase
            // 
            this.m_ComboDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_ComboDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.m_ComboDatabase.FormattingEnabled = true;
            this.m_ComboDatabase.Location = new System.Drawing.Point(75, 40);
            this.m_ComboDatabase.Name = "m_ComboDatabase";
            this.m_ComboDatabase.Size = new System.Drawing.Size(165, 21);
            this.m_ComboDatabase.TabIndex = 3;
            this.m_ComboDatabase.Enter += new System.EventHandler(this.m_comboDatabase_clickIn);
            this.m_ComboDatabase.TextChanged += new System.EventHandler(this.m_ComboDatabase_TextChanged);
            // 
            // m_labelDatabase
            // 
            this.m_labelDatabase.AutoSize = true;
            this.m_labelDatabase.Location = new System.Drawing.Point(16, 40);
            this.m_labelDatabase.Name = "m_labelDatabase";
            this.m_labelDatabase.Size = new System.Drawing.Size(53, 13);
            this.m_labelDatabase.TabIndex = 2;
            this.m_labelDatabase.Text = "&Database";
            // 
            // m_trayIcon
            // 
            this.m_trayIcon.ContextMenuStrip = this.m_traymenu;
            this.m_trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_trayIcon.Icon")));
            this.m_trayIcon.Text = "QueryBee";
            this.m_trayIcon.Visible = true;
            this.m_trayIcon.DoubleClick += new System.EventHandler(this.m_trayIcon_DoubleClick);
            // 
            // m_traymenu
            // 
            this.m_traymenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_trayMenuOpen,
            this.m_trayMenuClose});
            this.m_traymenu.Name = "contextMenuStrip1";
            this.m_traymenu.Size = new System.Drawing.Size(112, 48);
            // 
            // m_trayMenuOpen
            // 
            this.m_trayMenuOpen.Name = "m_trayMenuOpen";
            this.m_trayMenuOpen.Size = new System.Drawing.Size(111, 22);
            this.m_trayMenuOpen.Text = "Open";
            this.m_trayMenuOpen.Click += new System.EventHandler(this.m_trayMenuOpen_Click);
            // 
            // m_trayMenuClose
            // 
            this.m_trayMenuClose.Name = "m_trayMenuClose";
            this.m_trayMenuClose.Size = new System.Drawing.Size(111, 22);
            this.m_trayMenuClose.Text = "Close";
            this.m_trayMenuClose.Click += new System.EventHandler(this.m_trayMenuClose_Click);
            // 
            // m_connectButton
            // 
            this.m_connectButton.Enabled = false;
            this.m_connectButton.Location = new System.Drawing.Point(166, 67);
            this.m_connectButton.Name = "m_connectButton";
            this.m_connectButton.Size = new System.Drawing.Size(75, 23);
            this.m_connectButton.TabIndex = 4;
            this.m_connectButton.Text = "&Connect";
            this.m_connectButton.UseVisualStyleBackColor = true;
            this.m_connectButton.Click += new System.EventHandler(this.m_connectButton_Click);
            // 
            // m_connectProgress
            // 
            this.m_connectProgress.Location = new System.Drawing.Point(97, 67);
            this.m_connectProgress.Name = "m_connectProgress";
            this.m_connectProgress.Size = new System.Drawing.Size(144, 23);
            this.m_connectProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.m_connectProgress.TabIndex = 5;
            this.m_connectProgress.Visible = false;
            // 
            // m_labelError
            // 
            this.m_labelError.AutoSize = true;
            this.m_labelError.BackColor = System.Drawing.SystemColors.Control;
            this.m_labelError.Location = new System.Drawing.Point(31, 72);
            this.m_labelError.Name = "m_labelError";
            this.m_labelError.Size = new System.Drawing.Size(7, 13);
            this.m_labelError.TabIndex = 6;
            this.m_labelError.Text = "\r\n";
            this.m_labelError.Visible = false;
            // 
            // ConnectForm
            // 
            this.AcceptButton = this.m_connectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 101);
            this.Controls.Add(this.m_labelError);
            this.Controls.Add(this.m_connectProgress);
            this.Controls.Add(this.m_connectButton);
            this.Controls.Add(this.m_labelDatabase);
            this.Controls.Add(this.m_ComboDatabase);
            this.Controls.Add(this.m_comboServer);
            this.Controls.Add(this.m_labelServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConnectForm";
            this.ShowInTaskbar = false;
            this.Text = "QueryBee";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.m_traymenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox m_comboServer;
        private System.Windows.Forms.Label m_labelServer;
        private System.Windows.Forms.ComboBox m_ComboDatabase;
        private System.Windows.Forms.Label m_labelDatabase;
        private System.Windows.Forms.NotifyIcon m_trayIcon;
        private System.Windows.Forms.Button m_connectButton;
        private System.Windows.Forms.ProgressBar m_connectProgress;
        private SystemHotkey m_hotkey;
        private System.Windows.Forms.ContextMenuStrip m_traymenu;
        private System.Windows.Forms.ToolStripMenuItem m_trayMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem m_trayMenuClose;
        private System.Windows.Forms.Label m_labelError;
    }
}

