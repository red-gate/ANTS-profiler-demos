namespace PictureManager
{
    partial class FormPhotoSelector
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
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.openFileDialogChooseImage = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Location = new System.Drawing.Point(43, 37);
            this.buttonChooseFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(255, 28);
            this.buttonChooseFile.TabIndex = 0;
            this.buttonChooseFile.Text = "Open New Image";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // openFileDialogChooseImage
            // 
            this.openFileDialogChooseImage.FileName = "openFileDialog1";
            this.openFileDialogChooseImage.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogChooseImage_FileOk);
            // 
            // FormPhotoSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 102);
            this.Controls.Add(this.buttonChooseFile);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormPhotoSelector";
            this.Text = "Photo Selector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogChooseImage;
    }
}

