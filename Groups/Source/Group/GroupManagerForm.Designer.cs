namespace Tesserakt
{
    partial class GroupManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.iconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripCardManager = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExportFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExportPDF = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxFactionDescription = new System.Windows.Forms.TextBox();
            this.pictureBoxFaction = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            this.toolStripCardManager.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFaction)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGroups
            // 
            this.dataGridViewGroups.AllowUserToAddRows = false;
            this.dataGridViewGroups.AllowUserToDeleteRows = false;
            this.dataGridViewGroups.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewGroups.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGroups.AutoGenerateColumns = false;
            this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iconDataGridViewImageColumn,
            this.nameDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn});
            this.dataGridViewGroups.DataSource = this.groupBindingSource;
            this.dataGridViewGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGroups.Location = new System.Drawing.Point(0, 181);
            this.dataGridViewGroups.MultiSelect = false;
            this.dataGridViewGroups.Name = "dataGridViewGroups";
            this.dataGridViewGroups.ReadOnly = true;
            this.dataGridViewGroups.RowHeadersVisible = false;
            this.dataGridViewGroups.RowTemplate.Height = 100;
            this.dataGridViewGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroups.Size = new System.Drawing.Size(521, 392);
            this.dataGridViewGroups.TabIndex = 1;
            this.dataGridViewGroups.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGroups_CellDoubleClick);
            this.dataGridViewGroups.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewGroups_CellPainting);
            this.dataGridViewGroups.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewGroups_CellToolTipTextNeeded);
            this.dataGridViewGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewGroups_KeyDown);
            // 
            // iconDataGridViewImageColumn
            // 
            this.iconDataGridViewImageColumn.DataPropertyName = "Icon";
            this.iconDataGridViewImageColumn.HeaderText = "";
            this.iconDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.iconDataGridViewImageColumn.Name = "iconDataGridViewImageColumn";
            this.iconDataGridViewImageColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsDataGridViewTextBoxColumn.Width = 60;
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(Tesserakt.Group);
            // 
            // toolStripCardManager
            // 
            this.toolStripCardManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddGroup,
            this.toolStripButtonDeleteGroup,
            this.toolStripTextBoxSearch,
            this.toolStripButtonClearSearch,
            this.toolStripButtonCopy,
            this.toolStripButtonExportFile,
            this.toolStripButtonExportPDF});
            this.toolStripCardManager.Location = new System.Drawing.Point(0, 156);
            this.toolStripCardManager.Name = "toolStripCardManager";
            this.toolStripCardManager.Size = new System.Drawing.Size(521, 25);
            this.toolStripCardManager.TabIndex = 0;
            this.toolStripCardManager.Text = "toolStrip1";
            // 
            // toolStripButtonAddGroup
            // 
            this.toolStripButtonAddGroup.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddGroup.Image = global::Tesserakt.Properties.Resources.plus;
            this.toolStripButtonAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddGroup.Name = "toolStripButtonAddGroup";
            this.toolStripButtonAddGroup.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddGroup.ToolTipText = "neue Gruppe";
            this.toolStripButtonAddGroup.Click += new System.EventHandler(this.toolStripButtonAddGroups_Click);
            // 
            // toolStripButtonDeleteGroup
            // 
            this.toolStripButtonDeleteGroup.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDeleteGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteGroup.Image = global::Tesserakt.Properties.Resources.minus;
            this.toolStripButtonDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteGroup.Name = "toolStripButtonDeleteGroup";
            this.toolStripButtonDeleteGroup.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteGroup.ToolTipText = "Gruppe löschen";
            this.toolStripButtonDeleteGroup.Click += new System.EventHandler(this.toolStripButtonDeleteGroup_Click);
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxSearch.ToolTipText = "nach Namen filtern";
            this.toolStripTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxSearch_KeyDown);
            this.toolStripTextBoxSearch.TextChanged += new System.EventHandler(this.toolStripTextBoxSearch_TextChanged);
            // 
            // toolStripButtonClearSearch
            // 
            this.toolStripButtonClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClearSearch.Image = global::Tesserakt.Properties.Resources.clear;
            this.toolStripButtonClearSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearSearch.Name = "toolStripButtonClearSearch";
            this.toolStripButtonClearSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClearSearch.ToolTipText = "Text löschen";
            this.toolStripButtonClearSearch.Click += new System.EventHandler(this.toolStripButtonClearSearch_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::Tesserakt.Properties.Resources.copy;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopy.ToolTipText = "Gruppe kopieren";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonExportFile
            // 
            this.toolStripButtonExportFile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonExportFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportFile.Image = global::Tesserakt.Properties.Resources.document_export;
            this.toolStripButtonExportFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportFile.Name = "toolStripButtonExportFile";
            this.toolStripButtonExportFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExportFile.Text = "Als Datei exportieren";
            this.toolStripButtonExportFile.Click += new System.EventHandler(this.toolStripButtonExportFile_Click);
            // 
            // toolStripButtonExportPDF
            // 
            this.toolStripButtonExportPDF.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonExportPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportPDF.Image = global::Tesserakt.Properties.Resources.document_pdf;
            this.toolStripButtonExportPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportPDF.Name = "toolStripButtonExportPDF";
            this.toolStripButtonExportPDF.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExportPDF.Text = "Als PDF exportieren";
            this.toolStripButtonExportPDF.Click += new System.EventHandler(this.toolStripButtonExportPDF_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(521, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.textBoxFactionDescription);
            this.panel1.Controls.Add(this.pictureBoxFaction);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 156);
            this.panel1.TabIndex = 3;
            // 
            // textBoxFactionDescription
            // 
            this.textBoxFactionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFactionDescription.Location = new System.Drawing.Point(159, 3);
            this.textBoxFactionDescription.Multiline = true;
            this.textBoxFactionDescription.Name = "textBoxFactionDescription";
            this.textBoxFactionDescription.ReadOnly = true;
            this.textBoxFactionDescription.Size = new System.Drawing.Size(350, 150);
            this.textBoxFactionDescription.TabIndex = 1;
            // 
            // pictureBoxFaction
            // 
            this.pictureBoxFaction.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxFaction.Name = "pictureBoxFaction";
            this.pictureBoxFaction.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxFaction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFaction.TabIndex = 0;
            this.pictureBoxFaction.TabStop = false;
            // 
            // GroupManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 595);
            this.Controls.Add(this.dataGridViewGroups);
            this.Controls.Add(this.toolStripCardManager);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "GroupManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Einsatzgruppen Manager";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GroupManagerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            this.toolStripCardManager.ResumeLayout(false);
            this.toolStripCardManager.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFaction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripCardManager;
        private System.Windows.Forms.DataGridView dataGridViewGroups;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddGroup;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteGroup;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportPDF;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxFactionDescription;
        private System.Windows.Forms.PictureBox pictureBoxFaction;
    }
}