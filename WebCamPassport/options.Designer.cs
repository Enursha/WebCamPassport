namespace WebCamPassport
{
    partial class Options
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
        public void InitializeComponent()
        {
            this.AutoHighQuality = new System.Windows.Forms.RadioButton();
            this.Custom = new System.Windows.Forms.RadioButton();
            this.OptionsWebCamSettings = new System.Windows.Forms.ComboBox();
            this.OptionsWebCamList = new System.Windows.Forms.ComboBox();
            this.OptionsCropBoxRatioCombobox = new System.Windows.Forms.ComboBox();
            this.savePath = new System.Windows.Forms.TextBox();
            this.browseSavePath = new System.Windows.Forms.Button();
            this.optionsOk = new System.Windows.Forms.Button();
            this.optionCancel = new System.Windows.Forms.Button();
            this.OptionsCameraLabel = new System.Windows.Forms.Label();
            this.OptionsResolutionLabel = new System.Windows.Forms.Label();
            this.OptionsRatioLabel = new System.Windows.Forms.Label();
            this.OptionsNoScalingRadio = new System.Windows.Forms.RadioButton();
            this.OptionsScalingRadio = new System.Windows.Forms.RadioButton();
            this.OptionsScaleHeightTextBox = new System.Windows.Forms.TextBox();
            this.OptionsScaleWidthTextBox = new System.Windows.Forms.TextBox();
            this.OptionsHeightLabel = new System.Windows.Forms.Label();
            this.OptionsWidthLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CameraAuto = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveLocation = new System.Windows.Forms.Label();
            this.OptionsAutoStart = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoHighQuality
            // 
            this.AutoHighQuality.AutoSize = true;
            this.AutoHighQuality.Checked = true;
            this.AutoHighQuality.Location = new System.Drawing.Point(6, 19);
            this.AutoHighQuality.Name = "AutoHighQuality";
            this.AutoHighQuality.Size = new System.Drawing.Size(96, 17);
            this.AutoHighQuality.TabIndex = 1;
            this.AutoHighQuality.TabStop = true;
            this.AutoHighQuality.Text = "Highest Quality";
            this.AutoHighQuality.UseVisualStyleBackColor = true;
            this.AutoHighQuality.CheckedChanged += new System.EventHandler(this.AutoHighQuality_CheckedChanged);
            // 
            // Custom
            // 
            this.Custom.AutoSize = true;
            this.Custom.Location = new System.Drawing.Point(6, 66);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(60, 17);
            this.Custom.TabIndex = 1;
            this.Custom.TabStop = true;
            this.Custom.Text = "Custom";
            this.Custom.UseVisualStyleBackColor = true;
            this.Custom.CheckedChanged += new System.EventHandler(this.Custom_CheckedChanged);
            // 
            // OptionsWebCamSettings
            // 
            this.OptionsWebCamSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OptionsWebCamSettings.Enabled = false;
            this.OptionsWebCamSettings.FormattingEnabled = true;
            this.OptionsWebCamSettings.Location = new System.Drawing.Point(88, 117);
            this.OptionsWebCamSettings.Name = "OptionsWebCamSettings";
            this.OptionsWebCamSettings.Size = new System.Drawing.Size(199, 21);
            this.OptionsWebCamSettings.TabIndex = 3;
            // 
            // OptionsWebCamList
            // 
            this.OptionsWebCamList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OptionsWebCamList.Enabled = false;
            this.OptionsWebCamList.FormattingEnabled = true;
            this.OptionsWebCamList.Location = new System.Drawing.Point(88, 87);
            this.OptionsWebCamList.Name = "OptionsWebCamList";
            this.OptionsWebCamList.Size = new System.Drawing.Size(199, 21);
            this.OptionsWebCamList.TabIndex = 4;
            this.OptionsWebCamList.SelectedIndexChanged += new System.EventHandler(this.OptionsWebCamList_SelectedIndexChanged);
            // 
            // OptionsCropBoxRatioCombobox
            // 
            this.OptionsCropBoxRatioCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OptionsCropBoxRatioCombobox.FormattingEnabled = true;
            this.OptionsCropBoxRatioCombobox.Location = new System.Drawing.Point(101, 180);
            this.OptionsCropBoxRatioCombobox.Name = "OptionsCropBoxRatioCombobox";
            this.OptionsCropBoxRatioCombobox.Size = new System.Drawing.Size(199, 21);
            this.OptionsCropBoxRatioCombobox.TabIndex = 8;
            this.OptionsCropBoxRatioCombobox.SelectedIndexChanged += new System.EventHandler(this.OptionsCropBoxRatioCombobox_SelectedIndexChanged);
            // 
            // savePath
            // 
            this.savePath.Location = new System.Drawing.Point(101, 207);
            this.savePath.Name = "savePath";
            this.savePath.Size = new System.Drawing.Size(199, 20);
            this.savePath.TabIndex = 9;
            // 
            // browseSavePath
            // 
            this.browseSavePath.Location = new System.Drawing.Point(225, 233);
            this.browseSavePath.Name = "browseSavePath";
            this.browseSavePath.Size = new System.Drawing.Size(75, 23);
            this.browseSavePath.TabIndex = 10;
            this.browseSavePath.Text = "Browse";
            this.browseSavePath.UseVisualStyleBackColor = true;
            this.browseSavePath.Click += new System.EventHandler(this.browseSavePath_Click);
            // 
            // optionsOk
            // 
            this.optionsOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.optionsOk.Location = new System.Drawing.Point(360, 178);
            this.optionsOk.Name = "optionsOk";
            this.optionsOk.Size = new System.Drawing.Size(75, 23);
            this.optionsOk.TabIndex = 11;
            this.optionsOk.Text = "OK";
            this.optionsOk.UseVisualStyleBackColor = true;
            // 
            // optionCancel
            // 
            this.optionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.optionCancel.Location = new System.Drawing.Point(360, 210);
            this.optionCancel.Name = "optionCancel";
            this.optionCancel.Size = new System.Drawing.Size(75, 23);
            this.optionCancel.TabIndex = 12;
            this.optionCancel.Text = "Cancel";
            this.optionCancel.UseVisualStyleBackColor = true;
            // 
            // OptionsCameraLabel
            // 
            this.OptionsCameraLabel.AutoSize = true;
            this.OptionsCameraLabel.Location = new System.Drawing.Point(22, 92);
            this.OptionsCameraLabel.Name = "OptionsCameraLabel";
            this.OptionsCameraLabel.Size = new System.Drawing.Size(43, 13);
            this.OptionsCameraLabel.TabIndex = 13;
            this.OptionsCameraLabel.Text = "Camera";
            // 
            // OptionsResolutionLabel
            // 
            this.OptionsResolutionLabel.AutoSize = true;
            this.OptionsResolutionLabel.Location = new System.Drawing.Point(22, 120);
            this.OptionsResolutionLabel.Name = "OptionsResolutionLabel";
            this.OptionsResolutionLabel.Size = new System.Drawing.Size(57, 13);
            this.OptionsResolutionLabel.TabIndex = 14;
            this.OptionsResolutionLabel.Text = "Resolution";
            // 
            // OptionsRatioLabel
            // 
            this.OptionsRatioLabel.AutoSize = true;
            this.OptionsRatioLabel.Location = new System.Drawing.Point(15, 183);
            this.OptionsRatioLabel.Name = "OptionsRatioLabel";
            this.OptionsRatioLabel.Size = new System.Drawing.Size(78, 13);
            this.OptionsRatioLabel.TabIndex = 15;
            this.OptionsRatioLabel.Text = "Crop Box Ratio";
            // 
            // OptionsNoScalingRadio
            // 
            this.OptionsNoScalingRadio.AutoSize = true;
            this.OptionsNoScalingRadio.Checked = true;
            this.OptionsNoScalingRadio.Location = new System.Drawing.Point(6, 19);
            this.OptionsNoScalingRadio.Name = "OptionsNoScalingRadio";
            this.OptionsNoScalingRadio.Size = new System.Drawing.Size(75, 17);
            this.OptionsNoScalingRadio.TabIndex = 17;
            this.OptionsNoScalingRadio.TabStop = true;
            this.OptionsNoScalingRadio.Text = "No scaling";
            this.OptionsNoScalingRadio.UseVisualStyleBackColor = true;
            this.OptionsNoScalingRadio.CheckedChanged += new System.EventHandler(this.OptionsNoScalingRadio_CheckedChanged);
            // 
            // OptionsScalingRadio
            // 
            this.OptionsScalingRadio.AutoSize = true;
            this.OptionsScalingRadio.Location = new System.Drawing.Point(6, 42);
            this.OptionsScalingRadio.Name = "OptionsScalingRadio";
            this.OptionsScalingRadio.Size = new System.Drawing.Size(60, 17);
            this.OptionsScalingRadio.TabIndex = 18;
            this.OptionsScalingRadio.TabStop = true;
            this.OptionsScalingRadio.Text = "Custom";
            this.OptionsScalingRadio.UseVisualStyleBackColor = true;
            this.OptionsScalingRadio.CheckedChanged += new System.EventHandler(this.OptionsScalingRadio_CheckedChanged);
            // 
            // OptionsScaleHeightTextBox
            // 
            this.OptionsScaleHeightTextBox.Enabled = false;
            this.OptionsScaleHeightTextBox.Location = new System.Drawing.Point(6, 66);
            this.OptionsScaleHeightTextBox.Name = "OptionsScaleHeightTextBox";
            this.OptionsScaleHeightTextBox.Size = new System.Drawing.Size(75, 20);
            this.OptionsScaleHeightTextBox.TabIndex = 19;
            this.OptionsScaleHeightTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionsScaleHeightTextBox_KeyDown);
            this.OptionsScaleHeightTextBox.Leave += new System.EventHandler(this.OptionsScaleHeightTextBox_Leave);
            // 
            // OptionsScaleWidthTextBox
            // 
            this.OptionsScaleWidthTextBox.Enabled = false;
            this.OptionsScaleWidthTextBox.Location = new System.Drawing.Point(6, 93);
            this.OptionsScaleWidthTextBox.Name = "OptionsScaleWidthTextBox";
            this.OptionsScaleWidthTextBox.Size = new System.Drawing.Size(75, 20);
            this.OptionsScaleWidthTextBox.TabIndex = 20;
            this.OptionsScaleWidthTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionsScaleWidthTextBox_KeyDown);
            this.OptionsScaleWidthTextBox.Leave += new System.EventHandler(this.OptionsScaleWidthTextBox_Leave);
            // 
            // OptionsHeightLabel
            // 
            this.OptionsHeightLabel.AutoSize = true;
            this.OptionsHeightLabel.Location = new System.Drawing.Point(87, 69);
            this.OptionsHeightLabel.Name = "OptionsHeightLabel";
            this.OptionsHeightLabel.Size = new System.Drawing.Size(38, 13);
            this.OptionsHeightLabel.TabIndex = 21;
            this.OptionsHeightLabel.Text = "Height";
            // 
            // OptionsWidthLabel
            // 
            this.OptionsWidthLabel.AutoSize = true;
            this.OptionsWidthLabel.Location = new System.Drawing.Point(87, 96);
            this.OptionsWidthLabel.Name = "OptionsWidthLabel";
            this.OptionsWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.OptionsWidthLabel.TabIndex = 22;
            this.OptionsWidthLabel.Text = "Width";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OptionsNoScalingRadio);
            this.groupBox1.Controls.Add(this.OptionsWidthLabel);
            this.groupBox1.Controls.Add(this.OptionsScalingRadio);
            this.groupBox1.Controls.Add(this.OptionsHeightLabel);
            this.groupBox1.Controls.Add(this.OptionsScaleHeightTextBox);
            this.groupBox1.Controls.Add(this.OptionsScaleWidthTextBox);
            this.groupBox1.Location = new System.Drawing.Point(330, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 130);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scale cropped image";
            // 
            // CameraAuto
            // 
            this.CameraAuto.AutoSize = true;
            this.CameraAuto.Location = new System.Drawing.Point(6, 44);
            this.CameraAuto.Name = "CameraAuto";
            this.CameraAuto.Size = new System.Drawing.Size(181, 17);
            this.CameraAuto.TabIndex = 24;
            this.CameraAuto.TabStop = true;
            this.CameraAuto.Text = "Custom Camera / Highest Quality";
            this.CameraAuto.UseVisualStyleBackColor = true;
            this.CameraAuto.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AutoHighQuality);
            this.groupBox2.Controls.Add(this.CameraAuto);
            this.groupBox2.Controls.Add(this.Custom);
            this.groupBox2.Controls.Add(this.OptionsResolutionLabel);
            this.groupBox2.Controls.Add(this.OptionsWebCamList);
            this.groupBox2.Controls.Add(this.OptionsCameraLabel);
            this.groupBox2.Controls.Add(this.OptionsWebCamSettings);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 151);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quality Settings";
            // 
            // SaveLocation
            // 
            this.SaveLocation.AutoSize = true;
            this.SaveLocation.Location = new System.Drawing.Point(15, 210);
            this.SaveLocation.Name = "SaveLocation";
            this.SaveLocation.Size = new System.Drawing.Size(76, 13);
            this.SaveLocation.TabIndex = 26;
            this.SaveLocation.Text = "Save Location";
            // 
            // OptionsAutoStart
            // 
            this.OptionsAutoStart.AutoSize = true;
            this.OptionsAutoStart.Location = new System.Drawing.Point(101, 239);
            this.OptionsAutoStart.Name = "OptionsAutoStart";
            this.OptionsAutoStart.Size = new System.Drawing.Size(98, 17);
            this.OptionsAutoStart.TabIndex = 23;
            this.OptionsAutoStart.Text = "Start on launch";
            this.OptionsAutoStart.UseVisualStyleBackColor = true;
            this.OptionsAutoStart.CheckedChanged += new System.EventHandler(this.OptionsAutoStart_CheckedChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 263);
            this.Controls.Add(this.OptionsAutoStart);
            this.Controls.Add(this.SaveLocation);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OptionsRatioLabel);
            this.Controls.Add(this.optionCancel);
            this.Controls.Add(this.optionsOk);
            this.Controls.Add(this.browseSavePath);
            this.Controls.Add(this.savePath);
            this.Controls.Add(this.OptionsCropBoxRatioCombobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton AutoHighQuality;
        private System.Windows.Forms.RadioButton Custom;
        public System.Windows.Forms.ComboBox OptionsCropBoxRatioCombobox;
        private System.Windows.Forms.Button browseSavePath;
        private System.Windows.Forms.Button optionCancel;
        private System.Windows.Forms.Button optionsOk;
        public System.Windows.Forms.ComboBox OptionsWebCamSettings;
        public System.Windows.Forms.ComboBox OptionsWebCamList;
        public System.Windows.Forms.TextBox savePath;
        private System.Windows.Forms.Label OptionsCameraLabel;
        private System.Windows.Forms.Label OptionsResolutionLabel;
        private System.Windows.Forms.Label OptionsRatioLabel;
        private System.Windows.Forms.RadioButton OptionsNoScalingRadio;
        private System.Windows.Forms.RadioButton OptionsScalingRadio;
        private System.Windows.Forms.Label OptionsHeightLabel;
        private System.Windows.Forms.Label OptionsWidthLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox OptionsScaleHeightTextBox;
        public System.Windows.Forms.TextBox OptionsScaleWidthTextBox;
        private System.Windows.Forms.RadioButton CameraAuto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label SaveLocation;
        private System.Windows.Forms.CheckBox OptionsAutoStart;
    }
}