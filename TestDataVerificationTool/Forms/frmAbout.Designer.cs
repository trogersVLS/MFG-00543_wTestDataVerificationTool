namespace TestDataVerificationTool
{
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblSWRev = new System.Windows.Forms.Label();
            this.lblSWnum = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.RevLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(12, 58);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(214, 13);
            this.lblAuthor.TabIndex = 8;
            this.lblAuthor.Text = "Author: Anthony Lowe, Ventec Life Systems";
            // 
            // lblSWRev
            // 
            this.lblSWRev.AutoSize = true;
            this.lblSWRev.Location = new System.Drawing.Point(12, 33);
            this.lblSWRev.Name = "lblSWRev";
            this.lblSWRev.Size = new System.Drawing.Size(96, 13);
            this.lblSWRev.TabIndex = 7;
            this.lblSWRev.Text = "Software Revision:";
            // 
            // lblSWnum
            // 
            this.lblSWnum.AutoSize = true;
            this.lblSWnum.Location = new System.Drawing.Point(12, 9);
            this.lblSWnum.Name = "lblSWnum";
            this.lblSWnum.Size = new System.Drawing.Size(151, 13);
            this.lblSWnum.TabIndex = 6;
            this.lblSWnum.Text = "Software Number: MFG-00543";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(90, 167);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 33);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // RevLabel
            // 
            this.RevLabel.AutoSize = true;
            this.RevLabel.Location = new System.Drawing.Point(115, 33);
            this.RevLabel.Name = "RevLabel";
            this.RevLabel.Size = new System.Drawing.Size(55, 13);
            this.RevLabel.TabIndex = 9;
            this.RevLabel.Text = "<revision>";
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 213);
            this.Controls.Add(this.RevLabel);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblSWRev);
            this.Controls.Add(this.lblSWnum);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAbout";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblSWRev;
        private System.Windows.Forms.Label lblSWnum;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label RevLabel;
    }
}