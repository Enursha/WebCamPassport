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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainSave = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.Button();
            this.cropPic = new System.Windows.Forms.Button();
            this.snapShot = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapShot)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(172, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(30);
            this.pictureBox1.Size = new System.Drawing.Size(1074, 641);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // mainSave
            // 
            this.mainSave.Location = new System.Drawing.Point(12, 230);
            this.mainSave.Name = "mainSave";
            this.mainSave.Size = new System.Drawing.Size(135, 60);
            this.mainSave.TabIndex = 2;
            this.mainSave.Text = "&Save";
            this.mainSave.UseVisualStyleBackColor = true;
            this.mainSave.Click += new System.EventHandler(this.mainSave_Click);
            // 
            // options
            // 
            this.options.Location = new System.Drawing.Point(12, 12);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(135, 52);
            this.options.TabIndex = 10;
            this.options.Text = "Options";
            this.options.UseVisualStyleBackColor = true;
            this.options.Click += new System.EventHandler(this.options_Click);
            // 
            // cropPic
            // 
            this.cropPic.Location = new System.Drawing.Point(12, 161);
            this.cropPic.Name = "cropPic";
            this.cropPic.Size = new System.Drawing.Size(135, 63);
            this.cropPic.TabIndex = 6;
            this.cropPic.Text = "Begin Crop";
            this.cropPic.UseVisualStyleBackColor = true;
            this.cropPic.Click += new System.EventHandler(this.cropPic_Click);
            // 
            // snapShot
            // 
            this.snapShot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.snapShot.Location = new System.Drawing.Point(12, 317);
            this.snapShot.Name = "snapShot";
            this.snapShot.Size = new System.Drawing.Size(135, 168);
            this.snapShot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.snapShot.TabIndex = 4;
            this.snapShot.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ready";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(12, 100);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(135, 55);
            this.start.TabIndex = 1;
            this.start.Text = "Start &Webcam";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(156, 641);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 641);
            this.Controls.Add(this.snapShot);
            this.Controls.Add(this.mainSave);
            this.Controls.Add(this.options);
            this.Controls.Add(this.cropPic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.start);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "WebCamPassport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapShot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cropPic;
        private System.Windows.Forms.Button options;
        private System.Windows.Forms.Button mainSave;
        public System.Windows.Forms.PictureBox snapShot;
        private System.Windows.Forms.Splitter splitter1;
    }
}

