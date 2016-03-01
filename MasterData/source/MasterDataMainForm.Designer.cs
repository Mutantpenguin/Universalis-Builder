namespace Tesserakt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterDataMainForm));
            this.buttonWeapons = new System.Windows.Forms.Button();
            this.buttonArmor = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonTraits = new System.Windows.Forms.Button();
            this.buttonEquipment = new System.Windows.Forms.Button();
            this.buttonFactions = new System.Windows.Forms.Button();
            this.buttonActors = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonWeapons
            // 
            this.buttonWeapons.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonWeapons.Image = ((System.Drawing.Image)(resources.GetObject("buttonWeapons.Image")));
            this.buttonWeapons.Location = new System.Drawing.Point(0, 34);
            this.buttonWeapons.Name = "buttonWeapons";
            this.buttonWeapons.Size = new System.Drawing.Size(234, 34);
            this.buttonWeapons.TabIndex = 1;
            this.buttonWeapons.Text = "&Waffen";
            this.buttonWeapons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonWeapons.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonWeapons.UseVisualStyleBackColor = true;
            this.buttonWeapons.Click += new System.EventHandler(this.buttonWeapons_Click);
            // 
            // buttonArmor
            // 
            this.buttonArmor.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonArmor.Image = ((System.Drawing.Image)(resources.GetObject("buttonArmor.Image")));
            this.buttonArmor.Location = new System.Drawing.Point(0, 68);
            this.buttonArmor.Name = "buttonArmor";
            this.buttonArmor.Size = new System.Drawing.Size(234, 34);
            this.buttonArmor.TabIndex = 2;
            this.buttonArmor.Text = "&Rüstungen";
            this.buttonArmor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonArmor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonArmor.UseVisualStyleBackColor = true;
            this.buttonArmor.Click += new System.EventHandler(this.buttonArmor_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonQuit.Image = global::Tesserakt.Properties.Resources.cross_circle;
            this.buttonQuit.Location = new System.Drawing.Point(0, 204);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(234, 34);
            this.buttonQuit.TabIndex = 6;
            this.buttonQuit.Text = "&Beenden";
            this.buttonQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonTraits
            // 
            this.buttonTraits.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTraits.Image = ((System.Drawing.Image)(resources.GetObject("buttonTraits.Image")));
            this.buttonTraits.Location = new System.Drawing.Point(0, 136);
            this.buttonTraits.Name = "buttonTraits";
            this.buttonTraits.Size = new System.Drawing.Size(234, 34);
            this.buttonTraits.TabIndex = 4;
            this.buttonTraits.Text = "&Eigenschaften";
            this.buttonTraits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTraits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonTraits.UseVisualStyleBackColor = true;
            this.buttonTraits.Click += new System.EventHandler(this.buttonTraits_Click);
            // 
            // buttonEquipment
            // 
            this.buttonEquipment.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEquipment.Image = ((System.Drawing.Image)(resources.GetObject("buttonEquipment.Image")));
            this.buttonEquipment.Location = new System.Drawing.Point(0, 102);
            this.buttonEquipment.Name = "buttonEquipment";
            this.buttonEquipment.Size = new System.Drawing.Size(234, 34);
            this.buttonEquipment.TabIndex = 3;
            this.buttonEquipment.Text = "Ausrüstung";
            this.buttonEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEquipment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEquipment.UseVisualStyleBackColor = true;
            this.buttonEquipment.Click += new System.EventHandler(this.buttonEquipment_Click);
            // 
            // buttonFactions
            // 
            this.buttonFactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFactions.Image = ((System.Drawing.Image)(resources.GetObject("buttonFactions.Image")));
            this.buttonFactions.Location = new System.Drawing.Point(0, 170);
            this.buttonFactions.Name = "buttonFactions";
            this.buttonFactions.Size = new System.Drawing.Size(234, 34);
            this.buttonFactions.TabIndex = 5;
            this.buttonFactions.Text = "&Fraktionen";
            this.buttonFactions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonFactions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFactions.UseVisualStyleBackColor = true;
            this.buttonFactions.Click += new System.EventHandler(this.buttonFactions_Click);
            // 
            // buttonActors
            // 
            this.buttonActors.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonActors.Image = global::Tesserakt.Properties.Resources.application_list;
            this.buttonActors.Location = new System.Drawing.Point(0, 0);
            this.buttonActors.Name = "buttonActors";
            this.buttonActors.Size = new System.Drawing.Size(234, 34);
            this.buttonActors.TabIndex = 0;
            this.buttonActors.Text = "&Modelle";
            this.buttonActors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonActors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonActors.Click += new System.EventHandler(this.buttonActors_Click);
            // 
            // MasterDataMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.buttonQuit;
            this.ClientSize = new System.Drawing.Size(234, 224);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonFactions);
            this.Controls.Add(this.buttonTraits);
            this.Controls.Add(this.buttonEquipment);
            this.Controls.Add(this.buttonArmor);
            this.Controls.Add(this.buttonWeapons);
            this.Controls.Add(this.buttonActors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MasterDataMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tesserakt Stammdaten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterDataMainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonWeapons;
        private System.Windows.Forms.Button buttonArmor;
        private System.Windows.Forms.Button buttonTraits;
        private System.Windows.Forms.Button buttonEquipment;
        private System.Windows.Forms.Button buttonFactions;
        private System.Windows.Forms.Button buttonActors;
    }
}