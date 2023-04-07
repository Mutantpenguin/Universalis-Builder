
namespace Universalis
{
    partial class DeityModeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeityModeForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.buttonMasterData = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonQuit = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 150);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // buttonGroups
            // 
            this.buttonGroups.AutoSize = true;
            this.buttonGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGroups.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonGroups.ImageKey = "baseline_groups_black_48dp.png";
            this.buttonGroups.ImageList = this.imageListIcons;
            this.buttonGroups.Location = new System.Drawing.Point(3, 3);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Size = new System.Drawing.Size(283, 144);
            this.buttonGroups.TabIndex = 5;
            this.toolTip1.SetToolTip(this.buttonGroups, "Gruppen");
            this.buttonGroups.UseVisualStyleBackColor = true;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            this.buttonGroups.Paint += new System.Windows.Forms.PaintEventHandler(this.buttons_Paint);
            // 
            // buttonMasterData
            // 
            this.buttonMasterData.AutoSize = true;
            this.buttonMasterData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMasterData.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonMasterData.ImageKey = "baseline_construction_black_48dp.png";
            this.buttonMasterData.ImageList = this.imageListIcons;
            this.buttonMasterData.Location = new System.Drawing.Point(292, 3);
            this.buttonMasterData.Name = "buttonMasterData";
            this.buttonMasterData.Size = new System.Drawing.Size(283, 144);
            this.buttonMasterData.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonMasterData, "Stammdaten");
            this.buttonMasterData.UseVisualStyleBackColor = true;
            this.buttonMasterData.Click += new System.EventHandler(this.buttonMasterData_Click);
            this.buttonMasterData.Paint += new System.Windows.Forms.PaintEventHandler(this.buttons_Paint);
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
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.pictureBoxInfo);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(578, 50);
            this.panelHeader.TabIndex = 10;
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxInfo.Image = global::Universalis.Properties.Resources.baseline_info_black_24dp;
            this.pictureBoxInfo.Location = new System.Drawing.Point(551, 3);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxInfo.TabIndex = 2;
            this.pictureBoxInfo.TabStop = false;
            this.pictureBoxInfo.Click += new System.EventHandler(this.pictureBoxInfo_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(250, 19);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(79, 13);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "universe_name";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageListIcons
            // 
            this.imageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcons.ImageStream")));
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcons.Images.SetKeyName(0, "baseline_groups_black_48dp.png");
            this.imageListIcons.Images.SetKeyName(1, "baseline_construction_black_48dp.png");
            // 
            // DeityModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonQuit;
            this.ClientSize = new System.Drawing.Size(578, 234);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.buttonQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeityModeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gottheit Modus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeityModeForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonGroups;
        private System.Windows.Forms.Button buttonMasterData;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxInfo;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.ImageList imageListIcons;
    }
}