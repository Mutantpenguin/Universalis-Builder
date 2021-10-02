namespace Universalis
{
    partial class EquipmentEditorForm
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
            this.checkBoxUnwieldy = new System.Windows.Forms.CheckBox();
            this.equipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxPoints = new System.Windows.Forms.TextBox();
            this.numericUpDownWeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxUseOnce = new System.Windows.Forms.CheckBox();
            this.numericUpDownAP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAdditionalPoints = new System.Windows.Forms.NumericUpDown();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelProfileModifier = new System.Windows.Forms.Panel();
            this.textBoxProfileModifier = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonProfileMod = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonProfileModEditor = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.textBoxRules = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdditionalPoints)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelProfileModifier.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.checkBoxUnwieldy);
            this.panel1.Controls.Add(this.textBoxPoints);
            this.panel1.Controls.Add(this.numericUpDownWeight);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 65);
            this.panel1.TabIndex = 0;
            // 
            // checkBoxUnwieldy
            // 
            this.checkBoxUnwieldy.AutoSize = true;
            this.checkBoxUnwieldy.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.equipmentBindingSource, "Unwieldy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxUnwieldy.Location = new System.Drawing.Point(117, 43);
            this.checkBoxUnwieldy.Name = "checkBoxUnwieldy";
            this.checkBoxUnwieldy.Size = new System.Drawing.Size(80, 17);
            this.checkBoxUnwieldy.TabIndex = 36;
            this.checkBoxUnwieldy.Text = "Unhandlich";
            this.checkBoxUnwieldy.UseVisualStyleBackColor = true;
            // 
            // equipmentBindingSource
            // 
            this.equipmentBindingSource.DataSource = typeof(Universalis.Equipment);
            // 
            // textBoxPoints
            // 
            this.textBoxPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPoints.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentBindingSource, "Points", true));
            this.textBoxPoints.Location = new System.Drawing.Point(422, 16);
            this.textBoxPoints.Name = "textBoxPoints";
            this.textBoxPoints.ReadOnly = true;
            this.textBoxPoints.Size = new System.Drawing.Size(56, 20);
            this.textBoxPoints.TabIndex = 35;
            this.textBoxPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownWeight
            // 
            this.numericUpDownWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownWeight.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.equipmentBindingSource, "Weight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownWeight.DecimalPlaces = 1;
            this.numericUpDownWeight.Location = new System.Drawing.Point(3, 42);
            this.numericUpDownWeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownWeight.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownWeight.Name = "numericUpDownWeight";
            this.numericUpDownWeight.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownWeight.TabIndex = 11;
            this.numericUpDownWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gewicht";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Punkte";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxName.Location = new System.Drawing.Point(3, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(413, 20);
            this.textBoxName.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(205, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "AP";
            // 
            // checkBoxUseOnce
            // 
            this.checkBoxUseOnce.AutoSize = true;
            this.checkBoxUseOnce.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.equipmentBindingSource, "UseOnce", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxUseOnce.Location = new System.Drawing.Point(242, 4);
            this.checkBoxUseOnce.Name = "checkBoxUseOnce";
            this.checkBoxUseOnce.Size = new System.Drawing.Size(95, 17);
            this.checkBoxUseOnce.TabIndex = 3;
            this.checkBoxUseOnce.Text = "Einmalnutzung";
            this.checkBoxUseOnce.UseVisualStyleBackColor = true;
            this.checkBoxUseOnce.CheckedChanged += new System.EventHandler(this.checkBoxUseOnce_CheckedChanged);
            // 
            // numericUpDownAP
            // 
            this.numericUpDownAP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.equipmentBindingSource, "AP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownAP.Location = new System.Drawing.Point(143, 3);
            this.numericUpDownAP.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownAP.Name = "numericUpDownAP";
            this.numericUpDownAP.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownAP.TabIndex = 13;
            this.numericUpDownAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAP.ValueChanged += new System.EventHandler(this.numericUpDownAP_ValueChanged);
            // 
            // numericUpDownAdditionalPoints
            // 
            this.numericUpDownAdditionalPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownAdditionalPoints.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.equipmentBindingSource, "AdditionalPoints", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.numericUpDownAdditionalPoints.TabIndex = 4;
            this.numericUpDownAdditionalPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAdditionalPoints.ValueChanged += new System.EventHandler(this.numericUpDownAdditionalPoints_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.panelProfileModifier);
            this.panel3.Controls.Add(this.toolStrip2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 214);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(484, 54);
            this.panel3.TabIndex = 2;
            // 
            // panelProfileModifier
            // 
            this.panelProfileModifier.AutoSize = true;
            this.panelProfileModifier.Controls.Add(this.textBoxProfileModifier);
            this.panelProfileModifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProfileModifier.Location = new System.Drawing.Point(0, 25);
            this.panelProfileModifier.Name = "panelProfileModifier";
            this.panelProfileModifier.Padding = new System.Windows.Forms.Padding(5);
            this.panelProfileModifier.Size = new System.Drawing.Size(484, 29);
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
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonProfileMod,
            this.toolStripLabel2,
            this.toolStripButtonProfileModEditor});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(484, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
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
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(115, 22);
            this.toolStripLabel2.Text = "Profil-Modifikatoren";
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
            // panel4
            // 
            this.panel4.Controls.Add(this.textBoxDescription);
            this.panel4.Controls.Add(this.toolStrip1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 268);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(484, 211);
            this.panel4.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 25);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(484, 186);
            this.textBoxDescription.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(484, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel1.Text = "Beschreibung";
            // 
            // panel11
            // 
            this.panel11.AutoSize = true;
            this.panel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel11.Controls.Add(this.textBoxRules);
            this.panel11.Controls.Add(this.panel2);
            this.panel11.Controls.Add(this.toolStrip3);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 90);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(484, 124);
            this.panel11.TabIndex = 4;
            // 
            // textBoxRules
            // 
            this.textBoxRules.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.equipmentBindingSource, "Rules", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxRules.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxRules.Location = new System.Drawing.Point(0, 51);
            this.textBoxRules.Multiline = true;
            this.textBoxRules.Name = "textBoxRules";
            this.textBoxRules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRules.Size = new System.Drawing.Size(484, 73);
            this.textBoxRules.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.numericUpDownAdditionalPoints);
            this.panel2.Controls.Add(this.checkBoxUseOnce);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.numericUpDownAP);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 26);
            this.panel2.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Zusatzpunkte";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(484, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel3.Text = "Sonderregeln";
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(484, 25);
            this.toolStrip4.TabIndex = 2;
            this.toolStrip4.Text = "toolStrip4";
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
            // EquipmentEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 577);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip4);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(500, 39);
            this.Name = "EquipmentEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ausrüstungs Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EquipmentEditorForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EquipmentEditorForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdditionalPoints)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelProfileModifier.ResumeLayout(false);
            this.panelProfileModifier.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.NumericUpDown numericUpDownAdditionalPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource equipmentBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonProfileMod;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox textBoxRules;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.NumericUpDown numericUpDownWeight;
        private System.Windows.Forms.CheckBox checkBoxUseOnce;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownAP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPoints;
        private System.Windows.Forms.CheckBox checkBoxUnwieldy;
        private System.Windows.Forms.ToolStripButton toolStripButtonProfileModEditor;
        private System.Windows.Forms.Panel panelProfileModifier;
        private System.Windows.Forms.TextBox textBoxProfileModifier;
    }
}