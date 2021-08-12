namespace Universalis
{
    partial class ArmorManagerForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonArmorAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonArmorDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUsage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewArmor = new System.Windows.Forms.DataGridView();
            this.armorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypesImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Protection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EffectsImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.SelfSustaining = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GKString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HitPointsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGIString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NKString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KOString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WNString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EHString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArmor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonArmorAdd,
            this.toolStripButtonArmorDelete,
            this.toolStripButtonCopy,
            this.toolStripButtonUsage,
            this.toolStripButtonClearSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(858, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripButtonArmorAdd
            // 
            this.toolStripButtonArmorAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonArmorAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArmorAdd.Image = global::Universalis.Properties.Resources.plus;
            this.toolStripButtonArmorAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonArmorAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArmorAdd.Name = "toolStripButtonArmorAdd";
            this.toolStripButtonArmorAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArmorAdd.ToolTipText = "neue Rüstung";
            this.toolStripButtonArmorAdd.Click += new System.EventHandler(this.toolStripButtonArmorAdd_Click);
            // 
            // toolStripButtonArmorDelete
            // 
            this.toolStripButtonArmorDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonArmorDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArmorDelete.Image = global::Universalis.Properties.Resources.trash;
            this.toolStripButtonArmorDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonArmorDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArmorDelete.Name = "toolStripButtonArmorDelete";
            this.toolStripButtonArmorDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArmorDelete.ToolTipText = "Rüstung löschen";
            this.toolStripButtonArmorDelete.Click += new System.EventHandler(this.toolStripButtonArmorDelete_Click);
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
            this.toolStripButtonCopy.ToolTipText = "Rüstung kopieren";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonUsage
            // 
            this.toolStripButtonUsage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonUsage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUsage.Image = global::Universalis.Properties.Resources.link;
            this.toolStripButtonUsage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonUsage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUsage.Name = "toolStripButtonUsage";
            this.toolStripButtonUsage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUsage.Click += new System.EventHandler(this.toolStripButtonUsage_Click);
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
            this.TypesImage,
            this.Protection,
            this.EffectsImage,
            this.SelfSustaining,
            this.GKString,
            this.HitPointsString,
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
            this.dataGridViewArmor.Name = "dataGridViewArmor";
            this.dataGridViewArmor.ReadOnly = true;
            this.dataGridViewArmor.RowHeadersVisible = false;
            this.dataGridViewArmor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArmor.Size = new System.Drawing.Size(858, 379);
            this.dataGridViewArmor.TabIndex = 0;
            this.dataGridViewArmor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewArmor_CellDoubleClick);
            this.dataGridViewArmor.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewArmor_CellToolTipTextNeeded);
            this.dataGridViewArmor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewArmor_KeyDown);
            // 
            // armorBindingSource
            // 
            this.armorBindingSource.DataSource = typeof(Universalis.Armor);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(858, 22);
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
            // TypesImage
            // 
            this.TypesImage.DataPropertyName = "TypesImage";
            this.TypesImage.HeaderText = "Schadenstypen";
            this.TypesImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.TypesImage.Name = "TypesImage";
            this.TypesImage.ReadOnly = true;
            // 
            // Protection
            // 
            this.Protection.DataPropertyName = "FormattedProtection";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Protection.DefaultCellStyle = dataGridViewCellStyle2;
            this.Protection.HeaderText = "S";
            this.Protection.Name = "Protection";
            this.Protection.ReadOnly = true;
            this.Protection.ToolTipText = "Schutz";
            this.Protection.Width = 30;
            // 
            // EffectsImage
            // 
            this.EffectsImage.DataPropertyName = "EffectsImage";
            this.EffectsImage.HeaderText = "Effekte";
            this.EffectsImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EffectsImage.Name = "EffectsImage";
            this.EffectsImage.ReadOnly = true;
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
            // GKString
            // 
            this.GKString.DataPropertyName = "ProfileModifier.SpeedString";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.GKString.DefaultCellStyle = dataGridViewCellStyle3;
            this.GKString.HeaderText = "GK";
            this.GKString.Name = "GKString";
            this.GKString.ReadOnly = true;
            this.GKString.Width = 35;
            // 
            // HitPointsString
            // 
            this.HitPointsString.DataPropertyName = "ProfileModifier.HitPointsString";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HitPointsString.DefaultCellStyle = dataGridViewCellStyle4;
            this.HitPointsString.HeaderText = "TP";
            this.HitPointsString.Name = "HitPointsString";
            this.HitPointsString.ReadOnly = true;
            this.HitPointsString.Width = 35;
            // 
            // AGIString
            // 
            this.AGIString.DataPropertyName = "ProfileModifier.AttributeModifier.AGIString";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AGIString.DefaultCellStyle = dataGridViewCellStyle5;
            this.AGIString.HeaderText = "AGI";
            this.AGIString.Name = "AGIString";
            this.AGIString.ReadOnly = true;
            this.AGIString.Width = 35;
            // 
            // NKString
            // 
            this.NKString.DataPropertyName = "ProfileModifier.AttributeModifier.NKString";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NKString.DefaultCellStyle = dataGridViewCellStyle6;
            this.NKString.HeaderText = "NK";
            this.NKString.Name = "NKString";
            this.NKString.ReadOnly = true;
            this.NKString.Width = 35;
            // 
            // FKString
            // 
            this.FKString.DataPropertyName = "ProfileModifier.AttributeModifier.FKString";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FKString.DefaultCellStyle = dataGridViewCellStyle7;
            this.FKString.HeaderText = "FK";
            this.FKString.Name = "FKString";
            this.FKString.ReadOnly = true;
            this.FKString.Width = 35;
            // 
            // KOString
            // 
            this.KOString.DataPropertyName = "ProfileModifier.AttributeModifier.KOString";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KOString.DefaultCellStyle = dataGridViewCellStyle8;
            this.KOString.HeaderText = "KO";
            this.KOString.Name = "KOString";
            this.KOString.ReadOnly = true;
            this.KOString.Width = 35;
            // 
            // WNString
            // 
            this.WNString.DataPropertyName = "ProfileModifier.AttributeModifier.WNString";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.WNString.DefaultCellStyle = dataGridViewCellStyle9;
            this.WNString.HeaderText = "WN";
            this.WNString.Name = "WNString";
            this.WNString.ReadOnly = true;
            this.WNString.Width = 35;
            // 
            // EHString
            // 
            this.EHString.DataPropertyName = "ProfileModifier.AttributeModifier.EHString";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EHString.DefaultCellStyle = dataGridViewCellStyle10;
            this.EHString.HeaderText = "EH";
            this.EHString.Name = "EHString";
            this.EHString.ReadOnly = true;
            this.EHString.Width = 35;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N1";
            this.weightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.weightDataGridViewTextBoxColumn.HeaderText = "Gewicht";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightDataGridViewTextBoxColumn.Width = 60;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsDataGridViewTextBoxColumn.Width = 60;
            // 
            // ArmorManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 426);
            this.Controls.Add(this.dataGridViewArmor);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "ArmorManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rüstungen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArmorManagerForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArmor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonArmorDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonArmorAdd;
        private System.Windows.Forms.DataGridView dataGridViewArmor;
        private System.Windows.Forms.BindingSource armorBindingSource;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripButton toolStripButtonUsage;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn TypesImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protection;
        private System.Windows.Forms.DataGridViewImageColumn EffectsImage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelfSustaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn GKString;
        private System.Windows.Forms.DataGridViewTextBoxColumn HitPointsString;
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