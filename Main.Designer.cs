namespace ImageChopper
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pictureBoxCurrent = new System.Windows.Forms.PictureBox();
            this.splitContainerFirst = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnPrevFile = new System.Windows.Forms.ToolStripButton();
            this.btnNextFile = new System.Windows.Forms.ToolStripButton();
            this.lblGoToPage = new System.Windows.Forms.ToolStripLabel();
            this.cmbFile = new System.Windows.Forms.ToolStripComboBox();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblImgInfo = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFirst)).BeginInit();
            this.splitContainerFirst.Panel1.SuspendLayout();
            this.splitContainerFirst.Panel2.SuspendLayout();
            this.splitContainerFirst.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxCurrent
            // 
            this.pictureBoxCurrent.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCurrent.Image")));
            this.pictureBoxCurrent.Location = new System.Drawing.Point(28, 22);
            this.pictureBoxCurrent.Name = "pictureBoxCurrent";
            this.pictureBoxCurrent.Size = new System.Drawing.Size(2480, 1753);
            this.pictureBoxCurrent.TabIndex = 0;
            this.pictureBoxCurrent.TabStop = false;
            this.pictureBoxCurrent.Tag = "img";
            this.pictureBoxCurrent.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxSrc_Paint);
            this.pictureBoxCurrent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxSrc_MouseDown);
            this.pictureBoxCurrent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxSrc_MouseMove);
            this.pictureBoxCurrent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxSrc_MouseUp);
            // 
            // splitContainerFirst
            // 
            this.splitContainerFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFirst.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerFirst.IsSplitterFixed = true;
            this.splitContainerFirst.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFirst.Name = "splitContainerFirst";
            this.splitContainerFirst.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFirst.Panel1
            // 
            this.splitContainerFirst.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainerFirst.Panel2
            // 
            this.splitContainerFirst.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerFirst.Size = new System.Drawing.Size(1370, 749);
            this.splitContainerFirst.SplitterDistance = 40;
            this.splitContainerFirst.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUndo,
            this.btnPrevFile,
            this.btnNextFile,
            this.lblGoToPage,
            this.cmbFile,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1370, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 37);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // btnPrevFile
            // 
            this.btnPrevFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevFile.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevFile.Image")));
            this.btnPrevFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevFile.Name = "btnPrevFile";
            this.btnPrevFile.Size = new System.Drawing.Size(23, 37);
            this.btnPrevFile.Text = "Inapoi";
            this.btnPrevFile.Click += new System.EventHandler(this.BtnPrevFile_Click);
            // 
            // btnNextFile
            // 
            this.btnNextFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNextFile.Image = ((System.Drawing.Image)(resources.GetObject("btnNextFile.Image")));
            this.btnNextFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNextFile.Name = "btnNextFile";
            this.btnNextFile.Size = new System.Drawing.Size(23, 37);
            this.btnNextFile.Text = "Inainte";
            this.btnNextFile.Click += new System.EventHandler(this.BtnNextFile_Click);
            // 
            // lblGoToPage
            // 
            this.lblGoToPage.Name = "lblGoToPage";
            this.lblGoToPage.Size = new System.Drawing.Size(81, 37);
            this.lblGoToPage.Text = "Alege fisierul: ";
            // 
            // cmbFile
            // 
            this.cmbFile.Name = "cmbFile";
            this.cmbFile.Size = new System.Drawing.Size(255, 40);
            this.cmbFile.SelectedIndexChanged += new System.EventHandler(this.CmbFile_SelectedIndexChanged);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(23, 37);
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.Click += new System.EventHandler(this.BtnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 37);
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 37);
            this.btnSave.Text = "Salvare";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxCurrent);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.btnOpen);
            this.splitContainer1.Panel2.Controls.Add(this.lblImgInfo);
            this.splitContainer1.Panel2.Controls.Add(this.lblInfo);
            this.splitContainer1.Panel2.Controls.Add(this.lblLog);
            this.splitContainer1.Size = new System.Drawing.Size(1370, 705);
            this.splitContainer1.SplitterDistance = 1009;
            this.splitContainer1.TabIndex = 2;
            // 
            // lblImgInfo
            // 
            this.lblImgInfo.AutoSize = true;
            this.lblImgInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImgInfo.Location = new System.Drawing.Point(5, 12);
            this.lblImgInfo.Name = "lblImgInfo";
            this.lblImgInfo.Size = new System.Drawing.Size(66, 24);
            this.lblImgInfo.TabIndex = 5;
            this.lblImgInfo.Text = "label1";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblInfo.Location = new System.Drawing.Point(4, 70);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(52, 18);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label1";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblLog.Location = new System.Drawing.Point(13, 312);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(30, 17);
            this.lblLog.TabIndex = 1;
            this.lblLog.Text = "log";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(9, 203);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(183, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Deschide imaginea modificata";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.splitContainerFirst);
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Text = "Image Chopper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrent)).EndInit();
            this.splitContainerFirst.Panel1.ResumeLayout(false);
            this.splitContainerFirst.Panel1.PerformLayout();
            this.splitContainerFirst.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFirst)).EndInit();
            this.splitContainerFirst.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxCurrent;
        private System.Windows.Forms.SplitContainer splitContainerFirst;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnNextFile;
        private System.Windows.Forms.ToolStripButton btnPrevFile;
        private System.Windows.Forms.ToolStripLabel lblGoToPage;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripComboBox cmbFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ToolStripButton btnZoomIn;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.Label lblImgInfo;
        private System.Windows.Forms.Button btnOpen;
    }
}

