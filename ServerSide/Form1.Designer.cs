namespace ServerSide
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInterpolation = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.RichTextBox();
            this.btn_settings = new System.Windows.Forms.Button();
            this.btn_server = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInterpolation
            // 
            this.btnInterpolation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInterpolation.Location = new System.Drawing.Point(764, 571);
            this.btnInterpolation.Name = "btnInterpolation";
            this.btnInterpolation.Size = new System.Drawing.Size(176, 39);
            this.btnInterpolation.TabIndex = 6;
            this.btnInterpolation.Text = "Get Interpolation";
            this.btnInterpolation.UseVisualStyleBackColor = true;
            this.btnInterpolation.Click += new System.EventHandler(this.BtnInterpolation_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(460, 392);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(764, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 501);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Messages";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.ReadOnly = true;
            this.label1.Size = new System.Drawing.Size(338, 475);
            this.label1.TabIndex = 13;
            this.label1.Text = "";
            // 
            // btn_settings
            // 
            this.btn_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_settings.Location = new System.Drawing.Point(764, 12);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(176, 46);
            this.btn_settings.TabIndex = 9;
            this.btn_settings.Text = "Settings";
            this.btn_settings.UseVisualStyleBackColor = true;
            this.btn_settings.Click += new System.EventHandler(this.Btn_settings_Click);
            // 
            // btn_server
            // 
            this.btn_server.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_server.Location = new System.Drawing.Point(946, 12);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(163, 46);
            this.btn_server.TabIndex = 10;
            this.btn_server.Text = "Enable Server";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Click += new System.EventHandler(this.Btn_server_Click);
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_print.Location = new System.Drawing.Point(946, 571);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(169, 39);
            this.btn_print.TabIndex = 11;
            this.btn_print.Text = "Print Received Points";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.Btn_print_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(764, 616);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(351, 26);
            this.progressBar1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1127, 646);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_server);
            this.Controls.Add(this.btn_settings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInterpolation);
            this.MinimumSize = new System.Drawing.Size(1143, 685);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Interpolator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnInterpolation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Button btn_server;
        private System.Windows.Forms.Button btn_print;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox label1;
    }
}

