namespace Universalis
{
    partial class DamageEffectSelectionForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.dataGridViewDamageEffects = new System.Windows.Forms.DataGridView();
            this.iconDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rulesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damageEffectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDamageEffects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damageEffectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 32);
            this.panel1.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::Universalis.Properties.Resources.cross_circle;
            this.buttonCancel.Location = new System.Drawing.Point(3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 26);
            this.buttonCancel.TabIndex = 1;
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
            this.buttonOk.Location = new System.Drawing.Point(412, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 26);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Übernehmen";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
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
            this.dataGridViewDamageEffects.ColumnHeadersVisible = false;
            this.dataGridViewDamageEffects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iconDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.rulesDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn});
            this.dataGridViewDamageEffects.DataSource = this.damageEffectBindingSource;
            this.dataGridViewDamageEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDamageEffects.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDamageEffects.Name = "dataGridViewDamageEffects";
            this.dataGridViewDamageEffects.ReadOnly = true;
            this.dataGridViewDamageEffects.RowHeadersVisible = false;
            this.dataGridViewDamageEffects.RowTemplate.Height = 40;
            this.dataGridViewDamageEffects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDamageEffects.Size = new System.Drawing.Size(515, 394);
            this.dataGridViewDamageEffects.TabIndex = 0;
            this.dataGridViewDamageEffects.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // iconDataGridViewTextBoxColumn
            // 
            this.iconDataGridViewTextBoxColumn.DataPropertyName = "Icon";
            this.iconDataGridViewTextBoxColumn.HeaderText = "Icon";
            this.iconDataGridViewTextBoxColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.iconDataGridViewTextBoxColumn.Name = "iconDataGridViewTextBoxColumn";
            this.iconDataGridViewTextBoxColumn.ReadOnly = true;
            this.iconDataGridViewTextBoxColumn.Width = 40;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Bezeichnung";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 120;
            // 
            // rulesDataGridViewTextBoxColumn
            // 
            this.rulesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rulesDataGridViewTextBoxColumn.DataPropertyName = "Rules";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rulesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.rulesDataGridViewTextBoxColumn.HeaderText = "Rules";
            this.rulesDataGridViewTextBoxColumn.Name = "rulesDataGridViewTextBoxColumn";
            this.rulesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsDataGridViewTextBoxColumn.Width = 30;
            // 
            // damageEffectBindingSource
            // 
            this.damageEffectBindingSource.DataSource = typeof(Universalis.DamageEffect);
            // 
            // DamageEffectSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(515, 426);
            this.Controls.Add(this.dataGridViewDamageEffects);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "DamageEffectSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schadenseffekte";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDamageEffects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damageEffectBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.DataGridView dataGridViewDamageEffects;
        private System.Windows.Forms.BindingSource damageEffectBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rulesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
    }
}