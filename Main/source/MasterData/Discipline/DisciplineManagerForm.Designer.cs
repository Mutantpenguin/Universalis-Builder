namespace Universalis
{
    partial class DisciplineManagerForm
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
            this.dataGridViewDisciplines = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PowerCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedMaxQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasPermissions = new System.Windows.Forms.DataGridViewImageColumn();
            this.PointsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disciplineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripFactions = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonAddDiscipline = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteDiscipline = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisciplines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disciplineBindingSource)).BeginInit();
            this.toolStripFactions.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDisciplines
            // 
            this.dataGridViewDisciplines.AllowUserToAddRows = false;
            this.dataGridViewDisciplines.AllowUserToDeleteRows = false;
            this.dataGridViewDisciplines.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewDisciplines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDisciplines.AutoGenerateColumns = false;
            this.dataGridViewDisciplines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDisciplines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.PowerCount,
            this.FormattedMaxQuantity,
            this.MaxLevel,
            this.HasPermissions,
            this.PointsString});
            this.dataGridViewDisciplines.DataSource = this.disciplineBindingSource;
            this.dataGridViewDisciplines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDisciplines.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewDisciplines.MultiSelect = false;
            this.dataGridViewDisciplines.Name = "dataGridViewDisciplines";
            this.dataGridViewDisciplines.RowHeadersVisible = false;
            this.dataGridViewDisciplines.RowTemplate.Height = 40;
            this.dataGridViewDisciplines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDisciplines.Size = new System.Drawing.Size(457, 379);
            this.dataGridViewDisciplines.TabIndex = 0;
            this.dataGridViewDisciplines.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDiscipline_CellDoubleClick);
            this.dataGridViewDisciplines.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewDisciplines_CellFormatting);
            this.dataGridViewDisciplines.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewDisciplines_CellToolTipTextNeeded);
            this.dataGridViewDisciplines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewDisciplines_KeyDown);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PowerCount
            // 
            this.PowerCount.DataPropertyName = "PowerCount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PowerCount.DefaultCellStyle = dataGridViewCellStyle2;
            this.PowerCount.HeaderText = "#";
            this.PowerCount.Name = "PowerCount";
            this.PowerCount.ReadOnly = true;
            this.PowerCount.ToolTipText = "Anzahl Kräfte";
            this.PowerCount.Width = 35;
            // 
            // FormattedMaxQuantity
            // 
            this.FormattedMaxQuantity.DataPropertyName = "FormattedMaxQuantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FormattedMaxQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.FormattedMaxQuantity.HeaderText = "Max.";
            this.FormattedMaxQuantity.Name = "FormattedMaxQuantity";
            this.FormattedMaxQuantity.ReadOnly = true;
            this.FormattedMaxQuantity.ToolTipText = "Group";
            this.FormattedMaxQuantity.Width = 35;
            // 
            // MaxLevel
            // 
            this.MaxLevel.DataPropertyName = "MaxLevel";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MaxLevel.DefaultCellStyle = dataGridViewCellStyle4;
            this.MaxLevel.HeaderText = "Max. LVL";
            this.MaxLevel.Name = "MaxLevel";
            this.MaxLevel.ReadOnly = true;
            this.MaxLevel.Width = 75;
            // 
            // HasPermissions
            // 
            this.HasPermissions.HeaderText = "B";
            this.HasPermissions.Name = "HasPermissions";
            this.HasPermissions.ReadOnly = true;
            this.HasPermissions.ToolTipText = "Berechtigungen";
            this.HasPermissions.Width = 25;
            // 
            // PointsString
            // 
            this.PointsString.DataPropertyName = "PointsString";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PointsString.DefaultCellStyle = dataGridViewCellStyle5;
            this.PointsString.HeaderText = "Punkte";
            this.PointsString.Name = "PointsString";
            this.PointsString.ReadOnly = true;
            this.PointsString.Width = 80;
            // 
            // disciplineBindingSource
            // 
            this.disciplineBindingSource.AllowNew = true;
            this.disciplineBindingSource.DataSource = typeof(Universalis.Discipline);
            // 
            // toolStripFactions
            // 
            this.toolStripFactions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonAddDiscipline,
            this.toolStripButtonDeleteDiscipline,
            this.toolStripButtonClearSearch});
            this.toolStripFactions.Location = new System.Drawing.Point(0, 0);
            this.toolStripFactions.Name = "toolStripFactions";
            this.toolStripFactions.Size = new System.Drawing.Size(457, 25);
            this.toolStripFactions.TabIndex = 1;
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
            // toolStripButtonAddDiscipline
            // 
            this.toolStripButtonAddDiscipline.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAddDiscipline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddDiscipline.Image = global::Universalis.Properties.Resources.plus;
            this.toolStripButtonAddDiscipline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddDiscipline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddDiscipline.Name = "toolStripButtonAddDiscipline";
            this.toolStripButtonAddDiscipline.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddDiscipline.ToolTipText = "neue Fraktion";
            this.toolStripButtonAddDiscipline.Click += new System.EventHandler(this.toolStripButtonAddDiscipline_Click);
            // 
            // toolStripButtonDeleteDiscipline
            // 
            this.toolStripButtonDeleteDiscipline.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDeleteDiscipline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteDiscipline.Image = global::Universalis.Properties.Resources.trash;
            this.toolStripButtonDeleteDiscipline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonDeleteDiscipline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteDiscipline.Name = "toolStripButtonDeleteDiscipline";
            this.toolStripButtonDeleteDiscipline.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteDiscipline.ToolTipText = "Fraktion löschen";
            this.toolStripButtonDeleteDiscipline.Click += new System.EventHandler(this.toolStripButtonDeleteDiscipline_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(457, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // DisciplineManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 426);
            this.Controls.Add(this.dataGridViewDisciplines);
            this.Controls.Add(this.toolStripFactions);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "DisciplineManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Disziplinen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisciplineManagerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisciplines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disciplineBindingSource)).EndInit();
            this.toolStripFactions.ResumeLayout(false);
            this.toolStripFactions.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDisciplines;
        private System.Windows.Forms.BindingSource disciplineBindingSource;
        private System.Windows.Forms.ToolStrip toolStripFactions;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteDiscipline;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddDiscipline;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PowerCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedMaxQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxLevel;
        private System.Windows.Forms.DataGridViewImageColumn HasPermissions;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointsString;
    }
}