namespace Universalis
{
    partial class UniverseInfoForm
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
            this.labelAuthor = new System.Windows.Forms.Label();
            this.linkLabelContact = new System.Windows.Forms.LinkLabel();
            this.linkLabelWebsite = new System.Windows.Forms.LinkLabel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelAuthor = new System.Windows.Forms.Panel();
            this.pictureBoxAuthor = new System.Windows.Forms.PictureBox();
            this.panelContact = new System.Windows.Forms.Panel();
            this.pictureBoxContact = new System.Windows.Forms.PictureBox();
            this.panelWebsite = new System.Windows.Forms.Panel();
            this.pictureBoxWebsite = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelAuthor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAuthor)).BeginInit();
            this.panelContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContact)).BeginInit();
            this.panelWebsite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebsite)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAuthor
            // 
            this.labelAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAuthor.Location = new System.Drawing.Point(18, 0);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(366, 24);
            this.labelAuthor.TabIndex = 5;
            this.labelAuthor.Text = "labelAuthor";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelContact
            // 
            this.linkLabelContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabelContact.Location = new System.Drawing.Point(18, 0);
            this.linkLabelContact.Name = "linkLabelContact";
            this.linkLabelContact.Size = new System.Drawing.Size(366, 24);
            this.linkLabelContact.TabIndex = 4;
            this.linkLabelContact.TabStop = true;
            this.linkLabelContact.Text = "linkLabelContact";
            this.linkLabelContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelContact_LinkClicked);
            // 
            // linkLabelWebsite
            // 
            this.linkLabelWebsite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabelWebsite.Location = new System.Drawing.Point(18, 0);
            this.linkLabelWebsite.Name = "linkLabelWebsite";
            this.linkLabelWebsite.Size = new System.Drawing.Size(366, 24);
            this.linkLabelWebsite.TabIndex = 3;
            this.linkLabelWebsite.TabStop = true;
            this.linkLabelWebsite.Text = "linkLabelWebsite";
            this.linkLabelWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWebsite_LinkClicked);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 277);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(384, 173);
            this.textBoxDescription.TabIndex = 6;
            // 
            // panelLogo
            // 
            this.panelLogo.AutoSize = true;
            this.panelLogo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLogo.Controls.Add(this.pictureBoxLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(384, 205);
            this.panelLogo.TabIndex = 7;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxLogo.Location = new System.Drawing.Point(92, 2);
            this.pictureBoxLogo.MaximumSize = new System.Drawing.Size(200, 200);
            this.pictureBoxLogo.MinimumSize = new System.Drawing.Size(150, 150);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelAuthor
            // 
            this.panelAuthor.Controls.Add(this.labelAuthor);
            this.panelAuthor.Controls.Add(this.pictureBoxAuthor);
            this.panelAuthor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAuthor.Location = new System.Drawing.Point(0, 205);
            this.panelAuthor.Name = "panelAuthor";
            this.panelAuthor.Size = new System.Drawing.Size(384, 24);
            this.panelAuthor.TabIndex = 8;
            this.panelAuthor.Visible = false;
            // 
            // pictureBoxAuthor
            // 
            this.pictureBoxAuthor.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxAuthor.Image = global::Universalis.Properties.Resources.baseline_person_black_18dp;
            this.pictureBoxAuthor.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxAuthor.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.pictureBoxAuthor.Name = "pictureBoxAuthor";
            this.pictureBoxAuthor.Size = new System.Drawing.Size(18, 24);
            this.pictureBoxAuthor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxAuthor.TabIndex = 6;
            this.pictureBoxAuthor.TabStop = false;
            // 
            // panelContact
            // 
            this.panelContact.Controls.Add(this.linkLabelContact);
            this.panelContact.Controls.Add(this.pictureBoxContact);
            this.panelContact.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContact.Location = new System.Drawing.Point(0, 229);
            this.panelContact.Name = "panelContact";
            this.panelContact.Size = new System.Drawing.Size(384, 24);
            this.panelContact.TabIndex = 9;
            this.panelContact.Visible = false;
            // 
            // pictureBoxContact
            // 
            this.pictureBoxContact.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxContact.Image = global::Universalis.Properties.Resources.baseline_email_black_18dp;
            this.pictureBoxContact.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxContact.Name = "pictureBoxContact";
            this.pictureBoxContact.Size = new System.Drawing.Size(18, 24);
            this.pictureBoxContact.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxContact.TabIndex = 7;
            this.pictureBoxContact.TabStop = false;
            // 
            // panelWebsite
            // 
            this.panelWebsite.Controls.Add(this.linkLabelWebsite);
            this.panelWebsite.Controls.Add(this.pictureBoxWebsite);
            this.panelWebsite.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWebsite.Location = new System.Drawing.Point(0, 253);
            this.panelWebsite.Name = "panelWebsite";
            this.panelWebsite.Size = new System.Drawing.Size(384, 24);
            this.panelWebsite.TabIndex = 10;
            this.panelWebsite.Visible = false;
            // 
            // pictureBoxWebsite
            // 
            this.pictureBoxWebsite.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxWebsite.Image = global::Universalis.Properties.Resources.baseline_home_black_18dp;
            this.pictureBoxWebsite.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWebsite.Name = "pictureBoxWebsite";
            this.pictureBoxWebsite.Size = new System.Drawing.Size(18, 24);
            this.pictureBoxWebsite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxWebsite.TabIndex = 7;
            this.pictureBoxWebsite.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonClose.Image = global::Shared.Properties.Resources.cross_circle;
            this.buttonClose.Location = new System.Drawing.Point(0, 450);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(384, 26);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Schließen";
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // UniverseInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(384, 450);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.panelWebsite);
            this.Controls.Add(this.panelContact);
            this.Controls.Add(this.panelAuthor);
            this.Controls.Add(this.panelLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 39);
            this.Name = "UniverseInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info";
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelAuthor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAuthor)).EndInit();
            this.panelContact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContact)).EndInit();
            this.panelWebsite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebsite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.LinkLabel linkLabelContact;
        private System.Windows.Forms.LinkLabel linkLabelWebsite;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelAuthor;
        private System.Windows.Forms.Panel panelContact;
        private System.Windows.Forms.Panel panelWebsite;
        private System.Windows.Forms.PictureBox pictureBoxAuthor;
        private System.Windows.Forms.PictureBox pictureBoxContact;
        private System.Windows.Forms.PictureBox pictureBoxWebsite;
        private System.Windows.Forms.Button buttonClose;
    }
}