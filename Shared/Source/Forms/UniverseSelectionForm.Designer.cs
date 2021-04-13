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
            this.tableLayoutPanelCentered = new System.Windows.Forms.TableLayoutPanel();
            this.labelNoUniverses = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelControl = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelNoUniverses.SuspendLayout();
            this.tableLayoutPanelCentered.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListUniverses
            // 
            this.imageListUniverses.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageListUniverses.ImageSize = new System.Drawing.Size(200, 200);
            this.imageListUniverses.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewUniverses
            // 
            this.listViewUniverses.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewUniverses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewUniverses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUniverses.HideSelection = false;
            this.listViewUniverses.LargeImageList = this.imageListUniverses;
            this.listViewUniverses.Location = new System.Drawing.Point(0, 50);
            this.listViewUniverses.MultiSelect = false;
            this.listViewUniverses.Name = "listViewUniverses";
            this.listViewUniverses.ShowItemToolTips = true;
            this.listViewUniverses.Size = new System.Drawing.Size(868, 282);
            this.listViewUniverses.TabIndex = 1;
            this.listViewUniverses.UseCompatibleStateImageBehavior = false;
            this.listViewUniverses.ItemActivate += new System.EventHandler(this.listViewUniverses_ItemActivate);
            // 
            // panelNoUniverses
            // 
            this.panelNoUniverses.BackColor = System.Drawing.SystemColors.Window;
            this.panelNoUniverses.Controls.Add(this.tableLayoutPanelCentered);
            this.panelNoUniverses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoUniverses.Location = new System.Drawing.Point(0, 0);
            this.panelNoUniverses.Name = "panelNoUniverses";
            this.panelNoUniverses.Size = new System.Drawing.Size(868, 388);
            this.panelNoUniverses.TabIndex = 2;
            this.panelNoUniverses.Visible = false;
            // 
            // tableLayoutPanelCentered
            // 
            this.tableLayoutPanelCentered.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelCentered.AutoSize = true;
            this.tableLayoutPanelCentered.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelCentered.ColumnCount = 1;
            this.tableLayoutPanelCentered.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCentered.Controls.Add(this.labelNoUniverses, 0, 0);
            this.tableLayoutPanelCentered.Location = new System.Drawing.Point(365, 138);
            this.tableLayoutPanelCentered.Name = "tableLayoutPanelCentered";
            this.tableLayoutPanelCentered.RowCount = 2;
            this.tableLayoutPanelCentered.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCentered.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCentered.Size = new System.Drawing.Size(139, 13);
            this.tableLayoutPanelCentered.TabIndex = 2;
            // 
            // labelNoUniverses
            // 
            this.labelNoUniverses.AutoSize = true;
            this.labelNoUniverses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNoUniverses.Location = new System.Drawing.Point(3, 0);
            this.labelNoUniverses.Name = "labelNoUniverses";
            this.labelNoUniverses.Size = new System.Drawing.Size(133, 13);
            this.labelNoUniverses.TabIndex = 0;
            this.labelNoUniverses.Text = "Keine Universen gefunden";
            this.labelNoUniverses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Image = global::Shared.Properties.Resources.baseline_refresh_black_48dp;
            this.buttonRefresh.Location = new System.Drawing.Point(3, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(50, 50);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(868, 50);
            this.panelHeader.TabIndex = 1;
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(368, 19);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(153, 13);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Bitte wählen Sie ein Universum";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControl
            // 
            this.panelControl.AutoSize = true;
            this.panelControl.Controls.Add(this.buttonDelete);
            this.panelControl.Controls.Add(this.buttonAdd);
            this.panelControl.Controls.Add(this.buttonRefresh);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(0, 332);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(868, 56);
            this.panelControl.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Image = global::Shared.Properties.Resources.outline_playlist_add_black_48dp;
            this.buttonAdd.Location = new System.Drawing.Point(815, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(50, 50);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Image = global::Shared.Properties.Resources.baseline_delete_black_48dp;
            this.buttonDelete.Location = new System.Drawing.Point(759, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(50, 50);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // UniverseSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 388);
            this.Controls.Add(this.listViewUniverses);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelNoUniverses);
            this.KeyPreview = true;
            this.Name = "UniverseSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Universalis";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UniverseSelectionForm_KeyDown);
            this.panelNoUniverses.ResumeLayout(false);
            this.panelNoUniverses.PerformLayout();
            this.tableLayoutPanelCentered.ResumeLayout(false);
            this.tableLayoutPanelCentered.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageListUniverses;
        private System.Windows.Forms.ListView listViewUniverses;
        private System.Windows.Forms.Panel panelNoUniverses;
        private System.Windows.Forms.Label labelNoUniverses;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCentered;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
    }
}