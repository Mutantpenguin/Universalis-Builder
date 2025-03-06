namespace Universalis
{
    partial class EquipmentManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonEquipmentAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEquipmentDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewEquipment = new System.Windows.Forms.DataGridView();
            this.equipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedMaxQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseOnce = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Unwieldy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GKString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HitPointsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CritThresholdString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGIString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HTHString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LRCString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHYString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AWAString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasPermissions = new System.Windows.Forms.DataGridViewImageColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonEquipmentAdd,
            this.toolStripButtonEquipmentDelete,
            this.toolStripButtonCopy,
            this.toolStripButtonClearSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(814, 25);
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
            // toolStripButtonEquipmentAdd
            // 
            this.toolStripButtonEquipmentAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonEquipmentAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEquipmentAdd.Image = global::Universalis.Properties.Resources.plus;
            this.toolStripButtonEquipmentAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEquipmentAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEquipmentAdd.Name = "toolStripButtonEquipmentAdd";
            this.toolStripButtonEquipmentAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEquipmentAdd.ToolTipText = "neue Ausrüstung";
            this.toolStripButtonEquipmentAdd.Click += new System.EventHandler(this.toolStripButtonEquipmentAdd_Click);
            // 
            // toolStripButtonEquipmentDelete
            // 
            this.toolStripButtonEquipmentDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonEquipmentDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEquipmentDelete.Image = global::Universalis.Properties.Resources.trash;
            this.toolStripButtonEquipmentDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEquipmentDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEquipmentDelete.Name = "toolStripButtonEquipmentDelete";
            this.toolStripButtonEquipmentDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEquipmentDelete.ToolTipText = "Ausrüstung löschen";
            this.toolStripButtonEquipmentDelete.Click += new System.EventHandler(this.toolStripButtonEquipmentDelete_Click);
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
            this.toolStripButtonCopy.ToolTipText = "Ausrüstung kopieren";
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
            // dataGridViewEquipment
            // 
            this.dataGridViewEquipment.AllowUserToAddRows = false;
            this.dataGridViewEquipment.AllowUserToDeleteRows = false;
            this.dataGridViewEquipment.AllowUserToOrderColumns = true;
            this.dataGridViewEquipment.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewEquipment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEquipment.AutoGenerateColumns = false;
            this.dataGridViewEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.FormattedMaxQuantity,
            this.apDataGridViewTextBoxColumn,
            this.UseOnce,
            this.Unwieldy,
            this.GKString,
            this.HitPointsString,
            this.CritThresholdString,
            this.AGIString,
            this.HTHString,
            this.LRCString,
            this.PHYString,
            this.AWAString,
            this.DETString,
            this.HasPermissions,
            this.weightDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn});
            this.dataGridViewEquipment.DataSource = this.equipmentBindingSource;
            this.dataGridViewEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEquipment.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewEquipment.Name = "dataGridViewEquipment";
            this.dataGridViewEquipment.ReadOnly = true;
            this.dataGridViewEquipment.RowHeadersVisible = false;
            this.dataGridViewEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEquipment.Size = new System.Drawing.Size(814, 379);
            this.dataGridViewEquipment.TabIndex = 0;
            this.dataGridViewEquipment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEquipment_CellDoubleClick);
            this.dataGridViewEquipment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewEquipment_CellFormatting);
            this.dataGridViewEquipment.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewEquipment_CellToolTipTextNeeded);
            this.dataGridViewEquipment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewEquipment_KeyDown);
            // 
            // equipmentBindingSource
            // 
            this.equipmentBindingSource.DataSource = typeof(Universalis.Equipment);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AttributeModifier";
            this.dataGridViewTextBoxColumn1.HeaderText = "AttributeModifier";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AttributeModifier";
            this.dataGridViewTextBoxColumn2.HeaderText = "AttributeModifier";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AttributeModifier";
            this.dataGridViewTextBoxColumn3.HeaderText = "AttributeModifier";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(814, 22);
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
            // FormattedMaxQuantity
            // 
            this.FormattedMaxQuantity.DataPropertyName = "FormattedMaxQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedMaxQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.FormattedMaxQuantity.HeaderText = "Max.";
            this.FormattedMaxQuantity.Name = "FormattedMaxQuantity";
            this.FormattedMaxQuantity.ReadOnly = true;
            this.FormattedMaxQuantity.ToolTipText = "Modell / Gruppe";
            this.FormattedMaxQuantity.Width = 35;
            // 
            // apDataGridViewTextBoxColumn
            // 
            this.apDataGridViewTextBoxColumn.DataPropertyName = "FormattedAP";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.apDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.apDataGridViewTextBoxColumn.HeaderText = "AP";
            this.apDataGridViewTextBoxColumn.Name = "apDataGridViewTextBoxColumn";
            this.apDataGridViewTextBoxColumn.ReadOnly = true;
            this.apDataGridViewTextBoxColumn.ToolTipText = "Aktionspunkte";
            this.apDataGridViewTextBoxColumn.Width = 35;
            // 
            // UseOnce
            // 
            this.UseOnce.DataPropertyName = "UseOnce";
            this.UseOnce.HeaderText = "E";
            this.UseOnce.Name = "UseOnce";
            this.UseOnce.ReadOnly = true;
            this.UseOnce.ToolTipText = "Einmalnutzung";
            this.UseOnce.Width = 30;
            // 
            // Unwieldy
            // 
            this.Unwieldy.DataPropertyName = "Unwieldy";
            this.Unwieldy.HeaderText = "U";
            this.Unwieldy.Name = "Unwieldy";
            this.Unwieldy.ReadOnly = true;
            this.Unwieldy.ToolTipText = "Unhandlich";
            this.Unwieldy.Width = 30;
            // 
            // GKString
            // 
            this.GKString.DataPropertyName = "ProfileModifier.SpeedString";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.GKString.DefaultCellStyle = dataGridViewCellStyle4;
            this.GKString.HeaderText = "GK";
            this.GKString.Name = "GKString";
            this.GKString.ReadOnly = true;
            this.GKString.Width = 35;
            // 
            // HitPointsString
            // 
            this.HitPointsString.DataPropertyName = "ProfileModifier.HitPointsString";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HitPointsString.DefaultCellStyle = dataGridViewCellStyle5;
            this.HitPointsString.HeaderText = "TP";
            this.HitPointsString.Name = "HitPointsString";
            this.HitPointsString.ReadOnly = true;
            this.HitPointsString.Width = 35;
            // 
            // CritThresholdString
            // 
            this.CritThresholdString.DataPropertyName = "ProfileModifier.CritThresholdString";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CritThresholdString.DefaultCellStyle = dataGridViewCellStyle6;
            this.CritThresholdString.HeaderText = "KS";
            this.CritThresholdString.Name = "CritThresholdString";
            this.CritThresholdString.ReadOnly = true;
            this.CritThresholdString.ToolTipText = "Kritische Schwelle";
            this.CritThresholdString.Width = 35;
            // 
            // AGIString
            // 
            this.AGIString.DataPropertyName = "ProfileModifier.AttributeModifier.AGIString";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AGIString.DefaultCellStyle = dataGridViewCellStyle7;
            this.AGIString.HeaderText = "AGI";
            this.AGIString.Name = "AGIString";
            this.AGIString.ReadOnly = true;
            this.AGIString.Width = 35;
            // 
            // HTHString
            // 
            this.HTHString.DataPropertyName = "ProfileModifier.AttributeModifier.HTHString";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HTHString.DefaultCellStyle = dataGridViewCellStyle8;
            this.HTHString.HeaderText = "NK";
            this.HTHString.Name = "HTHString";
            this.HTHString.ReadOnly = true;
            this.HTHString.Width = 35;
            // 
            // LRCString
            // 
            this.LRCString.DataPropertyName = "ProfileModifier.AttributeModifier.LRCString";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LRCString.DefaultCellStyle = dataGridViewCellStyle9;
            this.LRCString.HeaderText = "FK";
            this.LRCString.Name = "LRCString";
            this.LRCString.ReadOnly = true;
            this.LRCString.Width = 35;
            // 
            // PHYString
            // 
            this.PHYString.DataPropertyName = "ProfileModifier.AttributeModifier.PHYString";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PHYString.DefaultCellStyle = dataGridViewCellStyle10;
            this.PHYString.HeaderText = "KO";
            this.PHYString.Name = "PHYString";
            this.PHYString.ReadOnly = true;
            this.PHYString.Width = 35;
            // 
            // AWAString
            // 
            this.AWAString.DataPropertyName = "ProfileModifier.AttributeModifier.AWAString";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AWAString.DefaultCellStyle = dataGridViewCellStyle11;
            this.AWAString.HeaderText = "WN";
            this.AWAString.Name = "AWAString";
            this.AWAString.ReadOnly = true;
            this.AWAString.Width = 35;
            // 
            // DETString
            // 
            this.DETString.DataPropertyName = "ProfileModifier.AttributeModifier.DETString";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DETString.DefaultCellStyle = dataGridViewCellStyle12;
            this.DETString.HeaderText = "EH";
            this.DETString.Name = "DETString";
            this.DETString.ReadOnly = true;
            this.DETString.Width = 35;
            // 
            // HasPermissions
            // 
            this.HasPermissions.HeaderText = "B";
            this.HasPermissions.Name = "HasPermissions";
            this.HasPermissions.ReadOnly = true;
            this.HasPermissions.ToolTipText = "Berechtigungen";
            this.HasPermissions.Width = 25;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N1";
            this.weightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.weightDataGridViewTextBoxColumn.HeaderText = "Gewicht";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightDataGridViewTextBoxColumn.Width = 60;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N0";
            this.pointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsDataGridViewTextBoxColumn.Width = 60;
            // 
            // EquipmentManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 426);
            this.Controls.Add(this.dataGridViewEquipment);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "EquipmentManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ausrüstung";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EquipmentManagerForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonEquipmentAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonEquipmentDelete;
        private System.Windows.Forms.DataGridView dataGridViewEquipment;
        private System.Windows.Forms.BindingSource equipmentBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedMaxQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn apDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UseOnce;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Unwieldy;
        private System.Windows.Forms.DataGridViewTextBoxColumn GKString;
        private System.Windows.Forms.DataGridViewTextBoxColumn HitPointsString;
        private System.Windows.Forms.DataGridViewTextBoxColumn CritThresholdString;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGIString;
        private System.Windows.Forms.DataGridViewTextBoxColumn HTHString;
        private System.Windows.Forms.DataGridViewTextBoxColumn LRCString;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHYString;
        private System.Windows.Forms.DataGridViewTextBoxColumn AWAString;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETString;
        private System.Windows.Forms.DataGridViewImageColumn HasPermissions;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
    }
}