namespace BookSearch
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.textBoxIsbn = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelIsbn = new System.Windows.Forms.Label();
            this.labelTitleLabel = new System.Windows.Forms.Label();
            this.labelAuthorLabel = new System.Windows.Forms.Label();
            this.labelCopiesLabel = new System.Windows.Forms.Label();
            this.labelPublishDateLabel = new System.Windows.Forms.Label();
            this.labelSizeLabel = new System.Windows.Forms.Label();
            this.labelTitleResult = new System.Windows.Forms.Label();
            this.labelAuthorResult = new System.Windows.Forms.Label();
            this.labelPublishDateResult = new System.Windows.Forms.Label();
            this.labelCopiesResult = new System.Windows.Forms.Label();
            this.labelSizeResult = new System.Windows.Forms.Label();
            this.labelStatusLabel = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxIsbn
            // 
            this.textBoxIsbn.Location = new System.Drawing.Point(98, 17);
            this.textBoxIsbn.Name = "textBoxIsbn";
            this.textBoxIsbn.Size = new System.Drawing.Size(134, 20);
            this.textBoxIsbn.TabIndex = 0;
            this.textBoxIsbn.Text = "978-1-906434-93-9";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(247, 15);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelIsbn
            // 
            this.labelIsbn.AutoSize = true;
            this.labelIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIsbn.Location = new System.Drawing.Point(50, 20);
            this.labelIsbn.Name = "labelIsbn";
            this.labelIsbn.Size = new System.Drawing.Size(35, 13);
            this.labelIsbn.TabIndex = 2;
            this.labelIsbn.Text = "ISBN:";
            // 
            // labelTitleLabel
            // 
            this.labelTitleLabel.AutoSize = true;
            this.labelTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleLabel.Location = new System.Drawing.Point(54, 88);
            this.labelTitleLabel.Name = "labelTitleLabel";
            this.labelTitleLabel.Size = new System.Drawing.Size(36, 13);
            this.labelTitleLabel.TabIndex = 3;
            this.labelTitleLabel.Text = "Title:";
            // 
            // labelAuthorLabel
            // 
            this.labelAuthorLabel.AutoSize = true;
            this.labelAuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorLabel.Location = new System.Drawing.Point(42, 118);
            this.labelAuthorLabel.Name = "labelAuthorLabel";
            this.labelAuthorLabel.Size = new System.Drawing.Size(48, 13);
            this.labelAuthorLabel.TabIndex = 4;
            this.labelAuthorLabel.Text = "Author:";
            // 
            // labelCopiesLabel
            // 
            this.labelCopiesLabel.AutoSize = true;
            this.labelCopiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCopiesLabel.Location = new System.Drawing.Point(41, 148);
            this.labelCopiesLabel.Name = "labelCopiesLabel";
            this.labelCopiesLabel.Size = new System.Drawing.Size(49, 13);
            this.labelCopiesLabel.TabIndex = 5;
            this.labelCopiesLabel.Text = "Copies:";
            // 
            // labelPublishDateLabel
            // 
            this.labelPublishDateLabel.AutoSize = true;
            this.labelPublishDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPublishDateLabel.Location = new System.Drawing.Point(9, 178);
            this.labelPublishDateLabel.Name = "labelPublishDateLabel";
            this.labelPublishDateLabel.Size = new System.Drawing.Size(81, 13);
            this.labelPublishDateLabel.TabIndex = 6;
            this.labelPublishDateLabel.Text = "Publish date:";
            // 
            // labelSizeLabel
            // 
            this.labelSizeLabel.AutoSize = true;
            this.labelSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSizeLabel.Location = new System.Drawing.Point(55, 208);
            this.labelSizeLabel.Name = "labelSizeLabel";
            this.labelSizeLabel.Size = new System.Drawing.Size(35, 13);
            this.labelSizeLabel.TabIndex = 7;
            this.labelSizeLabel.Text = "Size:";
            // 
            // labelTitleResult
            // 
            this.labelTitleResult.AutoSize = true;
            this.labelTitleResult.Location = new System.Drawing.Point(98, 88);
            this.labelTitleResult.Name = "labelTitleResult";
            this.labelTitleResult.Size = new System.Drawing.Size(0, 13);
            this.labelTitleResult.TabIndex = 8;
            // 
            // labelAuthorResult
            // 
            this.labelAuthorResult.AutoSize = true;
            this.labelAuthorResult.Location = new System.Drawing.Point(98, 118);
            this.labelAuthorResult.Name = "labelAuthorResult";
            this.labelAuthorResult.Size = new System.Drawing.Size(0, 13);
            this.labelAuthorResult.TabIndex = 9;
            // 
            // labelPublishDateResult
            // 
            this.labelPublishDateResult.AutoSize = true;
            this.labelPublishDateResult.Location = new System.Drawing.Point(98, 178);
            this.labelPublishDateResult.Name = "labelPublishDateResult";
            this.labelPublishDateResult.Size = new System.Drawing.Size(0, 13);
            this.labelPublishDateResult.TabIndex = 11;
            // 
            // labelCopiesResult
            // 
            this.labelCopiesResult.AutoSize = true;
            this.labelCopiesResult.Location = new System.Drawing.Point(98, 148);
            this.labelCopiesResult.Name = "labelCopiesResult";
            this.labelCopiesResult.Size = new System.Drawing.Size(0, 13);
            this.labelCopiesResult.TabIndex = 10;
            // 
            // labelSizeResult
            // 
            this.labelSizeResult.AutoSize = true;
            this.labelSizeResult.Location = new System.Drawing.Point(98, 208);
            this.labelSizeResult.Name = "labelSizeResult";
            this.labelSizeResult.Size = new System.Drawing.Size(0, 13);
            this.labelSizeResult.TabIndex = 12;
            // 
            // labelStatusLabel
            // 
            this.labelStatusLabel.AutoSize = true;
            this.labelStatusLabel.Location = new System.Drawing.Point(45, 50);
            this.labelStatusLabel.Name = "labelStatusLabel";
            this.labelStatusLabel.Size = new System.Drawing.Size(40, 13);
            this.labelStatusLabel.TabIndex = 13;
            this.labelStatusLabel.Text = "Status:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(95, 50);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 14;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 242);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelStatusLabel);
            this.Controls.Add(this.labelSizeResult);
            this.Controls.Add(this.labelPublishDateResult);
            this.Controls.Add(this.labelCopiesResult);
            this.Controls.Add(this.labelAuthorResult);
            this.Controls.Add(this.labelTitleResult);
            this.Controls.Add(this.labelSizeLabel);
            this.Controls.Add(this.labelPublishDateLabel);
            this.Controls.Add(this.labelCopiesLabel);
            this.Controls.Add(this.labelAuthorLabel);
            this.Controls.Add(this.labelTitleLabel);
            this.Controls.Add(this.labelIsbn);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxIsbn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.Text = "Book Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIsbn;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelIsbn;
        private System.Windows.Forms.Label labelTitleLabel;
        private System.Windows.Forms.Label labelAuthorLabel;
        private System.Windows.Forms.Label labelCopiesLabel;
        private System.Windows.Forms.Label labelPublishDateLabel;
        private System.Windows.Forms.Label labelSizeLabel;
        private System.Windows.Forms.Label labelTitleResult;
        private System.Windows.Forms.Label labelAuthorResult;
        private System.Windows.Forms.Label labelPublishDateResult;
        private System.Windows.Forms.Label labelCopiesResult;
        private System.Windows.Forms.Label labelSizeResult;
        private System.Windows.Forms.Label labelStatusLabel;
        private System.Windows.Forms.Label labelStatus;
    }
}

