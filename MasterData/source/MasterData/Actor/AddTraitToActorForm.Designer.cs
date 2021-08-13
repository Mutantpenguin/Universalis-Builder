namespace Universalis
{
    partial class AddTraitToActorForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemPositives = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNegatives = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNeutrals = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.dataGridViewTraits = new System.Windows.Forms.DataGridView();
            this.traitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UseOnce = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AvailableLevels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PointsRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonClearSearch,
            this.toolStripDropDownButtonFilter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(384, 25);
            this.toolStrip1.TabIndex = 0;
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
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.buttonOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 32);
            this.panel2.TabIndex = 3;
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
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Image = global::Universalis.Properties.Resources.tick;
            this.buttonOk.Location = new System.Drawing.Point(281, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 26);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Übernehmen";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // dataGridViewTraits
            // 
            this.dataGridViewTraits.AllowUserToAddRows = false;
            this.dataGridViewTraits.AllowUserToDeleteRows = false;
            this.dataGridViewTraits.AllowUserToOrderColumns = true;
            this.dataGridViewTraits.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTraits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTraits.AutoGenerateColumns = false;
            this.dataGridViewTraits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTraits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.nameDataGridViewTextBoxColumn,
            this.UseOnce,
            this.AvailableLevels,
            this.PointsRange});
            this.dataGridViewTraits.DataSource = this.traitBindingSource;
            this.dataGridViewTraits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTraits.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewTraits.Name = "dataGridViewTraits";
            this.dataGridViewTraits.ReadOnly = true;
            this.dataGridViewTraits.RowHeadersVisible = false;
            this.dataGridViewTraits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTraits.Size = new System.Drawing.Size(384, 369);
            this.dataGridViewTraits.TabIndex = 4;
            this.dataGridViewTraits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTraits_CellDoubleClick);
            this.dataGridViewTraits.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewTraits_CellToolTipTextNeeded);
            this.dataGridViewTraits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewTraits_KeyDown);
            // 
            // traitBindingSource
            // 
            this.traitBindingSource.DataSource = typeof(Universalis.Trait);
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
            // UseOnce
            // 
            this.UseOnce.DataPropertyName = "UseOnce";
            this.UseOnce.HeaderText = "E";
            this.UseOnce.Name = "UseOnce";
            this.UseOnce.ReadOnly = true;
            this.UseOnce.ToolTipText = "Einmalnutzung";
            this.UseOnce.Width = 30;
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
            // AddTraitToActorForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(384, 426);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewTraits);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AddTraitToActorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Eigenschaftsauswahl";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTraits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traitBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewTraits;
        private System.Windows.Forms.BindingSource traitBindingSource;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFilter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPositives;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNegatives;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNeutrals;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UseOnce;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableLevels;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointsRange;
    }
}