namespace Tesserakt
{
    partial class FactionEditorForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.factionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBoxFactionIcon = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonUsage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFactionIcon)).BeginInit();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.comboBoxType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.pictureBoxFactionIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 106);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(109, 45);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(222, 21);
            this.comboBoxType.TabIndex = 32;
            this.comboBoxType.SelectionChangeCommitted += new System.EventHandler(this.comboBoxType_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.factionBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxName.Location = new System.Drawing.Point(109, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(222, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // factionBindingSource
            // 
            this.factionBindingSource.DataSource = typeof(Tesserakt.Faction);
            // 
            // pictureBoxFactionIcon
            // 
            this.pictureBoxFactionIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFactionIcon.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.factionBindingSource, "Icon", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pictureBoxFactionIcon.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxFactionIcon.Name = "pictureBoxFactionIcon";
            this.pictureBoxFactionIcon.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxFactionIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFactionIcon.TabIndex = 0;
            this.pictureBoxFactionIcon.TabStop = false;
            this.pictureBoxFactionIcon.DoubleClick += new System.EventHandler(this.pictureBoxIcon_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBoxDescription);
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 321);
            this.panel3.TabIndex = 2;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.factionBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 25);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(343, 296);
            this.textBoxDescription.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(343, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel1.Text = "Beschreibung";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonUsage,
            this.toolStripButtonSave});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(343, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
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
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::Tesserakt.Properties.Resources.disk;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(79, 22);
            this.toolStripButtonSave.Text = "Speichern";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // FactionEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 452);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.KeyPreview = true;
            this.Name = "FactionEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fraktions Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FactionEditorForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FactionEditorForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFactionIcon)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.PictureBox pictureBoxFactionIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource factionBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ToolStripButton toolStripButtonUsage;
    }
}