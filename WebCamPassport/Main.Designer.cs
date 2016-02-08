namespace WebCamPassport
{
    partial class Main
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.cropPic = new System.Windows.Forms.Button();
            this.snapShot = new System.Windows.Forms.PictureBox();
            this.takePic = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.options = new System.Windows.Forms.Button();
            this.mainSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snapShot)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(285, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(10);
            this.pictureBox1.Size = new System.Drawing.Size(961, 641);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.mainSave);
            this.panel1.Controls.Add(this.options);
            this.panel1.Controls.Add(this.btnSaveAs);
            this.panel1.Controls.Add(this.cropPic);
            this.panel1.Controls.Add(this.snapShot);
            this.panel1.Controls.Add(this.takePic);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.start);
            this.panel1.Location = new System.Drawing.Point(26, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 617);
            this.panel1.TabIndex = 1;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(143, 578);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 9;
            this.btnSaveAs.Text = "Save &As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.button1_Click);
            // 
            // cropPic
            // 
            this.cropPic.Location = new System.Drawing.Point(30, 208);
            this.cropPic.Name = "cropPic";
            this.cropPic.Size = new System.Drawing.Size(186, 63);
            this.cropPic.TabIndex = 6;
            this.cropPic.Text = "Begin Crop";
            this.cropPic.UseVisualStyleBackColor = true;
            this.cropPic.Click += new System.EventHandler(this.cropPic_Click);
            // 
            // snapShot
            // 
            this.snapShot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.snapShot.Location = new System.Drawing.Point(56, 421);
            this.snapShot.Name = "snapShot";
            this.snapShot.Size = new System.Drawing.Size(135, 145);
            this.snapShot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.snapShot.TabIndex = 4;
            this.snapShot.TabStop = false;
            // 
            // takePic
            // 
            this.takePic.Location = new System.Drawing.Point(30, 277);
            this.takePic.Name = "takePic";
            this.takePic.Size = new System.Drawing.Size(186, 63);
            this.takePic.TabIndex = 2;
            this.takePic.Text = "Take Picture";
            this.takePic.UseVisualStyleBackColor = true;
            this.takePic.Click += new System.EventHandler(this.takePic_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Opened";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(30, 140);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 1;
            this.start.Text = "&Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // options
            // 
            this.options.Location = new System.Drawing.Point(30, 13);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(75, 23);
            this.options.TabIndex = 10;
            this.options.Text = "Options";
            this.options.UseVisualStyleBackColor = true;
            this.options.Click += new System.EventHandler(this.options_Click);
            // 
            // mainSave
            // 
            this.mainSave.Location = new System.Drawing.Point(30, 578);
            this.mainSave.Name = "mainSave";
            this.mainSave.Size = new System.Drawing.Size(75, 23);
            this.mainSave.TabIndex = 2;
            this.mainSave.Text = "&Save";
            this.mainSave.UseVisualStyleBackColor = true;
            this.mainSave.Click += new System.EventHandler(this.mainSave_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snapShot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button takePic;
        private System.Windows.Forms.PictureBox snapShot;
        private System.Windows.Forms.Button cropPic;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button options;
        private System.Windows.Forms.Button mainSave;
    }
}

