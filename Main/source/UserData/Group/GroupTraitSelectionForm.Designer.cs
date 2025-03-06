namespace Universalis
{
    partial class GroupTraitSelectionForm
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemPositives = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNegatives = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNeutrals = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewGroupTraits = new System.Windows.Forms.DataGridView();
            this.groupTraitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rulesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PointsPerModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupTraits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTraitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Image = global::Universalis.Properties.Resources.tick;
            this.buttonOk.Location = new System.Drawing.Point(486, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 26);
            this.buttonOk.TabIndex = 4;
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
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 32);
            this.panel1.TabIndex = 4;
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxSearch_KeyDown);
            this.toolStripTextBoxSearch.TextChanged += new System.EventHandler(this.toolStripTextBoxSearch_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(589, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
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
            // dataGridViewGroupTraits
            // 
            this.dataGridViewGroupTraits.AllowUserToAddRows = false;
            this.dataGridViewGroupTraits.AllowUserToDeleteRows = false;
            this.dataGridViewGroupTraits.AllowUserToOrderColumns = true;
            this.dataGridViewGroupTraits.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewGroupTraits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGroupTraits.AutoGenerateColumns = false;
            this.dataGridViewGroupTraits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroupTraits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.rulesDataGridViewTextBoxColumn,
            this.PointsPerModel});
            this.dataGridViewGroupTraits.DataSource = this.groupTraitBindingSource;
            this.dataGridViewGroupTraits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGroupTraits.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewGroupTraits.MultiSelect = false;
            this.dataGridViewGroupTraits.Name = "dataGridViewGroupTraits";
            this.dataGridViewGroupTraits.ReadOnly = true;
            this.dataGridViewGroupTraits.RowHeadersVisible = false;
            this.dataGridViewGroupTraits.RowTemplate.Height = 60;
            this.dataGridViewGroupTraits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroupTraits.Size = new System.Drawing.Size(589, 369);
            this.dataGridViewGroupTraits.TabIndex = 5;
            this.dataGridViewGroupTraits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGroupTraits_CellDoubleClick);
            this.dataGridViewGroupTraits.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewGroupTraits_CellToolTipTextNeeded);
            this.dataGridViewGroupTraits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewGroupTraits_KeyDown);
            // 
            // groupTraitBindingSource
            // 
            this.groupTraitBindingSource.DataSource = typeof(Universalis.GroupTrait);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // rulesDataGridViewTextBoxColumn
            // 
            this.rulesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rulesDataGridViewTextBoxColumn.DataPropertyName = "Rules";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rulesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.rulesDataGridViewTextBoxColumn.HeaderText = "Regeln";
            this.rulesDataGridViewTextBoxColumn.Name = "rulesDataGridViewTextBoxColumn";
            this.rulesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PointsPerModel
            // 
            this.PointsPerModel.DataPropertyName = "PointsPerModel";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.PointsPerModel.DefaultCellStyle = dataGridViewCellStyle3;
            this.PointsPerModel.HeaderText = "Punkte/Model";
            this.PointsPerModel.Name = "PointsPerModel";
            this.PointsPerModel.ReadOnly = true;
            this.PointsPerModel.Width = 90;
            // 
            // GroupTraitSelectionForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(589, 426);
            this.Controls.Add(this.dataGridViewGroupTraits);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "GroupTraitSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bitte wählen Sie eine Gruppeneigenschaft";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupTraits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTraitBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource groupTraitBindingSource;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridViewGroupTraits;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFilter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPositives;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNegatives;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNeutrals;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rulesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointsPerModel;
    }
}