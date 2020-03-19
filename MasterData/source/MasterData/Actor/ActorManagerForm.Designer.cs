namespace Universalis
{
    partial class ActorManagerForm
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
            this.dataGridViewActors = new System.Windows.Forms.DataGridView();
            this.factionIconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.iconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsRangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripCardManager = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonAddActor = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteActor = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.filterFaction = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterFaction = new System.Windows.Forms.ToolStripButton();
            this.filterType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExportImage = new System.Windows.Forms.ToolStripButton();
            this.checkBoxFilterType = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonChangeFaction = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actorBindingSource)).BeginInit();
            this.toolStripCardManager.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewActors
            // 
            this.dataGridViewActors.AllowUserToAddRows = false;
            this.dataGridViewActors.AllowUserToDeleteRows = false;
            this.dataGridViewActors.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewActors.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewActors.AutoGenerateColumns = false;
            this.dataGridViewActors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.factionIconDataGridViewImageColumn,
            this.iconDataGridViewImageColumn,
            this.nameDataGridViewTextBoxColumn,
            this.pointsRangeDataGridViewTextBoxColumn});
            this.dataGridViewActors.DataSource = this.actorBindingSource;
            this.dataGridViewActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewActors.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewActors.MultiSelect = false;
            this.dataGridViewActors.Name = "dataGridViewActors";
            this.dataGridViewActors.ReadOnly = true;
            this.dataGridViewActors.RowHeadersVisible = false;
            this.dataGridViewActors.RowTemplate.Height = 40;
            this.dataGridViewActors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActors.Size = new System.Drawing.Size(505, 548);
            this.dataGridViewActors.TabIndex = 0;
            this.dataGridViewActors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewActors_CellDoubleClick);
            this.dataGridViewActors.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewActors_CellToolTipTextNeeded);
            this.dataGridViewActors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewActors_KeyDown);
            // 
            // factionIconDataGridViewImageColumn
            // 
            this.factionIconDataGridViewImageColumn.DataPropertyName = "FactionIcon";
            this.factionIconDataGridViewImageColumn.HeaderText = "";
            this.factionIconDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.factionIconDataGridViewImageColumn.Name = "factionIconDataGridViewImageColumn";
            this.factionIconDataGridViewImageColumn.ReadOnly = true;
            this.factionIconDataGridViewImageColumn.Width = 40;
            // 
            // iconDataGridViewImageColumn
            // 
            this.iconDataGridViewImageColumn.DataPropertyName = "Icon";
            this.iconDataGridViewImageColumn.HeaderText = "";
            this.iconDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.iconDataGridViewImageColumn.Name = "iconDataGridViewImageColumn";
            this.iconDataGridViewImageColumn.ReadOnly = true;
            this.iconDataGridViewImageColumn.Width = 40;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 125;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pointsRangeDataGridViewTextBoxColumn
            // 
            this.pointsRangeDataGridViewTextBoxColumn.DataPropertyName = "PointsRange";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pointsRangeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.pointsRangeDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsRangeDataGridViewTextBoxColumn.Name = "pointsRangeDataGridViewTextBoxColumn";
            this.pointsRangeDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsRangeDataGridViewTextBoxColumn.Width = 80;
            // 
            // actorBindingSource
            // 
            this.actorBindingSource.DataSource = typeof(Universalis.Actor);
            // 
            // toolStripCardManager
            // 
            this.toolStripCardManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonAddActor,
            this.toolStripButtonDeleteActor,
            this.toolStripButtonClearSearch,
            this.filterFaction,
            this.checkBoxFilterFaction,
            this.filterType,
            this.toolStripButtonCopy,
            this.toolStripButtonExportImage,
            this.checkBoxFilterType,
            this.toolStripButtonChangeFaction});
            this.toolStripCardManager.Location = new System.Drawing.Point(0, 0);
            this.toolStripCardManager.Name = "toolStripCardManager";
            this.toolStripCardManager.Size = new System.Drawing.Size(505, 25);
            this.toolStripCardManager.TabIndex = 1;
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
            // toolStripButtonAddActor
            // 
            this.toolStripButtonAddActor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAddActor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddActor.Image = global::Universalis.Properties.Resources.plus;
            this.toolStripButtonAddActor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddActor.Name = "toolStripButtonAddActor";
            this.toolStripButtonAddActor.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddActor.ToolTipText = "neues Modell";
            this.toolStripButtonAddActor.Click += new System.EventHandler(this.toolStripButtonAddActor_Click);
            // 
            // toolStripButtonDeleteActor
            // 
            this.toolStripButtonDeleteActor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDeleteActor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteActor.Image = global::Universalis.Properties.Resources.minus;
            this.toolStripButtonDeleteActor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteActor.Name = "toolStripButtonDeleteActor";
            this.toolStripButtonDeleteActor.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteActor.ToolTipText = "Modell löschen";
            this.toolStripButtonDeleteActor.Click += new System.EventHandler(this.toolStripButtonDeleteActor_Click);
            // 
            // toolStripButtonClearSearch
            // 
            this.toolStripButtonClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClearSearch.Image = global::Universalis.Properties.Resources.clear;
            this.toolStripButtonClearSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearSearch.Name = "toolStripButtonClearSearch";
            this.toolStripButtonClearSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClearSearch.ToolTipText = "Text löschen";
            this.toolStripButtonClearSearch.Click += new System.EventHandler(this.toolStripButtonClearSearch_Click);
            // 
            // filterFaction
            // 
            this.filterFaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterFaction.Enabled = false;
            this.filterFaction.Name = "filterFaction";
            this.filterFaction.Size = new System.Drawing.Size(90, 25);
            this.filterFaction.ToolTipText = "Fraktion";
            // 
            // checkBoxFilterFaction
            // 
            this.checkBoxFilterFaction.CheckOnClick = true;
            this.checkBoxFilterFaction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBoxFilterFaction.Image = global::Universalis.Properties.Resources.ui_check_box_uncheck;
            this.checkBoxFilterFaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterFaction.Name = "checkBoxFilterFaction";
            this.checkBoxFilterFaction.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterFaction.ToolTipText = "nach Fraktion filtern";
            this.checkBoxFilterFaction.Click += new System.EventHandler(this.checkBoxFilterFaction_Click);
            // 
            // filterType
            // 
            this.filterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterType.Enabled = false;
            this.filterType.Name = "filterType";
            this.filterType.Size = new System.Drawing.Size(75, 25);
            this.filterType.ToolTipText = "Typ";
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::Universalis.Properties.Resources.copy;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopy.ToolTipText = "Modell kopieren";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonExportImage
            // 
            this.toolStripButtonExportImage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonExportImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportImage.Image = global::Universalis.Properties.Resources.image;
            this.toolStripButtonExportImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportImage.Name = "toolStripButtonExportImage";
            this.toolStripButtonExportImage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExportImage.Click += new System.EventHandler(this.toolStripButtonExportImage_Click);
            // 
            // checkBoxFilterType
            // 
            this.checkBoxFilterType.CheckOnClick = true;
            this.checkBoxFilterType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBoxFilterType.Image = global::Universalis.Properties.Resources.ui_check_box_uncheck;
            this.checkBoxFilterType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterType.Name = "checkBoxFilterType";
            this.checkBoxFilterType.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterType.ToolTipText = "nach Typ filtern";
            this.checkBoxFilterType.Click += new System.EventHandler(this.checkBoxFilterType_Click);
            // 
            // toolStripButtonChangeFaction
            // 
            this.toolStripButtonChangeFaction.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonChangeFaction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonChangeFaction.Image = global::Universalis.Properties.Resources.arrow_step_over;
            this.toolStripButtonChangeFaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonChangeFaction.Name = "toolStripButtonChangeFaction";
            this.toolStripButtonChangeFaction.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonChangeFaction.Text = "in andere Fraktion verschieben";
            this.toolStripButtonChangeFaction.Click += new System.EventHandler(this.toolStripButtonChangeFaction_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(505, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // ActorManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 595);
            this.Controls.Add(this.dataGridViewActors);
            this.Controls.Add(this.toolStripCardManager);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "ActorManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modelle";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActorManagerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actorBindingSource)).EndInit();
            this.toolStripCardManager.ResumeLayout(false);
            this.toolStripCardManager.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripCardManager;
        private System.Windows.Forms.DataGridView dataGridViewActors;
        private System.Windows.Forms.BindingSource actorBindingSource;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddActor;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteActor;
        private System.Windows.Forms.ToolStripComboBox filterFaction;
        private System.Windows.Forms.ToolStripButton checkBoxFilterFaction;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportImage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.ToolStripComboBox filterType;
        private System.Windows.Forms.ToolStripButton checkBoxFilterType;
        private System.Windows.Forms.DataGridViewImageColumn factionIconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsRangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton toolStripButtonChangeFaction;
    }
}