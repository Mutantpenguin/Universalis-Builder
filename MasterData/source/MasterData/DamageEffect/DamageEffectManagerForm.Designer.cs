namespace Universalis
{
    partial class DamageEffectManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
            this.dataGridViewDamageEffects = new System.Windows.Forms.DataGridView();
            this.damageEffectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripCardManager = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonAddDamageEffect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteDamageEffect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.iconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsageType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsRangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDamageEffects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damageEffectBindingSource)).BeginInit();
            this.toolStripCardManager.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDamageEffects
            // 
            this.dataGridViewDamageEffects.AllowUserToAddRows = false;
            this.dataGridViewDamageEffects.AllowUserToDeleteRows = false;
            this.dataGridViewDamageEffects.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewDamageEffects.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDamageEffects.AutoGenerateColumns = false;
            this.dataGridViewDamageEffects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDamageEffects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iconDataGridViewImageColumn,
            this.nameDataGridViewTextBoxColumn,
            this.UsageType,
            this.pointsRangeDataGridViewTextBoxColumn});
            this.dataGridViewDamageEffects.DataSource = this.damageEffectBindingSource;
            this.dataGridViewDamageEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDamageEffects.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewDamageEffects.MultiSelect = false;
            this.dataGridViewDamageEffects.Name = "dataGridViewDamageEffects";
            this.dataGridViewDamageEffects.ReadOnly = true;
            this.dataGridViewDamageEffects.RowHeadersVisible = false;
            this.dataGridViewDamageEffects.RowTemplate.Height = 40;
            this.dataGridViewDamageEffects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDamageEffects.Size = new System.Drawing.Size(505, 548);
            this.dataGridViewDamageEffects.TabIndex = 0;
            this.dataGridViewDamageEffects.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDamageEffects_CellDoubleClick);
            this.dataGridViewDamageEffects.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewDamageEffects_CellToolTipTextNeeded);
            this.dataGridViewDamageEffects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewDamageEffects_KeyDown);
            // 
            // damageEffectBindingSource
            // 
            this.damageEffectBindingSource.DataSource = typeof(Universalis.DamageEffect);
            // 
            // toolStripCardManager
            // 
            this.toolStripCardManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonAddDamageEffect,
            this.toolStripButtonDeleteDamageEffect,
            this.toolStripButtonClearSearch});
            this.toolStripCardManager.Location = new System.Drawing.Point(0, 0);
            this.toolStripCardManager.Name = "toolStripCardManager";
            this.toolStripCardManager.Size = new System.Drawing.Size(505, 25);
            this.toolStripCardManager.TabIndex = 1;
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
            // toolStripButtonAddDamageEffect
            // 
            this.toolStripButtonAddDamageEffect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAddDamageEffect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddDamageEffect.Image = global::Universalis.Properties.Resources.plus;
            this.toolStripButtonAddDamageEffect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddDamageEffect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddDamageEffect.Name = "toolStripButtonAddDamageEffect";
            this.toolStripButtonAddDamageEffect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddDamageEffect.ToolTipText = "neues Modell";
            this.toolStripButtonAddDamageEffect.Click += new System.EventHandler(this.toolStripButtonAddDamageEffect_Click);
            // 
            // toolStripButtonDeleteDamageEffect
            // 
            this.toolStripButtonDeleteDamageEffect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDeleteDamageEffect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteDamageEffect.Image = global::Universalis.Properties.Resources.trash;
            this.toolStripButtonDeleteDamageEffect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonDeleteDamageEffect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteDamageEffect.Name = "toolStripButtonDeleteDamageEffect";
            this.toolStripButtonDeleteDamageEffect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteDamageEffect.ToolTipText = "Modell löschen";
            this.toolStripButtonDeleteDamageEffect.Click += new System.EventHandler(this.toolStripButtonDeleteDamageEffect_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(505, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // iconDataGridViewImageColumn
            // 
            this.iconDataGridViewImageColumn.DataPropertyName = "Icon";
            this.iconDataGridViewImageColumn.HeaderText = "";
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
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 125;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // UsageType
            // 
            this.UsageType.DataPropertyName = "UsageType";
            this.UsageType.HeaderText = "Typ";
            this.UsageType.Name = "UsageType";
            this.UsageType.ReadOnly = true;
            this.UsageType.Width = 80;
            // 
            // pointsRangeDataGridViewTextBoxColumn
            // 
            this.pointsRangeDataGridViewTextBoxColumn.DataPropertyName = "PointsRange";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pointsRangeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.pointsRangeDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsRangeDataGridViewTextBoxColumn.Name = "pointsRangeDataGridViewTextBoxColumn";
            this.pointsRangeDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsRangeDataGridViewTextBoxColumn.Width = 80;
            // 
            // DamageEffectManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 595);
            this.Controls.Add(this.dataGridViewDamageEffects);
            this.Controls.Add(this.toolStripCardManager);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "DamageEffectManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schadenseffekte";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DamageEffectManagerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDamageEffects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damageEffectBindingSource)).EndInit();
            this.toolStripCardManager.ResumeLayout(false);
            this.toolStripCardManager.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripCardManager;
        private System.Windows.Forms.DataGridView dataGridViewDamageEffects;
        private System.Windows.Forms.BindingSource damageEffectBindingSource;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddDamageEffect;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteDamageEffect;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsageType;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsRangeDataGridViewTextBoxColumn;
    }
}