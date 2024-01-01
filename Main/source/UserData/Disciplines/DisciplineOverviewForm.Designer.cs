namespace Universalis
{
    partial class DisciplineOverviewForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.listViewPowers = new System.Windows.Forms.ListView();
            this.imageListPowers = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 50);
            this.panelHeader.TabIndex = 3;
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(361, 19);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(82, 13);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "discipline_name";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewPowers
            // 
            this.listViewPowers.CheckBoxes = true;
            this.listViewPowers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPowers.HideSelection = false;
            this.listViewPowers.LargeImageList = this.imageListPowers;
            this.listViewPowers.Location = new System.Drawing.Point(0, 50);
            this.listViewPowers.MultiSelect = false;
            this.listViewPowers.Name = "listViewPowers";
            this.listViewPowers.ShowItemToolTips = true;
            this.listViewPowers.Size = new System.Drawing.Size(800, 578);
            this.listViewPowers.TabIndex = 4;
            this.listViewPowers.UseCompatibleStateImageBehavior = false;
            // 
            // imageListPowers
            // 
            this.imageListPowers.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListPowers.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListPowers.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 628);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 32);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::Universalis.Properties.Resources.baseline_print_black_18dp;
            this.button1.Location = new System.Drawing.Point(697, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Drucken";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DisciplineOverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 660);
            this.Controls.Add(this.listViewPowers);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.MinimizeBox = false;
            this.Name = "DisciplineOverviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Disziplin";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.ListView listViewPowers;
        private System.Windows.Forms.ImageList imageListPowers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}