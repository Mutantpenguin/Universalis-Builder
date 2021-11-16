namespace Universalis
{
    partial class TraitsManagerForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonTraitAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTraitDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemPositives = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNegatives = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNeutrals = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTraits = new System.Windows.Forms.DataGridView();
            this.traitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traitBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonTraitAdd,
            this.toolStripButtonTraitDelete,
            this.toolStripButtonCopy,
            this.toolStripButtonClearSearch,
            this.toolStripDropDownButtonFilter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(780, 25);
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
            // toolStripButtonTraitAdd
            // 
            this.toolStripButtonTraitAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonTraitAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTraitAdd.Image = global::Universalis.Properties.Resources.plus;
            this.toolStripButtonTraitAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTraitAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTraitAdd.Name = "toolStripButtonTraitAdd";
            this.toolStripButtonTraitAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTraitAdd.ToolTipText = "neue Eigenschaft";
            this.toolStripButtonTraitAdd.Click += new System.EventHandler(this.toolStripButtonTraitAdd_Click);
            // 
            // toolStripButtonTraitDelete
            // 
            this.toolStripButtonTraitDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonTraitDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTraitDelete.Image = global::Universalis.Properties.Resources.trash;
            this.toolStripButtonTraitDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTraitDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTraitDelete.Name = "toolStripButtonTraitDelete";
            this.toolStripButtonTraitDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTraitDelete.ToolTipText = "Eigenschaft löschen";
            this.toolStripButtonTraitDelete.Click += new System.EventHandler(this.toolStripButtonTraitDelete_Click);
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
            this.toolStripButtonCopy.Text = "Eigenschaft kopieren";
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
            // dataGridViewTraits
            // 
            this.dataGridViewTraits.AllowUserToAddRows = false;
            this.dataGridViewTraits.AllowUserToDeleteRows = false;
            this.dataGridViewTraits.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTraits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTraits.AutoGenerateColumns = false;
            this.dataGridViewTraits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTraits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
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
            this.dataGridViewTraits.MultiSelect = false;
            this.dataGridViewTraits.Name = "dataGridViewTraits";
            this.dataGridViewTraits.ReadOnly = true;
            this.dataGridViewTraits.RowHeadersVisible = false;
            this.dataGridViewTraits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTraits.Size = new System.Drawing.Size(780, 379);
            this.dataGridViewTraits.TabIndex = 0;
            this.dataGridViewTraits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTraits_CellDoubleClick);
            this.dataGridViewTraits.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTraits_CellFormatting);
            this.dataGridViewTraits.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewTraits_CellToolTipTextNeeded);
            this.dataGridViewTraits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewTraits_KeyDown);
            // 
            // traitBindingSource
            // 
            this.traitBindingSource.DataSource = typeof(Universalis.Trait);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(780, 22);
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
            // MaxLevel
            // 
            this.MaxLevel.DataPropertyName = "MaxLevel";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MaxLevel.DefaultCellStyle = dataGridViewCellStyle2;
            this.MaxLevel.HeaderText = "Max";
            this.MaxLevel.Name = "MaxLevel";
            this.MaxLevel.ReadOnly = true;
            this.MaxLevel.ToolTipText = "Maximales Level";
            this.MaxLevel.Width = 35;
            // 
            // FormattedAP
            // 
            this.FormattedAP.DataPropertyName = "FormattedAP";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedAP.DefaultCellStyle = dataGridViewCellStyle3;
            this.FormattedAP.HeaderText = "AP";
            this.FormattedAP.Name = "FormattedAP";
            this.FormattedAP.ReadOnly = true;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SpeedString.DefaultCellStyle = dataGridViewCellStyle4;
            this.SpeedString.HeaderText = "GK";
            this.SpeedString.Name = "SpeedString";
            this.SpeedString.ReadOnly = true;
            this.SpeedString.Width = 35;
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
            // PointsString
            // 
            this.PointsString.DataPropertyName = "PointsString";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PointsString.DefaultCellStyle = dataGridViewCellStyle13;
            this.PointsString.HeaderText = "Punkte";
            this.PointsString.Name = "PointsString";
            this.PointsString.ReadOnly = true;
            this.PointsString.Width = 80;
            // 
            // TraitsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 426);
            this.Controls.Add(this.dataGridViewTraits);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "TraitsManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eigenschaften";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TraitManagerForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traitBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridViewTraits;
        private System.Windows.Forms.BindingSource traitBindingSource;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonTraitAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonTraitDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFilter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPositives;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNegatives;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNeutrals;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
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
    }
}