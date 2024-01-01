namespace Universalis
{
    partial class UniverseForm
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
            this.listViewFactions = new System.Windows.Forms.ListView();
            this.imageListFactions = new System.Windows.Forms.ImageList(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panelFactions = new System.Windows.Forms.Panel();
            this.panelDisciplines = new System.Windows.Forms.Panel();
            this.listViewDisciplines = new System.Windows.Forms.ListView();
            this.imageListDisciplines = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panelFactions.SuspendLayout();
            this.panelDisciplines.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewFactions
            // 
            this.listViewFactions.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewFactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFactions.HideSelection = false;
            this.listViewFactions.LargeImageList = this.imageListFactions;
            this.listViewFactions.Location = new System.Drawing.Point(0, 25);
            this.listViewFactions.MultiSelect = false;
            this.listViewFactions.Name = "listViewFactions";
            this.listViewFactions.ShowItemToolTips = true;
            this.listViewFactions.Size = new System.Drawing.Size(766, 385);
            this.listViewFactions.TabIndex = 0;
            this.listViewFactions.UseCompatibleStateImageBehavior = false;
            this.listViewFactions.ItemActivate += new System.EventHandler(this.listViewFactions_ItemActivate);
            // 
            // imageListFactions
            // 
            this.imageListFactions.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageListFactions.ImageSize = new System.Drawing.Size(150, 150);
            this.imageListFactions.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.pictureBoxInfo);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(772, 50);
            this.panelHeader.TabIndex = 2;
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxInfo.Image = global::Universalis.Properties.Resources.baseline_info_black_24dp;
            this.pictureBoxInfo.Location = new System.Drawing.Point(745, 3);
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
            this.labelHeader.Location = new System.Drawing.Point(347, 19);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(79, 13);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "universe_name";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(766, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = global::Universalis.Properties.Resources.icon_faction;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel1.Text = "Fraktionen";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(766, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::Universalis.Properties.Resources.icon_discipline;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel2.Text = "Disziplinen";
            // 
            // panelFactions
            // 
            this.panelFactions.Controls.Add(this.listViewFactions);
            this.panelFactions.Controls.Add(this.toolStrip1);
            this.panelFactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFactions.Location = new System.Drawing.Point(3, 3);
            this.panelFactions.Name = "panelFactions";
            this.panelFactions.Size = new System.Drawing.Size(766, 410);
            this.panelFactions.TabIndex = 5;
            // 
            // panelDisciplines
            // 
            this.panelDisciplines.Controls.Add(this.listViewDisciplines);
            this.panelDisciplines.Controls.Add(this.toolStrip2);
            this.panelDisciplines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisciplines.Location = new System.Drawing.Point(3, 419);
            this.panelDisciplines.Name = "panelDisciplines";
            this.panelDisciplines.Size = new System.Drawing.Size(766, 161);
            this.panelDisciplines.TabIndex = 6;
            // 
            // listViewDisciplines
            // 
            this.listViewDisciplines.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewDisciplines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDisciplines.HideSelection = false;
            this.listViewDisciplines.LargeImageList = this.imageListDisciplines;
            this.listViewDisciplines.Location = new System.Drawing.Point(0, 25);
            this.listViewDisciplines.MultiSelect = false;
            this.listViewDisciplines.Name = "listViewDisciplines";
            this.listViewDisciplines.ShowItemToolTips = true;
            this.listViewDisciplines.Size = new System.Drawing.Size(766, 136);
            this.listViewDisciplines.TabIndex = 5;
            this.listViewDisciplines.UseCompatibleStateImageBehavior = false;
            this.listViewDisciplines.ItemActivate += new System.EventHandler(this.listViewDisciplines_ItemActivate);
            // 
            // imageListDisciplines
            // 
            this.imageListDisciplines.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListDisciplines.ImageSize = new System.Drawing.Size(100, 100);
            this.imageListDisciplines.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDisciplines, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelFactions, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(772, 583);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // UniverseForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 633);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelHeader);
            this.KeyPreview = true;
            this.Name = "UniverseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Universalis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UniverseForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UniverseForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UniverseForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UniverseForm_KeyDown);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panelFactions.ResumeLayout(false);
            this.panelFactions.PerformLayout();
            this.panelDisciplines.ResumeLayout(false);
            this.panelDisciplines.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFactions;
        private System.Windows.Forms.ImageList imageListFactions;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxInfo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Panel panelFactions;
        private System.Windows.Forms.Panel panelDisciplines;
        private System.Windows.Forms.ListView listViewDisciplines;
        private System.Windows.Forms.ImageList imageListDisciplines;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}