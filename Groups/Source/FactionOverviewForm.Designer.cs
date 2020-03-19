namespace Universalis
{
    partial class FactionOverviewForm
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
            this.SuspendLayout();
            // 
            // listViewFactions
            // 
            this.listViewFactions.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewFactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFactions.LargeImageList = this.imageListFactions;
            this.listViewFactions.Location = new System.Drawing.Point(0, 0);
            this.listViewFactions.MultiSelect = false;
            this.listViewFactions.Name = "listViewFactions";
            this.listViewFactions.ShowItemToolTips = true;
            this.listViewFactions.Size = new System.Drawing.Size(728, 645);
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
            // FactionOverviewForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 645);
            this.Controls.Add(this.listViewFactions);
            this.KeyPreview = true;
            this.Name = "FactionOverviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wählen Sie Ihre Fraktion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FactionOverviewForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FactionOverviewForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FactionOverviewForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FactionOverviewForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFactions;
        private System.Windows.Forms.ImageList imageListFactions;
    }
}