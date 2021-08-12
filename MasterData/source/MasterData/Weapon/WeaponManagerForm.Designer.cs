namespace Universalis
{
    partial class WeaponManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonWeaponAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWeaponDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.filterWK = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterWK = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.filterDamageType = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterDamageType = new System.Windows.Forms.ToolStripButton();
            this.filterType = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterType = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUsage = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewWeapons = new System.Windows.Forms.DataGridView();
            this.weaponBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EHString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WNString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KOString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FKString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NKString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGIString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpeedString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reloadable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Unwieldy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UseOnce = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EffectsImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.IndirectFire = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FormattedRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedAF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Strength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DamageTypeImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeapons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonWeaponAdd,
            this.toolStripButtonWeaponDelete,
            this.toolStripButtonClearSearch,
            this.filterWK,
            this.checkBoxFilterWK,
            this.toolStripButtonCopy,
            this.filterDamageType,
            this.checkBoxFilterDamageType,
            this.filterType,
            this.checkBoxFilterType,
            this.toolStripButtonUsage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1019, 25);
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
            // toolStripButtonWeaponAdd
            // 
            this.toolStripButtonWeaponAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonWeaponAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWeaponAdd.Image = global::Universalis.Properties.Resources.plus;
            this.toolStripButtonWeaponAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonWeaponAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWeaponAdd.Name = "toolStripButtonWeaponAdd";
            this.toolStripButtonWeaponAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonWeaponAdd.ToolTipText = "neue Waffe";
            this.toolStripButtonWeaponAdd.Click += new System.EventHandler(this.toolStripButtonWeaponAdd_Click);
            // 
            // toolStripButtonWeaponDelete
            // 
            this.toolStripButtonWeaponDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonWeaponDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWeaponDelete.Image = global::Universalis.Properties.Resources.trash;
            this.toolStripButtonWeaponDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonWeaponDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWeaponDelete.Name = "toolStripButtonWeaponDelete";
            this.toolStripButtonWeaponDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonWeaponDelete.ToolTipText = "Waffe löschen";
            this.toolStripButtonWeaponDelete.Click += new System.EventHandler(this.toolStripButtonWeaponDelete_Click);
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
            // filterWK
            // 
            this.filterWK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterWK.DropDownWidth = 100;
            this.filterWK.Enabled = false;
            this.filterWK.Name = "filterWK";
            this.filterWK.Size = new System.Drawing.Size(75, 25);
            // 
            // checkBoxFilterWK
            // 
            this.checkBoxFilterWK.CheckOnClick = true;
            this.checkBoxFilterWK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBoxFilterWK.Image = global::Universalis.Properties.Resources.ui_check_box_uncheck;
            this.checkBoxFilterWK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkBoxFilterWK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterWK.Name = "checkBoxFilterWK";
            this.checkBoxFilterWK.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterWK.ToolTipText = "nach WK filtern";
            this.checkBoxFilterWK.Click += new System.EventHandler(this.checkBoxFilterWK_Click);
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
            this.toolStripButtonCopy.ToolTipText = "Waffe kopieren";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
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
            this.checkBoxFilterDamageType.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkBoxFilterDamageType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterDamageType.Name = "checkBoxFilterDamageType";
            this.checkBoxFilterDamageType.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterDamageType.ToolTipText = "nach Schadenstyp filtern";
            this.checkBoxFilterDamageType.Click += new System.EventHandler(this.checkBoxFilterDamageType_Click);
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
            this.checkBoxFilterType.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkBoxFilterType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterType.Name = "checkBoxFilterType";
            this.checkBoxFilterType.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterType.ToolTipText = "nach Typ filtern";
            this.checkBoxFilterType.Click += new System.EventHandler(this.checkBoxFilterType_Click);
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
            this.WK,
            this.nameDataGridViewTextBoxColumn,
            this.DamageTypeImage,
            this.Strength,
            this.Damage,
            this.FormattedRange,
            this.MaxRange,
            this.FormattedAF,
            this.FormattedRadius,
            this.IndirectFire,
            this.EffectsImage,
            this.UseOnce,
            this.Unwieldy,
            this.Reloadable,
            this.SpeedString,
            this.AGIString,
            this.NKString,
            this.FKString,
            this.KOString,
            this.WNString,
            this.EHString,
            this.weightDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn});
            this.dataGridViewWeapons.DataSource = this.weaponBindingSource;
            this.dataGridViewWeapons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWeapons.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewWeapons.Name = "dataGridViewWeapons";
            this.dataGridViewWeapons.ReadOnly = true;
            this.dataGridViewWeapons.RowHeadersVisible = false;
            this.dataGridViewWeapons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWeapons.Size = new System.Drawing.Size(1019, 379);
            this.dataGridViewWeapons.TabIndex = 0;
            this.dataGridViewWeapons.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWeapons_CellDoubleClick);
            this.dataGridViewWeapons.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewWeapons_CellToolTipTextNeeded);
            this.dataGridViewWeapons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewWeapons_KeyDown);
            // 
            // weaponBindingSource
            // 
            this.weaponBindingSource.DataSource = typeof(Universalis.Weapon);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1019, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsDataGridViewTextBoxColumn.Width = 50;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N1";
            this.weightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.weightDataGridViewTextBoxColumn.HeaderText = "Gewicht";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightDataGridViewTextBoxColumn.Width = 50;
            // 
            // EHString
            // 
            this.EHString.DataPropertyName = "ProfileModifier.AttributeModifier.EHString";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EHString.DefaultCellStyle = dataGridViewCellStyle15;
            this.EHString.HeaderText = "EH";
            this.EHString.Name = "EHString";
            this.EHString.ReadOnly = true;
            this.EHString.Width = 35;
            // 
            // WNString
            // 
            this.WNString.DataPropertyName = "ProfileModifier.AttributeModifier.WNString";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.WNString.DefaultCellStyle = dataGridViewCellStyle14;
            this.WNString.HeaderText = "WN";
            this.WNString.Name = "WNString";
            this.WNString.ReadOnly = true;
            this.WNString.Width = 35;
            // 
            // KOString
            // 
            this.KOString.DataPropertyName = "ProfileModifier.AttributeModifier.KOString";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KOString.DefaultCellStyle = dataGridViewCellStyle13;
            this.KOString.HeaderText = "KO";
            this.KOString.Name = "KOString";
            this.KOString.ReadOnly = true;
            this.KOString.Width = 35;
            // 
            // FKString
            // 
            this.FKString.DataPropertyName = "ProfileModifier.AttributeModifier.FKString";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FKString.DefaultCellStyle = dataGridViewCellStyle12;
            this.FKString.HeaderText = "FK";
            this.FKString.Name = "FKString";
            this.FKString.ReadOnly = true;
            this.FKString.Width = 35;
            // 
            // NKString
            // 
            this.NKString.DataPropertyName = "ProfileModifier.AttributeModifier.NKString";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NKString.DefaultCellStyle = dataGridViewCellStyle11;
            this.NKString.HeaderText = "NK";
            this.NKString.Name = "NKString";
            this.NKString.ReadOnly = true;
            this.NKString.Width = 35;
            // 
            // AGIString
            // 
            this.AGIString.DataPropertyName = "ProfileModifier.AttributeModifier";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AGIString.DefaultCellStyle = dataGridViewCellStyle10;
            this.AGIString.HeaderText = "AGI";
            this.AGIString.Name = "AGIString";
            this.AGIString.ReadOnly = true;
            this.AGIString.Width = 35;
            // 
            // SpeedString
            // 
            this.SpeedString.DataPropertyName = "ProfileModifier.SpeedString";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SpeedString.DefaultCellStyle = dataGridViewCellStyle9;
            this.SpeedString.HeaderText = "GK";
            this.SpeedString.Name = "SpeedString";
            this.SpeedString.ReadOnly = true;
            this.SpeedString.Width = 35;
            // 
            // Reloadable
            // 
            this.Reloadable.DataPropertyName = "Reloadable";
            this.Reloadable.HeaderText = "N";
            this.Reloadable.Name = "Reloadable";
            this.Reloadable.ReadOnly = true;
            this.Reloadable.ToolTipText = "Nachladen";
            this.Reloadable.Width = 30;
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
            // UseOnce
            // 
            this.UseOnce.DataPropertyName = "UseOnce";
            this.UseOnce.HeaderText = "E";
            this.UseOnce.Name = "UseOnce";
            this.UseOnce.ReadOnly = true;
            this.UseOnce.ToolTipText = "Einmalnutzung";
            this.UseOnce.Width = 30;
            // 
            // EffectsImage
            // 
            this.EffectsImage.DataPropertyName = "EffectsImage";
            this.EffectsImage.HeaderText = "Effekte";
            this.EffectsImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EffectsImage.Name = "EffectsImage";
            this.EffectsImage.ReadOnly = true;
            this.EffectsImage.Width = 60;
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
            // FormattedRadius
            // 
            this.FormattedRadius.DataPropertyName = "FormattedRadius";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedRadius.DefaultCellStyle = dataGridViewCellStyle8;
            this.FormattedRadius.HeaderText = "Radius";
            this.FormattedRadius.Name = "FormattedRadius";
            this.FormattedRadius.ReadOnly = true;
            this.FormattedRadius.Width = 50;
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
            // FormattedRange
            // 
            this.FormattedRange.DataPropertyName = "FormattedRange";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedRange.DefaultCellStyle = dataGridViewCellStyle5;
            this.FormattedRange.HeaderText = "R";
            this.FormattedRange.Name = "FormattedRange";
            this.FormattedRange.ReadOnly = true;
            this.FormattedRange.ToolTipText = "Reichweite";
            this.FormattedRange.Width = 40;
            // 
            // Damage
            // 
            this.Damage.DataPropertyName = "FormattedDamage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Damage.DefaultCellStyle = dataGridViewCellStyle4;
            this.Damage.HeaderText = "S";
            this.Damage.Name = "Damage";
            this.Damage.ReadOnly = true;
            this.Damage.ToolTipText = "Schaden";
            this.Damage.Width = 30;
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
            // DamageTypeImage
            // 
            this.DamageTypeImage.DataPropertyName = "DamageTypeImage";
            this.DamageTypeImage.HeaderText = "Typ";
            this.DamageTypeImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DamageTypeImage.Name = "DamageTypeImage";
            this.DamageTypeImage.ReadOnly = true;
            this.DamageTypeImage.Width = 30;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // WK
            // 
            this.WK.DataPropertyName = "WK";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WK.DefaultCellStyle = dataGridViewCellStyle2;
            this.WK.HeaderText = "WK";
            this.WK.Name = "WK";
            this.WK.ReadOnly = true;
            this.WK.Width = 30;
            // 
            // WeaponManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 426);
            this.Controls.Add(this.dataGridViewWeapons);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "WeaponManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Waffen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WeaponManagerForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeapons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonWeaponAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonWeaponDelete;
        private System.Windows.Forms.DataGridView dataGridViewWeapons;
        private System.Windows.Forms.BindingSource weaponBindingSource;
        private System.Windows.Forms.ToolStripComboBox filterWK;
        private System.Windows.Forms.ToolStripButton checkBoxFilterWK;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripComboBox filterDamageType;
        private System.Windows.Forms.ToolStripButton checkBoxFilterDamageType;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripComboBox filterType;
        private System.Windows.Forms.ToolStripButton checkBoxFilterType;
        private System.Windows.Forms.ToolStripButton toolStripButtonUsage;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn WK;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn DamageTypeImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Strength;
        private System.Windows.Forms.DataGridViewTextBoxColumn Damage;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedAF;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedRadius;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IndirectFire;
        private System.Windows.Forms.DataGridViewImageColumn EffectsImage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UseOnce;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Unwieldy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Reloadable;
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