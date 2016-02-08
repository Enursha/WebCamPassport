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
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.savePath = new System.Windows.Forms.TextBox();
            this.browseSavePath = new System.Windows.Forms.Button();
            this.optionsOk = new System.Windows.Forms.Button();
            this.optionCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AutoHighQuality
            // 
            this.AutoHighQuality.AutoSize = true;
            this.AutoHighQuality.Location = new System.Drawing.Point(13, 13);
            this.AutoHighQuality.Name = "AutoHighQuality";
            this.AutoHighQuality.Size = new System.Drawing.Size(96, 17);
            this.AutoHighQuality.TabIndex = 1;
            this.AutoHighQuality.TabStop = true;
            this.AutoHighQuality.Text = "Highest Quality";
            this.AutoHighQuality.UseVisualStyleBackColor = true;
            this.AutoHighQuality.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Custom
            // 
            this.Custom.AutoSize = true;
            this.Custom.Location = new System.Drawing.Point(13, 36);
            this.Custom.Name = "Custom";
            this.Custom.Size = new System.Drawing.Size(60, 17);
            this.Custom.TabIndex = 1;
            this.Custom.TabStop = true;
            this.Custom.Text = "Custom";
            this.Custom.UseVisualStyleBackColor = true;
            // 
            // OptionsWebCamSettings
            // 
            this.OptionsWebCamSettings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OptionsWebCamSettings.FormattingEnabled = true;
            this.OptionsWebCamSettings.Location = new System.Drawing.Point(120, 105);
            this.OptionsWebCamSettings.Name = "OptionsWebCamSettings";
            this.OptionsWebCamSettings.Size = new System.Drawing.Size(186, 21);
            this.OptionsWebCamSettings.TabIndex = 3;
            // 
            // OptionsWebCamList
            // 
            this.OptionsWebCamList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OptionsWebCamList.FormattingEnabled = true;
            this.OptionsWebCamList.Location = new System.Drawing.Point(120, 66);
            this.OptionsWebCamList.Name = "OptionsWebCamList";
            this.OptionsWebCamList.Size = new System.Drawing.Size(186, 21);
            this.OptionsWebCamList.TabIndex = 4;
            this.OptionsWebCamList.SelectedIndexChanged += new System.EventHandler(this.OptionsWebCamList_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(122, 204);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(184, 21);
            this.comboBox3.TabIndex = 8;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged_1);
            // 
            // savePath
            // 
            this.savePath.Location = new System.Drawing.Point(122, 306);
            this.savePath.Name = "savePath";
            this.savePath.Size = new System.Drawing.Size(184, 20);
            this.savePath.TabIndex = 9;
            // 
            // browseSavePath
            // 
            this.browseSavePath.Location = new System.Drawing.Point(330, 306);
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
            this.optionsOk.Location = new System.Drawing.Point(101, 396);
            this.optionsOk.Name = "optionsOk";
            this.optionsOk.Size = new System.Drawing.Size(75, 23);
            this.optionsOk.TabIndex = 11;
            this.optionsOk.Text = "OK";
            this.optionsOk.UseVisualStyleBackColor = true;
            // 
            // optionCancel
            // 
            this.optionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.optionCancel.Location = new System.Drawing.Point(257, 396);
            this.optionCancel.Name = "optionCancel";
            this.optionCancel.Size = new System.Drawing.Size(75, 23);
            this.optionCancel.TabIndex = 12;
            this.optionCancel.Text = "Cancel";
            this.optionCancel.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 475);
            this.Controls.Add(this.optionCancel);
            this.Controls.Add(this.optionsOk);
            this.Controls.Add(this.browseSavePath);
            this.Controls.Add(this.savePath);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.OptionsWebCamSettings);
            this.Controls.Add(this.OptionsWebCamList);
            this.Controls.Add(this.Custom);
            this.Controls.Add(this.AutoHighQuality);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton AutoHighQuality;
        private System.Windows.Forms.RadioButton Custom;
        public System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button browseSavePath;
        private System.Windows.Forms.Button optionCancel;
        private System.Windows.Forms.Button optionsOk;
        public System.Windows.Forms.ComboBox OptionsWebCamSettings;
        public System.Windows.Forms.ComboBox OptionsWebCamList;
        public System.Windows.Forms.TextBox savePath;
    }
}