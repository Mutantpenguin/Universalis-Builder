namespace Universalis
{
    partial class AddArmorToActorForm
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
            this.dataGridViewArmor = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.armorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelfSustaining = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.typesImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.protectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effectsImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.SpeedString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGIString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NKString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KOString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WNString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EHString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArmor)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.armorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Image = global::Universalis.Properties.Resources.tick;
            this.buttonOk.Location = new System.Drawing.Point(693, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 26);
            this.buttonOk.TabIndex = 2;
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
            this.buttonCancel.Size = new System.Drawing.Size(100, 26);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewArmor
            // 
            this.dataGridViewArmor.AllowUserToAddRows = false;
            this.dataGridViewArmor.AllowUserToDeleteRows = false;
            this.dataGridViewArmor.AllowUserToOrderColumns = true;
            this.dataGridViewArmor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewArmor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewArmor.AutoGenerateColumns = false;
            this.dataGridViewArmor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArmor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.SelfSustaining,
            this.typesImageDataGridViewImageColumn,
            this.protectionDataGridViewTextBoxColumn,
            this.effectsImageDataGridViewImageColumn,
            this.SpeedString,
            this.AGIString,
            this.NKString,
            this.FKString,
            this.KOString,
            this.WNString,
            this.EHString,
            this.weightDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn});
            this.dataGridViewArmor.DataSource = this.armorBindingSource;
            this.dataGridViewArmor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewArmor.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewArmor.MultiSelect = false;
            this.dataGridViewArmor.Name = "dataGridViewArmor";
            this.dataGridViewArmor.ReadOnly = true;
            this.dataGridViewArmor.RowHeadersVisible = false;
            this.dataGridViewArmor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArmor.Size = new System.Drawing.Size(796, 369);
            this.dataGridViewArmor.TabIndex = 3;
            this.dataGridViewArmor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewArmor_CellDoubleClick);
            this.dataGridViewArmor.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewArmor_CellToolTipTextNeeded);
            this.dataGridViewArmor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewArmor_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonClearSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(796, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.buttonOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 32);
            this.panel2.TabIndex = 2;
            // 
            // armorBindingSource
            // 
            this.armorBindingSource.DataSource = typeof(Universalis.Armor);
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
            // SelfSustaining
            // 
            this.SelfSustaining.DataPropertyName = "SelfSustaining";
            this.SelfSustaining.HeaderText = "ST";
            this.SelfSustaining.Name = "SelfSustaining";
            this.SelfSustaining.ReadOnly = true;
            this.SelfSustaining.ToolTipText = "Selbsttragend";
            this.SelfSustaining.Width = 30;
            // 
            // typesImageDataGridViewImageColumn
            // 
            this.typesImageDataGridViewImageColumn.DataPropertyName = "TypesImage";
            this.typesImageDataGridViewImageColumn.HeaderText = "Schadenstypen";
            this.typesImageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.typesImageDataGridViewImageColumn.Name = "typesImageDataGridViewImageColumn";
            this.typesImageDataGridViewImageColumn.ReadOnly = true;
            // 
            // protectionDataGridViewTextBoxColumn
            // 
            this.protectionDataGridViewTextBoxColumn.DataPropertyName = "FormattedProtection";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.protectionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.protectionDataGridViewTextBoxColumn.HeaderText = "S";
            this.protectionDataGridViewTextBoxColumn.Name = "protectionDataGridViewTextBoxColumn";
            this.protectionDataGridViewTextBoxColumn.ReadOnly = true;
            this.protectionDataGridViewTextBoxColumn.ToolTipText = "Schutz";
            this.protectionDataGridViewTextBoxColumn.Width = 30;
            // 
            // effectsImageDataGridViewImageColumn
            // 
            this.effectsImageDataGridViewImageColumn.DataPropertyName = "EffectsImage";
            this.effectsImageDataGridViewImageColumn.HeaderText = "Effekte";
            this.effectsImageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.effectsImageDataGridViewImageColumn.Name = "effectsImageDataGridViewImageColumn";
            this.effectsImageDataGridViewImageColumn.ReadOnly = true;
            // 
            // SpeedString
            // 
            this.SpeedString.DataPropertyName = "ProfileModifier.SpeedString";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SpeedString.DefaultCellStyle = dataGridViewCellStyle3;
            this.SpeedString.HeaderText = "GK";
            this.SpeedString.Name = "SpeedString";
            this.SpeedString.ReadOnly = true;
            this.SpeedString.Width = 35;
            // 
            // AGIString
            // 
            this.AGIString.DataPropertyName = "ProfileModifier.AttributeModifier.AGIString";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AGIString.DefaultCellStyle = dataGridViewCellStyle4;
            this.AGIString.HeaderText = "AGI";
            this.AGIString.Name = "AGIString";
            this.AGIString.ReadOnly = true;
            this.AGIString.Width = 35;
            // 
            // NKString
            // 
            this.NKString.DataPropertyName = "ProfileModifier.AttributeModifier.NKString";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NKString.DefaultCellStyle = dataGridViewCellStyle5;
            this.NKString.HeaderText = "NK";
            this.NKString.Name = "NKString";
            this.NKString.ReadOnly = true;
            this.NKString.Width = 35;
            // 
            // FKString
            // 
            this.FKString.DataPropertyName = "ProfileModifier.AttributeModifier.FKString";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FKString.DefaultCellStyle = dataGridViewCellStyle6;
            this.FKString.HeaderText = "FK";
            this.FKString.Name = "FKString";
            this.FKString.ReadOnly = true;
            this.FKString.Width = 35;
            // 
            // KOString
            // 
            this.KOString.DataPropertyName = "ProfileModifier.AttributeModifier.KOString";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KOString.DefaultCellStyle = dataGridViewCellStyle7;
            this.KOString.HeaderText = "KO";
            this.KOString.Name = "KOString";
            this.KOString.ReadOnly = true;
            this.KOString.Width = 35;
            // 
            // WNString
            // 
            this.WNString.DataPropertyName = "ProfileModifier.AttributeModifier.WNString";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.WNString.DefaultCellStyle = dataGridViewCellStyle8;
            this.WNString.HeaderText = "WN";
            this.WNString.Name = "WNString";
            this.WNString.ReadOnly = true;
            this.WNString.Width = 35;
            // 
            // EHString
            // 
            this.EHString.DataPropertyName = "ProfileModifier.AttributeModifier.EHString";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EHString.DefaultCellStyle = dataGridViewCellStyle9;
            this.EHString.HeaderText = "EH";
            this.EHString.Name = "EHString";
            this.EHString.ReadOnly = true;
            this.EHString.Width = 35;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N1";
            dataGridViewCellStyle10.NullValue = null;
            this.weightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.weightDataGridViewTextBoxColumn.HeaderText = "Gewicht";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightDataGridViewTextBoxColumn.Width = 60;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsDataGridViewTextBoxColumn.Width = 60;
            // 
            // AddArmorToActorForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(796, 426);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewArmor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AddArmorToActorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rüstungsauswahl";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArmor)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.armorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewArmor;
        private System.Windows.Forms.BindingSource armorBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelfSustaining;
        private System.Windows.Forms.DataGridViewImageColumn typesImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn protectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn effectsImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpeedString;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGIString;
        private System.Windows.Forms.DataGridViewTextBoxColumn NKString;
        private System.Windows.Forms.DataGridViewTextBoxColumn FKString;
        private System.Windows.Forms.DataGridViewTextBoxColumn KOString;
        private System.Windows.Forms.DataGridViewTextBoxColumn WNString;
        private System.Windows.Forms.DataGridViewTextBoxColumn EHString;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
    }
}