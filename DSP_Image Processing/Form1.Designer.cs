namespace DSP_Image_Processing
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
            this.picBox_oldBtmp = new System.Windows.Forms.PictureBox();
            this.picBox_NewBtmp = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianEdgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianSharpeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaptiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcessingTimeLabel = new System.Windows.Forms.Label();
            this.boundryDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erossionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_oldBtmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_NewBtmp)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox_oldBtmp
            // 
            this.picBox_oldBtmp.Location = new System.Drawing.Point(12, 24);
            this.picBox_oldBtmp.Name = "picBox_oldBtmp";
            this.picBox_oldBtmp.Size = new System.Drawing.Size(476, 453);
            this.picBox_oldBtmp.TabIndex = 0;
            this.picBox_oldBtmp.TabStop = false;
            // 
            // picBox_NewBtmp
            // 
            this.picBox_NewBtmp.Location = new System.Drawing.Point(509, 24);
            this.picBox_NewBtmp.Name = "picBox_NewBtmp";
            this.picBox_NewBtmp.Size = new System.Drawing.Size(476, 453);
            this.picBox_NewBtmp.TabIndex = 1;
            this.picBox_NewBtmp.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1017, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothingToolStripMenuItem,
            this.grayScaleToolStripMenuItem,
            this.invertColorsToolStripMenuItem,
            this.edgeDetectionToolStripMenuItem,
            this.sharpeningToolStripMenuItem,
            this.thresholdingToolStripMenuItem,
            this.boundryDetectionToolStripMenuItem,
            this.erossionToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // smoothingToolStripMenuItem
            // 
            this.smoothingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fastToolStripMenuItem,
            this.slowToolStripMenuItem});
            this.smoothingToolStripMenuItem.Name = "smoothingToolStripMenuItem";
            this.smoothingToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.smoothingToolStripMenuItem.Text = "Smoothing";
            // 
            // fastToolStripMenuItem
            // 
            this.fastToolStripMenuItem.Name = "fastToolStripMenuItem";
            this.fastToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fastToolStripMenuItem.Text = "Optimized";
            this.fastToolStripMenuItem.Click += new System.EventHandler(this.fastToolStripMenuItem_Click);
            // 
            // slowToolStripMenuItem
            // 
            this.slowToolStripMenuItem.Name = "slowToolStripMenuItem";
            this.slowToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.slowToolStripMenuItem.Text = "Original";
            this.slowToolStripMenuItem.Click += new System.EventHandler(this.slowToolStripMenuItem_Click);
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.grayScaleToolStripMenuItem.Text = "GrayScale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.grayScaleToolStripMenuItem_Click);
            // 
            // invertColorsToolStripMenuItem
            // 
            this.invertColorsToolStripMenuItem.Name = "invertColorsToolStripMenuItem";
            this.invertColorsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.invertColorsToolStripMenuItem.Text = "Invert Colors";
            this.invertColorsToolStripMenuItem.Click += new System.EventHandler(this.invertColorsToolStripMenuItem_Click);
            // 
            // edgeDetectionToolStripMenuItem
            // 
            this.edgeDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.laplacianEdgeDetectionToolStripMenuItem});
            this.edgeDetectionToolStripMenuItem.Name = "edgeDetectionToolStripMenuItem";
            this.edgeDetectionToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.edgeDetectionToolStripMenuItem.Text = "Edge Detection";
            // 
            // laplacianEdgeDetectionToolStripMenuItem
            // 
            this.laplacianEdgeDetectionToolStripMenuItem.Name = "laplacianEdgeDetectionToolStripMenuItem";
            this.laplacianEdgeDetectionToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.laplacianEdgeDetectionToolStripMenuItem.Text = "Laplacian Edge Detection";
            this.laplacianEdgeDetectionToolStripMenuItem.Click += new System.EventHandler(this.laplacianEdgeDetectionToolStripMenuItem_Click);
            // 
            // sharpeningToolStripMenuItem
            // 
            this.sharpeningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.laplacianSharpeningToolStripMenuItem});
            this.sharpeningToolStripMenuItem.Name = "sharpeningToolStripMenuItem";
            this.sharpeningToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.sharpeningToolStripMenuItem.Text = "Sharpening";
            // 
            // laplacianSharpeningToolStripMenuItem
            // 
            this.laplacianSharpeningToolStripMenuItem.Name = "laplacianSharpeningToolStripMenuItem";
            this.laplacianSharpeningToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.laplacianSharpeningToolStripMenuItem.Text = "Laplacian Sharpening";
            this.laplacianSharpeningToolStripMenuItem.Click += new System.EventHandler(this.laplacianSharpeningToolStripMenuItem_Click);
            // 
            // thresholdingToolStripMenuItem
            // 
            this.thresholdingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staticToolStripMenuItem,
            this.averageToolStripMenuItem,
            this.adaptiveToolStripMenuItem});
            this.thresholdingToolStripMenuItem.Name = "thresholdingToolStripMenuItem";
            this.thresholdingToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.thresholdingToolStripMenuItem.Text = "Thresholding";
            // 
            // staticToolStripMenuItem
            // 
            this.staticToolStripMenuItem.Name = "staticToolStripMenuItem";
            this.staticToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.staticToolStripMenuItem.Text = "Static";
            this.staticToolStripMenuItem.Click += new System.EventHandler(this.staticToolStripMenuItem_Click);
            // 
            // averageToolStripMenuItem
            // 
            this.averageToolStripMenuItem.Name = "averageToolStripMenuItem";
            this.averageToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.averageToolStripMenuItem.Text = "Average";
            this.averageToolStripMenuItem.Click += new System.EventHandler(this.averageToolStripMenuItem_Click);
            // 
            // adaptiveToolStripMenuItem
            // 
            this.adaptiveToolStripMenuItem.Name = "adaptiveToolStripMenuItem";
            this.adaptiveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.adaptiveToolStripMenuItem.Text = "Adaptive";
            this.adaptiveToolStripMenuItem.Click += new System.EventHandler(this.adaptiveToolStripMenuItem_Click);
            // 
            // ProcessingTimeLabel
            // 
            this.ProcessingTimeLabel.AutoSize = true;
            this.ProcessingTimeLabel.Location = new System.Drawing.Point(37, 485);
            this.ProcessingTimeLabel.Name = "ProcessingTimeLabel";
            this.ProcessingTimeLabel.Size = new System.Drawing.Size(35, 13);
            this.ProcessingTimeLabel.TabIndex = 6;
            this.ProcessingTimeLabel.Text = "label1";
            this.ProcessingTimeLabel.Visible = false;
            // 
            // boundryDetectionToolStripMenuItem
            // 
            this.boundryDetectionToolStripMenuItem.Name = "boundryDetectionToolStripMenuItem";
            this.boundryDetectionToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.boundryDetectionToolStripMenuItem.Text = "Boundry Detection";
            this.boundryDetectionToolStripMenuItem.Click += new System.EventHandler(this.boundryDetectionToolStripMenuItem_Click);
            // 
            // erossionToolStripMenuItem
            // 
            this.erossionToolStripMenuItem.Name = "erossionToolStripMenuItem";
            this.erossionToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.erossionToolStripMenuItem.Text = "Erossion";
            this.erossionToolStripMenuItem.Click += new System.EventHandler(this.erossionToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 507);
            this.Controls.Add(this.ProcessingTimeLabel);
            this.Controls.Add(this.picBox_NewBtmp);
            this.Controls.Add(this.picBox_oldBtmp);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBox_oldBtmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_NewBtmp)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_oldBtmp;
        private System.Windows.Forms.PictureBox picBox_NewBtmp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianEdgeDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpeningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianSharpeningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaptiveToolStripMenuItem;
        private System.Windows.Forms.Label ProcessingTimeLabel;
        private System.Windows.Forms.ToolStripMenuItem boundryDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erossionToolStripMenuItem;
    }
}

