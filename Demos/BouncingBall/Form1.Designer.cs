namespace PracticeApp1
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
            this.components = new System.ComponentModel.Container();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.m_Physics = new System.Windows.Forms.Timer(this.components);
            this.createLots = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.m_fps = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.Location = new System.Drawing.Point(12, 46);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(789, 604);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // m_Physics
            // 
            this.m_Physics.Enabled = true;
            this.m_Physics.Interval = 15;
            this.m_Physics.Tick += new System.EventHandler(this.MPhysicsTick);
            // 
            // createLots
            // 
            this.createLots.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createLots.Location = new System.Drawing.Point(128, 7);
            this.createLots.Name = "createLots";
            this.createLots.Size = new System.Drawing.Size(216, 33);
            this.createLots.TabIndex = 1;
            this.createLots.Text = "Create 100 balls";
            this.createLots.UseVisualStyleBackColor = true;
            this.createLots.Click += new System.EventHandler(this.CreateLotsClick);
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(12, 8);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(110, 32);
            this.start.TabIndex = 2;
            this.start.Text = "Restart";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.StartClick);
            // 
            // m_fps
            // 
            this.m_fps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_fps.AutoSize = true;
            this.m_fps.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_fps.Location = new System.Drawing.Point(723, 7);
            this.m_fps.Name = "m_fps";
            this.m_fps.Size = new System.Drawing.Size(66, 24);
            this.m_fps.TabIndex = 3;
            this.m_fps.Text = "FPS: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 662);
            this.Controls.Add(this.m_fps);
            this.Controls.Add(this.start);
            this.Controls.Add(this.createLots);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Bouncing Ball Profiler Demo";
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Timer m_Physics;
        private System.Windows.Forms.Button createLots;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label m_fps;

    }
}

