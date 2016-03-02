namespace Tesserakt
{
    partial class ActorDisplayForm
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
            this.dataGridViewActors = new System.Windows.Forms.DataGridView();
            this.factionIconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.iconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewActors
            // 
            this.dataGridViewActors.AllowUserToAddRows = false;
            this.dataGridViewActors.AllowUserToDeleteRows = false;
            this.dataGridViewActors.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewActors.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewActors.AutoGenerateColumns = false;
            this.dataGridViewActors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.factionIconDataGridViewImageColumn,
            this.iconDataGridViewImageColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridViewActors.DataSource = this.actorBindingSource;
            this.dataGridViewActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewActors.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewActors.Name = "dataGridViewActors";
            this.dataGridViewActors.ReadOnly = true;
            this.dataGridViewActors.RowHeadersVisible = false;
            this.dataGridViewActors.RowTemplate.Height = 40;
            this.dataGridViewActors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActors.Size = new System.Drawing.Size(372, 354);
            this.dataGridViewActors.TabIndex = 1;
            this.dataGridViewActors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewActors_CellDoubleClick);
            // 
            // factionIconDataGridViewImageColumn
            // 
            this.factionIconDataGridViewImageColumn.DataPropertyName = "FactionIcon";
            this.factionIconDataGridViewImageColumn.HeaderText = "";
            this.factionIconDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.factionIconDataGridViewImageColumn.Name = "factionIconDataGridViewImageColumn";
            this.factionIconDataGridViewImageColumn.ReadOnly = true;
            this.factionIconDataGridViewImageColumn.Width = 40;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actorBindingSource
            // 
            this.actorBindingSource.DataSource = typeof(Tesserakt.Actor);
            // 
            // ActorDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 354);
            this.Controls.Add(this.dataGridViewActors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActorDisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wird von folgenden Modellen verwendet:";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActorDisplayForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewActors;
        private System.Windows.Forms.BindingSource actorBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn factionIconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}