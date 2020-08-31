namespace TestDataVerificationTool
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblSWRev = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblRevisionLetter = new System.Windows.Forms.Label();
            this.lblSWnum = new System.Windows.Forms.Label();
            this.lblBuildVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSWRev
            // 
            this.lblSWRev.AutoSize = true;
            this.lblSWRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSWRev.Location = new System.Drawing.Point(24, 123);
            this.lblSWRev.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSWRev.Name = "lblSWRev";
            this.lblSWRev.Size = new System.Drawing.Size(173, 25);
            this.lblSWRev.TabIndex = 2;
            this.lblSWRev.Text = "Released Revision";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.Location = new System.Drawing.Point(24, 172);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(260, 25);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "© 2020 Ventec Life Systems";
            // 
            // lblRevisionLetter
            // 
            this.lblRevisionLetter.AutoSize = true;
            this.lblRevisionLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisionLetter.Location = new System.Drawing.Point(264, 123);
            this.lblRevisionLetter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevisionLetter.Name = "lblRevisionLetter";
            this.lblRevisionLetter.Size = new System.Drawing.Size(103, 25);
            this.lblRevisionLetter.TabIndex = 5;
            this.lblRevisionLetter.Text = "<revision>";
            // 
            // lblSWnum
            // 
            this.lblSWnum.AutoSize = true;
            this.lblSWnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSWnum.Location = new System.Drawing.Point(24, 25);
            this.lblSWnum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSWnum.Name = "lblSWnum";
            this.lblSWnum.Size = new System.Drawing.Size(365, 25);
            this.lblSWnum.TabIndex = 1;
            this.lblSWnum.Text = "MFG-00543 - Test Data Verification Tool";
            // 
            // lblBuildVersion
            // 
            this.lblBuildVersion.AutoSize = true;
            this.lblBuildVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildVersion.Location = new System.Drawing.Point(24, 74);
            this.lblBuildVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuildVersion.Name = "lblBuildVersion";
            this.lblBuildVersion.Size = new System.Drawing.Size(144, 25);
            this.lblBuildVersion.TabIndex = 6;
            this.lblBuildVersion.Text = "<buildVersion>";
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 226);
            this.Controls.Add(this.lblBuildVersion);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblRevisionLetter);
            this.Controls.Add(this.lblSWRev);
            this.Controls.Add(this.lblSWnum);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSWRev;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblRevisionLetter;
        private System.Windows.Forms.Label lblSWnum;
        private System.Windows.Forms.Label lblBuildVersion;
    }
}