namespace Tesserakt
{
    partial class GroupPDFExportForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxEquipment = new System.Windows.Forms.CheckBox();
            this.checkBoxArmor = new System.Windows.Forms.CheckBox();
            this.checkBoxWeapons = new System.Windows.Forms.CheckBox();
            this.checkBoxTraits = new System.Windows.Forms.CheckBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBoxEquipment);
            this.panel1.Controls.Add(this.checkBoxArmor);
            this.panel1.Controls.Add(this.checkBoxWeapons);
            this.panel1.Controls.Add(this.checkBoxTraits);
            this.panel1.Controls.Add(this.buttonExport);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 262);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "Auswahl zu exportierender Angaben:";
            // 
            // checkBoxEquipment
            // 
            this.checkBoxEquipment.AutoSize = true;
            this.checkBoxEquipment.Location = new System.Drawing.Point(6, 121);
            this.checkBoxEquipment.Name = "checkBoxEquipment";
            this.checkBoxEquipment.Size = new System.Drawing.Size(79, 17);
            this.checkBoxEquipment.TabIndex = 5;
            this.checkBoxEquipment.Text = "Ausrüstung";
            this.checkBoxEquipment.UseVisualStyleBackColor = true;
            // 
            // checkBoxArmor
            // 
            this.checkBoxArmor.AutoSize = true;
            this.checkBoxArmor.Location = new System.Drawing.Point(6, 98);
            this.checkBoxArmor.Name = "checkBoxArmor";
            this.checkBoxArmor.Size = new System.Drawing.Size(66, 17);
            this.checkBoxArmor.TabIndex = 4;
            this.checkBoxArmor.Text = "Rüstung";
            this.checkBoxArmor.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeapons
            // 
            this.checkBoxWeapons.AutoSize = true;
            this.checkBoxWeapons.Location = new System.Drawing.Point(6, 75);
            this.checkBoxWeapons.Name = "checkBoxWeapons";
            this.checkBoxWeapons.Size = new System.Drawing.Size(61, 17);
            this.checkBoxWeapons.TabIndex = 3;
            this.checkBoxWeapons.Text = "Waffen";
            this.checkBoxWeapons.UseVisualStyleBackColor = true;
            // 
            // checkBoxTraits
            // 
            this.checkBoxTraits.AutoSize = true;
            this.checkBoxTraits.Location = new System.Drawing.Point(6, 52);
            this.checkBoxTraits.Name = "checkBoxTraits";
            this.checkBoxTraits.Size = new System.Drawing.Size(94, 17);
            this.checkBoxTraits.TabIndex = 2;
            this.checkBoxTraits.Text = "Eigenschaften";
            this.checkBoxTraits.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Image = global::Tesserakt.Properties.Resources.document_pdf;
            this.buttonExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExport.Location = new System.Drawing.Point(6, 144);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(144, 24);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "E&xportieren";
            this.buttonExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::Tesserakt.Properties.Resources.cross_circle;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.Location = new System.Drawing.Point(6, 174);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(144, 24);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "A&bbrechen";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // GroupPDFExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupPDFExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PDF erstellen";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.CheckBox checkBoxEquipment;
        private System.Windows.Forms.CheckBox checkBoxArmor;
        private System.Windows.Forms.CheckBox checkBoxWeapons;
        private System.Windows.Forms.CheckBox checkBoxTraits;
        private System.Windows.Forms.Label label1;
    }
}