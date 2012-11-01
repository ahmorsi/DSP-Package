namespace DSP_Image_Processing
{
    partial class Structural_Element_Options
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.windowHeight_txt = new System.Windows.Forms.TextBox();
            this.windowWidth_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pnlGridDraw = new System.Windows.Forms.Panel();
            this.btnDrawGrid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(112, 289);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 27);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(18, 289);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 27);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // windowHeight_txt
            // 
            this.windowHeight_txt.Location = new System.Drawing.Point(101, 36);
            this.windowHeight_txt.Name = "windowHeight_txt";
            this.windowHeight_txt.Size = new System.Drawing.Size(100, 20);
            this.windowHeight_txt.TabIndex = 9;
            // 
            // windowWidth_txt
            // 
            this.windowWidth_txt.Location = new System.Drawing.Point(101, 10);
            this.windowWidth_txt.Name = "windowWidth_txt";
            this.windowWidth_txt.Size = new System.Drawing.Size(100, 20);
            this.windowWidth_txt.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Window Height :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Window Width :";
            // 
            // pnlGridDraw
            // 
            this.pnlGridDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGridDraw.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlGridDraw.Location = new System.Drawing.Point(12, 94);
            this.pnlGridDraw.Name = "pnlGridDraw";
            this.pnlGridDraw.Size = new System.Drawing.Size(180, 174);
            this.pnlGridDraw.TabIndex = 12;
            this.pnlGridDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGridDraw_Paint);
            // 
            // btnDrawGrid
            // 
            this.btnDrawGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawGrid.Location = new System.Drawing.Point(12, 65);
            this.btnDrawGrid.Name = "btnDrawGrid";
            this.btnDrawGrid.Size = new System.Drawing.Size(180, 23);
            this.btnDrawGrid.TabIndex = 13;
            this.btnDrawGrid.Text = "Draw Grid";
            this.btnDrawGrid.UseVisualStyleBackColor = true;
            this.btnDrawGrid.Click += new System.EventHandler(this.btnDrawGrid_Click);
            // 
            // Structural_Element_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 323);
            this.Controls.Add(this.btnDrawGrid);
            this.Controls.Add(this.pnlGridDraw);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.windowHeight_txt);
            this.Controls.Add(this.windowWidth_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Structural_Element_Options";
            this.Text = "Structural_Element_Options";
            this.Load += new System.EventHandler(this.Structural_Element_Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox windowHeight_txt;
        private System.Windows.Forms.TextBox windowWidth_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel pnlGridDraw;
        private System.Windows.Forms.Button btnDrawGrid;
    }
}