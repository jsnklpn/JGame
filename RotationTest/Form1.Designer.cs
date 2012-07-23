namespace RotationTest
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
            this.sliderPosX = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.lblPosY = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sliderPosY = new System.Windows.Forms.TrackBar();
            this.lblAngle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sliderAngle = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPosX)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // sliderPosX
            // 
            this.sliderPosX.Location = new System.Drawing.Point(26, 19);
            this.sliderPosX.Name = "sliderPosX";
            this.sliderPosX.Size = new System.Drawing.Size(135, 45);
            this.sliderPosX.TabIndex = 1;
            this.sliderPosX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderPosX.ValueChanged += new System.EventHandler(this.sliderPosX_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblAngle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.sliderAngle);
            this.groupBox1.Controls.Add(this.lblPosY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.sliderPosY);
            this.groupBox1.Controls.Add(this.lblPosX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sliderPosX);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(237, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 139);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transform";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.BackColor = System.Drawing.Color.Black;
            this.lblPosX.Location = new System.Drawing.Point(167, 22);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(37, 13);
            this.lblPosX.TabIndex = 3;
            this.lblPosX.Text = "01234";
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.BackColor = System.Drawing.Color.Black;
            this.lblPosY.Location = new System.Drawing.Point(167, 57);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(37, 13);
            this.lblPosY.TabIndex = 6;
            this.lblPosY.Text = "01234";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Y";
            // 
            // sliderPosY
            // 
            this.sliderPosY.Location = new System.Drawing.Point(26, 54);
            this.sliderPosY.Name = "sliderPosY";
            this.sliderPosY.Size = new System.Drawing.Size(135, 45);
            this.sliderPosY.TabIndex = 4;
            this.sliderPosY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderPosY.ValueChanged += new System.EventHandler(this.sliderPosY_ValueChanged);
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.BackColor = System.Drawing.Color.Black;
            this.lblAngle.Location = new System.Drawing.Point(167, 94);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(37, 13);
            this.lblAngle.TabIndex = 9;
            this.lblAngle.Text = "01234";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "θ";
            // 
            // sliderAngle
            // 
            this.sliderAngle.Location = new System.Drawing.Point(26, 91);
            this.sliderAngle.Name = "sliderAngle";
            this.sliderAngle.Size = new System.Drawing.Size(135, 45);
            this.sliderAngle.TabIndex = 7;
            this.sliderAngle.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderAngle.ValueChanged += new System.EventHandler(this.sliderAngle_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(458, 339);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.sliderPosX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderAngle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar sliderPosX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar sliderAngle;
        private System.Windows.Forms.Label lblPosY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar sliderPosY;
        private System.Windows.Forms.Label lblPosX;
        private System.Windows.Forms.Label label1;
    }
}

