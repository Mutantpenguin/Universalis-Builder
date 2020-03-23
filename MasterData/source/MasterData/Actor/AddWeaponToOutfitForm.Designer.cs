namespace Universalis
{
    partial class AddWeaponToOutfitForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddWeaponToOutfitForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewWeapons = new System.Windows.Forms.DataGridView();
            this.weaponBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.filterWK = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterWK = new System.Windows.Forms.ToolStripButton();
            this.filterDamageType = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterDamageType = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.filterType = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterType = new System.Windows.Forms.ToolStripButton();
            this.wKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Strength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedDamage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeaponRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedAF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effectsImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.UseOnce = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Unwieldy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IndirectFire = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeapons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Image = global::Universalis.Properties.Resources.tick;
            this.buttonOk.Location = new System.Drawing.Point(651, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Übernehmen";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::Universalis.Properties.Resources.cross_circle;
            this.buttonCancel.Location = new System.Drawing.Point(3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWeapons
            // 
            this.dataGridViewWeapons.AllowUserToAddRows = false;
            this.dataGridViewWeapons.AllowUserToDeleteRows = false;
            this.dataGridViewWeapons.AllowUserToOrderColumns = true;
            this.dataGridViewWeapons.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewWeapons.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewWeapons.AutoGenerateColumns = false;
            this.dataGridViewWeapons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeapons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wKDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeImageDataGridViewImageColumn,
            this.Strength,
            this.FormattedDamage,
            this.WeaponRange,
            this.MaxRange,
            this.FormattedAF,
            this.FormattedRadius,
            this.effectsImageDataGridViewImageColumn,
            this.UseOnce,
            this.Unwieldy,
            this.IndirectFire,
            this.weightDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn});
            this.dataGridViewWeapons.DataSource = this.weaponBindingSource;
            this.dataGridViewWeapons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWeapons.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewWeapons.Name = "dataGridViewWeapons";
            this.dataGridViewWeapons.ReadOnly = true;
            this.dataGridViewWeapons.RowHeadersVisible = false;
            this.dataGridViewWeapons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWeapons.Size = new System.Drawing.Size(754, 372);
            this.dataGridViewWeapons.TabIndex = 2;
            this.dataGridViewWeapons.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWeapons_CellDoubleClick);
            this.dataGridViewWeapons.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewWeapons_CellToolTipTextNeeded);
            this.dataGridViewWeapons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewWeapons_KeyDown);
            // 
            // weaponBindingSource
            // 
            this.weaponBindingSource.DataSource = typeof(Universalis.Weapon);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.dataGridViewWeapons);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 372);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.buttonOk);
            this.panel3.Controls.Add(this.buttonCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 397);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(754, 29);
            this.panel3.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "WeaponRange";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn1.HeaderText = "R";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ToolTipText = "Reichweite";
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxSearch_KeyDown);
            this.toolStripTextBoxSearch.TextChanged += new System.EventHandler(this.toolStripTextBoxSearch_TextChanged);
            // 
            // filterWK
            // 
            this.filterWK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterWK.Enabled = false;
            this.filterWK.Name = "filterWK";
            this.filterWK.Size = new System.Drawing.Size(75, 25);
            // 
            // checkBoxFilterWK
            // 
            this.checkBoxFilterWK.CheckOnClick = true;
            this.checkBoxFilterWK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBoxFilterWK.Image = global::Universalis.Properties.Resources.ui_check_box_uncheck;
            this.checkBoxFilterWK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterWK.Name = "checkBoxFilterWK";
            this.checkBoxFilterWK.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterWK.ToolTipText = "nach WK filtern";
            this.checkBoxFilterWK.Click += new System.EventHandler(this.checkBoxFilterWK_Click);
            // 
            // filterDamageType
            // 
            this.filterDamageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterDamageType.Enabled = false;
            this.filterDamageType.Name = "filterDamageType";
            this.filterDamageType.Size = new System.Drawing.Size(121, 25);
            // 
            // checkBoxFilterDamageType
            // 
            this.checkBoxFilterDamageType.CheckOnClick = true;
            this.checkBoxFilterDamageType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBoxFilterDamageType.Image = global::Universalis.Properties.Resources.ui_check_box_uncheck;
            this.checkBoxFilterDamageType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterDamageType.Name = "checkBoxFilterDamageType";
            this.checkBoxFilterDamageType.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterDamageType.ToolTipText = "nach Schadenstyp filtern";
            this.checkBoxFilterDamageType.Click += new System.EventHandler(this.checkBoxFilterDamageType_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonClearSearch,
            this.filterWK,
            this.checkBoxFilterWK,
            this.filterDamageType,
            this.checkBoxFilterDamageType,
            this.filterType,
            this.checkBoxFilterType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(754, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonClearSearch
            // 
            this.toolStripButtonClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClearSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearSearch.Image")));
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
            this.filterType.Size = new System.Drawing.Size(121, 25);
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
            // wKDataGridViewTextBoxColumn
            // 
            this.wKDataGridViewTextBoxColumn.DataPropertyName = "WK";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.wKDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.wKDataGridViewTextBoxColumn.HeaderText = "WK";
            this.wKDataGridViewTextBoxColumn.Name = "wKDataGridViewTextBoxColumn";
            this.wKDataGridViewTextBoxColumn.ReadOnly = true;
            this.wKDataGridViewTextBoxColumn.ToolTipText = "Waffenklasse";
            this.wKDataGridViewTextBoxColumn.Width = 30;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 95;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeImageDataGridViewImageColumn
            // 
            this.typeImageDataGridViewImageColumn.DataPropertyName = "DamageTypeImage";
            this.typeImageDataGridViewImageColumn.HeaderText = "Typ";
            this.typeImageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.typeImageDataGridViewImageColumn.Name = "typeImageDataGridViewImageColumn";
            this.typeImageDataGridViewImageColumn.ReadOnly = true;
            this.typeImageDataGridViewImageColumn.Width = 30;
            // 
            // Strength
            // 
            this.Strength.DataPropertyName = "FormattedStrength";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Strength.DefaultCellStyle = dataGridViewCellStyle3;
            this.Strength.HeaderText = "ST";
            this.Strength.Name = "Strength";
            this.Strength.ReadOnly = true;
            this.Strength.ToolTipText = "Stärke";
            this.Strength.Width = 30;
            // 
            // FormattedDamage
            // 
            this.FormattedDamage.DataPropertyName = "FormattedDamage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedDamage.DefaultCellStyle = dataGridViewCellStyle4;
            this.FormattedDamage.HeaderText = "S";
            this.FormattedDamage.Name = "FormattedDamage";
            this.FormattedDamage.ReadOnly = true;
            this.FormattedDamage.ToolTipText = "Schaden";
            this.FormattedDamage.Width = 30;
            // 
            // WeaponRange
            // 
            this.WeaponRange.DataPropertyName = "FormattedRange";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WeaponRange.DefaultCellStyle = dataGridViewCellStyle5;
            this.WeaponRange.HeaderText = "R";
            this.WeaponRange.Name = "WeaponRange";
            this.WeaponRange.ReadOnly = true;
            this.WeaponRange.ToolTipText = "Reichweite";
            this.WeaponRange.Width = 40;
            // 
            // MaxRange
            // 
            this.MaxRange.DataPropertyName = "MaxRange";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MaxRange.DefaultCellStyle = dataGridViewCellStyle6;
            this.MaxRange.HeaderText = "MR";
            this.MaxRange.Name = "MaxRange";
            this.MaxRange.ReadOnly = true;
            this.MaxRange.ToolTipText = "maximale Reichweite";
            this.MaxRange.Width = 40;
            // 
            // FormattedAF
            // 
            this.FormattedAF.DataPropertyName = "FormattedAF";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedAF.DefaultCellStyle = dataGridViewCellStyle7;
            this.FormattedAF.HeaderText = "AF";
            this.FormattedAF.Name = "FormattedAF";
            this.FormattedAF.ReadOnly = true;
            this.FormattedAF.ToolTipText = "Autofeuer";
            this.FormattedAF.Width = 30;
            // 
            // FormattedRadius
            // 
            this.FormattedRadius.DataPropertyName = "FormattedRadius";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedRadius.DefaultCellStyle = dataGridViewCellStyle8;
            this.FormattedRadius.HeaderText = "Radius";
            this.FormattedRadius.Name = "FormattedRadius";
            this.FormattedRadius.ReadOnly = true;
            this.FormattedRadius.ToolTipText = "Radius";
            this.FormattedRadius.Width = 50;
            // 
            // effectsImageDataGridViewImageColumn
            // 
            this.effectsImageDataGridViewImageColumn.DataPropertyName = "EffectsImage";
            this.effectsImageDataGridViewImageColumn.HeaderText = "Effekte";
            this.effectsImageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.effectsImageDataGridViewImageColumn.Name = "effectsImageDataGridViewImageColumn";
            this.effectsImageDataGridViewImageColumn.ReadOnly = true;
            this.effectsImageDataGridViewImageColumn.Width = 60;
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
            this.Unwieldy.HeaderText = "S";
            this.Unwieldy.Name = "Unwieldy";
            this.Unwieldy.ReadOnly = true;
            this.Unwieldy.ToolTipText = "Schwerfällig";
            this.Unwieldy.Width = 30;
            // 
            // IndirectFire
            // 
            this.IndirectFire.DataPropertyName = "IndirectFire";
            this.IndirectFire.HeaderText = "I";
            this.IndirectFire.Name = "IndirectFire";
            this.IndirectFire.ReadOnly = true;
            this.IndirectFire.ToolTipText = "Indirektes Feuer";
            this.IndirectFire.Width = 30;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N1";
            this.weightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.weightDataGridViewTextBoxColumn.HeaderText = "Gewicht";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightDataGridViewTextBoxColumn.Width = 50;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsDataGridViewTextBoxColumn.Width = 50;
            // 
            // AddWeaponToOutfitForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(754, 426);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel3);
            this.Name = "AddWeaponToOutfitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Waffenauswahl";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeapons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewWeapons;
        private System.Windows.Forms.BindingSource weaponBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripComboBox filterWK;
        private System.Windows.Forms.ToolStripButton checkBoxFilterWK;
        private System.Windows.Forms.ToolStripComboBox filterDamageType;
        private System.Windows.Forms.ToolStripButton checkBoxFilterDamageType;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox filterType;
        private System.Windows.Forms.ToolStripButton checkBoxFilterType;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn wKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn typeImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Strength;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedDamage;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeaponRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedAF;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedRadius;
        private System.Windows.Forms.DataGridViewImageColumn effectsImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UseOnce;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Unwieldy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IndirectFire;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
    }
}