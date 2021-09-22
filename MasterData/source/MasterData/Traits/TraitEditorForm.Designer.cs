namespace Universalis
{
    partial class TraitEditorForm
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
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDownAP = new System.Windows.Forms.NumericUpDown();
            this.textBoxPoints = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxUseOnce = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxRules = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonInsertLevelPlaceholder = new System.Windows.Forms.Button();
            this.numericUpDownAdditionalPoints = new System.Windows.Forms.NumericUpDown();
            this.labelMaxLevel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownMaxLevel = new System.Windows.Forms.NumericUpDown();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelProfileModifier = new System.Windows.Forms.Panel();
            this.textBoxProfileModifier = new System.Windows.Forms.TextBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.traitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripButtonProfileMod = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonProfileModEditor = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAP)).BeginInit();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdditionalPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLevel)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelProfileModifier.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.numericUpDownAP);
            this.panel1.Controls.Add(this.textBoxPoints);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.checkBoxUseOnce);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 65);
            this.panel1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "AP";
            // 
            // numericUpDownAP
            // 
            this.numericUpDownAP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.traitBindingSource, "AP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownAP.Location = new System.Drawing.Point(3, 42);
            this.numericUpDownAP.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownAP.Name = "numericUpDownAP";
            this.numericUpDownAP.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownAP.TabIndex = 38;
            this.numericUpDownAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxPoints
            // 
            this.textBoxPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPoints.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traitBindingSource, "PointsString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxPoints.Location = new System.Drawing.Point(351, 16);
            this.textBoxPoints.Name = "textBoxPoints";
            this.textBoxPoints.ReadOnly = true;
            this.textBoxPoints.Size = new System.Drawing.Size(80, 20);
            this.textBoxPoints.TabIndex = 37;
            this.textBoxPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxPoints, "pro Modell");
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Punkte";
            // 
            // checkBoxUseOnce
            // 
            this.checkBoxUseOnce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxUseOnce.AutoSize = true;
            this.checkBoxUseOnce.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.traitBindingSource, "UseOnce", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxUseOnce.Location = new System.Drawing.Point(95, 43);
            this.checkBoxUseOnce.Name = "checkBoxUseOnce";
            this.checkBoxUseOnce.Size = new System.Drawing.Size(95, 17);
            this.checkBoxUseOnce.TabIndex = 33;
            this.checkBoxUseOnce.Text = "Einmalnutzung";
            this.checkBoxUseOnce.UseVisualStyleBackColor = true;
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
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traitBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxName.Location = new System.Drawing.Point(3, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(342, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBoxDescription);
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 274);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(434, 187);
            this.panel3.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traitBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.textBoxRules);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.toolStrip2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 144);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(434, 130);
            this.panel4.TabIndex = 1;
            // 
            // textBoxRules
            // 
            this.textBoxRules.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traitBindingSource, "Rules", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxRules.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.traitBindingSource, "AdditionalPoints", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxRules.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxRules.Location = new System.Drawing.Point(0, 57);
            this.textBoxRules.Multiline = true;
            this.textBoxRules.Name = "textBoxRules";
            this.textBoxRules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRules.Size = new System.Drawing.Size(434, 73);
            this.textBoxRules.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.Controls.Add(this.buttonInsertLevelPlaceholder);
            this.panel6.Controls.Add(this.numericUpDownAdditionalPoints);
            this.panel6.Controls.Add(this.labelMaxLevel);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.numericUpDownMaxLevel);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 25);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(434, 32);
            this.panel6.TabIndex = 51;
            // 
            // buttonInsertLevelPlaceholder
            // 
            this.buttonInsertLevelPlaceholder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInsertLevelPlaceholder.Image = global::Universalis.Properties.Resources.baseline_post_add_black_18dp;
            this.buttonInsertLevelPlaceholder.Location = new System.Drawing.Point(405, 3);
            this.buttonInsertLevelPlaceholder.Name = "buttonInsertLevelPlaceholder";
            this.buttonInsertLevelPlaceholder.Size = new System.Drawing.Size(26, 26);
            this.buttonInsertLevelPlaceholder.TabIndex = 51;
            this.toolTip1.SetToolTip(this.buttonInsertLevelPlaceholder, "Platzhalter für Level einfügen");
            this.buttonInsertLevelPlaceholder.UseVisualStyleBackColor = true;
            this.buttonInsertLevelPlaceholder.Click += new System.EventHandler(this.buttonInsertLevelPlaceholder_Click);
            // 
            // numericUpDownAdditionalPoints
            // 
            this.numericUpDownAdditionalPoints.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.traitBindingSource, "AdditionalPoints", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownAdditionalPoints.Location = new System.Drawing.Point(3, 3);
            this.numericUpDownAdditionalPoints.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownAdditionalPoints.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownAdditionalPoints.Name = "numericUpDownAdditionalPoints";
            this.numericUpDownAdditionalPoints.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownAdditionalPoints.TabIndex = 47;
            this.numericUpDownAdditionalPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAdditionalPoints.ValueChanged += new System.EventHandler(this.numericUpDownAdditionalPoints_ValueChanged);
            // 
            // labelMaxLevel
            // 
            this.labelMaxLevel.AutoSize = true;
            this.labelMaxLevel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.traitBindingSource, "AdditionalPoints", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelMaxLevel.Location = new System.Drawing.Point(205, 5);
            this.labelMaxLevel.Name = "labelMaxLevel";
            this.labelMaxLevel.Size = new System.Drawing.Size(85, 13);
            this.labelMaxLevel.TabIndex = 50;
            this.labelMaxLevel.Text = "Maximales Level";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Zusatzpunkte";
            // 
            // numericUpDownMaxLevel
            // 
            this.numericUpDownMaxLevel.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.traitBindingSource, "MaxLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownMaxLevel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.traitBindingSource, "AdditionalPoints", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownMaxLevel.Location = new System.Drawing.Point(143, 3);
            this.numericUpDownMaxLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMaxLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxLevel.Name = "numericUpDownMaxLevel";
            this.numericUpDownMaxLevel.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownMaxLevel.TabIndex = 49;
            this.numericUpDownMaxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMaxLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.panelProfileModifier);
            this.panel5.Controls.Add(this.toolStrip4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(434, 54);
            this.panel5.TabIndex = 3;
            // 
            // panelProfileModifier
            // 
            this.panelProfileModifier.AutoSize = true;
            this.panelProfileModifier.Controls.Add(this.textBoxProfileModifier);
            this.panelProfileModifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProfileModifier.Location = new System.Drawing.Point(0, 25);
            this.panelProfileModifier.Name = "panelProfileModifier";
            this.panelProfileModifier.Padding = new System.Windows.Forms.Padding(5);
            this.panelProfileModifier.Size = new System.Drawing.Size(434, 29);
            this.panelProfileModifier.TabIndex = 47;
            // 
            // textBoxProfileModifier
            // 
            this.textBoxProfileModifier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxProfileModifier.Location = new System.Drawing.Point(6, 8);
            this.textBoxProfileModifier.Name = "textBoxProfileModifier";
            this.textBoxProfileModifier.ReadOnly = true;
            this.textBoxProfileModifier.Size = new System.Drawing.Size(472, 13);
            this.textBoxProfileModifier.TabIndex = 45;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonProfileMod,
            this.toolStripLabel3,
            this.toolStripButtonProfileModEditor});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(434, 25);
            this.toolStrip4.TabIndex = 0;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(115, 22);
            this.toolStripLabel3.Text = "Profil-Modifikatoren";
            // 
            // traitBindingSource
            // 
            this.traitBindingSource.DataSource = typeof(Universalis.Trait);
            // 
            // toolStripButtonProfileMod
            // 
            this.toolStripButtonProfileMod.CheckOnClick = true;
            this.toolStripButtonProfileMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonProfileMod.Image = global::Universalis.Properties.Resources.ui_check_box_uncheck;
            this.toolStripButtonProfileMod.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonProfileMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonProfileMod.Name = "toolStripButtonProfileMod";
            this.toolStripButtonProfileMod.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonProfileMod.Click += new System.EventHandler(this.toolStripButtonProfileMod_Click);
            // 
            // toolStripButtonProfileModEditor
            // 
            this.toolStripButtonProfileModEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonProfileModEditor.Image = global::Universalis.Properties.Resources.baseline_tune_black_18dp;
            this.toolStripButtonProfileModEditor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonProfileModEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonProfileModEditor.Name = "toolStripButtonProfileModEditor";
            this.toolStripButtonProfileModEditor.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonProfileModEditor.Text = "editieren";
            this.toolStripButtonProfileModEditor.Click += new System.EventHandler(this.toolStripButtonProfileModEditor_Click);
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
            // TraitEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(434, 529);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip3);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(450, 39);
            this.Name = "TraitEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Eigenschaften Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TraitEditorForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TraitEditorForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAP)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdditionalPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLevel)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelProfileModifier.ResumeLayout(false);
            this.panelProfileModifier.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traitBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource traitBindingSource;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxRules;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.CheckBox checkBoxUseOnce;
        private System.Windows.Forms.TextBox textBoxPoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownAdditionalPoints;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownAP;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelProfileModifier;
        private System.Windows.Forms.TextBox textBoxProfileModifier;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButtonProfileMod;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButtonProfileModEditor;
        private System.Windows.Forms.Label labelMaxLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxLevel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button buttonInsertLevelPlaceholder;
    }
}