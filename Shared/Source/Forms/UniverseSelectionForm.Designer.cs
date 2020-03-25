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
            this.listViewUniverses.Location = new System.Drawing.Point(0, 0);
            this.listViewUniverses.MultiSelect = false;
            this.listViewUniverses.Name = "listViewUniverses";
            this.listViewUniverses.ShowItemToolTips = true;
            this.listViewUniverses.Size = new System.Drawing.Size(800, 450);
            this.listViewUniverses.TabIndex = 1;
            this.listViewUniverses.UseCompatibleStateImageBehavior = false;
            this.listViewUniverses.ItemActivate += new System.EventHandler(this.listViewUniverses_ItemActivate);
            // 
            // UniverseSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewUniverses);
            this.Name = "UniverseSelectionForm";
            this.Text = "UniverseSelectionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageListUniverses;
        private System.Windows.Forms.ListView listViewUniverses;
    }
}