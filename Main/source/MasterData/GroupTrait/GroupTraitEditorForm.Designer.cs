namespace Universalis
{
    partial class GroupTraitEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupTraitEditorForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownPoints = new System.Windows.Forms.NumericUpDown();
            this.groupTraitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxRules = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripFactions = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxFaction = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonFactionAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFactionDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.dataGridViewFaction = new System.Windows.Forms.DataGridView();
            this.iconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTraitBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStripFactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.numericUpDownPoints);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 39);
            this.panel1.TabIndex = 1;
            // 
            // numericUpDownPoints
            // 
            this.numericUpDownPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPoints.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.groupTraitBindingSource, "PointsPerModel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownPoints.Location = new System.Drawing.Point(375, 16);
            this.numericUpDownPoints.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPoints.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownPoints.Name = "numericUpDownPoints";
            this.numericUpDownPoints.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownPoints.TabIndex = 48;
            this.numericUpDownPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPoints.ThousandsSeparator = true;
            this.toolTip1.SetToolTip(this.numericUpDownPoints, "Punkte pro Modell");
            // 
            // groupTraitBindingSource
            // 
            this.groupTraitBindingSource.DataSource = typeof(Universalis.GroupTrait);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Punkte";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.groupTraitBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxName.Location = new System.Drawing.Point(3, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(366, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBoxDescription);
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 408);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(434, 187);
            this.panel3.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.groupTraitBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 25);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(434, 162);
            this.textBoxDescription.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(434, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel1.Text = "Beschreibung";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBoxRules);
            this.panel4.Controls.Add(this.toolStrip2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 64);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(434, 150);
            this.panel4.TabIndex = 1;
            // 
            // textBoxRules
            // 
            this.textBoxRules.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.groupTraitBindingSource, "Rules", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRules.Location = new System.Drawing.Point(0, 25);
            this.textBoxRules.Multiline = true;
            this.textBoxRules.Name = "textBoxRules";
            this.textBoxRules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRules.Size = new System.Drawing.Size(434, 125);
            this.textBoxRules.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(434, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel2.Text = "Regeln";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(434, 25);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::Universalis.Properties.Resources.disk;
            this.toolStripButtonSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(81, 22);
            this.toolStripButtonSave.Text = "Speichern";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripFactions
            // 
            this.toolStripFactions.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripFactions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFactions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxFaction,
            this.toolStripButtonFactionAdd,
            this.toolStripButtonFactionDelete,
            this.toolStripLabel3});
            this.toolStripFactions.Location = new System.Drawing.Point(0, 214);
            this.toolStripFactions.Name = "toolStripFactions";
            this.toolStripFactions.Size = new System.Drawing.Size(434, 25);
            this.toolStripFactions.TabIndex = 2;
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
            this.toolStripButtonFactionAdd.ToolTipText = "Fraktion hinzufügen";
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
            this.toolStripButtonFactionDelete.ToolTipText = "Fraktion entfernen";
            this.toolStripButtonFactionDelete.Visible = false;
            this.toolStripButtonFactionDelete.Click += new System.EventHandler(this.toolStripButtonFactionDelete_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(139, 22);
            this.toolStripLabel3.Text = "Fraktionsberechtigungen";
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
            this.dataGridViewFaction.Location = new System.Drawing.Point(0, 239);
            this.dataGridViewFaction.MultiSelect = false;
            this.dataGridViewFaction.Name = "dataGridViewFaction";
            this.dataGridViewFaction.ReadOnly = true;
            this.dataGridViewFaction.RowHeadersVisible = false;
            this.dataGridViewFaction.RowTemplate.Height = 40;
            this.dataGridViewFaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFaction.Size = new System.Drawing.Size(434, 169);
            this.dataGridViewFaction.TabIndex = 4;
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
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // factionsBindingSource
            // 
            this.factionsBindingSource.DataSource = typeof(Universalis.Faction);
            // 
            // GroupTraitEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(434, 668);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridViewFaction);
            this.Controls.Add(this.toolStripFactions);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip3);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(450, 39);
            this.Name = "GroupTraitEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gruppeneigenschaften Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupTraitEditorForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TraitEditorForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupTraitBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStripFactions.ResumeLayout(false);
            this.toolStripFactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.BindingSource groupTraitBindingSource;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxRules;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownPoints;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStripFactions;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFaction;
        private System.Windows.Forms.ToolStripButton toolStripButtonFactionAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonFactionDelete;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.DataGridView dataGridViewFaction;
        private System.Windows.Forms.BindingSource factionsBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}