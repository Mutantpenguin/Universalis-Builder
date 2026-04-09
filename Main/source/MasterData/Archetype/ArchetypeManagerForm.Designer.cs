namespace Universalis
{
    partial class ArchetypeManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonArchetypeAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonArchetypeDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.filterFaction = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterFaction = new System.Windows.Forms.ToolStripButton();
            this.filterType = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterType = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewArchetypes = new System.Windows.Forms.DataGridView();
            this.archetypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movementTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasRules = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SpeedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hitPointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.critThresholdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HTHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LRCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AWADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasPermissions = new System.Windows.Forms.DataGridViewImageColumn();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchetypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archetypeBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonArchetypeAdd,
            this.toolStripButtonArchetypeDelete,
            this.toolStripButtonCopy,
            this.toolStripButtonClearSearch,
            this.filterFaction,
            this.checkBoxFilterFaction,
            this.filterType,
            this.checkBoxFilterType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(909, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxSearch.ToolTipText = "nach Namen filtern";
            this.toolStripTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxSearch_KeyDown);
            this.toolStripTextBoxSearch.TextChanged += new System.EventHandler(this.toolStripTextBoxSearch_TextChanged);
            // 
            // toolStripButtonArchetypeAdd
            // 
            this.toolStripButtonArchetypeAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonArchetypeAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArchetypeAdd.Image = global::Universalis.Properties.Resources.plus;
            this.toolStripButtonArchetypeAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonArchetypeAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArchetypeAdd.Name = "toolStripButtonArchetypeAdd";
            this.toolStripButtonArchetypeAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArchetypeAdd.ToolTipText = "neuer Archetyp";
            this.toolStripButtonArchetypeAdd.Click += new System.EventHandler(this.toolStripButtonArchetypeAdd_Click);
            // 
            // toolStripButtonArchetypeDelete
            // 
            this.toolStripButtonArchetypeDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonArchetypeDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArchetypeDelete.Image = global::Universalis.Properties.Resources.trash;
            this.toolStripButtonArchetypeDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonArchetypeDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArchetypeDelete.Name = "toolStripButtonArchetypeDelete";
            this.toolStripButtonArchetypeDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArchetypeDelete.ToolTipText = "Archetyp löschen";
            this.toolStripButtonArchetypeDelete.Click += new System.EventHandler(this.toolStripButtonArchetypeDelete_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::Universalis.Properties.Resources.copy;
            this.toolStripButtonCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopy.ToolTipText = "Archetyp kopieren";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonClearSearch
            // 
            this.toolStripButtonClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClearSearch.Image = global::Universalis.Properties.Resources.clear;
            this.toolStripButtonClearSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.checkBoxFilterFaction.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            // checkBoxFilterType
            // 
            this.checkBoxFilterType.CheckOnClick = true;
            this.checkBoxFilterType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBoxFilterType.Image = global::Universalis.Properties.Resources.ui_check_box_uncheck;
            this.checkBoxFilterType.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkBoxFilterType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterType.Name = "checkBoxFilterType";
            this.checkBoxFilterType.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterType.ToolTipText = "nach Typ filtern";
            this.checkBoxFilterType.Click += new System.EventHandler(this.checkBoxFilterType_Click);
            // 
            // dataGridViewArchetypes
            // 
            this.dataGridViewArchetypes.AllowUserToAddRows = false;
            this.dataGridViewArchetypes.AllowUserToDeleteRows = false;
            this.dataGridViewArchetypes.AllowUserToOrderColumns = true;
            this.dataGridViewArchetypes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewArchetypes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewArchetypes.AutoGenerateColumns = false;
            this.dataGridViewArchetypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArchetypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.maxQuantityDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.movementTypeDataGridViewTextBoxColumn,
            this.HasRules,
            this.SpeedDataGridViewTextBoxColumn,
            this.hitPointsDataGridViewTextBoxColumn,
            this.critThresholdDataGridViewTextBoxColumn,
            this.AGIDataGridViewTextBoxColumn,
            this.HTHDataGridViewTextBoxColumn,
            this.LRCDataGridViewTextBoxColumn,
            this.PHYDataGridViewTextBoxColumn,
            this.AWADataGridViewTextBoxColumn,
            this.DETDataGridViewTextBoxColumn,
            this.Weight,
            this.HasPermissions,
            this.Points});
            this.dataGridViewArchetypes.DataSource = this.archetypeBindingSource;
            this.dataGridViewArchetypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewArchetypes.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewArchetypes.MultiSelect = false;
            this.dataGridViewArchetypes.Name = "dataGridViewArchetypes";
            this.dataGridViewArchetypes.ReadOnly = true;
            this.dataGridViewArchetypes.RowHeadersVisible = false;
            this.dataGridViewArchetypes.RowTemplate.Height = 40;
            this.dataGridViewArchetypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArchetypes.Size = new System.Drawing.Size(909, 379);
            this.dataGridViewArchetypes.TabIndex = 0;
            this.dataGridViewArchetypes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewArchetype_CellDoubleClick);
            this.dataGridViewArchetypes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewArchetypes_CellFormatting);
            this.dataGridViewArchetypes.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewArchetype_CellToolTipTextNeeded);
            this.dataGridViewArchetypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewArchetype_KeyDown);
            // 
            // archetypeBindingSource
            // 
            this.archetypeBindingSource.DataSource = typeof(Universalis.Archetype);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(909, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // maxQuantityDataGridViewTextBoxColumn
            // 
            this.maxQuantityDataGridViewTextBoxColumn.DataPropertyName = "MaxQuantityString";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.maxQuantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.maxQuantityDataGridViewTextBoxColumn.HeaderText = "Max.";
            this.maxQuantityDataGridViewTextBoxColumn.Name = "maxQuantityDataGridViewTextBoxColumn";
            this.maxQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxQuantityDataGridViewTextBoxColumn.ToolTipText = "Maximale Anzahl";
            this.maxQuantityDataGridViewTextBoxColumn.Width = 35;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Typ";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Width = 80;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Größe";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            this.sizeDataGridViewTextBoxColumn.ReadOnly = true;
            this.sizeDataGridViewTextBoxColumn.Width = 60;
            // 
            // movementTypeDataGridViewTextBoxColumn
            // 
            this.movementTypeDataGridViewTextBoxColumn.DataPropertyName = "MovementType";
            this.movementTypeDataGridViewTextBoxColumn.HeaderText = "Bewegungsart";
            this.movementTypeDataGridViewTextBoxColumn.Name = "movementTypeDataGridViewTextBoxColumn";
            this.movementTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.movementTypeDataGridViewTextBoxColumn.Width = 80;
            // 
            // HasRules
            // 
            this.HasRules.HeaderText = "R";
            this.HasRules.Name = "HasRules";
            this.HasRules.ReadOnly = true;
            this.HasRules.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HasRules.ToolTipText = "Regeln";
            this.HasRules.Width = 25;
            // 
            // SpeedDataGridViewTextBoxColumn
            // 
            this.SpeedDataGridViewTextBoxColumn.DataPropertyName = "Profile.Speed";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0.0\\\"";
            this.SpeedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.SpeedDataGridViewTextBoxColumn.HeaderText = "GK";
            this.SpeedDataGridViewTextBoxColumn.Name = "SpeedDataGridViewTextBoxColumn";
            this.SpeedDataGridViewTextBoxColumn.ReadOnly = true;
            this.SpeedDataGridViewTextBoxColumn.Width = 35;
            // 
            // hitPointsDataGridViewTextBoxColumn
            // 
            this.hitPointsDataGridViewTextBoxColumn.DataPropertyName = "Profile.HitPoints";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.hitPointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.hitPointsDataGridViewTextBoxColumn.HeaderText = "TP";
            this.hitPointsDataGridViewTextBoxColumn.Name = "hitPointsDataGridViewTextBoxColumn";
            this.hitPointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.hitPointsDataGridViewTextBoxColumn.Width = 35;
            // 
            // critThresholdDataGridViewTextBoxColumn
            // 
            this.critThresholdDataGridViewTextBoxColumn.DataPropertyName = "Profile.CritThreshold";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "0\\%";
            this.critThresholdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.critThresholdDataGridViewTextBoxColumn.HeaderText = "KS";
            this.critThresholdDataGridViewTextBoxColumn.Name = "critThresholdDataGridViewTextBoxColumn";
            this.critThresholdDataGridViewTextBoxColumn.ReadOnly = true;
            this.critThresholdDataGridViewTextBoxColumn.ToolTipText = "Kritische Schwelle";
            this.critThresholdDataGridViewTextBoxColumn.Width = 35;
            // 
            // AGIDataGridViewTextBoxColumn
            // 
            this.AGIDataGridViewTextBoxColumn.DataPropertyName = "AGIString";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AGIDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.AGIDataGridViewTextBoxColumn.HeaderText = "AGI";
            this.AGIDataGridViewTextBoxColumn.Name = "AGIDataGridViewTextBoxColumn";
            this.AGIDataGridViewTextBoxColumn.ReadOnly = true;
            this.AGIDataGridViewTextBoxColumn.Width = 35;
            // 
            // HTHDataGridViewTextBoxColumn
            // 
            this.HTHDataGridViewTextBoxColumn.DataPropertyName = "HTHString";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HTHDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.HTHDataGridViewTextBoxColumn.HeaderText = "NK";
            this.HTHDataGridViewTextBoxColumn.Name = "HTHDataGridViewTextBoxColumn";
            this.HTHDataGridViewTextBoxColumn.ReadOnly = true;
            this.HTHDataGridViewTextBoxColumn.Width = 35;
            // 
            // LRCDataGridViewTextBoxColumn
            // 
            this.LRCDataGridViewTextBoxColumn.DataPropertyName = "LRCString";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LRCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.LRCDataGridViewTextBoxColumn.HeaderText = "FK";
            this.LRCDataGridViewTextBoxColumn.Name = "LRCDataGridViewTextBoxColumn";
            this.LRCDataGridViewTextBoxColumn.ReadOnly = true;
            this.LRCDataGridViewTextBoxColumn.Width = 35;
            // 
            // PHYDataGridViewTextBoxColumn
            // 
            this.PHYDataGridViewTextBoxColumn.DataPropertyName = "PHYString";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PHYDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.PHYDataGridViewTextBoxColumn.HeaderText = "KO";
            this.PHYDataGridViewTextBoxColumn.Name = "PHYDataGridViewTextBoxColumn";
            this.PHYDataGridViewTextBoxColumn.ReadOnly = true;
            this.PHYDataGridViewTextBoxColumn.Width = 35;
            // 
            // AWADataGridViewTextBoxColumn
            // 
            this.AWADataGridViewTextBoxColumn.DataPropertyName = "AWAString";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AWADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.AWADataGridViewTextBoxColumn.HeaderText = "WN";
            this.AWADataGridViewTextBoxColumn.Name = "AWADataGridViewTextBoxColumn";
            this.AWADataGridViewTextBoxColumn.ReadOnly = true;
            this.AWADataGridViewTextBoxColumn.Width = 35;
            // 
            // DETDataGridViewTextBoxColumn
            // 
            this.DETDataGridViewTextBoxColumn.DataPropertyName = "DETString";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DETDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.DETDataGridViewTextBoxColumn.HeaderText = "EH";
            this.DETDataGridViewTextBoxColumn.Name = "DETDataGridViewTextBoxColumn";
            this.DETDataGridViewTextBoxColumn.ReadOnly = true;
            this.DETDataGridViewTextBoxColumn.Width = 35;
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N1";
            this.Weight.DefaultCellStyle = dataGridViewCellStyle12;
            this.Weight.HeaderText = "Gewicht";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Width = 60;
            // 
            // HasPermissions
            // 
            this.HasPermissions.HeaderText = "B";
            this.HasPermissions.Name = "HasPermissions";
            this.HasPermissions.ReadOnly = true;
            this.HasPermissions.ToolTipText = "Berechtigungen";
            this.HasPermissions.Width = 25;
            // 
            // Points
            // 
            this.Points.DataPropertyName = "Points";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N0";
            this.Points.DefaultCellStyle = dataGridViewCellStyle13;
            this.Points.HeaderText = "Punkte";
            this.Points.Name = "Points";
            this.Points.ReadOnly = true;
            this.Points.Width = 60;
            // 
            // ArchetypeManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 426);
            this.Controls.Add(this.dataGridViewArchetypes);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "ArchetypeManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archetypen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArchetypeManagerForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchetypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archetypeBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonArchetypeDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonArchetypeAdd;
        private System.Windows.Forms.DataGridView dataGridViewArchetypes;
        private System.Windows.Forms.BindingSource archetypeBindingSource;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.ToolStripComboBox filterFaction;
        private System.Windows.Forms.ToolStripButton checkBoxFilterFaction;
        private System.Windows.Forms.ToolStripComboBox filterType;
        private System.Windows.Forms.ToolStripButton checkBoxFilterType;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movementTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpeedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hitPointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn critThresholdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HTHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LRCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AWADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewImageColumn HasPermissions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Points;
    }
}