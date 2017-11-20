namespace QueryBee
{
    partial class QueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
            this.m_textQuery = new System.Windows.Forms.TextBox();
            this.m_execute = new System.Windows.Forms.Button();
            this.m_dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_labelErrorTri = new System.Windows.Forms.Label();
            this.m_labelError = new System.Windows.Forms.Label();
            this.m_progress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_textQuery
            // 
            this.m_textQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_textQuery.Location = new System.Drawing.Point(0, 0);
            this.m_textQuery.Name = "m_textQuery";
            this.m_textQuery.Size = new System.Drawing.Size(600, 20);
            this.m_textQuery.TabIndex = 0;
            this.m_textQuery.Text = "Enter SQL Query";
            // 
            // m_execute
            // 
            this.m_execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_execute.Location = new System.Drawing.Point(480, 27);
            this.m_execute.Name = "m_execute";
            this.m_execute.Size = new System.Drawing.Size(108, 23);
            this.m_execute.TabIndex = 1;
            this.m_execute.Text = "&Execute Query";
            this.m_execute.UseVisualStyleBackColor = true;
            this.m_execute.Click += new System.EventHandler(this.m_execute_Click);
            // 
            // m_dataGridView
            // 
            this.m_dataGridView.AllowUserToAddRows = false;
            this.m_dataGridView.AllowUserToDeleteRows = false;
            this.m_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGridView.Location = new System.Drawing.Point(0, 0);
            this.m_dataGridView.Name = "m_dataGridView";
            this.m_dataGridView.ReadOnly = true;
            this.m_dataGridView.Size = new System.Drawing.Size(600, 391);
            this.m_dataGridView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_labelErrorTri);
            this.panel1.Controls.Add(this.m_execute);
            this.panel1.Controls.Add(this.m_textQuery);
            this.panel1.Controls.Add(this.m_labelError);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 391);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 62);
            this.panel1.TabIndex = 2;
            // 
            // m_labelErrorTri
            // 
            this.m_labelErrorTri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_labelErrorTri.Image = ((System.Drawing.Image)(resources.GetObject("m_labelErrorTri.Image")));
            this.m_labelErrorTri.Location = new System.Drawing.Point(12, 27);
            this.m_labelErrorTri.Name = "m_labelErrorTri";
            this.m_labelErrorTri.Size = new System.Drawing.Size(20, 20);
            this.m_labelErrorTri.TabIndex = 2;
            this.m_labelErrorTri.Visible = false;
            // 
            // m_labelError
            // 
            this.m_labelError.AllowDrop = true;
            this.m_labelError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_labelError.Location = new System.Drawing.Point(38, 23);
            this.m_labelError.Name = "m_labelError";
            this.m_labelError.Size = new System.Drawing.Size(436, 39);
            this.m_labelError.TabIndex = 3;
            this.m_labelError.Visible = false;
            // 
            // m_progress
            // 
            this.m_progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_progress.Location = new System.Drawing.Point(257, 194);
            this.m_progress.Name = "m_progress";
            this.m_progress.Size = new System.Drawing.Size(100, 23);
            this.m_progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.m_progress.TabIndex = 1;
            this.m_progress.Visible = false;
            // 
            // QueryForm
            // 
            this.AcceptButton = this.m_execute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 453);
            this.Controls.Add(this.m_progress);
            this.Controls.Add(this.m_dataGridView);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QueryForm";
            this.Text = "QueryBee - ";
            this.Resize += new System.EventHandler(this.QueryForm_Resize);
            this.Load += new System.EventHandler(this.QueryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox m_textQuery;
        private System.Windows.Forms.Button m_execute;
        private System.Windows.Forms.DataGridView m_dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar m_progress;
        private System.Windows.Forms.Label m_labelError;
        private System.Windows.Forms.Label m_labelErrorTri;
    }
}