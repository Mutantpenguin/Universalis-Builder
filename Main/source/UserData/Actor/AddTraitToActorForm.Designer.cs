namespace Universalis
{
    partial class AddTraitToActorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemPositives = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNegatives = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNeutrals = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.dataGridViewTraits = new System.Windows.Forms.DataGridView();
            this.traitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedMaxQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseOnce = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SpeedString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HitPointsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CritThresholdString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGIString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HTHString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LRCString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHYString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AWAString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PointsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxFilterTraitGroup = new System.Windows.Forms.ToolStripButton();
            this.filterGroup = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonClearSearch,
            this.filterGroup,
            this.checkBoxFilterTraitGroup,
            this.toolStripDropDownButtonFilter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripDropDownButtonFilter
            // 
            this.toolStripDropDownButtonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemPositives,
            this.toolStripMenuItemNegatives,
            this.toolStripMenuItemNeutrals});
            this.toolStripDropDownButtonFilter.Image = global::Universalis.Properties.Resources.funnel;
            this.toolStripDropDownButtonFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButtonFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonFilter.Name = "toolStripDropDownButtonFilter";
            this.toolStripDropDownButtonFilter.Size = new System.Drawing.Size(31, 22);
            this.toolStripDropDownButtonFilter.ToolTipText = "Nach positiven/negativen Eigenschaften filtern";
            // 
            // toolStripMenuItemPositives
            // 
            this.toolStripMenuItemPositives.Checked = true;
            this.toolStripMenuItemPositives.CheckOnClick = true;
            this.toolStripMenuItemPositives.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemPositives.Name = "toolStripMenuItemPositives";
            this.toolStripMenuItemPositives.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItemPositives.Text = "zeige Positive";
            this.toolStripMenuItemPositives.CheckedChanged += new System.EventHandler(this.toolStripMenuItemPositives_CheckedChanged);
            // 
            // toolStripMenuItemNegatives
            // 
            this.toolStripMenuItemNegatives.Checked = true;
            this.toolStripMenuItemNegatives.CheckOnClick = true;
            this.toolStripMenuItemNegatives.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemNegatives.Name = "toolStripMenuItemNegatives";
            this.toolStripMenuItemNegatives.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItemNegatives.Text = "zeige Negative";
            this.toolStripMenuItemNegatives.CheckedChanged += new System.EventHandler(this.toolStripMenuItemNegatives_CheckedChanged);
            // 
            // toolStripMenuItemNeutrals
            // 
            this.toolStripMenuItemNeutrals.Checked = true;
            this.toolStripMenuItemNeutrals.CheckOnClick = true;
            this.toolStripMenuItemNeutrals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemNeutrals.Name = "toolStripMenuItemNeutrals";
            this.toolStripMenuItemNeutrals.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItemNeutrals.Text = "zeige Neutrale";
            this.toolStripMenuItemNeutrals.CheckedChanged += new System.EventHandler(this.toolStripMenuItemNeutrals_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.buttonOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 32);
            this.panel2.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::Universalis.Properties.Resources.cross_circle;
            this.buttonCancel.Location = new System.Drawing.Point(3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 26);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Image = global::Universalis.Properties.Resources.tick;
            this.buttonOk.Location = new System.Drawing.Point(781, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 26);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Übernehmen";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // dataGridViewTraits
            // 
            this.dataGridViewTraits.AllowUserToAddRows = false;
            this.dataGridViewTraits.AllowUserToDeleteRows = false;
            this.dataGridViewTraits.AllowUserToOrderColumns = true;
            this.dataGridViewTraits.AllowUserToResizeRows = false;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTraits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridViewTraits.AutoGenerateColumns = false;
            this.dataGridViewTraits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTraits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.groupDataGridViewTextBoxColumn,
            this.FormattedMaxQuantity,
            this.MaxLevel,
            this.FormattedAP,
            this.UseOnce,
            this.SpeedString,
            this.HitPointsString,
            this.CritThresholdString,
            this.AGIString,
            this.HTHString,
            this.LRCString,
            this.PHYString,
            this.AWAString,
            this.DETString,
            this.PointsString});
            this.dataGridViewTraits.DataSource = this.traitBindingSource;
            this.dataGridViewTraits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTraits.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewTraits.Name = "dataGridViewTraits";
            this.dataGridViewTraits.ReadOnly = true;
            this.dataGridViewTraits.RowHeadersVisible = false;
            this.dataGridViewTraits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTraits.Size = new System.Drawing.Size(884, 369);
            this.dataGridViewTraits.TabIndex = 4;
            this.dataGridViewTraits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTraits_CellDoubleClick);
            this.dataGridViewTraits.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTraits_CellFormatting);
            this.dataGridViewTraits.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewTraits_CellToolTipTextNeeded);
            this.dataGridViewTraits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewTraits_KeyDown);
            // 
            // traitBindingSource
            // 
            this.traitBindingSource.DataSource = typeof(Universalis.Trait);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "Group";
            this.groupDataGridViewTextBoxColumn.HeaderText = "Gruppe";
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            this.groupDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormattedMaxQuantity
            // 
            this.FormattedMaxQuantity.DataPropertyName = "FormattedMaxQuantity";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedMaxQuantity.DefaultCellStyle = dataGridViewCellStyle30;
            this.FormattedMaxQuantity.HeaderText = "Max.";
            this.FormattedMaxQuantity.Name = "FormattedMaxQuantity";
            this.FormattedMaxQuantity.ReadOnly = true;
            this.FormattedMaxQuantity.ToolTipText = "Gruppe";
            this.FormattedMaxQuantity.Width = 35;
            // 
            // MaxLevel
            // 
            this.MaxLevel.DataPropertyName = "MaxLevel";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MaxLevel.DefaultCellStyle = dataGridViewCellStyle31;
            this.MaxLevel.HeaderText = "Max. LVL";
            this.MaxLevel.Name = "MaxLevel";
            this.MaxLevel.ReadOnly = true;
            this.MaxLevel.Width = 75;
            // 
            // FormattedAP
            // 
            this.FormattedAP.DataPropertyName = "FormattedAP";
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FormattedAP.DefaultCellStyle = dataGridViewCellStyle32;
            this.FormattedAP.HeaderText = "AP";
            this.FormattedAP.Name = "FormattedAP";
            this.FormattedAP.ReadOnly = true;
            this.FormattedAP.ToolTipText = "Aktionspunkte";
            this.FormattedAP.Width = 35;
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
            // SpeedString
            // 
            this.SpeedString.DataPropertyName = "ProfileModifier.SpeedString";
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SpeedString.DefaultCellStyle = dataGridViewCellStyle33;
            this.SpeedString.HeaderText = "GK";
            this.SpeedString.Name = "SpeedString";
            this.SpeedString.ReadOnly = true;
            this.SpeedString.ToolTipText = "Geschwindigkeit";
            this.SpeedString.Width = 35;
            // 
            // HitPointsString
            // 
            this.HitPointsString.DataPropertyName = "ProfileModifier.HitPointsString";
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HitPointsString.DefaultCellStyle = dataGridViewCellStyle34;
            this.HitPointsString.HeaderText = "TP";
            this.HitPointsString.Name = "HitPointsString";
            this.HitPointsString.ReadOnly = true;
            this.HitPointsString.ToolTipText = "Trefferpunkte";
            this.HitPointsString.Width = 35;
            // 
            // CritThresholdString
            // 
            this.CritThresholdString.DataPropertyName = "ProfileModifier.CritThresholdString";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CritThresholdString.DefaultCellStyle = dataGridViewCellStyle35;
            this.CritThresholdString.HeaderText = "KS";
            this.CritThresholdString.Name = "CritThresholdString";
            this.CritThresholdString.ReadOnly = true;
            this.CritThresholdString.ToolTipText = "Kritische Schwelle";
            this.CritThresholdString.Width = 35;
            // 
            // AGIString
            // 
            this.AGIString.DataPropertyName = "ProfileModifier.AttributeModifier.AGIString";
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AGIString.DefaultCellStyle = dataGridViewCellStyle36;
            this.AGIString.HeaderText = "AGI";
            this.AGIString.Name = "AGIString";
            this.AGIString.ReadOnly = true;
            this.AGIString.ToolTipText = "Agilität";
            this.AGIString.Width = 35;
            // 
            // HTHString
            // 
            this.HTHString.DataPropertyName = "ProfileModifier.AttributeModifier.HTHString";
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HTHString.DefaultCellStyle = dataGridViewCellStyle37;
            this.HTHString.HeaderText = "NK";
            this.HTHString.Name = "HTHString";
            this.HTHString.ReadOnly = true;
            this.HTHString.ToolTipText = "Nahkampf";
            this.HTHString.Width = 35;
            // 
            // LRCString
            // 
            this.LRCString.DataPropertyName = "ProfileModifier.AttributeModifier.LRCString";
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LRCString.DefaultCellStyle = dataGridViewCellStyle38;
            this.LRCString.HeaderText = "FK";
            this.LRCString.Name = "LRCString";
            this.LRCString.ReadOnly = true;
            this.LRCString.ToolTipText = "Fernkampf";
            this.LRCString.Width = 35;
            // 
            // PHYString
            // 
            this.PHYString.DataPropertyName = "ProfileModifier.AttributeModifier.PHYString";
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PHYString.DefaultCellStyle = dataGridViewCellStyle39;
            this.PHYString.HeaderText = "KO";
            this.PHYString.Name = "PHYString";
            this.PHYString.ReadOnly = true;
            this.PHYString.ToolTipText = "Konstitution";
            this.PHYString.Width = 35;
            // 
            // AWAString
            // 
            this.AWAString.DataPropertyName = "ProfileModifier.AttributeModifier.AWAString";
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AWAString.DefaultCellStyle = dataGridViewCellStyle40;
            this.AWAString.HeaderText = "WN";
            this.AWAString.Name = "AWAString";
            this.AWAString.ReadOnly = true;
            this.AWAString.ToolTipText = "Wahrnehmung";
            this.AWAString.Width = 35;
            // 
            // DETString
            // 
            this.DETString.DataPropertyName = "ProfileModifier.AttributeModifier.DETString";
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DETString.DefaultCellStyle = dataGridViewCellStyle41;
            this.DETString.HeaderText = "EH";
            this.DETString.Name = "DETString";
            this.DETString.ReadOnly = true;
            this.DETString.ToolTipText = "Entschlossenheit";
            this.DETString.Width = 35;
            // 
            // PointsString
            // 
            this.PointsString.DataPropertyName = "PointsString";
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PointsString.DefaultCellStyle = dataGridViewCellStyle42;
            this.PointsString.HeaderText = "Punkte";
            this.PointsString.Name = "PointsString";
            this.PointsString.ReadOnly = true;
            this.PointsString.Width = 80;
            // 
            // checkBoxFilterTraitGroup
            // 
            this.checkBoxFilterTraitGroup.CheckOnClick = true;
            this.checkBoxFilterTraitGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBoxFilterTraitGroup.Image = global::Universalis.Properties.Resources.ui_check_box_uncheck;
            this.checkBoxFilterTraitGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkBoxFilterTraitGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterTraitGroup.Name = "checkBoxFilterTraitGroup";
            this.checkBoxFilterTraitGroup.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterTraitGroup.ToolTipText = "nach WK filtern";
            this.checkBoxFilterTraitGroup.Click += new System.EventHandler(this.checkBoxFilterTraitGroup_Click);
            // 
            // filterGroup
            // 
            this.filterGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterGroup.Enabled = false;
            this.filterGroup.Name = "filterGroup";
            this.filterGroup.Size = new System.Drawing.Size(121, 25);
            // 
            // AddTraitToActorForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(884, 426);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewTraits);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AddTraitToActorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Eigenschaftsauswahl";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traitBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewTraits;
        private System.Windows.Forms.BindingSource traitBindingSource;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFilter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPositives;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNegatives;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNeutrals;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedMaxQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedAP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UseOnce;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpeedString;
        private System.Windows.Forms.DataGridViewTextBoxColumn HitPointsString;
        private System.Windows.Forms.DataGridViewTextBoxColumn CritThresholdString;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGIString;
        private System.Windows.Forms.DataGridViewTextBoxColumn HTHString;
        private System.Windows.Forms.DataGridViewTextBoxColumn LRCString;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHYString;
        private System.Windows.Forms.DataGridViewTextBoxColumn AWAString;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETString;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointsString;
        private System.Windows.Forms.ToolStripComboBox filterGroup;
        private System.Windows.Forms.ToolStripButton checkBoxFilterTraitGroup;
    }
}