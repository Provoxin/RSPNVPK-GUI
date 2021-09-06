
namespace GUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPatch = new System.Windows.Forms.Button();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectGame = new System.Windows.Forms.Button();
            this.btnSelectPatch = new System.Windows.Forms.Button();
            this.cbShowConfirm = new System.Windows.Forms.CheckBox();
            this.infoPatch = new System.Windows.Forms.PictureBox();
            this.infoVPK = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbBackup = new System.Windows.Forms.CheckBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.lvBackups = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chDate = new System.Windows.Forms.ColumnHeader();
            this.chTime = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.infoPatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoVPK)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPatch
            // 
            this.btnPatch.Enabled = false;
            this.btnPatch.Location = new System.Drawing.Point(7, 95);
            this.btnPatch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(96, 32);
            this.btnPatch.TabIndex = 0;
            this.btnPatch.Text = "Patch VPK";
            this.btnPatch.UseVisualStyleBackColor = true;
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFrom.Location = new System.Drawing.Point(40, 67);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.PlaceholderText = "Choose patch folder directory...";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(466, 23);
            this.txtFrom.TabIndex = 4;
            this.txtFrom.TabStop = false;
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTo.Location = new System.Drawing.Point(40, 21);
            this.txtTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTo.Name = "txtTo";
            this.txtTo.PlaceholderText = "Choose Titanfall 2 directory...";
            this.txtTo.ReadOnly = true;
            this.txtTo.Size = new System.Drawing.Size(466, 23);
            this.txtTo.TabIndex = 5;
            this.txtTo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Patch Folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "VPK Directory";
            // 
            // btnSelectGame
            // 
            this.btnSelectGame.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectGame.Image")));
            this.btnSelectGame.Location = new System.Drawing.Point(7, 20);
            this.btnSelectGame.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelectGame.Name = "btnSelectGame";
            this.btnSelectGame.Size = new System.Drawing.Size(31, 25);
            this.btnSelectGame.TabIndex = 4;
            this.btnSelectGame.UseVisualStyleBackColor = true;
            this.btnSelectGame.Click += new System.EventHandler(this.btnSelectGame_Click);
            // 
            // btnSelectPatch
            // 
            this.btnSelectPatch.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectPatch.Image")));
            this.btnSelectPatch.Location = new System.Drawing.Point(7, 66);
            this.btnSelectPatch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelectPatch.Name = "btnSelectPatch";
            this.btnSelectPatch.Size = new System.Drawing.Size(32, 25);
            this.btnSelectPatch.TabIndex = 5;
            this.btnSelectPatch.UseVisualStyleBackColor = true;
            this.btnSelectPatch.Click += new System.EventHandler(this.btnSelectPatch_Click);
            // 
            // cbShowConfirm
            // 
            this.cbShowConfirm.AutoSize = true;
            this.cbShowConfirm.Checked = true;
            this.cbShowConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowConfirm.Location = new System.Drawing.Point(8, 130);
            this.cbShowConfirm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbShowConfirm.Name = "cbShowConfirm";
            this.cbShowConfirm.Size = new System.Drawing.Size(129, 19);
            this.cbShowConfirm.TabIndex = 1;
            this.cbShowConfirm.Text = "Show Confirmation";
            this.cbShowConfirm.UseVisualStyleBackColor = true;
            // 
            // infoPatch
            // 
            this.infoPatch.Cursor = System.Windows.Forms.Cursors.Help;
            this.infoPatch.Image = ((System.Drawing.Image)(resources.GetObject("infoPatch.Image")));
            this.infoPatch.Location = new System.Drawing.Point(77, 50);
            this.infoPatch.Name = "infoPatch";
            this.infoPatch.Size = new System.Drawing.Size(16, 16);
            this.infoPatch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.infoPatch.TabIndex = 11;
            this.infoPatch.TabStop = false;
            this.toolTip1.SetToolTip(this.infoPatch, "Select the patch folder. To learn how to set up this folder, check out the\r\n[Modd" +
        "ing introduction -> Modding tools -> How to use RSPNVPK] section on the NoSkill " +
        "wiki.");
            // 
            // infoVPK
            // 
            this.infoVPK.Cursor = System.Windows.Forms.Cursors.Help;
            this.infoVPK.Image = ((System.Drawing.Image)(resources.GetObject("infoVPK.Image")));
            this.infoVPK.Location = new System.Drawing.Point(83, 4);
            this.infoVPK.Name = "infoVPK";
            this.infoVPK.Size = new System.Drawing.Size(16, 16);
            this.infoVPK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.infoVPK.TabIndex = 12;
            this.infoVPK.TabStop = false;
            this.toolTip1.SetToolTip(this.infoVPK, "Select your Titanfall 2 VPK directory");
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 32767;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 20;
            // 
            // cbBackup
            // 
            this.cbBackup.AutoSize = true;
            this.cbBackup.Checked = true;
            this.cbBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBackup.Location = new System.Drawing.Point(8, 149);
            this.cbBackup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbBackup.Name = "cbBackup";
            this.cbBackup.Size = new System.Drawing.Size(102, 19);
            this.cbBackup.TabIndex = 2;
            this.cbBackup.Text = "Create Backup";
            this.cbBackup.UseVisualStyleBackColor = true;
            // 
            // btnRestore
            // 
            this.btnRestore.Enabled = false;
            this.btnRestore.Location = new System.Drawing.Point(109, 95);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(96, 32);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restore Backup";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // lvBackups
            // 
            this.lvBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBackups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chDate,
            this.chTime});
            this.lvBackups.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvBackups.FullRowSelect = true;
            this.lvBackups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvBackups.HideSelection = false;
            this.lvBackups.Location = new System.Drawing.Point(212, 96);
            this.lvBackups.MultiSelect = false;
            this.lvBackups.Name = "lvBackups";
            this.lvBackups.Size = new System.Drawing.Size(294, 68);
            this.lvBackups.TabIndex = 16;
            this.lvBackups.TabStop = false;
            this.lvBackups.UseCompatibleStateImageBehavior = false;
            this.lvBackups.View = System.Windows.Forms.View.Details;
            this.lvBackups.SelectedIndexChanged += new System.EventHandler(this.lvBackups_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Name = "chName";
            this.chName.Text = "Name";
            this.chName.Width = 140;
            // 
            // chDate
            // 
            this.chDate.Name = "chDate";
            this.chDate.Text = "Date";
            this.chDate.Width = 70;
            // 
            // chTime
            // 
            this.chTime.Name = "chTime";
            this.chTime.Text = "Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 170);
            this.Controls.Add(this.lvBackups);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.cbBackup);
            this.Controls.Add(this.infoVPK);
            this.Controls.Add(this.infoPatch);
            this.Controls.Add(this.cbShowConfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectGame);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.btnSelectPatch);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.btnPatch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 512);
            this.MinimumSize = new System.Drawing.Size(226, 209);
            this.Name = "Form1";
            this.Text = "VPK Patcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.infoPatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoVPK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPatch;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnSelectPatch;
        private System.Windows.Forms.Button btnSelectGame;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbShowConfirm;
        private System.Windows.Forms.PictureBox infoPatch;
        private System.Windows.Forms.PictureBox infoVPK;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ListView lvBackups;
        private System.Windows.Forms.ColumnHeader chTime;
    }
}

