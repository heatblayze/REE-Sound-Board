namespace Sound_events
{
    partial class AddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            this.txtSound = new System.Windows.Forms.TextBox();
            this.txtIcon = new System.Windows.Forms.TextBox();
            this.btnSound = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtMod = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackVolume = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkEcho = new System.Windows.Forms.CheckBox();
            this.trackEcho = new System.Windows.Forms.TrackBar();
            this.rb_playmode_multi = new System.Windows.Forms.RadioButton();
            this.rb_playmode_once = new System.Windows.Forms.RadioButton();
            this.rb_playmode_start_stop = new System.Windows.Forms.RadioButton();
            this.groupBox_playmode = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackEcho)).BeginInit();
            this.groupBox_playmode.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSound
            // 
            this.txtSound.Location = new System.Drawing.Point(12, 131);
            this.txtSound.Name = "txtSound";
            this.txtSound.Size = new System.Drawing.Size(239, 20);
            this.txtSound.TabIndex = 0;
            this.txtSound.Text = "Sound file...";
            this.txtSound.TextChanged += new System.EventHandler(this.txtSound_TextChanged);
            // 
            // txtIcon
            // 
            this.txtIcon.Location = new System.Drawing.Point(12, 186);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(239, 20);
            this.txtIcon.TabIndex = 1;
            this.txtIcon.Text = "Icon file...";
            this.txtIcon.TextChanged += new System.EventHandler(this.txtIcon_TextChanged);
            // 
            // btnSound
            // 
            this.btnSound.Location = new System.Drawing.Point(257, 131);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(26, 20);
            this.btnSound.TabIndex = 2;
            this.btnSound.Text = "...";
            this.btnSound.UseVisualStyleBackColor = true;
            this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(257, 185);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(26, 20);
            this.btnImage.TabIndex = 3;
            this.btnImage.Text = "...";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(11, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(208, 279);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtMod
            // 
            this.txtMod.Location = new System.Drawing.Point(13, 44);
            this.txtMod.Name = "txtMod";
            this.txtMod.ReadOnly = true;
            this.txtMod.Size = new System.Drawing.Size(271, 20);
            this.txtMod.TabIndex = 6;
            this.txtMod.Enter += new System.EventHandler(this.txtMod_Enter);
            this.txtMod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMod_KeyDown);
            this.txtMod.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMod_KeyUp);
            this.txtMod.Leave += new System.EventHandler(this.txtMod_Leave);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(12, 82);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(271, 20);
            this.txtKey.TabIndex = 7;
            this.txtKey.Enter += new System.EventHandler(this.txtKey_Enter);
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            this.txtKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyUp);
            this.txtKey.Leave += new System.EventHandler(this.txtKey_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Modifier Keys";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Regular Keys";
            // 
            // trackVolume
            // 
            this.trackVolume.Location = new System.Drawing.Point(11, 228);
            this.trackVolume.Maximum = 100;
            this.trackVolume.Name = "trackVolume";
            this.trackVolume.Size = new System.Drawing.Size(272, 45);
            this.trackVolume.TabIndex = 10;
            this.trackVolume.TabStop = false;
            this.trackVolume.TickFrequency = 10;
            this.trackVolume.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "SoundFile";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Icon File";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(106, 279);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkEcho
            // 
            this.chkEcho.AutoSize = true;
            this.chkEcho.Location = new System.Drawing.Point(329, 24);
            this.chkEcho.Name = "chkEcho";
            this.chkEcho.Size = new System.Drawing.Size(51, 17);
            this.chkEcho.TabIndex = 14;
            this.chkEcho.Text = "Echo";
            this.chkEcho.UseVisualStyleBackColor = true;
            this.chkEcho.CheckedChanged += new System.EventHandler(this.chkEcho_CheckedChanged);
            // 
            // trackEcho
            // 
            this.trackEcho.Location = new System.Drawing.Point(386, 24);
            this.trackEcho.Maximum = 1000;
            this.trackEcho.Minimum = 50;
            this.trackEcho.Name = "trackEcho";
            this.trackEcho.Size = new System.Drawing.Size(104, 45);
            this.trackEcho.TabIndex = 15;
            this.trackEcho.TabStop = false;
            this.trackEcho.TickFrequency = 190;
            this.trackEcho.Value = 50;
            this.trackEcho.Scroll += new System.EventHandler(this.trackEcho_Scroll);
            // 
            // rb_playmode_multi
            // 
            this.rb_playmode_multi.AutoSize = true;
            this.rb_playmode_multi.Location = new System.Drawing.Point(17, 19);
            this.rb_playmode_multi.Name = "rb_playmode_multi";
            this.rb_playmode_multi.Size = new System.Drawing.Size(87, 17);
            this.rb_playmode_multi.TabIndex = 17;
            this.rb_playmode_multi.TabStop = true;
            this.rb_playmode_multi.Text = "Multi (normal)";
            this.rb_playmode_multi.UseVisualStyleBackColor = true;
            this.rb_playmode_multi.CheckedChanged += new System.EventHandler(this.rb_playmode_multi_CheckedChanged);
            // 
            // rb_playmode_once
            // 
            this.rb_playmode_once.AutoSize = true;
            this.rb_playmode_once.Location = new System.Drawing.Point(17, 42);
            this.rb_playmode_once.Name = "rb_playmode_once";
            this.rb_playmode_once.Size = new System.Drawing.Size(51, 17);
            this.rb_playmode_once.TabIndex = 18;
            this.rb_playmode_once.TabStop = true;
            this.rb_playmode_once.Text = "Once";
            this.rb_playmode_once.UseVisualStyleBackColor = true;
            this.rb_playmode_once.CheckedChanged += new System.EventHandler(this.rb_playmode_once_CheckedChanged);
            // 
            // rb_playmode_start_stop
            // 
            this.rb_playmode_start_stop.AutoSize = true;
            this.rb_playmode_start_stop.Location = new System.Drawing.Point(17, 65);
            this.rb_playmode_start_stop.Name = "rb_playmode_start_stop";
            this.rb_playmode_start_stop.Size = new System.Drawing.Size(80, 17);
            this.rb_playmode_start_stop.TabIndex = 19;
            this.rb_playmode_start_stop.TabStop = true;
            this.rb_playmode_start_stop.Text = "Start / Stop";
            this.rb_playmode_start_stop.UseVisualStyleBackColor = true;
            this.rb_playmode_start_stop.CheckedChanged += new System.EventHandler(this.rb_playmode_start_stop_CheckedChanged);
            // 
            // groupBox_playmode
            // 
            this.groupBox_playmode.Controls.Add(this.rb_playmode_multi);
            this.groupBox_playmode.Controls.Add(this.rb_playmode_start_stop);
            this.groupBox_playmode.Controls.Add(this.rb_playmode_once);
            this.groupBox_playmode.Location = new System.Drawing.Point(329, 66);
            this.groupBox_playmode.Name = "groupBox_playmode";
            this.groupBox_playmode.Size = new System.Drawing.Size(173, 85);
            this.groupBox_playmode.TabIndex = 20;
            this.groupBox_playmode.TabStop = false;
            this.groupBox_playmode.Text = "Play Mode";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 329);
            this.Controls.Add(this.groupBox_playmode);
            this.Controls.Add(this.trackEcho);
            this.Controls.Add(this.chkEcho);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackVolume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtMod);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.btnSound);
            this.Controls.Add(this.txtIcon);
            this.Controls.Add(this.txtSound);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "New Sound";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackEcho)).EndInit();
            this.groupBox_playmode.ResumeLayout(false);
            this.groupBox_playmode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSound;
        private System.Windows.Forms.TextBox txtIcon;
        private System.Windows.Forms.Button btnSound;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtMod;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkEcho;
        private System.Windows.Forms.TrackBar trackEcho;
        private System.Windows.Forms.RadioButton rb_playmode_multi;
        private System.Windows.Forms.RadioButton rb_playmode_once;
        private System.Windows.Forms.RadioButton rb_playmode_start_stop;
        private System.Windows.Forms.GroupBox groupBox_playmode;
    }
}