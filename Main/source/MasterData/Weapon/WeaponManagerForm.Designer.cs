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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonWeaponAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWeaponDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.filterWeaponClass = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterWeaponClass = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.filterType = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterType = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewWeapons = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.weaponBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.WeaponClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedMaxQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Strength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedSustainedFire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndirectFire = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EffectsImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.UseOnce = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Unwieldy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Reloadable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SpeedString = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeapons)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonWeaponAdd,
            this.toolStripButtonWeaponDelete,
            this.toolStripButtonClearSearch,
            this.filterWeaponClass,
            this.checkBoxFilterWeaponClass,
            this.toolStripButtonCopy,
            this.filterType,
            this.checkBoxFilterType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1044, 25);
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
            // filterWeaponClass
            // 
            this.filterWeaponClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterWeaponClass.DropDownWidth = 100;
            this.filterWeaponClass.Enabled = false;
            this.filterWeaponClass.Name = "filterWeaponClass";
            this.filterWeaponClass.Size = new System.Drawing.Size(75, 25);
            // 
            // checkBoxFilterWeaponClass
            // 
            this.checkBoxFilterWeaponClass.CheckOnClick = true;
            this.checkBoxFilterWeaponClass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBoxFilterWeaponClass.Image = global::Universalis.Properties.Resources.ui_check_box_uncheck;
            this.checkBoxFilterWeaponClass.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkBoxFilterWeaponClass.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterWeaponClass.Name = "checkBoxFilterWeaponClass";
            this.checkBoxFilterWeaponClass.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterWeaponClass.ToolTipText = "nach WK filtern";
            this.checkBoxFilterWeaponClass.Click += new System.EventHandler(this.checkBoxFilterWeaponClass_Click);
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
            this.WeaponClass,
            this.nameDataGridViewTextBoxColumn,
            this.FormattedMaxQuantity,
            this.Strength,
            this.Damage,
            this.FormattedRange,
            this.MaxRange,
            this.FormattedSustainedFire,
            this.FormattedRadius,
            this.IndirectFire,
            this.EffectsImage,
            this.UseOnce,
            this.Unwieldy,
            this.Reloadable,
            this.SpeedString,
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
            this.dataGridViewWeapons.DataSource = this.weaponBindingSource;
            this.dataGridViewWeapons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWeapons.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewWeapons.Name = "dataGridViewWeapons";
            this.dataGridViewWeapons.ReadOnly = true;
            this.dataGridViewWeapons.RowHeadersVisible = false;
            this.dataGridViewWeapons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWeapons.Size = new System.Drawing.Size(1044, 379);
            this.dataGridViewWeapons.TabIndex = 0;
            this.dataGridViewWeapons.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWeapons_CellDoubleClick);
            this.dataGridViewWeapons.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewWeapons_CellFormatting);
            this.dataGridViewWeapons.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewWeapons_CellToolTipTextNeeded);
            this.dataGridViewWeapons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewWeapons_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // weaponBindingSource
            // 
            this.weaponBindingSource.DataSource = typeof(Universalis.Weapon);
            // 
            // WeaponClass
            // 
            this.WeaponClass.DataPropertyName = "Class";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WeaponClass.DefaultCellStyle = dataGridViewCellStyle2;
            this.WeaponClass.HeaderText = "WK";
            this.WeaponClass.Name = "WeaponClass";
            this.WeaponClass.ReadOnly = true;
            this.WeaponClass.Width = 30;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedMaxQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.FormattedMaxQuantity.HeaderText = "Max.";
            this.FormattedMaxQuantity.Name = "FormattedMaxQuantity";
            this.FormattedMaxQuantity.ReadOnly = true;
            this.FormattedMaxQuantity.ToolTipText = "Modell / Gruppe";
            this.FormattedMaxQuantity.Width = 35;
            // 
            // Strength
            // 
            this.Strength.DataPropertyName = "FormattedStrength";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Strength.DefaultCellStyle = dataGridViewCellStyle4;
            this.Strength.HeaderText = "ST";
            this.Strength.Name = "Strength";
            this.Strength.ReadOnly = true;
            this.Strength.ToolTipText = "Stärke";
            this.Strength.Width = 30;
            // 
            // Damage
            // 
            this.Damage.DataPropertyName = "FormattedDamage";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Damage.DefaultCellStyle = dataGridViewCellStyle5;
            this.Damage.HeaderText = "S";
            this.Damage.Name = "Damage";
            this.Damage.ReadOnly = true;
            this.Damage.ToolTipText = "Schaden";
            this.Damage.Width = 30;
            // 
            // FormattedRange
            // 
            this.FormattedRange.DataPropertyName = "FormattedRange";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedRange.DefaultCellStyle = dataGridViewCellStyle6;
            this.FormattedRange.HeaderText = "R";
            this.FormattedRange.Name = "FormattedRange";
            this.FormattedRange.ReadOnly = true;
            this.FormattedRange.ToolTipText = "Reichweite";
            this.FormattedRange.Width = 50;
            // 
            // MaxRange
            // 
            this.MaxRange.DataPropertyName = "MaxRange";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MaxRange.DefaultCellStyle = dataGridViewCellStyle7;
            this.MaxRange.HeaderText = "MR";
            this.MaxRange.Name = "MaxRange";
            this.MaxRange.ReadOnly = true;
            this.MaxRange.ToolTipText = "maximale Reichweite";
            this.MaxRange.Width = 50;
            // 
            // FormattedSustainedFire
            // 
            this.FormattedSustainedFire.DataPropertyName = "FormattedSustainedFire";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedSustainedFire.DefaultCellStyle = dataGridViewCellStyle8;
            this.FormattedSustainedFire.HeaderText = "DF";
            this.FormattedSustainedFire.Name = "FormattedSustainedFire";
            this.FormattedSustainedFire.ReadOnly = true;
            this.FormattedSustainedFire.ToolTipText = "Dauerfeuer";
            this.FormattedSustainedFire.Width = 30;
            // 
            // FormattedRadius
            // 
            this.FormattedRadius.DataPropertyName = "FormattedRadius";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedRadius.DefaultCellStyle = dataGridViewCellStyle9;
            this.FormattedRadius.HeaderText = "Radius";
            this.FormattedRadius.Name = "FormattedRadius";
            this.FormattedRadius.ReadOnly = true;
            this.FormattedRadius.Width = 50;
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
            // EffectsImage
            // 
            this.EffectsImage.DataPropertyName = "EffectsImage";
            this.EffectsImage.HeaderText = "Effekte";
            this.EffectsImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EffectsImage.Name = "EffectsImage";
            this.EffectsImage.ReadOnly = true;
            this.EffectsImage.Width = 60;
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
            // Reloadable
            // 
            this.Reloadable.DataPropertyName = "Reloadable";
            this.Reloadable.HeaderText = "N";
            this.Reloadable.Name = "Reloadable";
            this.Reloadable.ReadOnly = true;
            this.Reloadable.ToolTipText = "Nachladen";
            this.Reloadable.Width = 30;
            // 
            // SpeedString
            // 
            this.SpeedString.DataPropertyName = "ProfileModifier.SpeedString";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SpeedString.DefaultCellStyle = dataGridViewCellStyle10;
            this.SpeedString.HeaderText = "GK";
            this.SpeedString.Name = "SpeedString";
            this.SpeedString.ReadOnly = true;
            this.SpeedString.Width = 35;
            // 
            // HitPointsString
            // 
            this.HitPointsString.DataPropertyName = "ProfileModifier.HitPointsString";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HitPointsString.DefaultCellStyle = dataGridViewCellStyle11;
            this.HitPointsString.HeaderText = "TP";
            this.HitPointsString.Name = "HitPointsString";
            this.HitPointsString.ReadOnly = true;
            this.HitPointsString.Width = 35;
            // 
            // CritThresholdString
            // 
            this.CritThresholdString.DataPropertyName = "ProfileModifier.CritThresholdString";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CritThresholdString.DefaultCellStyle = dataGridViewCellStyle12;
            this.CritThresholdString.HeaderText = "KS";
            this.CritThresholdString.Name = "CritThresholdString";
            this.CritThresholdString.ReadOnly = true;
            this.CritThresholdString.ToolTipText = "Kritische Schwelle";
            this.CritThresholdString.Width = 35;
            // 
            // AGIString
            // 
            this.AGIString.DataPropertyName = "ProfileModifier.AttributeModifier.AGIString";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AGIString.DefaultCellStyle = dataGridViewCellStyle13;
            this.AGIString.HeaderText = "AGI";
            this.AGIString.Name = "AGIString";
            this.AGIString.ReadOnly = true;
            this.AGIString.Width = 35;
            // 
            // HTHString
            // 
            this.HTHString.DataPropertyName = "ProfileModifier.AttributeModifier.HTHString";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HTHString.DefaultCellStyle = dataGridViewCellStyle14;
            this.HTHString.HeaderText = "NK";
            this.HTHString.Name = "HTHString";
            this.HTHString.ReadOnly = true;
            this.HTHString.Width = 35;
            // 
            // LRCString
            // 
            this.LRCString.DataPropertyName = "ProfileModifier.AttributeModifier.LRCString";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LRCString.DefaultCellStyle = dataGridViewCellStyle15;
            this.LRCString.HeaderText = "FK";
            this.LRCString.Name = "LRCString";
            this.LRCString.ReadOnly = true;
            this.LRCString.Width = 35;
            // 
            // PHYString
            // 
            this.PHYString.DataPropertyName = "ProfileModifier.AttributeModifier.PHYString";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PHYString.DefaultCellStyle = dataGridViewCellStyle16;
            this.PHYString.HeaderText = "KO";
            this.PHYString.Name = "PHYString";
            this.PHYString.ReadOnly = true;
            this.PHYString.Width = 35;
            // 
            // AWAString
            // 
            this.AWAString.DataPropertyName = "ProfileModifier.AttributeModifier.AWAString";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AWAString.DefaultCellStyle = dataGridViewCellStyle17;
            this.AWAString.HeaderText = "WN";
            this.AWAString.Name = "AWAString";
            this.AWAString.ReadOnly = true;
            this.AWAString.Width = 35;
            // 
            // DETString
            // 
            this.DETString.DataPropertyName = "ProfileModifier.AttributeModifier.DETString";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DETString.DefaultCellStyle = dataGridViewCellStyle18;
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N1";
            this.weightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle19;
            this.weightDataGridViewTextBoxColumn.HeaderText = "Gewicht";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightDataGridViewTextBoxColumn.Width = 50;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N0";
            this.pointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle20;
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsDataGridViewTextBoxColumn.Width = 50;
            // 
            // WeaponManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 426);
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBindingSource)).EndInit();
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
        private System.Windows.Forms.ToolStripComboBox filterWeaponClass;
        private System.Windows.Forms.ToolStripButton checkBoxFilterWeaponClass;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripComboBox filterType;
        private System.Windows.Forms.ToolStripButton checkBoxFilterType;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeaponClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedMaxQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Strength;
        private System.Windows.Forms.DataGridViewTextBoxColumn Damage;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedSustainedFire;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedRadius;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IndirectFire;
        private System.Windows.Forms.DataGridViewImageColumn EffectsImage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UseOnce;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Unwieldy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Reloadable;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpeedString;
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