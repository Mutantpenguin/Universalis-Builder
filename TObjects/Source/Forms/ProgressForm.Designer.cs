namespace Tesserakt
{
    partial class ProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.labelTitel = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // timerProgress
            // 
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // labelTitel
            // 
            this.labelTitel.BackColor = System.Drawing.Color.SteelBlue;
            this.labelTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitel.Location = new System.Drawing.Point(0, 0);
            this.labelTitel.Name = "labelTitel";
            this.labelTitel.Size = new System.Drawing.Size(370, 30);
            this.labelTitel.TabIndex = 0;
            this.labelTitel.Text = "Projekt Tesserakt";
            this.labelTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxLogo.Image = global::TObjects.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 45);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxLogo.MinimumSize = new System.Drawing.Size(256, 256);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(370, 300);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Location = new System.Drawing.Point(0, 360);
            this.progressBar.Maximum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(370, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 2;
            // 
            // labelVersion
            // 
            this.labelVersion.BackColor = System.Drawing.Color.SteelBlue;
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(0, 30);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(370, 15);
            this.labelVersion.TabIndex = 4;
            this.labelVersion.Text = "Platzhalter für Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.Color.SteelBlue;
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(0, 345);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(370, 15);
            this.labelMessage.TabIndex = 5;
            this.labelMessage.Text = "Platzhalter für Message";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(370, 381);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelTitel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressForm_FormClosing);
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerProgress;
        private System.Windows.Forms.Label labelTitel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelMessage;
    }
}