namespace Universalis
{
    partial class MasterDataMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonFactions = new System.Windows.Forms.Button();
            this.buttonTraits = new System.Windows.Forms.Button();
            this.buttonArchetypes = new System.Windows.Forms.Button();
            this.buttonWeapons = new System.Windows.Forms.Button();
            this.buttonArmor = new System.Windows.Forms.Button();
            this.buttonEquipment = new System.Windows.Forms.Button();
            this.buttonActors = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonDamageEffects = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonFactions, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTraits, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonArchetypes, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonWeapons, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonArmor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonEquipment, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonDamageEffects, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonActors, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 537);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // buttonFactions
            // 
            this.buttonFactions.AutoSize = true;
            this.buttonFactions.BackgroundImage = global::Universalis.Properties.Resources.factions;
            this.buttonFactions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonFactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFactions.Location = new System.Drawing.Point(3, 3);
            this.buttonFactions.Name = "buttonFactions";
            this.buttonFactions.Size = new System.Drawing.Size(312, 128);
            this.buttonFactions.TabIndex = 5;
            this.toolTip1.SetToolTip(this.buttonFactions, "Fraktionen");
            this.buttonFactions.UseVisualStyleBackColor = true;
            this.buttonFactions.Click += new System.EventHandler(this.buttonFactions_Click);
            // 
            // buttonTraits
            // 
            this.buttonTraits.AutoSize = true;
            this.buttonTraits.BackgroundImage = global::Universalis.Properties.Resources.traits;
            this.buttonTraits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonTraits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTraits.Location = new System.Drawing.Point(3, 271);
            this.buttonTraits.Name = "buttonTraits";
            this.buttonTraits.Size = new System.Drawing.Size(312, 128);
            this.buttonTraits.TabIndex = 4;
            this.toolTip1.SetToolTip(this.buttonTraits, "Eigenschaften");
            this.buttonTraits.UseVisualStyleBackColor = true;
            this.buttonTraits.Click += new System.EventHandler(this.buttonTraits_Click);
            // 
            // buttonArchetypes
            // 
            this.buttonArchetypes.AutoSize = true;
            this.buttonArchetypes.BackgroundImage = global::Universalis.Properties.Resources.archetypes;
            this.buttonArchetypes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonArchetypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonArchetypes.Location = new System.Drawing.Point(321, 3);
            this.buttonArchetypes.Name = "buttonArchetypes";
            this.buttonArchetypes.Size = new System.Drawing.Size(312, 128);
            this.buttonArchetypes.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonArchetypes, "Archetypen");
            this.buttonArchetypes.UseVisualStyleBackColor = true;
            this.buttonArchetypes.Click += new System.EventHandler(this.buttonArchetypes_Click);
            // 
            // buttonWeapons
            // 
            this.buttonWeapons.AutoSize = true;
            this.buttonWeapons.BackgroundImage = global::Universalis.Properties.Resources.weapons;
            this.buttonWeapons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonWeapons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonWeapons.Location = new System.Drawing.Point(3, 137);
            this.buttonWeapons.Name = "buttonWeapons";
            this.buttonWeapons.Size = new System.Drawing.Size(312, 128);
            this.buttonWeapons.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonWeapons, "Waffen");
            this.buttonWeapons.UseVisualStyleBackColor = true;
            this.buttonWeapons.Click += new System.EventHandler(this.buttonWeapons_Click);
            // 
            // buttonArmor
            // 
            this.buttonArmor.AutoSize = true;
            this.buttonArmor.BackgroundImage = global::Universalis.Properties.Resources.armor;
            this.buttonArmor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonArmor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonArmor.Location = new System.Drawing.Point(321, 137);
            this.buttonArmor.Name = "buttonArmor";
            this.buttonArmor.Size = new System.Drawing.Size(312, 128);
            this.buttonArmor.TabIndex = 2;
            this.toolTip1.SetToolTip(this.buttonArmor, "Rüstungen");
            this.buttonArmor.UseVisualStyleBackColor = true;
            this.buttonArmor.Click += new System.EventHandler(this.buttonArmor_Click);
            // 
            // buttonEquipment
            // 
            this.buttonEquipment.AutoSize = true;
            this.buttonEquipment.BackgroundImage = global::Universalis.Properties.Resources.equipment;
            this.buttonEquipment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEquipment.Location = new System.Drawing.Point(321, 271);
            this.buttonEquipment.Name = "buttonEquipment";
            this.buttonEquipment.Size = new System.Drawing.Size(312, 128);
            this.buttonEquipment.TabIndex = 3;
            this.toolTip1.SetToolTip(this.buttonEquipment, "Ausrüstung");
            this.buttonEquipment.UseVisualStyleBackColor = true;
            this.buttonEquipment.Click += new System.EventHandler(this.buttonEquipment_Click);
            // 
            // buttonActors
            // 
            this.buttonActors.AutoSize = true;
            this.buttonActors.BackgroundImage = global::Universalis.Properties.Resources.models;
            this.buttonActors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonActors.Location = new System.Drawing.Point(3, 405);
            this.buttonActors.Name = "buttonActors";
            this.buttonActors.Size = new System.Drawing.Size(312, 129);
            this.buttonActors.TabIndex = 0;
            this.toolTip1.SetToolTip(this.buttonActors, "Modelle");
            this.buttonActors.Click += new System.EventHandler(this.buttonActors_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonQuit.Image = global::Universalis.Properties.Resources.cross_circle;
            this.buttonQuit.Location = new System.Drawing.Point(0, 537);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(636, 34);
            this.buttonQuit.TabIndex = 6;
            this.buttonQuit.Text = "&Beenden";
            this.buttonQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonDamageEffects
            // 
            this.buttonDamageEffects.AutoSize = true;
            this.buttonDamageEffects.BackgroundImage = global::Universalis.Properties.Resources.equipment;
            this.buttonDamageEffects.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDamageEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDamageEffects.Location = new System.Drawing.Point(321, 405);
            this.buttonDamageEffects.Name = "buttonDamageEffects";
            this.buttonDamageEffects.Size = new System.Drawing.Size(312, 129);
            this.buttonDamageEffects.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonDamageEffects, "Schadenseffekte");
            this.buttonDamageEffects.UseVisualStyleBackColor = true;
            this.buttonDamageEffects.Click += new System.EventHandler(this.buttonDamageEffects_Click);
            // 
            // MasterDataMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.buttonQuit;
            this.ClientSize = new System.Drawing.Size(636, 571);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MasterDataMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterDataMainForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonWeapons;
        private System.Windows.Forms.Button buttonArmor;
        private System.Windows.Forms.Button buttonTraits;
        private System.Windows.Forms.Button buttonEquipment;
        private System.Windows.Forms.Button buttonFactions;
        private System.Windows.Forms.Button buttonActors;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonArchetypes;
        private System.Windows.Forms.Button buttonDamageEffects;
    }
}