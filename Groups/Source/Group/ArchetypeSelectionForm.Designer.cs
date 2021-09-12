namespace Universalis
{
    partial class ArchetypeSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchetypeSelectionForm));
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.filterType = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterType = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewArchetypes = new System.Windows.Forms.DataGridView();
            this.archetypeBindingSource = new System.Windows.Forms.BindingSource();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movementTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hitPointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpeedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HTHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LRCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AWADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchetypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archetypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Image = ((System.Drawing.Image)(resources.GetObject("buttonOk.Image")));
            this.buttonOk.Location = new System.Drawing.Point(697, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 26);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Übernehmen";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 26);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 418);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 32);
            this.panel1.TabIndex = 4;
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxSearch_KeyDown);
            this.toolStripTextBoxSearch.TextChanged += new System.EventHandler(this.toolStripTextBoxSearch_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonClearSearch,
            this.filterType,
            this.checkBoxFilterType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonClearSearch
            // 
            this.toolStripButtonClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClearSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearSearch.Image")));
            this.toolStripButtonClearSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonClearSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearSearch.Name = "toolStripButtonClearSearch";
            this.toolStripButtonClearSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClearSearch.ToolTipText = "Text löschen";
            this.toolStripButtonClearSearch.Click += new System.EventHandler(this.toolStripButtonClearSearch_Click);
            // 
            // filterType
            // 
            this.filterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterType.Enabled = false;
            this.filterType.Name = "filterType";
            this.filterType.Size = new System.Drawing.Size(80, 25);
            this.filterType.ToolTipText = "Typ";
            // 
            // checkBoxFilterType
            // 
            this.checkBoxFilterType.CheckOnClick = true;
            this.checkBoxFilterType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBoxFilterType.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxFilterType.Image")));
            this.checkBoxFilterType.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkBoxFilterType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterType.Name = "checkBoxFilterType";
            this.checkBoxFilterType.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterType.ToolTipText = "nach Tarnung filtern";
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
            this.typeDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.movementTypeDataGridViewTextBoxColumn,
            this.hitPointsDataGridViewTextBoxColumn,
            this.SpeedDataGridViewTextBoxColumn,
            this.AGIDataGridViewTextBoxColumn,
            this.HTHDataGridViewTextBoxColumn,
            this.LRCDataGridViewTextBoxColumn,
            this.PHYDataGridViewTextBoxColumn,
            this.AWADataGridViewTextBoxColumn,
            this.DETDataGridViewTextBoxColumn,
            this.Weight,
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
            this.dataGridViewArchetypes.Size = new System.Drawing.Size(800, 393);
            this.dataGridViewArchetypes.TabIndex = 5;
            this.dataGridViewArchetypes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewArchetypes_CellDoubleClick);
            this.dataGridViewArchetypes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewArchetypes_CellFormatting);
            this.dataGridViewArchetypes.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewArchetypes_CellToolTipTextNeeded);
            this.dataGridViewArchetypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewArchetypes_KeyDown);
            // 
            // archetypeBindingSource
            // 
            this.archetypeBindingSource.DataSource = typeof(Universalis.Archetype);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
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
            // hitPointsDataGridViewTextBoxColumn
            // 
            this.hitPointsDataGridViewTextBoxColumn.DataPropertyName = "Profile.HitPoints";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.hitPointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.hitPointsDataGridViewTextBoxColumn.HeaderText = "TP";
            this.hitPointsDataGridViewTextBoxColumn.Name = "hitPointsDataGridViewTextBoxColumn";
            this.hitPointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.hitPointsDataGridViewTextBoxColumn.Width = 35;
            // 
            // SpeedDataGridViewTextBoxColumn
            // 
            this.SpeedDataGridViewTextBoxColumn.DataPropertyName = "Profile.Speed";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SpeedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.SpeedDataGridViewTextBoxColumn.HeaderText = "GK";
            this.SpeedDataGridViewTextBoxColumn.Name = "SpeedDataGridViewTextBoxColumn";
            this.SpeedDataGridViewTextBoxColumn.ReadOnly = true;
            this.SpeedDataGridViewTextBoxColumn.Width = 35;
            // 
            // AGIDataGridViewTextBoxColumn
            // 
            this.AGIDataGridViewTextBoxColumn.DataPropertyName = "Profile.Attributes.AGI";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AGIDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.AGIDataGridViewTextBoxColumn.HeaderText = "AGI";
            this.AGIDataGridViewTextBoxColumn.Name = "AGIDataGridViewTextBoxColumn";
            this.AGIDataGridViewTextBoxColumn.ReadOnly = true;
            this.AGIDataGridViewTextBoxColumn.Width = 35;
            // 
            // HTHDataGridViewTextBoxColumn
            // 
            this.HTHDataGridViewTextBoxColumn.DataPropertyName = "Profile.Attributes.HTH";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HTHDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.HTHDataGridViewTextBoxColumn.HeaderText = "NK";
            this.HTHDataGridViewTextBoxColumn.Name = "HTHDataGridViewTextBoxColumn";
            this.HTHDataGridViewTextBoxColumn.ReadOnly = true;
            this.HTHDataGridViewTextBoxColumn.Width = 35;
            // 
            // LRCDataGridViewTextBoxColumn
            // 
            this.LRCDataGridViewTextBoxColumn.DataPropertyName = "Profile.Attributes.LRC";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LRCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.LRCDataGridViewTextBoxColumn.HeaderText = "FK";
            this.LRCDataGridViewTextBoxColumn.Name = "LRCDataGridViewTextBoxColumn";
            this.LRCDataGridViewTextBoxColumn.ReadOnly = true;
            this.LRCDataGridViewTextBoxColumn.Width = 35;
            // 
            // PHYDataGridViewTextBoxColumn
            // 
            this.PHYDataGridViewTextBoxColumn.DataPropertyName = "Profile.Attributes.PHY";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PHYDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.PHYDataGridViewTextBoxColumn.HeaderText = "KO";
            this.PHYDataGridViewTextBoxColumn.Name = "PHYDataGridViewTextBoxColumn";
            this.PHYDataGridViewTextBoxColumn.ReadOnly = true;
            this.PHYDataGridViewTextBoxColumn.Width = 35;
            // 
            // AWADataGridViewTextBoxColumn
            // 
            this.AWADataGridViewTextBoxColumn.DataPropertyName = "Profile.Attributes.AWA";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AWADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.AWADataGridViewTextBoxColumn.HeaderText = "WN";
            this.AWADataGridViewTextBoxColumn.Name = "AWADataGridViewTextBoxColumn";
            this.AWADataGridViewTextBoxColumn.ReadOnly = true;
            this.AWADataGridViewTextBoxColumn.Width = 35;
            // 
            // DETDataGridViewTextBoxColumn
            // 
            this.DETDataGridViewTextBoxColumn.DataPropertyName = "Profile.Attributes.DET";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DETDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.DETDataGridViewTextBoxColumn.HeaderText = "EH";
            this.DETDataGridViewTextBoxColumn.Name = "DETDataGridViewTextBoxColumn";
            this.DETDataGridViewTextBoxColumn.ReadOnly = true;
            this.DETDataGridViewTextBoxColumn.Width = 35;
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N1";
            this.Weight.DefaultCellStyle = dataGridViewCellStyle10;
            this.Weight.HeaderText = "Gewicht";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.Width = 60;
            // 
            // Points
            // 
            this.Points.DataPropertyName = "Points";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Points.DefaultCellStyle = dataGridViewCellStyle11;
            this.Points.HeaderText = "Punkte";
            this.Points.Name = "Points";
            this.Points.ReadOnly = true;
            this.Points.Width = 60;
            // 
            // ArchetypeSelectionForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewArchetypes);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "ArchetypeSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bitte wählen Sie einen Archetyp";
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchetypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archetypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource archetypeBindingSource;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridViewArchetypes;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.ToolStripComboBox filterType;
        private System.Windows.Forms.ToolStripButton checkBoxFilterType;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movementTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hitPointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpeedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HTHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LRCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AWADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Points;
    }
}