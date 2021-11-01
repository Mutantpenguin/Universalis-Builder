
namespace Universalis
{
    partial class ActorImageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonWebcam = new System.Windows.Forms.Button();
            this.comboBoxCameraDevice = new System.Windows.Forms.ComboBox();
            this.pictureBoxWebcam = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebcam)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUpload
            // 
            this.buttonUpload.Image = global::Universalis.Properties.Resources.baseline_image_search_black_24dp;
            this.buttonUpload.Location = new System.Drawing.Point(3, 3);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 37);
            this.buttonUpload.TabIndex = 0;
            this.toolTip1.SetToolTip(this.buttonUpload, "Bild auswählen");
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonWebcam
            // 
            this.buttonWebcam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWebcam.Image = global::Universalis.Properties.Resources.baseline_photo_camera_black_24dp;
            this.buttonWebcam.Location = new System.Drawing.Point(466, 3);
            this.buttonWebcam.Name = "buttonWebcam";
            this.buttonWebcam.Size = new System.Drawing.Size(75, 37);
            this.buttonWebcam.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonWebcam, "Foto mit Kamera machen");
            this.buttonWebcam.UseVisualStyleBackColor = true;
            this.buttonWebcam.Click += new System.EventHandler(this.buttonWebcam_Click);
            // 
            // comboBoxCameraDevice
            // 
            this.comboBoxCameraDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCameraDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraDevice.FormattingEnabled = true;
            this.comboBoxCameraDevice.Location = new System.Drawing.Point(3, 46);
            this.comboBoxCameraDevice.Name = "comboBoxCameraDevice";
            this.comboBoxCameraDevice.Size = new System.Drawing.Size(538, 21);
            this.comboBoxCameraDevice.TabIndex = 2;
            // 
            // pictureBoxWebcam
            // 
            this.pictureBoxWebcam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxWebcam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxWebcam.Location = new System.Drawing.Point(3, 73);
            this.pictureBoxWebcam.Name = "pictureBoxWebcam";
            this.pictureBoxWebcam.Size = new System.Drawing.Size(538, 360);
            this.pictureBoxWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWebcam.TabIndex = 3;
            this.pictureBoxWebcam.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.buttonUpload);
            this.panel1.Controls.Add(this.buttonWebcam);
            this.panel1.Controls.Add(this.comboBoxCameraDevice);
            this.panel1.Controls.Add(this.pictureBoxWebcam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 436);
            this.panel1.TabIndex = 4;
            // 
            // ActorImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(544, 436);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "ActorImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bilder auswählen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActorImageForm_FormClosing);
            this.Load += new System.EventHandler(this.ActorImageForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActorImageForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebcam)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonWebcam;
        private System.Windows.Forms.ComboBox comboBoxCameraDevice;
        private System.Windows.Forms.PictureBox pictureBoxWebcam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}