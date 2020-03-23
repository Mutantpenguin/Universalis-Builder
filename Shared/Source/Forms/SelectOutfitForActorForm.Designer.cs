namespace Universalis
{
    partial class SelectOutfitForActorForm
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
            this.dataGridViewOutfits = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actorOutfitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxActorName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutfits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actorOutfitBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOutfits
            // 
            this.dataGridViewOutfits.AllowUserToAddRows = false;
            this.dataGridViewOutfits.AllowUserToDeleteRows = false;
            this.dataGridViewOutfits.AllowUserToResizeColumns = false;
            this.dataGridViewOutfits.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewOutfits.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOutfits.AutoGenerateColumns = false;
            this.dataGridViewOutfits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutfits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.Points});
            this.dataGridViewOutfits.DataSource = this.actorOutfitBindingSource;
            this.dataGridViewOutfits.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewOutfits.Location = new System.Drawing.Point(0, 20);
            this.dataGridViewOutfits.MultiSelect = false;
            this.dataGridViewOutfits.Name = "dataGridViewOutfits";
            this.dataGridViewOutfits.ReadOnly = true;
            this.dataGridViewOutfits.RowHeadersVisible = false;
            this.dataGridViewOutfits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOutfits.Size = new System.Drawing.Size(254, 196);
            this.dataGridViewOutfits.TabIndex = 0;
            this.dataGridViewOutfits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOutfits_CellDoubleClick);
            this.dataGridViewOutfits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewOutfits_KeyDown);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Points
            // 
            this.Points.DataPropertyName = "Points";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Points.DefaultCellStyle = dataGridViewCellStyle2;
            this.Points.HeaderText = "Punkte";
            this.Points.Name = "Points";
            this.Points.ReadOnly = true;
            this.Points.Width = 50;
            // 
            // actorOutfitBindingSource
            // 
            this.actorOutfitBindingSource.DataSource = typeof(Universalis.Actor.ActorOutfit);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 29);
            this.panel1.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Image = global::Shared.Properties.Resources.tick;
            this.buttonOk.Location = new System.Drawing.Point(151, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 23);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "Übernehmen";
            this.buttonOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::Shared.Properties.Resources.cross_circle;
            this.buttonCancel.Location = new System.Drawing.Point(3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxActorName
            // 
            this.textBoxActorName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxActorName.Location = new System.Drawing.Point(0, 0);
            this.textBoxActorName.Name = "textBoxActorName";
            this.textBoxActorName.ReadOnly = true;
            this.textBoxActorName.Size = new System.Drawing.Size(254, 20);
            this.textBoxActorName.TabIndex = 2;
            // 
            // SelectOutfitForActorForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(254, 284);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewOutfits);
            this.Controls.Add(this.textBoxActorName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(260, 39);
            this.Name = "SelectOutfitForActorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Outfit auswählen";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutfits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actorOutfitBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOutfits;
        private System.Windows.Forms.BindingSource actorOutfitBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxActorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Points;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}