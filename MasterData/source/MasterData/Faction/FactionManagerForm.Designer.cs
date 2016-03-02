namespace Tesserakt
{
    partial class FactionManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FactionManagerForm));
            this.dataGridViewFactions = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.factionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripFactions = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonAddFaction = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteFaction = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripButtonUsage = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factionBindingSource)).BeginInit();
            this.toolStripFactions.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewFactions
            // 
            this.dataGridViewFactions.AllowUserToAddRows = false;
            this.dataGridViewFactions.AllowUserToDeleteRows = false;
            this.dataGridViewFactions.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewFactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFactions.AutoGenerateColumns = false;
            this.dataGridViewFactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.iconDataGridViewImageColumn});
            this.dataGridViewFactions.DataSource = this.factionBindingSource;
            this.dataGridViewFactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFactions.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewFactions.MultiSelect = false;
            this.dataGridViewFactions.Name = "dataGridViewFactions";
            this.dataGridViewFactions.ReadOnly = true;
            this.dataGridViewFactions.RowHeadersVisible = false;
            this.dataGridViewFactions.RowTemplate.Height = 40;
            this.dataGridViewFactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFactions.Size = new System.Drawing.Size(343, 379);
            this.dataGridViewFactions.TabIndex = 0;
            this.dataGridViewFactions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFaction_CellDoubleClick);
            this.dataGridViewFactions.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewFactions_CellToolTipTextNeeded);
            this.dataGridViewFactions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewFactions_KeyDown);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
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
            // factionBindingSource
            // 
            this.factionBindingSource.AllowNew = true;
            this.factionBindingSource.DataSource = typeof(Tesserakt.Faction);
            // 
            // toolStripFactions
            // 
            this.toolStripFactions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonAddFaction,
            this.toolStripButtonDeleteFaction,
            this.toolStripButtonClearSearch,
            this.toolStripButtonUsage});
            this.toolStripFactions.Location = new System.Drawing.Point(0, 0);
            this.toolStripFactions.Name = "toolStripFactions";
            this.toolStripFactions.Size = new System.Drawing.Size(343, 25);
            this.toolStripFactions.TabIndex = 1;
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
            // toolStripButtonAddFaction
            // 
            this.toolStripButtonAddFaction.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAddFaction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddFaction.Image = global::Tesserakt.Properties.Resources.plus;
            this.toolStripButtonAddFaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddFaction.Name = "toolStripButtonAddFaction";
            this.toolStripButtonAddFaction.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddFaction.ToolTipText = "neue Fraktion";
            this.toolStripButtonAddFaction.Click += new System.EventHandler(this.toolStripButtonAddFaction_Click);
            // 
            // toolStripButtonDeleteFaction
            // 
            this.toolStripButtonDeleteFaction.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDeleteFaction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteFaction.Image = global::Tesserakt.Properties.Resources.minus;
            this.toolStripButtonDeleteFaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteFaction.Name = "toolStripButtonDeleteFaction";
            this.toolStripButtonDeleteFaction.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteFaction.ToolTipText = "Fraktion löschen";
            this.toolStripButtonDeleteFaction.Click += new System.EventHandler(this.toolStripButtonDeleteFaction_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(343, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 17);
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
            // FactionManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 426);
            this.Controls.Add(this.dataGridViewFactions);
            this.Controls.Add(this.toolStripFactions);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "FactionManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fraktionen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FactionManagerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factionBindingSource)).EndInit();
            this.toolStripFactions.ResumeLayout(false);
            this.toolStripFactions.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFactions;
        private System.Windows.Forms.BindingSource factionBindingSource;
        private System.Windows.Forms.ToolStrip toolStripFactions;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddFaction;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteFaction;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonUsage;
    }
}