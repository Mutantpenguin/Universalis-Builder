namespace Tesserakt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraitsManagerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.toolStripButtonUsage = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTraits = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableLevels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PointsRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.traitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.toolStripDropDownButtonFilter,
            this.toolStripButtonUsage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(384, 25);
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
            this.toolStripButtonTraitAdd.Image = global::Tesserakt.Properties.Resources.plus;
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
            this.toolStripButtonTraitDelete.Image = global::Tesserakt.Properties.Resources.minus;
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
            this.toolStripButtonCopy.Image = global::Tesserakt.Properties.Resources.copy;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopy.Text = "toolStripButton1";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
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
            // toolStripDropDownButtonFilter
            // 
            this.toolStripDropDownButtonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemPositives,
            this.toolStripMenuItemNegatives,
            this.toolStripMenuItemNeutrals});
            this.toolStripDropDownButtonFilter.Image = global::Tesserakt.Properties.Resources.funnel;
            this.toolStripDropDownButtonFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonFilter.Name = "toolStripDropDownButtonFilter";
            this.toolStripDropDownButtonFilter.Size = new System.Drawing.Size(29, 22);
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
            // toolStripButtonUsage
            // 
            this.toolStripButtonUsage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonUsage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUsage.Image = global::Tesserakt.Properties.Resources.pin;
            this.toolStripButtonUsage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUsage.Name = "toolStripButtonUsage";
            this.toolStripButtonUsage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUsage.Click += new System.EventHandler(this.toolStripButtonUsage_Click);
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
            this.Type,
            this.nameDataGridViewTextBoxColumn,
            this.AvailableLevels,
            this.PointsRange});
            this.dataGridViewTraits.DataSource = this.traitBindingSource;
            this.dataGridViewTraits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTraits.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewTraits.MultiSelect = false;
            this.dataGridViewTraits.Name = "dataGridViewTraits";
            this.dataGridViewTraits.ReadOnly = true;
            this.dataGridViewTraits.RowHeadersVisible = false;
            this.dataGridViewTraits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTraits.Size = new System.Drawing.Size(384, 379);
            this.dataGridViewTraits.TabIndex = 0;
            this.dataGridViewTraits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTraits_CellDoubleClick);
            this.dataGridViewTraits.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewTraits_CellToolTipTextNeeded);
            this.dataGridViewTraits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewTraits_KeyDown);
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Type.DefaultCellStyle = dataGridViewCellStyle2;
            this.Type.HeaderText = "";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Type.Width = 24;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AvailableLevels
            // 
            this.AvailableLevels.DataPropertyName = "AvailableLevels";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AvailableLevels.DefaultCellStyle = dataGridViewCellStyle3;
            this.AvailableLevels.HeaderText = "Stufen";
            this.AvailableLevels.Name = "AvailableLevels";
            this.AvailableLevels.ReadOnly = true;
            this.AvailableLevels.Width = 45;
            // 
            // PointsRange
            // 
            this.PointsRange.DataPropertyName = "PointsRange";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PointsRange.DefaultCellStyle = dataGridViewCellStyle4;
            this.PointsRange.HeaderText = "Punkte";
            this.PointsRange.Name = "PointsRange";
            this.PointsRange.ReadOnly = true;
            this.PointsRange.Width = 80;
            // 
            // traitBindingSource
            // 
            this.traitBindingSource.DataSource = typeof(Tesserakt.Trait);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(384, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // TraitsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 426);
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
        private System.Windows.Forms.ToolStripButton toolStripButtonUsage;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableLevels;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointsRange;
    }
}