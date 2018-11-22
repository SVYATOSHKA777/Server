namespace ServerSide
{
    partial class InterpolationForm
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
            this.pctrboxInterpolation = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctrboxInterpolation)).BeginInit();
            this.SuspendLayout();
            // 
            // pctrboxInterpolation
            // 
            this.pctrboxInterpolation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctrboxInterpolation.Location = new System.Drawing.Point(13, 13);
            this.pctrboxInterpolation.Name = "pctrboxInterpolation";
            this.pctrboxInterpolation.Size = new System.Drawing.Size(707, 621);
            this.pctrboxInterpolation.TabIndex = 0;
            this.pctrboxInterpolation.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 652);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // InterpolatioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(760, 677);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pctrboxInterpolation);
            this.Name = "InterpolatioForm";
            this.Text = "InterpolatioForm";
            ((System.ComponentModel.ISupportInitialize)(this.pctrboxInterpolation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctrboxInterpolation;
        private System.Windows.Forms.Label label1;

    }
}