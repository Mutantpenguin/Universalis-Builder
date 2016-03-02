namespace Tesserakt
{
    partial class DamageTypeSelectionForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewDamageTypes = new System.Windows.Forms.DataGridView();
            this.getOriginalImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damageTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDamageTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damageTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 29);
            this.panel1.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Image = global::Tesserakt.Properties.Resources.tick;
            this.buttonOk.Location = new System.Drawing.Point(108, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Übernehmen";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::Tesserakt.Properties.Resources.cross_circle;
            this.buttonCancel.Location = new System.Drawing.Point(3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDamageTypes
            // 
            this.dataGridViewDamageTypes.AllowUserToAddRows = false;
            this.dataGridViewDamageTypes.AllowUserToDeleteRows = false;
            this.dataGridViewDamageTypes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewDamageTypes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDamageTypes.AutoGenerateColumns = false;
            this.dataGridViewDamageTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDamageTypes.ColumnHeadersVisible = false;
            this.dataGridViewDamageTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.getOriginalImageDataGridViewImageColumn,
            this.typeDataGridViewTextBoxColumn});
            this.dataGridViewDamageTypes.DataSource = this.damageTypeBindingSource;
            this.dataGridViewDamageTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDamageTypes.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDamageTypes.Name = "dataGridViewDamageTypes";
            this.dataGridViewDamageTypes.RowHeadersVisible = false;
            this.dataGridViewDamageTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDamageTypes.Size = new System.Drawing.Size(211, 118);
            this.dataGridViewDamageTypes.TabIndex = 1;
            this.dataGridViewDamageTypes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDamageTypes_CellDoubleClick);
            // 
            // getOriginalImageDataGridViewImageColumn
            // 
            this.getOriginalImageDataGridViewImageColumn.DataPropertyName = "GetOriginalImage";
            this.getOriginalImageDataGridViewImageColumn.HeaderText = "GetOriginalImage";
            this.getOriginalImageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.getOriginalImageDataGridViewImageColumn.Name = "getOriginalImageDataGridViewImageColumn";
            this.getOriginalImageDataGridViewImageColumn.ReadOnly = true;
            this.getOriginalImageDataGridViewImageColumn.Width = 22;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // damageTypeBindingSource
            // 
            this.damageTypeBindingSource.DataSource = typeof(Tesserakt.DamageType);
            // 
            // DamageTypeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(211, 147);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewDamageTypes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DamageTypeSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schadenstypauswahl";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDamageTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damageTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.DataGridView dataGridViewDamageTypes;
        private System.Windows.Forms.BindingSource damageTypeBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn getOriginalImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
    }
}