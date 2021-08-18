namespace Universalis
{
    partial class GroupEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBoxFactionIcon = new System.Windows.Forms.PictureBox();
            this.pictureBoxGroupIcon = new System.Windows.Forms.PictureBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridViewGroupActors = new System.Windows.Forms.DataGridView();
            this.groupActorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupActorIconDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupActorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupActorPointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupActorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonActorsAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonActorsRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonActorsCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.pictureBoxCard = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFactionIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroupIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupActors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupActorBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxCard);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(1264, 639);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 639);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.pictureBoxFactionIcon);
            this.panel7.Controls.Add(this.pictureBoxGroupIcon);
            this.panel7.Controls.Add(this.textBoxName);
            this.panel7.Controls.Add(this.textBoxCost);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(290, 66);
            this.panel7.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(200, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "Punkte";
            // 
            // pictureBoxFactionIcon
            // 
            this.pictureBoxFactionIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFactionIcon.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxFactionIcon.Name = "pictureBoxFactionIcon";
            this.pictureBoxFactionIcon.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxFactionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFactionIcon.TabIndex = 48;
            this.pictureBoxFactionIcon.TabStop = false;
            // 
            // pictureBoxGroupIcon
            // 
            this.pictureBoxGroupIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGroupIcon.Location = new System.Drawing.Point(69, 3);
            this.pictureBoxGroupIcon.Name = "pictureBoxGroupIcon";
            this.pictureBoxGroupIcon.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxGroupIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGroupIcon.TabIndex = 7;
            this.pictureBoxGroupIcon.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBoxGroupIcon, "Icon der Gruppe");
            this.pictureBoxGroupIcon.DoubleClick += new System.EventHandler(this.pictureBoxGroupIcon_DoubleClick);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(135, 3);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(155, 20);
            this.textBoxName.TabIndex = 14;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(135, 29);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.ReadOnly = true;
            this.textBoxCost.Size = new System.Drawing.Size(59, 20);
            this.textBoxCost.TabIndex = 29;
            this.textBoxCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxDescription);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 107);
            this.panel2.TabIndex = 9;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 25);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(290, 82);
            this.textBoxDescription.TabIndex = 7;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(290, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel2.Text = "Beschreibung";
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.dataGridViewGroupActors);
            this.panel5.Controls.Add(this.toolStrip1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 188);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(290, 448);
            this.panel5.TabIndex = 5;
            // 
            // dataGridViewGroupActors
            // 
            this.dataGridViewGroupActors.AllowUserToAddRows = false;
            this.dataGridViewGroupActors.AllowUserToDeleteRows = false;
            this.dataGridViewGroupActors.AllowUserToOrderColumns = true;
            this.dataGridViewGroupActors.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewGroupActors.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGroupActors.AutoGenerateColumns = false;
            this.dataGridViewGroupActors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroupActors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupActorIdDataGridViewTextBoxColumn,
            this.groupActorIconDataGridViewTextBoxColumn,
            this.groupActorNameDataGridViewTextBoxColumn,
            this.groupActorPointsDataGridViewTextBoxColumn});
            this.dataGridViewGroupActors.DataSource = this.groupActorBindingSource;
            this.dataGridViewGroupActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGroupActors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridViewGroupActors.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewGroupActors.MultiSelect = false;
            this.dataGridViewGroupActors.Name = "dataGridViewGroupActors";
            this.dataGridViewGroupActors.ReadOnly = true;
            this.dataGridViewGroupActors.RowHeadersVisible = false;
            this.dataGridViewGroupActors.RowTemplate.Height = 40;
            this.dataGridViewGroupActors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroupActors.Size = new System.Drawing.Size(290, 423);
            this.dataGridViewGroupActors.TabIndex = 5;
            this.dataGridViewGroupActors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGroupActors_CellDoubleClick);
            this.dataGridViewGroupActors.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewGroupActors_CellFormatting);
            this.dataGridViewGroupActors.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewActors_CellPainting);
            this.dataGridViewGroupActors.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewActors_CellToolTipTextNeeded);
            this.dataGridViewGroupActors.SelectionChanged += new System.EventHandler(this.dataGridViewActors_SelectionChanged);
            this.dataGridViewGroupActors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewActors_KeyDown);
            // 
            // groupActorIdDataGridViewTextBoxColumn
            // 
            this.groupActorIdDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.groupActorIdDataGridViewTextBoxColumn.HeaderText = "ID";
            this.groupActorIdDataGridViewTextBoxColumn.Name = "groupActorIdDataGridViewTextBoxColumn";
            this.groupActorIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupActorIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // groupActorIconDataGridViewTextBoxColumn
            // 
            this.groupActorIconDataGridViewTextBoxColumn.DataPropertyName = "Actor.Icon";
            this.groupActorIconDataGridViewTextBoxColumn.HeaderText = "";
            this.groupActorIconDataGridViewTextBoxColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.groupActorIconDataGridViewTextBoxColumn.Name = "groupActorIconDataGridViewTextBoxColumn";
            this.groupActorIconDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupActorIconDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.groupActorIconDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.groupActorIconDataGridViewTextBoxColumn.Width = 40;
            // 
            // groupActorNameDataGridViewTextBoxColumn
            // 
            this.groupActorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.groupActorNameDataGridViewTextBoxColumn.DataPropertyName = "Actor.Name";
            this.groupActorNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.groupActorNameDataGridViewTextBoxColumn.Name = "groupActorNameDataGridViewTextBoxColumn";
            this.groupActorNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupActorPointsDataGridViewTextBoxColumn
            // 
            this.groupActorPointsDataGridViewTextBoxColumn.DataPropertyName = "Actor.Points";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.groupActorPointsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.groupActorPointsDataGridViewTextBoxColumn.HeaderText = "Punkte";
            this.groupActorPointsDataGridViewTextBoxColumn.Name = "groupActorPointsDataGridViewTextBoxColumn";
            this.groupActorPointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupActorPointsDataGridViewTextBoxColumn.Width = 50;
            // 
            // groupActorBindingSource
            // 
            this.groupActorBindingSource.DataSource = typeof(Universalis.Group.GroupActor);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonActorsAdd,
            this.toolStripButtonActorsRemove,
            this.toolStripButtonActorsCopy,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(290, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonActorsAdd
            // 
            this.toolStripButtonActorsAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonActorsAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonActorsAdd.Image = global::Universalis.Properties.Resources.plus;
            this.toolStripButtonActorsAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonActorsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonActorsAdd.Name = "toolStripButtonActorsAdd";
            this.toolStripButtonActorsAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonActorsAdd.ToolTipText = "Modell hinzufügen";
            this.toolStripButtonActorsAdd.Click += new System.EventHandler(this.toolStripButtonActorsAdd_Click);
            // 
            // toolStripButtonActorsRemove
            // 
            this.toolStripButtonActorsRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonActorsRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonActorsRemove.Image = global::Universalis.Properties.Resources.trash;
            this.toolStripButtonActorsRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonActorsRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonActorsRemove.Name = "toolStripButtonActorsRemove";
            this.toolStripButtonActorsRemove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonActorsRemove.ToolTipText = "Modell entfernen";
            this.toolStripButtonActorsRemove.Click += new System.EventHandler(this.toolStripButtonActorsRemove_Click);
            // 
            // toolStripButtonActorsCopy
            // 
            this.toolStripButtonActorsCopy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonActorsCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonActorsCopy.Image = global::Universalis.Properties.Resources.copy;
            this.toolStripButtonActorsCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonActorsCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonActorsCopy.Name = "toolStripButtonActorsCopy";
            this.toolStripButtonActorsCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonActorsCopy.ToolTipText = "Ausrüstung kopieren";
            this.toolStripButtonActorsCopy.Click += new System.EventHandler(this.toolStripButtonActorsCopy_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel1.Text = "Modelle";
            // 
            // pictureBoxCard
            // 
            this.pictureBoxCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCard.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCard.Name = "pictureBoxCard";
            this.pictureBoxCard.Size = new System.Drawing.Size(964, 639);
            this.pictureBoxCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCard.TabIndex = 0;
            this.pictureBoxCard.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.buttonBack);
            this.panel3.Controls.Add(this.buttonSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 639);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1264, 32);
            this.panel3.TabIndex = 1;
            // 
            // buttonBack
            // 
            this.buttonBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonBack.Image = global::Universalis.Properties.Resources.cross_circle;
            this.buttonBack.Location = new System.Drawing.Point(3, 3);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(100, 26);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "&Zurück";
            this.buttonBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Image = global::Universalis.Properties.Resources.disk;
            this.buttonSave.Location = new System.Drawing.Point(1161, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 26);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "&Speichern";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 1000;
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 1000;
            this.toolTip.ReshowDelay = 500;
            this.toolTip.ShowAlways = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Actor";
            this.dataGridViewTextBoxColumn1.HeaderText = "Actor";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Actor";
            this.dataGridViewTextBoxColumn2.HeaderText = "Actor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // GroupEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonBack;
            this.ClientSize = new System.Drawing.Size(1264, 671);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Name = "GroupEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gruppe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupEditorForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFactionIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroupIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroupActors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupActorBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCard)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewGroupActors;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.PictureBox pictureBoxCard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.BindingSource groupActorBindingSource;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox pictureBoxGroupIcon;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonActorsAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonActorsRemove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.PictureBox pictureBoxFactionIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupActorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn groupActorIconDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupActorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupActorPointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton toolStripButtonActorsCopy;
    }
}