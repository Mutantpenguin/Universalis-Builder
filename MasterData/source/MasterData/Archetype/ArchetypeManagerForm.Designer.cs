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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchetypeManagerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonArchetypeAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonArchetypeDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUsage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.filterFaction = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterFaction = new System.Windows.Forms.ToolStripButton();
            this.filterType = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterType = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewArchetypes = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.archetypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FactionIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModAGI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModNK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModFK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModKO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModWN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModEH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModBW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchetypes)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.archetypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonArchetypeAdd,
            this.toolStripButtonArchetypeDelete,
            this.toolStripButtonCopy,
            this.toolStripButtonUsage,
            this.toolStripButtonClearSearch,
            this.filterFaction,
            this.checkBoxFilterFaction,
            this.filterType,
            this.checkBoxFilterType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(796, 25);
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
            this.toolStripButtonArchetypeAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArchetypeAdd.Name = "toolStripButtonArchetypeAdd";
            this.toolStripButtonArchetypeAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArchetypeAdd.ToolTipText = "neue Rüstung";
            this.toolStripButtonArchetypeAdd.Click += new System.EventHandler(this.toolStripButtonArchetypeAdd_Click);
            // 
            // toolStripButtonArchetypeDelete
            // 
            this.toolStripButtonArchetypeDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonArchetypeDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArchetypeDelete.Image = global::Universalis.Properties.Resources.minus;
            this.toolStripButtonArchetypeDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArchetypeDelete.Name = "toolStripButtonArchetypeDelete";
            this.toolStripButtonArchetypeDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArchetypeDelete.ToolTipText = "Rüstung löschen";
            this.toolStripButtonArchetypeDelete.Click += new System.EventHandler(this.toolStripButtonArchetypeDelete_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::Universalis.Properties.Resources.copy;
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
            this.toolStripButtonUsage.Image = global::Universalis.Properties.Resources.pin;
            this.toolStripButtonUsage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUsage.Name = "toolStripButtonUsage";
            this.toolStripButtonUsage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUsage.Click += new System.EventHandler(this.toolStripButtonUsage_Click);
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
            this.FactionIcon,
            this.nameDataGridViewTextBoxColumn,
            this.ModAGI,
            this.ModNK,
            this.ModFK,
            this.ModKO,
            this.ModWN,
            this.ModEH,
            this.ModBW});
            this.dataGridViewArchetypes.DataSource = this.archetypeBindingSource;
            this.dataGridViewArchetypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewArchetypes.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewArchetypes.MultiSelect = false;
            this.dataGridViewArchetypes.Name = "dataGridViewArchetypes";
            this.dataGridViewArchetypes.ReadOnly = true;
            this.dataGridViewArchetypes.RowHeadersVisible = false;
            this.dataGridViewArchetypes.RowTemplate.Height = 40;
            this.dataGridViewArchetypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArchetypes.Size = new System.Drawing.Size(796, 379);
            this.dataGridViewArchetypes.TabIndex = 0;
            this.dataGridViewArchetypes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewArchetype_CellDoubleClick);
            this.dataGridViewArchetypes.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewArchetype_CellToolTipTextNeeded);
            this.dataGridViewArchetypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewArchetype_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(796, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // archetypeBindingSource
            // 
            this.archetypeBindingSource.DataSource = typeof(Universalis.Archetype);
            // 
            // FactionIcon
            // 
            this.FactionIcon.DataPropertyName = "FactionIcon";
            this.FactionIcon.HeaderText = "";
            this.FactionIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.FactionIcon.Name = "FactionIcon";
            this.FactionIcon.ReadOnly = true;
            this.FactionIcon.Width = 40;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ModAGI
            // 
            this.ModAGI.DataPropertyName = "ModAGI";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModAGI.DefaultCellStyle = dataGridViewCellStyle2;
            this.ModAGI.HeaderText = "AGI";
            this.ModAGI.Name = "ModAGI";
            this.ModAGI.ReadOnly = true;
            this.ModAGI.Width = 35;
            // 
            // ModNK
            // 
            this.ModNK.DataPropertyName = "ModNK";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModNK.DefaultCellStyle = dataGridViewCellStyle3;
            this.ModNK.HeaderText = "NK";
            this.ModNK.Name = "ModNK";
            this.ModNK.ReadOnly = true;
            this.ModNK.Width = 35;
            // 
            // ModFK
            // 
            this.ModFK.DataPropertyName = "ModFK";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModFK.DefaultCellStyle = dataGridViewCellStyle4;
            this.ModFK.HeaderText = "FK";
            this.ModFK.Name = "ModFK";
            this.ModFK.ReadOnly = true;
            this.ModFK.Width = 35;
            // 
            // ModKO
            // 
            this.ModKO.DataPropertyName = "ModKO";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModKO.DefaultCellStyle = dataGridViewCellStyle5;
            this.ModKO.HeaderText = "KO";
            this.ModKO.Name = "ModKO";
            this.ModKO.ReadOnly = true;
            this.ModKO.Width = 35;
            // 
            // ModWN
            // 
            this.ModWN.DataPropertyName = "ModWN";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModWN.DefaultCellStyle = dataGridViewCellStyle6;
            this.ModWN.HeaderText = "WN";
            this.ModWN.Name = "ModWN";
            this.ModWN.ReadOnly = true;
            this.ModWN.Width = 35;
            // 
            // ModEH
            // 
            this.ModEH.DataPropertyName = "ModEH";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModEH.DefaultCellStyle = dataGridViewCellStyle7;
            this.ModEH.HeaderText = "EH";
            this.ModEH.Name = "ModEH";
            this.ModEH.ReadOnly = true;
            this.ModEH.Width = 35;
            // 
            // ModBW
            // 
            this.ModBW.DataPropertyName = "ModBW";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModBW.DefaultCellStyle = dataGridViewCellStyle8;
            this.ModBW.HeaderText = "BW";
            this.ModBW.Name = "ModBW";
            this.ModBW.ReadOnly = true;
            this.ModBW.Width = 35;
            // 
            // ArchetypeManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 426);
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.archetypeBindingSource)).EndInit();
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
        private System.Windows.Forms.ToolStripButton toolStripButtonUsage;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.ToolStripComboBox filterFaction;
        private System.Windows.Forms.ToolStripButton checkBoxFilterFaction;
        private System.Windows.Forms.ToolStripComboBox filterType;
        private System.Windows.Forms.ToolStripButton checkBoxFilterType;
        private System.Windows.Forms.DataGridViewImageColumn FactionIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModAGI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModNK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModFK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModKO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModWN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModEH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModBW;
    }
}