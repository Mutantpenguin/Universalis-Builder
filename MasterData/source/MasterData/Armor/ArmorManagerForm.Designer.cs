namespace Tesserakt
{
    partial class ArmorManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArmorManagerForm));
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonArmorAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonArmorDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUsage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.filterCamouflage = new System.Windows.Forms.ToolStripComboBox();
            this.checkBoxFilterCamouflage = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewArmor = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelfSustaining = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TypesImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Potential = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EffectsImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Camouflage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CamouflageLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModAGI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModBW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModKK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModHAK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModAFG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModSH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.armorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArmor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxSearch,
            this.toolStripButtonArmorAdd,
            this.toolStripButtonArmorDelete,
            this.toolStripButtonCopy,
            this.toolStripButtonUsage,
            this.toolStripButtonClearSearch,
            this.filterCamouflage,
            this.checkBoxFilterCamouflage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(796, 25);
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
            // toolStripButtonArmorAdd
            // 
            this.toolStripButtonArmorAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonArmorAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArmorAdd.Image = global::Tesserakt.Properties.Resources.plus;
            this.toolStripButtonArmorAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArmorAdd.Name = "toolStripButtonArmorAdd";
            this.toolStripButtonArmorAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArmorAdd.ToolTipText = "neue Rüstung";
            this.toolStripButtonArmorAdd.Click += new System.EventHandler(this.toolStripButtonArmorAdd_Click);
            // 
            // toolStripButtonArmorDelete
            // 
            this.toolStripButtonArmorDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonArmorDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArmorDelete.Image = global::Tesserakt.Properties.Resources.minus;
            this.toolStripButtonArmorDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArmorDelete.Name = "toolStripButtonArmorDelete";
            this.toolStripButtonArmorDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArmorDelete.ToolTipText = "Rüstung löschen";
            this.toolStripButtonArmorDelete.Click += new System.EventHandler(this.toolStripButtonArmorDelete_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::Tesserakt.Properties.Resources.copy;
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
            this.toolStripButtonUsage.Image = global::Tesserakt.Properties.Resources.pin;
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
            // filterCamouflage
            // 
            this.filterCamouflage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterCamouflage.Enabled = false;
            this.filterCamouflage.Name = "filterCamouflage";
            this.filterCamouflage.Size = new System.Drawing.Size(80, 25);
            this.filterCamouflage.ToolTipText = "Tarnung";
            // 
            // checkBoxFilterCamouflage
            // 
            this.checkBoxFilterCamouflage.CheckOnClick = true;
            this.checkBoxFilterCamouflage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBoxFilterCamouflage.Image = global::Tesserakt.Properties.Resources.ui_check_box_uncheck;
            this.checkBoxFilterCamouflage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBoxFilterCamouflage.Name = "checkBoxFilterCamouflage";
            this.checkBoxFilterCamouflage.Size = new System.Drawing.Size(23, 22);
            this.checkBoxFilterCamouflage.ToolTipText = "nach Tarnung filtern";
            this.checkBoxFilterCamouflage.Click += new System.EventHandler(this.checkBoxFilterCamouflage_Click);
            // 
            // dataGridViewArmor
            // 
            this.dataGridViewArmor.AllowUserToAddRows = false;
            this.dataGridViewArmor.AllowUserToDeleteRows = false;
            this.dataGridViewArmor.AllowUserToOrderColumns = true;
            this.dataGridViewArmor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewArmor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewArmor.AutoGenerateColumns = false;
            this.dataGridViewArmor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArmor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.SelfSustaining,
            this.TypesImage,
            this.Potential,
            this.EffectsImage,
            this.Camouflage,
            this.CamouflageLevel,
            this.ModAGI,
            this.ModBW,
            this.ModKK,
            this.ModHAK,
            this.ModAFG,
            this.ModSH,
            this.weightDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn});
            this.dataGridViewArmor.DataSource = this.armorBindingSource;
            this.dataGridViewArmor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewArmor.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewArmor.Name = "dataGridViewArmor";
            this.dataGridViewArmor.ReadOnly = true;
            this.dataGridViewArmor.RowHeadersVisible = false;
            this.dataGridViewArmor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArmor.Size = new System.Drawing.Size(796, 379);
            this.dataGridViewArmor.TabIndex = 0;
            this.dataGridViewArmor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewArmor_CellDoubleClick);
            this.dataGridViewArmor.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewArmor_CellToolTipTextNeeded);
            this.dataGridViewArmor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewArmor_KeyDown);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SelfSustaining
            // 
            this.SelfSustaining.DataPropertyName = "SelfSustaining";
            this.SelfSustaining.HeaderText = "ST";
            this.SelfSustaining.Name = "SelfSustaining";
            this.SelfSustaining.ReadOnly = true;
            this.SelfSustaining.ToolTipText = "Selbsttragend";
            this.SelfSustaining.Width = 30;
            // 
            // TypesImage
            // 
            this.TypesImage.DataPropertyName = "TypesImage";
            this.TypesImage.HeaderText = "Schadenstypen";
            this.TypesImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.TypesImage.Name = "TypesImage";
            this.TypesImage.ReadOnly = true;
            // 
            // Potential
            // 
            this.Potential.DataPropertyName = "Potential";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Potential.DefaultCellStyle = dataGridViewCellStyle2;
            this.Potential.HeaderText = "P";
            this.Potential.Name = "Potential";
            this.Potential.ReadOnly = true;
            this.Potential.ToolTipText = "Potential";
            this.Potential.Width = 30;
            // 
            // EffectsImage
            // 
            this.EffectsImage.DataPropertyName = "EffectsImage";
            this.EffectsImage.HeaderText = "Effekte";
            this.EffectsImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EffectsImage.Name = "EffectsImage";
            this.EffectsImage.ReadOnly = true;
            this.EffectsImage.Width = 60;
            // 
            // Camouflage
            // 
            this.Camouflage.DataPropertyName = "Camouflage";
            this.Camouflage.HeaderText = "T";
            this.Camouflage.Name = "Camouflage";
            this.Camouflage.ReadOnly = true;
            this.Camouflage.ToolTipText = "Tarnung";
            this.Camouflage.Width = 40;
            // 
            // CamouflageLevel
            // 
            this.CamouflageLevel.DataPropertyName = "CamouflageLevel";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CamouflageLevel.DefaultCellStyle = dataGridViewCellStyle3;
            this.CamouflageLevel.HeaderText = "TL";
            this.CamouflageLevel.Name = "CamouflageLevel";
            this.CamouflageLevel.ReadOnly = true;
            this.CamouflageLevel.ToolTipText = "Tarnungslevel";
            this.CamouflageLevel.Width = 30;
            // 
            // ModAGI
            // 
            this.ModAGI.DataPropertyName = "ModAGI";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModAGI.DefaultCellStyle = dataGridViewCellStyle4;
            this.ModAGI.HeaderText = "AGI";
            this.ModAGI.Name = "ModAGI";
            this.ModAGI.ReadOnly = true;
            this.ModAGI.Width = 35;
            // 
            // ModBW
            // 
            this.ModBW.DataPropertyName = "ModBW";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModBW.DefaultCellStyle = dataGridViewCellStyle5;
            this.ModBW.HeaderText = "BW";
            this.ModBW.Name = "ModBW";
            this.ModBW.ReadOnly = true;
            this.ModBW.Width = 35;
            // 
            // ModKK
            // 
            this.ModKK.DataPropertyName = "ModKK";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModKK.DefaultCellStyle = dataGridViewCellStyle6;
            this.ModKK.HeaderText = "KK";
            this.ModKK.Name = "ModKK";
            this.ModKK.ReadOnly = true;
            this.ModKK.Width = 35;
            // 
            // ModHAK
            // 
            this.ModHAK.DataPropertyName = "ModHAK";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModHAK.DefaultCellStyle = dataGridViewCellStyle7;
            this.ModHAK.HeaderText = "HAK";
            this.ModHAK.Name = "ModHAK";
            this.ModHAK.ReadOnly = true;
            this.ModHAK.Width = 35;
            // 
            // ModAFG
            // 
            this.ModAFG.DataPropertyName = "ModAFG";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModAFG.DefaultCellStyle = dataGridViewCellStyle8;
            this.ModAFG.HeaderText = "AFG";
            this.ModAFG.Name = "ModAFG";
            this.ModAFG.ReadOnly = true;
            this.ModAFG.Width = 35;
            // 
            // ModSH
            // 
            this.ModSH.DataPropertyName = "ModSH";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ModSH.DefaultCellStyle = dataGridViewCellStyle9;
            this.ModSH.HeaderText = "SH";
            this.ModSH.Name = "ModSH";
            this.ModSH.ReadOnly = true;
            this.ModSH.Width = 35;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N1";
            this.weightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.weightDataGridViewTextBoxColumn.HeaderText = "Gewicht";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.ReadOnly = true;
            this.weightDataGridViewTextBoxColumn.Width = 60;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsDataGridViewTextBoxColumn.Width = 60;
            // 
            // armorBindingSource
            // 
            this.armorBindingSource.DataSource = typeof(Tesserakt.Armor);
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
            // ArmorManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 426);
            this.Controls.Add(this.dataGridViewArmor);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "ArmorManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rüstungen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArmorManagerForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArmor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonArmorDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonArmorAdd;
        private System.Windows.Forms.DataGridView dataGridViewArmor;
        private System.Windows.Forms.BindingSource armorBindingSource;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ToolStripButton toolStripButtonUsage;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelfSustaining;
        private System.Windows.Forms.DataGridViewImageColumn TypesImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Potential;
        private System.Windows.Forms.DataGridViewImageColumn EffectsImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Camouflage;
        private System.Windows.Forms.DataGridViewTextBoxColumn CamouflageLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModAGI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModBW;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModKK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModHAK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModAFG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModSH;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripComboBox filterCamouflage;
        private System.Windows.Forms.ToolStripButton checkBoxFilterCamouflage;
    }
}