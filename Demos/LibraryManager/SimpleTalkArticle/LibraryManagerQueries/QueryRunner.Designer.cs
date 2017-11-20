namespace LibraryManager
{
    partial class QueryRunner
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
            this.buttonListing2 = new System.Windows.Forms.Button();
            this.buttonListing4 = new System.Windows.Forms.Button();
            this.buttonListing8 = new System.Windows.Forms.Button();
            this.buttonListing10 = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonListing2
            // 
            this.buttonListing2.Location = new System.Drawing.Point(12, 12);
            this.buttonListing2.Name = "buttonListing2";
            this.buttonListing2.Size = new System.Drawing.Size(211, 45);
            this.buttonListing2.TabIndex = 0;
            this.buttonListing2.Text = "Listing 2";
            this.buttonListing2.UseVisualStyleBackColor = true;
            this.buttonListing2.Click += new System.EventHandler(this.buttonListing2_Click);
            // 
            // buttonListing4
            // 
            this.buttonListing4.Location = new System.Drawing.Point(229, 12);
            this.buttonListing4.Name = "buttonListing4";
            this.buttonListing4.Size = new System.Drawing.Size(211, 45);
            this.buttonListing4.TabIndex = 1;
            this.buttonListing4.Text = "Listing 4";
            this.buttonListing4.UseVisualStyleBackColor = true;
            this.buttonListing4.Click += new System.EventHandler(this.buttonListing4_Click);
            // 
            // buttonListing8
            // 
            this.buttonListing8.Location = new System.Drawing.Point(12, 63);
            this.buttonListing8.Name = "buttonListing8";
            this.buttonListing8.Size = new System.Drawing.Size(211, 45);
            this.buttonListing8.TabIndex = 2;
            this.buttonListing8.Text = "Listing 8";
            this.buttonListing8.UseVisualStyleBackColor = true;
            this.buttonListing8.Click += new System.EventHandler(this.buttonListing8_Click);
            // 
            // buttonListing10
            // 
            this.buttonListing10.Location = new System.Drawing.Point(229, 63);
            this.buttonListing10.Name = "buttonListing10";
            this.buttonListing10.Size = new System.Drawing.Size(211, 45);
            this.buttonListing10.TabIndex = 3;
            this.buttonListing10.Text = "Listing 10";
            this.buttonListing10.UseVisualStyleBackColor = true;
            this.buttonListing10.Click += new System.EventHandler(this.buttonListing10_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(17, 125);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 13);
            this.labelResult.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(17, 153);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(131, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "View article on SimpleTalk";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // QueryRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 177);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonListing10);
            this.Controls.Add(this.buttonListing8);
            this.Controls.Add(this.buttonListing4);
            this.Controls.Add(this.buttonListing2);
            this.Name = "QueryRunner";
            this.Text = "Library Manager Query Runner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonListing2;
        private System.Windows.Forms.Button buttonListing4;
        private System.Windows.Forms.Button buttonListing8;
        private System.Windows.Forms.Button buttonListing10;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

