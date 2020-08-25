namespace TestDataVerificationTool
{
    partial class FrmApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApp));
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSN = new System.Windows.Forms.Label();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOperator = new System.Windows.Forms.Label();
            this.txtUnitSN = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnFail = new System.Windows.Forms.Button();
            this.operatorID = new System.Windows.Forms.TextBox();
            this.RecordCount = new System.Windows.Forms.Button();
            this.panelFinalAccept = new System.Windows.Forms.Panel();
            this.btnFT2 = new System.Windows.Forms.Button();
            this.btnFT1 = new System.Windows.Forms.Button();
            this.lblFT2 = new System.Windows.Forms.Label();
            this.lblFT1 = new System.Windows.Forms.Label();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkMultipleSerialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelFinalAccept.SuspendLayout();
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
            this.lblSN.Location = new System.Drawing.Point(11, 72);
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(986, 24);
            this.menuStrip1.TabIndex = 70;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(22, 45);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(65, 13);
            this.lblOperator.TabIndex = 73;
            this.lblOperator.Text = "Operator ID:";
            // 
            // txtUnitSN
            // 
            this.txtUnitSN.Location = new System.Drawing.Point(89, 68);
            this.txtUnitSN.Name = "txtUnitSN";
            this.txtUnitSN.Size = new System.Drawing.Size(121, 20);
            this.txtUnitSN.TabIndex = 64;
            this.txtUnitSN.LostFocus += new System.EventHandler(this.TxtUnitSN_LostFocus);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(962, 397);
            this.dataGridView1.TabIndex = 75;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.UpdateRecordCount);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView1_DataError);
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
            // rtbStatus
            // 
            this.rtbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.rtbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbStatus.Location = new System.Drawing.Point(298, 72);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.ReadOnly = true;
            this.rtbStatus.Size = new System.Drawing.Size(676, 100);
            this.rtbStatus.TabIndex = 72;
            this.rtbStatus.TabStop = false;
            this.rtbStatus.Text = "<";
            this.rtbStatus.WordWrap = false;
            this.rtbStatus.TextChanged += new System.EventHandler(this.RtbStatus_TextChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConfirm.Location = new System.Drawing.Point(258, 615);
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
            this.lbl1.Location = new System.Drawing.Point(268, 44);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(85, 13);
            this.lbl1.TabIndex = 81;
            this.lbl1.Text = "Part Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 20);
            this.label2.TabIndex = 82;
            this.label2.Text = "Test Records to Verify:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(359, 44);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(13, 13);
            this.lblDescription.TabIndex = 83;
            this.lblDescription.Text = "_";
            // 
            // btnFail
            // 
            this.btnFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFail.BackColor = System.Drawing.Color.Red;
            this.btnFail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFail.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFail.Location = new System.Drawing.Point(531, 615);
            this.btnFail.Name = "btnFail";
            this.btnFail.Size = new System.Drawing.Size(196, 69);
            this.btnFail.TabIndex = 84;
            this.btnFail.Text = "Confirm FAIL";
            this.btnFail.UseVisualStyleBackColor = false;
            this.btnFail.Click += new System.EventHandler(this.ButtonFail_Click);
            // 
            // operatorID
            // 
            this.operatorID.Location = new System.Drawing.Point(89, 42);
            this.operatorID.Name = "operatorID";
            this.operatorID.Size = new System.Drawing.Size(121, 20);
            this.operatorID.TabIndex = 85;
            // 
            // RecordCount
            // 
            this.RecordCount.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.RecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordCount.Location = new System.Drawing.Point(208, 96);
            this.RecordCount.Name = "RecordCount";
            this.RecordCount.Size = new System.Drawing.Size(43, 40);
            this.RecordCount.TabIndex = 86;
            this.RecordCount.Text = "0";
            this.RecordCount.UseVisualStyleBackColor = false;
            // 
            // panelFinalAccept
            // 
            this.panelFinalAccept.Controls.Add(this.btnFT2);
            this.panelFinalAccept.Controls.Add(this.btnFT1);
            this.panelFinalAccept.Controls.Add(this.lblFT2);
            this.panelFinalAccept.Controls.Add(this.lblFT1);
            this.panelFinalAccept.Location = new System.Drawing.Point(16, 144);
            this.panelFinalAccept.Name = "panelFinalAccept";
            this.panelFinalAccept.Size = new System.Drawing.Size(256, 48);
            this.panelFinalAccept.TabIndex = 87;
            this.panelFinalAccept.Visible = false;
            // 
            // btnFT2
            // 
            this.btnFT2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnFT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFT2.Location = new System.Drawing.Point(192, 0);
            this.btnFT2.Name = "btnFT2";
            this.btnFT2.Size = new System.Drawing.Size(43, 40);
            this.btnFT2.TabIndex = 90;
            this.btnFT2.Text = "0";
            this.btnFT2.UseVisualStyleBackColor = false;
            // 
            // btnFT1
            // 
            this.btnFT1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnFT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFT1.Location = new System.Drawing.Point(64, 0);
            this.btnFT1.Name = "btnFT1";
            this.btnFT1.Size = new System.Drawing.Size(43, 40);
            this.btnFT1.TabIndex = 88;
            this.btnFT1.Text = "0";
            this.btnFT1.UseVisualStyleBackColor = false;
            // 
            // lblFT2
            // 
            this.lblFT2.AutoSize = true;
            this.lblFT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFT2.Location = new System.Drawing.Point(144, 16);
            this.lblFT2.Name = "lblFT2";
            this.lblFT2.Size = new System.Drawing.Size(45, 20);
            this.lblFT2.TabIndex = 89;
            this.lblFT2.Text = "FT2:";
            // 
            // lblFT1
            // 
            this.lblFT1.AutoSize = true;
            this.lblFT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFT1.Location = new System.Drawing.Point(16, 16);
            this.lblFT1.Name = "lblFT1";
            this.lblFT1.Size = new System.Drawing.Size(45, 20);
            this.lblFT1.TabIndex = 88;
            this.lblFT1.Text = "FT1:";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkMultipleSerialsToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // checkMultipleSerialsToolStripMenuItem
            // 
            this.checkMultipleSerialsToolStripMenuItem.Name = "checkMultipleSerialsToolStripMenuItem";
            this.checkMultipleSerialsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.checkMultipleSerialsToolStripMenuItem.Text = "Check multiple serials";
            this.checkMultipleSerialsToolStripMenuItem.Click += new System.EventHandler(this.checkMultipleSerialsToolStripMenuItem_Click);
            // 
            // FrmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(986, 692);
            this.Controls.Add(this.panelFinalAccept);
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
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmApp";
            this.Text = "MFG-00543  Test Data Verification Tool";
            this.Load += new System.EventHandler(this.FrmApp_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelFinalAccept.ResumeLayout(false);
            this.panelFinalAccept.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnFail;
        private System.Windows.Forms.TextBox operatorID;
        private System.Windows.Forms.Button RecordCount;
        private System.Windows.Forms.Panel panelFinalAccept;
        private System.Windows.Forms.Button btnFT2;
        private System.Windows.Forms.Button btnFT1;
        private System.Windows.Forms.Label lblFT2;
        private System.Windows.Forms.Label lblFT1;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkMultipleSerialsToolStripMenuItem;
    }
}

