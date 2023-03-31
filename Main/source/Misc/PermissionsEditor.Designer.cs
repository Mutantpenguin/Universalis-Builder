
namespace Universalis
{
    partial class PermissionsEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PermissionsEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripFactions = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxFaction = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFactionAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFactionDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dataGridViewFaction = new System.Windows.Forms.DataGridView();
            this.iconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripArchetypes = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxArchetype = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonArchetypeAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonArchetypeDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripType = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSize = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripMovementType = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxMovementType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.dataGridViewArchetype = new System.Windows.Forms.DataGridView();
            this.archetypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkedListBoxType = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxSize = new System.Windows.Forms.CheckedListBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.checkedListBoxMovementType = new System.Windows.Forms.CheckedListBox();
            this.permissionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripFactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factionsBindingSource)).BeginInit();
            this.toolStripArchetypes.SuspendLayout();
            this.toolStripType.SuspendLayout();
            this.toolStripSize.SuspendLayout();
            this.toolStripMovementType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchetype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archetypesBindingSource)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripFactions
            // 
            this.toolStripFactions.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripFactions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFactions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxFaction,
            this.toolStripButtonFactionAdd,
            this.toolStripButtonFactionDelete,
            this.toolStripLabel1});
            this.toolStripFactions.Location = new System.Drawing.Point(0, 0);
            this.toolStripFactions.Name = "toolStripFactions";
            this.toolStripFactions.Size = new System.Drawing.Size(448, 25);
            this.toolStripFactions.TabIndex = 0;
            this.toolStripFactions.Text = "toolStrip1";
            // 
            // toolStripComboBoxFaction
            // 
            this.toolStripComboBoxFaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxFaction.Name = "toolStripComboBoxFaction";
            this.toolStripComboBoxFaction.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripButtonFactionAdd
            // 
            this.toolStripButtonFactionAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonFactionAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFactionAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFactionAdd.Image")));
            this.toolStripButtonFactionAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonFactionAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFactionAdd.Name = "toolStripButtonFactionAdd";
            this.toolStripButtonFactionAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFactionAdd.Text = "toolStripButton1";
            this.toolStripButtonFactionAdd.Visible = false;
            this.toolStripButtonFactionAdd.Click += new System.EventHandler(this.toolStripButtonFactionAdd_Click);
            // 
            // toolStripButtonFactionDelete
            // 
            this.toolStripButtonFactionDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonFactionDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFactionDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFactionDelete.Image")));
            this.toolStripButtonFactionDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonFactionDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFactionDelete.Name = "toolStripButtonFactionDelete";
            this.toolStripButtonFactionDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFactionDelete.Text = "toolStripButton2";
            this.toolStripButtonFactionDelete.Visible = false;
            this.toolStripButtonFactionDelete.Click += new System.EventHandler(this.toolStripButtonFactionDelete_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel1.Text = "Fraktionen";
            // 
            // dataGridViewFaction
            // 
            this.dataGridViewFaction.AllowUserToAddRows = false;
            this.dataGridViewFaction.AllowUserToDeleteRows = false;
            this.dataGridViewFaction.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewFaction.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFaction.AutoGenerateColumns = false;
            this.dataGridViewFaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFaction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iconDataGridViewImageColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridViewFaction.DataSource = this.factionsBindingSource;
            this.dataGridViewFaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewFaction.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewFaction.MultiSelect = false;
            this.dataGridViewFaction.Name = "dataGridViewFaction";
            this.dataGridViewFaction.ReadOnly = true;
            this.dataGridViewFaction.RowHeadersVisible = false;
            this.dataGridViewFaction.RowTemplate.Height = 40;
            this.dataGridViewFaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFaction.Size = new System.Drawing.Size(448, 169);
            this.dataGridViewFaction.TabIndex = 3;
            this.dataGridViewFaction.Visible = false;
            // 
            // iconDataGridViewImageColumn
            // 
            this.iconDataGridViewImageColumn.DataPropertyName = "Icon";
            this.iconDataGridViewImageColumn.HeaderText = "Icon";
            this.iconDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.iconDataGridViewImageColumn.Name = "iconDataGridViewImageColumn";
            this.iconDataGridViewImageColumn.ReadOnly = true;
            this.iconDataGridViewImageColumn.Width = 40;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 206.7227F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factionsBindingSource
            // 
            this.factionsBindingSource.DataSource = typeof(Universalis.Faction);
            // 
            // toolStripArchetypes
            // 
            this.toolStripArchetypes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripArchetypes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripArchetypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxArchetype,
            this.toolStripButtonArchetypeAdd,
            this.toolStripButtonArchetypeDelete,
            this.toolStripLabel4});
            this.toolStripArchetypes.Location = new System.Drawing.Point(0, 194);
            this.toolStripArchetypes.Name = "toolStripArchetypes";
            this.toolStripArchetypes.Size = new System.Drawing.Size(448, 25);
            this.toolStripArchetypes.TabIndex = 2;
            this.toolStripArchetypes.Text = "toolStrip4";
            // 
            // toolStripComboBoxArchetype
            // 
            this.toolStripComboBoxArchetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxArchetype.Name = "toolStripComboBoxArchetype";
            this.toolStripComboBoxArchetype.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripButtonArchetypeAdd
            // 
            this.toolStripButtonArchetypeAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonArchetypeAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArchetypeAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonArchetypeAdd.Image")));
            this.toolStripButtonArchetypeAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonArchetypeAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArchetypeAdd.Name = "toolStripButtonArchetypeAdd";
            this.toolStripButtonArchetypeAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArchetypeAdd.Text = "toolStripButton3";
            this.toolStripButtonArchetypeAdd.Visible = false;
            this.toolStripButtonArchetypeAdd.Click += new System.EventHandler(this.toolStripButtonArchetypeAdd_Click);
            // 
            // toolStripButtonArchetypeDelete
            // 
            this.toolStripButtonArchetypeDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonArchetypeDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArchetypeDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonArchetypeDelete.Image")));
            this.toolStripButtonArchetypeDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonArchetypeDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArchetypeDelete.Name = "toolStripButtonArchetypeDelete";
            this.toolStripButtonArchetypeDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArchetypeDelete.Text = "toolStripButton4";
            this.toolStripButtonArchetypeDelete.Visible = false;
            this.toolStripButtonArchetypeDelete.Click += new System.EventHandler(this.toolStripButtonArchetypeDelete_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel4.Text = "Archetypen";
            // 
            // toolStripType
            // 
            this.toolStripType.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripType.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxType,
            this.toolStripLabel5});
            this.toolStripType.Location = new System.Drawing.Point(0, 388);
            this.toolStripType.Name = "toolStripType";
            this.toolStripType.Size = new System.Drawing.Size(448, 25);
            this.toolStripType.TabIndex = 3;
            this.toolStripType.Text = "toolStrip5";
            // 
            // toolStripComboBoxType
            // 
            this.toolStripComboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxType.Name = "toolStripComboBoxType";
            this.toolStripComboBoxType.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(25, 22);
            this.toolStripLabel5.Text = "Typ";
            // 
            // toolStripSize
            // 
            this.toolStripSize.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripSize.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSize.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxSize,
            this.toolStripLabel6});
            this.toolStripSize.Location = new System.Drawing.Point(0, 492);
            this.toolStripSize.Name = "toolStripSize";
            this.toolStripSize.Size = new System.Drawing.Size(448, 25);
            this.toolStripSize.TabIndex = 4;
            this.toolStripSize.Text = "toolStrip6";
            // 
            // toolStripComboBoxSize
            // 
            this.toolStripComboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxSize.Name = "toolStripComboBoxSize";
            this.toolStripComboBoxSize.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel6.Text = "Größe";
            // 
            // toolStripMovementType
            // 
            this.toolStripMovementType.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMovementType.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMovementType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxMovementType,
            this.toolStripLabel7});
            this.toolStripMovementType.Location = new System.Drawing.Point(0, 596);
            this.toolStripMovementType.Name = "toolStripMovementType";
            this.toolStripMovementType.Size = new System.Drawing.Size(448, 25);
            this.toolStripMovementType.TabIndex = 5;
            this.toolStripMovementType.Text = "toolStrip7";
            // 
            // toolStripComboBoxMovementType
            // 
            this.toolStripComboBoxMovementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxMovementType.Name = "toolStripComboBoxMovementType";
            this.toolStripComboBoxMovementType.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(82, 22);
            this.toolStripLabel7.Text = "Bewegungsart";
            // 
            // dataGridViewArchetype
            // 
            this.dataGridViewArchetype.AllowUserToAddRows = false;
            this.dataGridViewArchetype.AllowUserToDeleteRows = false;
            this.dataGridViewArchetype.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewArchetype.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewArchetype.AutoGenerateColumns = false;
            this.dataGridViewArchetype.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArchetype.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn2});
            this.dataGridViewArchetype.DataSource = this.archetypesBindingSource;
            this.dataGridViewArchetype.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewArchetype.Location = new System.Drawing.Point(0, 219);
            this.dataGridViewArchetype.MultiSelect = false;
            this.dataGridViewArchetype.Name = "dataGridViewArchetype";
            this.dataGridViewArchetype.ReadOnly = true;
            this.dataGridViewArchetype.RowHeadersVisible = false;
            this.dataGridViewArchetype.RowTemplate.Height = 40;
            this.dataGridViewArchetype.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArchetype.Size = new System.Drawing.Size(448, 169);
            this.dataGridViewArchetype.TabIndex = 3;
            this.dataGridViewArchetype.Visible = false;
            this.dataGridViewArchetype.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewArchetype_CellFormatting);
            // 
            // archetypesBindingSource
            // 
            this.archetypesBindingSource.DataSource = typeof(Universalis.Archetype);
            // 
            // checkedListBoxType
            // 
            this.checkedListBoxType.CheckOnClick = true;
            this.checkedListBoxType.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBoxType.FormattingEnabled = true;
            this.checkedListBoxType.Location = new System.Drawing.Point(0, 413);
            this.checkedListBoxType.Name = "checkedListBoxType";
            this.checkedListBoxType.Size = new System.Drawing.Size(448, 79);
            this.checkedListBoxType.TabIndex = 5;
            this.checkedListBoxType.Visible = false;
            // 
            // checkedListBoxSize
            // 
            this.checkedListBoxSize.CheckOnClick = true;
            this.checkedListBoxSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBoxSize.FormattingEnabled = true;
            this.checkedListBoxSize.Location = new System.Drawing.Point(0, 517);
            this.checkedListBoxSize.Name = "checkedListBoxSize";
            this.checkedListBoxSize.Size = new System.Drawing.Size(448, 79);
            this.checkedListBoxSize.TabIndex = 6;
            this.checkedListBoxSize.Visible = false;
            // 
            // panel11
            // 
            this.panel11.AutoSize = true;
            this.panel11.Controls.Add(this.buttonCancel);
            this.panel11.Controls.Add(this.buttonOk);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 700);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(448, 32);
            this.panel11.TabIndex = 10;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::Universalis.Properties.Resources.cross_circle;
            this.buttonCancel.Location = new System.Drawing.Point(3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 26);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Abbrechen";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Image = global::Universalis.Properties.Resources.tick;
            this.buttonOk.Location = new System.Drawing.Point(345, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 26);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // checkedListBoxMovementType
            // 
            this.checkedListBoxMovementType.CheckOnClick = true;
            this.checkedListBoxMovementType.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBoxMovementType.FormattingEnabled = true;
            this.checkedListBoxMovementType.Location = new System.Drawing.Point(0, 621);
            this.checkedListBoxMovementType.Name = "checkedListBoxMovementType";
            this.checkedListBoxMovementType.Size = new System.Drawing.Size(448, 79);
            this.checkedListBoxMovementType.TabIndex = 6;
            this.checkedListBoxMovementType.Visible = false;
            // 
            // permissionsBindingSource
            // 
            this.permissionsBindingSource.DataSource = typeof(Universalis.Permissions);
            // 
            // nameDataGridViewTextBoxColumn2
            // 
            this.nameDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn2.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn2.Name = "nameDataGridViewTextBoxColumn2";
            this.nameDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // PermissionsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(448, 915);
            this.ControlBox = false;
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.checkedListBoxMovementType);
            this.Controls.Add(this.toolStripMovementType);
            this.Controls.Add(this.checkedListBoxSize);
            this.Controls.Add(this.toolStripSize);
            this.Controls.Add(this.checkedListBoxType);
            this.Controls.Add(this.toolStripType);
            this.Controls.Add(this.dataGridViewArchetype);
            this.Controls.Add(this.toolStripArchetypes);
            this.Controls.Add(this.dataGridViewFaction);
            this.Controls.Add(this.toolStripFactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(450, 39);
            this.Name = "PermissionsEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Berechtigungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PermissionForm_FormClosing);
            this.toolStripFactions.ResumeLayout(false);
            this.toolStripFactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factionsBindingSource)).EndInit();
            this.toolStripArchetypes.ResumeLayout(false);
            this.toolStripArchetypes.PerformLayout();
            this.toolStripType.ResumeLayout(false);
            this.toolStripType.PerformLayout();
            this.toolStripSize.ResumeLayout(false);
            this.toolStripSize.PerformLayout();
            this.toolStripMovementType.ResumeLayout(false);
            this.toolStripMovementType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchetype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archetypesBindingSource)).EndInit();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.permissionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripFactions;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridView dataGridViewFaction;
        private System.Windows.Forms.ToolStrip toolStripArchetypes;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStrip toolStripType;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStrip toolStripSize;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStrip toolStripMovementType;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.BindingSource permissionsBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewArchetype;
        private System.Windows.Forms.CheckedListBox checkedListBoxType;
        private System.Windows.Forms.CheckedListBox checkedListBoxSize;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.BindingSource factionsBindingSource;
        private System.Windows.Forms.BindingSource archetypesBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFaction;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxArchetype;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxType;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSize;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMovementType;
        private System.Windows.Forms.CheckedListBox checkedListBoxMovementType;
        private System.Windows.Forms.ToolStripButton toolStripButtonFactionAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonFactionDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonArchetypeAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonArchetypeDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn2;
    }
}