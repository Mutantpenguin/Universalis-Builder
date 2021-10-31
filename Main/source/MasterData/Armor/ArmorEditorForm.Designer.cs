namespace Universalis
{
    partial class ArmorEditorForm
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
            this.textBoxPoints = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.numericUpDownWeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxDamageEffects = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxAdditiveProtection = new System.Windows.Forms.CheckBox();
            this.checkBoxSelfSustaining = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownProtection = new System.Windows.Forms.NumericUpDown();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonAddEffect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveEffect = new System.Windows.Forms.ToolStripButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridViewDamageEffects = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelProfileModifier = new System.Windows.Forms.Panel();
            this.textBoxProfileModifier = new System.Windows.Forms.TextBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonProfileMod = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonProfileModEditor = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.textBoxRules = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownAdditionalPoints = new System.Windows.Forms.NumericUpDown();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownDamageReduction = new System.Windows.Forms.NumericUpDown();
            this.armorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damageEffectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDamageEffects)).BeginInit();
            this.panel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProtection)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDamageEffects)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelProfileModifier.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdditionalPoints)).BeginInit();
            this.toolStrip6.SuspendLayout();
            this.toolStrip7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDamageReduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damageEffectsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.textBoxPoints);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 39);
            this.panel1.TabIndex = 1;
            // 
            // textBoxPoints
            // 
            this.textBoxPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPoints.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.armorBindingSource, "Points", true));
            this.textBoxPoints.Location = new System.Drawing.Point(425, 16);
            this.textBoxPoints.Name = "textBoxPoints";
            this.textBoxPoints.ReadOnly = true;
            this.textBoxPoints.Size = new System.Drawing.Size(56, 20);
            this.textBoxPoints.TabIndex = 34;
            this.textBoxPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Punkte";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.armorBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxName.Location = new System.Drawing.Point(3, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(416, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // numericUpDownWeight
            // 
            this.numericUpDownWeight.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.armorBindingSource, "Weight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownWeight.DecimalPlaces = 1;
            this.numericUpDownWeight.Location = new System.Drawing.Point(108, 80);
            this.numericUpDownWeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownWeight.Name = "numericUpDownWeight";
            this.numericUpDownWeight.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownWeight.TabIndex = 10;
            this.numericUpDownWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gewicht";
            // 
            // pictureBoxDamageEffects
            // 
            this.pictureBoxDamageEffects.BackColor = System.Drawing.Color.White;
            this.pictureBoxDamageEffects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDamageEffects.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxDamageEffects.Location = new System.Drawing.Point(0, 25);
            this.pictureBoxDamageEffects.MaximumSize = new System.Drawing.Size(1000, 24);
            this.pictureBoxDamageEffects.MinimumSize = new System.Drawing.Size(2, 24);
            this.pictureBoxDamageEffects.Name = "pictureBoxDamageEffects";
            this.pictureBoxDamageEffects.Size = new System.Drawing.Size(236, 24);
            this.pictureBoxDamageEffects.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDamageEffects.TabIndex = 21;
            this.pictureBoxDamageEffects.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.textBoxDescription);
            this.panel4.Controls.Add(this.toolStrip1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 397);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(484, 98);
            this.panel4.TabIndex = 5;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.armorBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 25);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(484, 73);
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
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.numericUpDownDamageReduction);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.checkBoxAdditiveProtection);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.numericUpDownWeight);
            this.panel3.Controls.Add(this.checkBoxSelfSustaining);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.numericUpDownProtection);
            this.panel3.Controls.Add(this.toolStrip2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 149);
            this.panel3.TabIndex = 6;
            // 
            // checkBoxAdditiveProtection
            // 
            this.checkBoxAdditiveProtection.AutoSize = true;
            this.checkBoxAdditiveProtection.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.armorBindingSource, "AdditiveProtection", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxAdditiveProtection.Location = new System.Drawing.Point(149, 30);
            this.checkBoxAdditiveProtection.Name = "checkBoxAdditiveProtection";
            this.checkBoxAdditiveProtection.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAdditiveProtection.TabIndex = 44;
            this.toolTip.SetToolTip(this.checkBoxAdditiveProtection, "Additiver Schutz");
            // 
            // checkBoxSelfSustaining
            // 
            this.checkBoxSelfSustaining.AutoSize = true;
            this.checkBoxSelfSustaining.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.armorBindingSource, "SelfSustaining", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxSelfSustaining.Location = new System.Drawing.Point(108, 106);
            this.checkBoxSelfSustaining.Name = "checkBoxSelfSustaining";
            this.checkBoxSelfSustaining.Size = new System.Drawing.Size(91, 17);
            this.checkBoxSelfSustaining.TabIndex = 32;
            this.checkBoxSelfSustaining.Text = "Selbsttragend";
            this.checkBoxSelfSustaining.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Schutz";
            // 
            // numericUpDownProtection
            // 
            this.numericUpDownProtection.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.armorBindingSource, "Protection", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownProtection.Location = new System.Drawing.Point(108, 28);
            this.numericUpDownProtection.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownProtection.Name = "numericUpDownProtection";
            this.numericUpDownProtection.Size = new System.Drawing.Size(35, 20);
            this.numericUpDownProtection.TabIndex = 30;
            this.numericUpDownProtection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(236, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel2.Text = "Werte";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripButtonAddEffect,
            this.toolStripButtonRemoveEffect});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(236, 25);
            this.toolStrip3.TabIndex = 28;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel3.Text = "Effekte";
            // 
            // toolStripButtonAddEffect
            // 
            this.toolStripButtonAddEffect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAddEffect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddEffect.Image = global::Universalis.Properties.Resources.plus;
            this.toolStripButtonAddEffect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddEffect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddEffect.Name = "toolStripButtonAddEffect";
            this.toolStripButtonAddEffect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddEffect.Text = "Effekt hinzufügen";
            this.toolStripButtonAddEffect.Click += new System.EventHandler(this.toolStripButtonAddEffect_Click);
            // 
            // toolStripButtonRemoveEffect
            // 
            this.toolStripButtonRemoveEffect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonRemoveEffect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemoveEffect.Image = global::Universalis.Properties.Resources.trash;
            this.toolStripButtonRemoveEffect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRemoveEffect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveEffect.Name = "toolStripButtonRemoveEffect";
            this.toolStripButtonRemoveEffect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRemoveEffect.Text = "Effekt entfernen";
            this.toolStripButtonRemoveEffect.Click += new System.EventHandler(this.toolStripButtonRemoveEffect_Click);
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.Controls.Add(this.dataGridViewDamageEffects);
            this.panel6.Controls.Add(this.pictureBoxDamageEffects);
            this.panel6.Controls.Add(this.toolStrip3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(245, 3);
            this.panel6.MinimumSize = new System.Drawing.Size(20, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(236, 149);
            this.panel6.TabIndex = 29;
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
            this.nameDataGridViewTextBoxColumn});
            this.dataGridViewDamageEffects.DataSource = this.damageEffectsBindingSource;
            this.dataGridViewDamageEffects.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewDamageEffects.Location = new System.Drawing.Point(0, 49);
            this.dataGridViewDamageEffects.MinimumSize = new System.Drawing.Size(0, 90);
            this.dataGridViewDamageEffects.MultiSelect = false;
            this.dataGridViewDamageEffects.Name = "dataGridViewDamageEffects";
            this.dataGridViewDamageEffects.ReadOnly = true;
            this.dataGridViewDamageEffects.RowHeadersVisible = false;
            this.dataGridViewDamageEffects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDamageEffects.Size = new System.Drawing.Size(236, 100);
            this.dataGridViewDamageEffects.TabIndex = 28;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 64);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(484, 155);
            this.tableLayoutPanel3.TabIndex = 32;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.panelProfileModifier);
            this.panel5.Controls.Add(this.toolStrip4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 343);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(484, 54);
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
            this.panelProfileModifier.Size = new System.Drawing.Size(484, 29);
            this.panelProfileModifier.TabIndex = 46;
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
            this.toolStripLabel4,
            this.toolStripButtonProfileModEditor});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(484, 25);
            this.toolStrip4.TabIndex = 0;
            this.toolStrip4.Text = "toolStrip4";
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
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(115, 22);
            this.toolStripLabel4.Text = "Profil-Modifikatoren";
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 64);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(484, 0);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // panel14
            // 
            this.panel14.AutoSize = true;
            this.panel14.Controls.Add(this.textBoxRules);
            this.panel14.Controls.Add(this.panel2);
            this.panel14.Controls.Add(this.toolStrip6);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 219);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(484, 124);
            this.panel14.TabIndex = 6;
            // 
            // textBoxRules
            // 
            this.textBoxRules.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.armorBindingSource, "Rules", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 26);
            this.panel2.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Zusatzpunkte";
            // 
            // numericUpDownAdditionalPoints
            // 
            this.numericUpDownAdditionalPoints.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.armorBindingSource, "AdditionalPoints", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.numericUpDownAdditionalPoints.TabIndex = 44;
            this.numericUpDownAdditionalPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAdditionalPoints.ValueChanged += new System.EventHandler(this.numericUpDownAdditionalPoints_ValueChanged);
            // 
            // toolStrip6
            // 
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6});
            this.toolStrip6.Location = new System.Drawing.Point(0, 0);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(484, 25);
            this.toolStrip6.TabIndex = 0;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel6.Text = "Sonderregeln";
            // 
            // toolStrip7
            // 
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave});
            this.toolStrip7.Location = new System.Drawing.Point(0, 0);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Size = new System.Drawing.Size(484, 25);
            this.toolStrip7.TabIndex = 33;
            this.toolStrip7.Text = "toolStrip7";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Schadensreduktion";
            // 
            // numericUpDownDamageReduction
            // 
            this.numericUpDownDamageReduction.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.armorBindingSource, "DamageReduction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownDamageReduction.Location = new System.Drawing.Point(108, 54);
            this.numericUpDownDamageReduction.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownDamageReduction.Name = "numericUpDownDamageReduction";
            this.numericUpDownDamageReduction.Size = new System.Drawing.Size(35, 20);
            this.numericUpDownDamageReduction.TabIndex = 46;
            this.numericUpDownDamageReduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // armorBindingSource
            // 
            this.armorBindingSource.DataSource = typeof(Universalis.Armor);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // damageEffectsBindingSource
            // 
            this.damageEffectsBindingSource.DataSource = typeof(Universalis.DamageEffect);
            // 
            // ArmorEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 522);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip7);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(500, 39);
            this.Name = "ArmorEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rüstungs Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArmorEditorForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArmorEditorForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDamageEffects)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProtection)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDamageEffects)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelProfileModifier.ResumeLayout(false);
            this.panelProfileModifier.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdditionalPoints)).EndInit();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDamageReduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damageEffectsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.BindingSource armorBindingSource;
        private System.Windows.Forms.PictureBox pictureBoxDamageEffects;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveEffect;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddEffect;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridViewDamageEffects;
        private System.Windows.Forms.BindingSource damageEffectsBindingSource;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButtonProfileMod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownProtection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TextBox textBoxRules;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.CheckBox checkBoxSelfSustaining;
        private System.Windows.Forms.NumericUpDown numericUpDownWeight;
        private System.Windows.Forms.TextBox textBoxPoints;
        private System.Windows.Forms.NumericUpDown numericUpDownAdditionalPoints;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBoxAdditiveProtection;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton toolStripButtonProfileModEditor;
        private System.Windows.Forms.TextBox textBoxProfileModifier;
        private System.Windows.Forms.Panel panelProfileModifier;
        private System.Windows.Forms.NumericUpDown numericUpDownDamageReduction;
        private System.Windows.Forms.Label label4;
    }
}