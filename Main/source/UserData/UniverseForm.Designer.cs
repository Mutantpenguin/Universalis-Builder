namespace Universalis
{
    partial class UniverseForm
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
            this.listViewFactions = new System.Windows.Forms.ListView();
            this.imageListFactions = new System.Windows.Forms.ImageList(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewFactions
            // 
            this.listViewFactions.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewFactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFactions.HideSelection = false;
            this.listViewFactions.LargeImageList = this.imageListFactions;
            this.listViewFactions.Location = new System.Drawing.Point(0, 50);
            this.listViewFactions.MultiSelect = false;
            this.listViewFactions.Name = "listViewFactions";
            this.listViewFactions.ShowItemToolTips = true;
            this.listViewFactions.Size = new System.Drawing.Size(728, 595);
            this.listViewFactions.TabIndex = 0;
            this.listViewFactions.UseCompatibleStateImageBehavior = false;
            this.listViewFactions.ItemActivate += new System.EventHandler(this.listViewFactions_ItemActivate);
            // 
            // imageListFactions
            // 
            this.imageListFactions.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageListFactions.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListFactions.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.pictureBoxInfo);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(728, 50);
            this.panelHeader.TabIndex = 2;
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxInfo.Image = global::Universalis.Properties.Resources.baseline_info_black_24dp;
            this.pictureBoxInfo.Location = new System.Drawing.Point(701, 3);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxInfo.TabIndex = 2;
            this.pictureBoxInfo.TabStop = false;
            this.pictureBoxInfo.Click += new System.EventHandler(this.pictureBoxInfo_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(325, 19);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(79, 13);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "universe_name";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UniverseForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 645);
            this.Controls.Add(this.listViewFactions);
            this.Controls.Add(this.panelHeader);
            this.KeyPreview = true;
            this.Name = "UniverseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wählen Sie Ihre Fraktion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UniverseForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UniverseForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UniverseForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UniverseForm_KeyDown);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFactions;
        private System.Windows.Forms.ImageList imageListFactions;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxInfo;
    }
}