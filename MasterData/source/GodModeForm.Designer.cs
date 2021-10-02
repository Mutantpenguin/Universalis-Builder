
namespace Universalis
{
    partial class GodModeForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.buttonMasterData = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonGroups, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonMasterData, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 200);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // buttonGroups
            // 
            this.buttonGroups.AutoSize = true;
            this.buttonGroups.BackgroundImage = global::Universalis.Properties.Resources.baseline_block_black_18dp;
            this.buttonGroups.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGroups.Location = new System.Drawing.Point(3, 3);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Size = new System.Drawing.Size(283, 194);
            this.buttonGroups.TabIndex = 5;
            this.toolTip1.SetToolTip(this.buttonGroups, "Gruppen");
            this.buttonGroups.UseVisualStyleBackColor = true;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            // 
            // buttonMasterData
            // 
            this.buttonMasterData.AutoSize = true;
            this.buttonMasterData.BackgroundImage = global::Universalis.Properties.Resources.baseline_block_black_18dp;
            this.buttonMasterData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMasterData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMasterData.Location = new System.Drawing.Point(292, 3);
            this.buttonMasterData.Name = "buttonMasterData";
            this.buttonMasterData.Size = new System.Drawing.Size(283, 194);
            this.buttonMasterData.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonMasterData, "Stammdaten");
            this.buttonMasterData.UseVisualStyleBackColor = true;
            this.buttonMasterData.Click += new System.EventHandler(this.buttonMasterData_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonQuit.Image = global::Universalis.Properties.Resources.cross_circle;
            this.buttonQuit.Location = new System.Drawing.Point(0, 200);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(578, 34);
            this.buttonQuit.TabIndex = 9;
            this.buttonQuit.Text = "&Beenden";
            this.buttonQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // GodModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonQuit;
            this.ClientSize = new System.Drawing.Size(578, 234);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GodModeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GodModeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GodModeForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonGroups;
        private System.Windows.Forms.Button buttonMasterData;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}