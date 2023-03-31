
namespace Universalis
{
    partial class ActorWebcamImageForm
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
            this.buttonWebcam = new System.Windows.Forms.Button();
            this.pictureBoxWebcam = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonWebcam
            // 
            this.buttonWebcam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonWebcam.Image = global::Universalis.Properties.Resources.baseline_photo_camera_black_24dp;
            this.buttonWebcam.Location = new System.Drawing.Point(0, 474);
            this.buttonWebcam.Name = "buttonWebcam";
            this.buttonWebcam.Size = new System.Drawing.Size(734, 37);
            this.buttonWebcam.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonWebcam, "Foto mit Kamera machen");
            this.buttonWebcam.UseVisualStyleBackColor = true;
            this.buttonWebcam.Click += new System.EventHandler(this.buttonWebcam_Click);
            // 
            // pictureBoxWebcam
            // 
            this.pictureBoxWebcam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxWebcam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxWebcam.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWebcam.Name = "pictureBoxWebcam";
            this.pictureBoxWebcam.Size = new System.Drawing.Size(734, 474);
            this.pictureBoxWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWebcam.TabIndex = 3;
            this.pictureBoxWebcam.TabStop = false;
            // 
            // ActorWebcamImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.pictureBoxWebcam);
            this.Controls.Add(this.buttonWebcam);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "ActorWebcamImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Foto aufnehmen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActorImageForm_FormClosing);
            this.Load += new System.EventHandler(this.ActorImageForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActorImageForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebcam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonWebcam;
        private System.Windows.Forms.PictureBox pictureBoxWebcam;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}