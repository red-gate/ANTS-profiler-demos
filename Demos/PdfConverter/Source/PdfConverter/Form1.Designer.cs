namespace PdfConverter
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
            this.buttonBegin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPageSelector = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonSaveOutput = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonChooseOutput = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPageSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBegin
            // 
            this.buttonBegin.Location = new System.Drawing.Point(8, 13);
            this.buttonBegin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBegin.Name = "buttonBegin";
            this.buttonBegin.Size = new System.Drawing.Size(317, 257);
            this.buttonBegin.TabIndex = 0;
            this.buttonBegin.Text = "Load Pdf File";
            this.buttonBegin.UseVisualStyleBackColor = true;
            this.buttonBegin.Click += new System.EventHandler(this.buttonBegin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(337, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 600);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 2;
            // 
            // numericUpDownPageSelector
            // 
            this.numericUpDownPageSelector.Enabled = false;
            this.numericUpDownPageSelector.Location = new System.Drawing.Point(181, 321);
            this.numericUpDownPageSelector.Name = "numericUpDownPageSelector";
            this.numericUpDownPageSelector.Size = new System.Drawing.Size(143, 22);
            this.numericUpDownPageSelector.TabIndex = 3;
            this.numericUpDownPageSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPageSelector.ValueChanged += new System.EventHandler(this.numericUpDownPageSelector_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(12, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose page to preview:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Adobe Acrobat Files|*.pdf";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // buttonSaveOutput
            // 
            this.buttonSaveOutput.Enabled = false;
            this.buttonSaveOutput.Location = new System.Drawing.Point(7, 498);
            this.buttonSaveOutput.Name = "buttonSaveOutput";
            this.buttonSaveOutput.Size = new System.Drawing.Size(317, 114);
            this.buttonSaveOutput.TabIndex = 6;
            this.buttonSaveOutput.Text = "Save Images";
            this.buttonSaveOutput.UseVisualStyleBackColor = true;
            this.buttonSaveOutput.Click += new System.EventHandler(this.buttonSaveOutput_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 7;
            // 
            // buttonChooseOutput
            // 
            this.buttonChooseOutput.Enabled = false;
            this.buttonChooseOutput.Location = new System.Drawing.Point(7, 367);
            this.buttonChooseOutput.Name = "buttonChooseOutput";
            this.buttonChooseOutput.Size = new System.Drawing.Size(317, 85);
            this.buttonChooseOutput.TabIndex = 8;
            this.buttonChooseOutput.Text = "Select output folder";
            this.buttonChooseOutput.UseVisualStyleBackColor = true;
            this.buttonChooseOutput.Click += new System.EventHandler(this.buttonChooseOutput_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 467);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 622);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonChooseOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSaveOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownPageSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonBegin);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Pdf Converter (ANTS Memory Profiler unmanaged code demo)";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPageSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBegin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPageSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonSaveOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonChooseOutput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
    }
}

