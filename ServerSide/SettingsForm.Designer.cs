namespace ServerSide
{
    partial class SettingsForm
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
            this.chkbx_draw = new System.Windows.Forms.CheckBox();
            this.chkbx_sound = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Brwsr_btn = new System.Windows.Forms.Button();
            this.Excption_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkbx_draw
            // 
            this.chkbx_draw.AutoSize = true;
            this.chkbx_draw.Checked = true;
            this.chkbx_draw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbx_draw.Location = new System.Drawing.Point(12, 27);
            this.chkbx_draw.Name = "chkbx_draw";
            this.chkbx_draw.Size = new System.Drawing.Size(129, 17);
            this.chkbx_draw.TabIndex = 0;
            this.chkbx_draw.Text = "Draw Recieving Point";
            this.chkbx_draw.UseVisualStyleBackColor = true;
            // 
            // chkbx_sound
            // 
            this.chkbx_sound.AutoSize = true;
            this.chkbx_sound.Checked = true;
            this.chkbx_sound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbx_sound.Location = new System.Drawing.Point(12, 50);
            this.chkbx_sound.Name = "chkbx_sound";
            this.chkbx_sound.Size = new System.Drawing.Size(113, 17);
            this.chkbx_sound.TabIndex = 1;
            this.chkbx_sound.Text = "Notification Sound";
            this.chkbx_sound.UseVisualStyleBackColor = true;
            this.chkbx_sound.CheckedChanged += new System.EventHandler(this.Chkbx_sound_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(150, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(402, 251);
            this.listBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 19);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add Plot From File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select a Plot";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(44, 111);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(44, 137);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(44, 163);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(44, 189);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Xstart";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ystart";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Xend";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Yend";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Insert Limit of {X, Y}";
            // 
            // Brwsr_btn
            // 
            this.Brwsr_btn.Location = new System.Drawing.Point(6, 228);
            this.Brwsr_btn.Name = "Brwsr_btn";
            this.Brwsr_btn.Size = new System.Drawing.Size(135, 23);
            this.Brwsr_btn.TabIndex = 15;
            this.Brwsr_btn.Text = "Add Plot From GMaps";
            this.Brwsr_btn.UseVisualStyleBackColor = true;
            this.Brwsr_btn.Click += new System.EventHandler(this.Brwsr_btn_Click);
            // 
            // Excption_lbl
            // 
            this.Excption_lbl.AutoSize = true;
            this.Excption_lbl.Location = new System.Drawing.Point(12, 212);
            this.Excption_lbl.Name = "Excption_lbl";
            this.Excption_lbl.Size = new System.Drawing.Size(0, 13);
            this.Excption_lbl.TabIndex = 16;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 280);
            this.Controls.Add(this.Excption_lbl);
            this.Controls.Add(this.Brwsr_btn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.chkbx_sound);
            this.Controls.Add(this.chkbx_draw);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkbx_draw;
        private System.Windows.Forms.CheckBox chkbx_sound;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Brwsr_btn;
        private System.Windows.Forms.Label Excption_lbl;
    }
}