﻿namespace TestDataVerificationTool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSN = new System.Windows.Forms.Label();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bothellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kokomoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kokomoArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AfterBurnIn_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.BeforeBurnIn_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.automationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOperator = new System.Windows.Forms.Label();
            this.txtUnitSN = new System.Windows.Forms.TextBox();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnFail = new System.Windows.Forms.Button();
            this.operatorID = new System.Windows.Forms.TextBox();
            this.RecordCount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // lblSN
            // 
            this.lblSN.AutoSize = true;
            this.lblSN.Location = new System.Drawing.Point(9, 205);
            this.lblSN.Name = "lblSN";
            this.lblSN.Size = new System.Drawing.Size(76, 13);
            this.lblSN.TabIndex = 76;
            this.lblSN.Text = "Serial Number:";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 70;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locationToolStripMenuItem,
            this.finalTestToolStripMenuItem,
            this.automationToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.debugToolStripMenuItem.Text = "Settings";
            // 
            // locationToolStripMenuItem
            // 
            this.locationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bothellToolStripMenuItem,
            this.kokomoToolStripMenuItem,
            this.kokomoArchiveToolStripMenuItem});
            this.locationToolStripMenuItem.Name = "locationToolStripMenuItem";
            this.locationToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.locationToolStripMenuItem.Text = "Location";
            // 
            // bothellToolStripMenuItem
            // 
            this.bothellToolStripMenuItem.Checked = true;
            this.bothellToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bothellToolStripMenuItem.Name = "bothellToolStripMenuItem";
            this.bothellToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.bothellToolStripMenuItem.Text = "Bothell";
            this.bothellToolStripMenuItem.Click += new System.EventHandler(this.LocationMenuItem_Click);
            // 
            // kokomoToolStripMenuItem
            // 
            this.kokomoToolStripMenuItem.Name = "kokomoToolStripMenuItem";
            this.kokomoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.kokomoToolStripMenuItem.Text = "Kokomo";
            this.kokomoToolStripMenuItem.Click += new System.EventHandler(this.LocationMenuItem_Click);
            // 
            // kokomoArchiveToolStripMenuItem
            // 
            this.kokomoArchiveToolStripMenuItem.Name = "kokomoArchiveToolStripMenuItem";
            this.kokomoArchiveToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.kokomoArchiveToolStripMenuItem.Text = "KokomoArchive";
            this.kokomoArchiveToolStripMenuItem.Click += new System.EventHandler(this.LocationMenuItem_Click);
            // 
            // finalTestToolStripMenuItem
            // 
            this.finalTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AfterBurnIn_Menu,
            this.BeforeBurnIn_Menu});
            this.finalTestToolStripMenuItem.Name = "finalTestToolStripMenuItem";
            this.finalTestToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.finalTestToolStripMenuItem.Text = "Final Test";
            // 
            // AfterBurnIn_Menu
            // 
            this.AfterBurnIn_Menu.Checked = true;
            this.AfterBurnIn_Menu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AfterBurnIn_Menu.Name = "AfterBurnIn_Menu";
            this.AfterBurnIn_Menu.Size = new System.Drawing.Size(149, 22);
            this.AfterBurnIn_Menu.Text = "After Burn In";
            this.AfterBurnIn_Menu.Click += new System.EventHandler(this.FinalTestMenuItem_Click);
            // 
            // BeforeBurnIn_Menu
            // 
            this.BeforeBurnIn_Menu.Name = "BeforeBurnIn_Menu";
            this.BeforeBurnIn_Menu.Size = new System.Drawing.Size(149, 22);
            this.BeforeBurnIn_Menu.Text = "Before Burn In";
            this.BeforeBurnIn_Menu.Click += new System.EventHandler(this.FinalTestMenuItem_Click);
            // 
            // automationToolStripMenuItem
            // 
            this.automationToolStripMenuItem.Name = "automationToolStripMenuItem";
            this.automationToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.automationToolStripMenuItem.Text = "Automation";
            this.automationToolStripMenuItem.Click += new System.EventHandler(this.automationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(21, 177);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(65, 13);
            this.lblOperator.TabIndex = 73;
            this.lblOperator.Text = "Operator ID:";
            // 
            // txtUnitSN
            // 
            this.txtUnitSN.Location = new System.Drawing.Point(88, 201);
            this.txtUnitSN.Name = "txtUnitSN";
            this.txtUnitSN.Size = new System.Drawing.Size(121, 20);
            this.txtUnitSN.TabIndex = 64;
            this.txtUnitSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnitSN_KeyDown);
            this.txtUnitSN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtUnitSN_PreviewKeyDown);
            // 
            // DataGrid
            // 
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(12, 281);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowHeadersWidth = 62;
            this.DataGrid.Size = new System.Drawing.Size(856, 370);
            this.DataGrid.TabIndex = 75;
            this.DataGrid.TabStop = false;
            this.DataGrid.DataSourceChanged += new System.EventHandler(this.UpdateRecordCount);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Previous Test Records for:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConfirm.Location = new System.Drawing.Point(32, 657);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(196, 69);
            this.btnConfirm.TabIndex = 79;
            this.btnConfirm.Text = "Confirm PASS";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(267, 177);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(85, 13);
            this.lbl1.TabIndex = 81;
            this.lbl1.Text = "Part Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 20);
            this.label2.TabIndex = 82;
            this.label2.Text = "Test Records to Verify:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(357, 177);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(17, 17);
            this.lblDescription.TabIndex = 83;
            this.lblDescription.Text = "_";
            // 
            // btnFail
            // 
            this.btnFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFail.BackColor = System.Drawing.Color.Red;
            this.btnFail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFail.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFail.Location = new System.Drawing.Point(240, 657);
            this.btnFail.Name = "btnFail";
            this.btnFail.Size = new System.Drawing.Size(196, 69);
            this.btnFail.TabIndex = 84;
            this.btnFail.Text = "Confirm FAIL";
            this.btnFail.UseVisualStyleBackColor = false;
            this.btnFail.Click += new System.EventHandler(this.ButtonFail_Click);
            // 
            // operatorID
            // 
            this.operatorID.Location = new System.Drawing.Point(88, 175);
            this.operatorID.Name = "operatorID";
            this.operatorID.ReadOnly = true;
            this.operatorID.Size = new System.Drawing.Size(121, 20);
            this.operatorID.TabIndex = 85;
            // 
            // RecordCount
            // 
            this.RecordCount.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.RecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordCount.Location = new System.Drawing.Point(205, 227);
            this.RecordCount.Name = "RecordCount";
            this.RecordCount.Size = new System.Drawing.Size(43, 40);
            this.RecordCount.TabIndex = 86;
            this.RecordCount.Text = "0";
            this.RecordCount.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(448, 32);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 128);
            this.button1.TabIndex = 87;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 732);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RecordCount);
            this.Controls.Add(this.operatorID);
            this.Controls.Add(this.btnFail);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblSN);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.txtUnitSN);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(896, 771);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.FrmApp_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblSN;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.TextBox txtUnitSN;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnFail;
        private System.Windows.Forms.TextBox operatorID;
        private System.Windows.Forms.Button RecordCount;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bothellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kokomoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AfterBurnIn_Menu;
        private System.Windows.Forms.ToolStripMenuItem BeforeBurnIn_Menu;
        private System.Windows.Forms.ToolStripMenuItem automationToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem kokomoArchiveToolStripMenuItem;
    }
}

