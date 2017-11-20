namespace AsyncFileAccess
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
            this.folderBrowserSource = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxDestSelect = new System.Windows.Forms.TextBox();
            this.buttonSourceBrowse = new System.Windows.Forms.Button();
            this.textBoxSourceSelect = new System.Windows.Forms.TextBox();
            this.labelDestFolder = new System.Windows.Forms.Label();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.labelSourceFolder = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonDestBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDest = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarCopied = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // textBoxDestSelect
            // 
            this.textBoxDestSelect.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxDestSelect.Location = new System.Drawing.Point(87, 53);
            this.textBoxDestSelect.Name = "textBoxDestSelect";
            this.textBoxDestSelect.Size = new System.Drawing.Size(235, 20);
            this.textBoxDestSelect.TabIndex = 0;
            this.textBoxDestSelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonSourceBrowse
            // 
            this.buttonSourceBrowse.Location = new System.Drawing.Point(328, 12);
            this.buttonSourceBrowse.Name = "buttonSourceBrowse";
            this.buttonSourceBrowse.Size = new System.Drawing.Size(61, 23);
            this.buttonSourceBrowse.TabIndex = 1;
            this.buttonSourceBrowse.Text = "Browse";
            this.buttonSourceBrowse.UseVisualStyleBackColor = true;
            this.buttonSourceBrowse.Click += new System.EventHandler(this.buttonSourceBrowse_Click);
            // 
            // textBoxSourceSelect
            // 
            this.textBoxSourceSelect.Location = new System.Drawing.Point(87, 14);
            this.textBoxSourceSelect.Name = "textBoxSourceSelect";
            this.textBoxSourceSelect.Size = new System.Drawing.Size(235, 20);
            this.textBoxSourceSelect.TabIndex = 2;
            this.textBoxSourceSelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelDestFolder
            // 
            this.labelDestFolder.AutoSize = true;
            this.labelDestFolder.Location = new System.Drawing.Point(12, 56);
            this.labelDestFolder.Name = "labelDestFolder";
            this.labelDestFolder.Size = new System.Drawing.Size(61, 13);
            this.labelDestFolder.TabIndex = 3;
            this.labelDestFolder.Text = "Dest folder:";
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(15, 90);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(374, 45);
            this.buttonCopy.TabIndex = 0;
            this.buttonCopy.Text = "Copy!";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // labelSourceFolder
            // 
            this.labelSourceFolder.AutoSize = true;
            this.labelSourceFolder.Location = new System.Drawing.Point(12, 17);
            this.labelSourceFolder.Name = "labelSourceFolder";
            this.labelSourceFolder.Size = new System.Drawing.Size(73, 13);
            this.labelSourceFolder.TabIndex = 5;
            this.labelSourceFolder.Text = "Source folder:";
            // 
            // labelResult
            // 
            this.labelResult.Location = new System.Drawing.Point(84, 149);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(304, 19);
            this.labelResult.TabIndex = 6;
            // 
            // buttonDestBrowse
            // 
            this.buttonDestBrowse.Location = new System.Drawing.Point(328, 51);
            this.buttonDestBrowse.Name = "buttonDestBrowse";
            this.buttonDestBrowse.Size = new System.Drawing.Size(60, 23);
            this.buttonDestBrowse.TabIndex = 7;
            this.buttonDestBrowse.Text = "Browse";
            this.buttonDestBrowse.UseVisualStyleBackColor = true;
            this.buttonDestBrowse.Click += new System.EventHandler(this.buttonDestBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Progress:";
            // 
            // progressBarCopied
            // 
            this.progressBarCopied.Location = new System.Drawing.Point(87, 145);
            this.progressBarCopied.Name = "progressBarCopied";
            this.progressBarCopied.Size = new System.Drawing.Size(302, 23);
            this.progressBarCopied.TabIndex = 9;
            this.progressBarCopied.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 196);
            this.Controls.Add(this.progressBarCopied);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDestBrowse);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelSourceFolder);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.labelDestFolder);
            this.Controls.Add(this.textBoxSourceSelect);
            this.Controls.Add(this.buttonSourceBrowse);
            this.Controls.Add(this.textBoxDestSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Folder copier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserSource;
        private System.Windows.Forms.TextBox textBoxDestSelect;
        private System.Windows.Forms.Button buttonSourceBrowse;
        private System.Windows.Forms.TextBox textBoxSourceSelect;
        private System.Windows.Forms.Label labelDestFolder;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Label labelSourceFolder;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonDestBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarCopied;
    }
}

