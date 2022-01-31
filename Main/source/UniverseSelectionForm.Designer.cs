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
            this.panelGodMode = new System.Windows.Forms.Panel();
            this.buttonOpenVscode = new System.Windows.Forms.Button();
            this.buttonCreateUniverse = new System.Windows.Forms.Button();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelWorking = new System.Windows.Forms.Panel();
            this.pictureBoxSpinner = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelNoUniverses.SuspendLayout();
            this.tableLayoutPanelCentered.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.panelGodMode.SuspendLayout();
            this.panelWorking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinner)).BeginInit();
            this.panelMain.SuspendLayout();
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
            this.listViewUniverses.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewUniverses_ItemSelectionChanged);
            // 
            // panelNoUniverses
            // 
            this.panelNoUniverses.BackColor = System.Drawing.SystemColors.Window;
            this.panelNoUniverses.Controls.Add(this.tableLayoutPanelCentered);
            this.panelNoUniverses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNoUniverses.Location = new System.Drawing.Point(0, 0);
            this.panelNoUniverses.Name = "panelNoUniverses";
            this.panelNoUniverses.Size = new System.Drawing.Size(868, 332);
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
            this.tableLayoutPanelCentered.Location = new System.Drawing.Point(365, 110);
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
            this.buttonRefresh.Image = global::Universalis.Properties.Resources.baseline_refresh_black_48dp;
            this.buttonRefresh.Location = new System.Drawing.Point(3, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(50, 50);
            this.buttonRefresh.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonRefresh, "Universen neu laden");
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
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
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
            this.panelControl.Controls.Add(this.panelGodMode);
            this.panelControl.Controls.Add(this.buttonInfo);
            this.panelControl.Controls.Add(this.buttonDelete);
            this.panelControl.Controls.Add(this.buttonAdd);
            this.panelControl.Controls.Add(this.buttonRefresh);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(0, 332);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(868, 56);
            this.panelControl.TabIndex = 3;
            this.panelControl.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl_Paint);
            // 
            // panelGodMode
            // 
            this.panelGodMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelGodMode.AutoSize = true;
            this.panelGodMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelGodMode.Controls.Add(this.buttonOpenVscode);
            this.panelGodMode.Controls.Add(this.buttonCreateUniverse);
            this.panelGodMode.Controls.Add(this.buttonOpenFolder);
            this.panelGodMode.Location = new System.Drawing.Point(356, 3);
            this.panelGodMode.Margin = new System.Windows.Forms.Padding(0);
            this.panelGodMode.Name = "panelGodMode";
            this.panelGodMode.Size = new System.Drawing.Size(165, 53);
            this.panelGodMode.TabIndex = 6;
            this.panelGodMode.Visible = false;
            // 
            // buttonOpenVscode
            // 
            this.buttonOpenVscode.Enabled = false;
            this.buttonOpenVscode.FlatAppearance.BorderSize = 0;
            this.buttonOpenVscode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenVscode.Image = global::Universalis.Properties.Resources.microsoft_visual_studio_code;
            this.buttonOpenVscode.Location = new System.Drawing.Point(112, 0);
            this.buttonOpenVscode.Name = "buttonOpenVscode";
            this.buttonOpenVscode.Size = new System.Drawing.Size(50, 50);
            this.buttonOpenVscode.TabIndex = 5;
            this.toolTip1.SetToolTip(this.buttonOpenVscode, "Universum im Explorer öffnen");
            this.buttonOpenVscode.UseVisualStyleBackColor = false;
            this.buttonOpenVscode.Click += new System.EventHandler(this.buttonOpenVscode_Click);
            // 
            // buttonCreateUniverse
            // 
            this.buttonCreateUniverse.FlatAppearance.BorderSize = 0;
            this.buttonCreateUniverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateUniverse.Image = global::Universalis.Properties.Resources.baseline_add_box_black_48dp;
            this.buttonCreateUniverse.Location = new System.Drawing.Point(0, -1);
            this.buttonCreateUniverse.Name = "buttonCreateUniverse";
            this.buttonCreateUniverse.Size = new System.Drawing.Size(50, 50);
            this.buttonCreateUniverse.TabIndex = 4;
            this.toolTip1.SetToolTip(this.buttonCreateUniverse, "Neues Universum erstellen");
            this.buttonCreateUniverse.UseVisualStyleBackColor = false;
            this.buttonCreateUniverse.Click += new System.EventHandler(this.buttonCreateUniverse_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Enabled = false;
            this.buttonOpenFolder.FlatAppearance.BorderSize = 0;
            this.buttonOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenFolder.Image = global::Universalis.Properties.Resources.baseline_folder_black_48dp;
            this.buttonOpenFolder.Location = new System.Drawing.Point(56, -1);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(50, 50);
            this.buttonOpenFolder.TabIndex = 3;
            this.toolTip1.SetToolTip(this.buttonOpenFolder, "Universum im Explorer öffnen");
            this.buttonOpenFolder.UseVisualStyleBackColor = false;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInfo.Enabled = false;
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Image = global::Universalis.Properties.Resources.baseline_info_black_48dp;
            this.buttonInfo.Location = new System.Drawing.Point(703, 3);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(50, 50);
            this.buttonInfo.TabIndex = 5;
            this.toolTip1.SetToolTip(this.buttonInfo, "Infos zum Universum");
            this.buttonInfo.UseVisualStyleBackColor = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Image = global::Universalis.Properties.Resources.baseline_delete_black_48dp;
            this.buttonDelete.Location = new System.Drawing.Point(759, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(50, 50);
            this.buttonDelete.TabIndex = 2;
            this.toolTip1.SetToolTip(this.buttonDelete, "Universum löschen");
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Image = global::Universalis.Properties.Resources.outline_playlist_add_black_48dp;
            this.buttonAdd.Location = new System.Drawing.Point(815, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(50, 50);
            this.buttonAdd.TabIndex = 0;
            this.toolTip1.SetToolTip(this.buttonAdd, "Universum hinzufügen");
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panelWorking
            // 
            this.panelWorking.BackColor = System.Drawing.SystemColors.Window;
            this.panelWorking.Controls.Add(this.pictureBoxSpinner);
            this.panelWorking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorking.Location = new System.Drawing.Point(0, 0);
            this.panelWorking.Name = "panelWorking";
            this.panelWorking.Size = new System.Drawing.Size(868, 332);
            this.panelWorking.TabIndex = 3;
            this.panelWorking.Visible = false;
            // 
            // pictureBoxSpinner
            // 
            this.pictureBoxSpinner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxSpinner.Image = global::Universalis.Properties.Resources.spinner;
            this.pictureBoxSpinner.Location = new System.Drawing.Point(334, 92);
            this.pictureBoxSpinner.Name = "pictureBoxSpinner";
            this.pictureBoxSpinner.Size = new System.Drawing.Size(200, 148);
            this.pictureBoxSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSpinner.TabIndex = 4;
            this.pictureBoxSpinner.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.listViewUniverses);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(868, 332);
            this.panelMain.TabIndex = 3;
            // 
            // UniverseSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 388);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelNoUniverses);
            this.Controls.Add(this.panelWorking);
            this.Controls.Add(this.panelControl);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(884, 427);
            this.Name = "UniverseSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Universalis";
            this.Shown += new System.EventHandler(this.UniverseSelectionForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UniverseSelectionForm_KeyDown);
            this.panelNoUniverses.ResumeLayout(false);
            this.panelNoUniverses.PerformLayout();
            this.tableLayoutPanelCentered.ResumeLayout(false);
            this.tableLayoutPanelCentered.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.panelGodMode.ResumeLayout(false);
            this.panelWorking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinner)).EndInit();
            this.panelMain.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Panel panelWorking;
        private System.Windows.Forms.PictureBox pictureBoxSpinner;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonCreateUniverse;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Panel panelGodMode;
        private System.Windows.Forms.Button buttonOpenVscode;
    }
}