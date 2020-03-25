namespace Universalis
{
    partial class UniverseSelectionForm
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
            this.imageListUniverses = new System.Windows.Forms.ImageList(this.components);
            this.listViewUniverses = new System.Windows.Forms.ListView();
            this.panelNoUniverses = new System.Windows.Forms.Panel();
            this.labelNoUniverses = new System.Windows.Forms.Label();
            this.panelNoUniverses.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListUniverses
            // 
            this.imageListUniverses.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageListUniverses.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListUniverses.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewUniverses
            // 
            this.listViewUniverses.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewUniverses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUniverses.HideSelection = false;
            this.listViewUniverses.LargeImageList = this.imageListUniverses;
            this.listViewUniverses.Location = new System.Drawing.Point(0, 0);
            this.listViewUniverses.MultiSelect = false;
            this.listViewUniverses.Name = "listViewUniverses";
            this.listViewUniverses.ShowItemToolTips = true;
            this.listViewUniverses.Size = new System.Drawing.Size(714, 388);
            this.listViewUniverses.TabIndex = 1;
            this.listViewUniverses.UseCompatibleStateImageBehavior = false;
            this.listViewUniverses.ItemActivate += new System.EventHandler(this.listViewUniverses_ItemActivate);
            // 
            // panelNoUniverses
            // 
            this.panelNoUniverses.Controls.Add(this.labelNoUniverses);
            this.panelNoUniverses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoUniverses.Location = new System.Drawing.Point(0, 0);
            this.panelNoUniverses.Name = "panelNoUniverses";
            this.panelNoUniverses.Size = new System.Drawing.Size(714, 388);
            this.panelNoUniverses.TabIndex = 2;
            this.panelNoUniverses.Visible = false;
            // 
            // labelNoUniverses
            // 
            this.labelNoUniverses.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNoUniverses.AutoSize = true;
            this.labelNoUniverses.Location = new System.Drawing.Point(291, 188);
            this.labelNoUniverses.Name = "labelNoUniverses";
            this.labelNoUniverses.Size = new System.Drawing.Size(133, 13);
            this.labelNoUniverses.TabIndex = 0;
            this.labelNoUniverses.Text = "Keine Universen gefunden";
            this.labelNoUniverses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UniverseSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 388);
            this.Controls.Add(this.listViewUniverses);
            this.Controls.Add(this.panelNoUniverses);
            this.KeyPreview = true;
            this.Name = "UniverseSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Universalis";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UniverseSelectionForm_KeyDown);
            this.panelNoUniverses.ResumeLayout(false);
            this.panelNoUniverses.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageListUniverses;
        private System.Windows.Forms.ListView listViewUniverses;
        private System.Windows.Forms.Panel panelNoUniverses;
        private System.Windows.Forms.Label labelNoUniverses;
    }
}