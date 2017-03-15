namespace CleanTileEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.layersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.wireFrameCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteLayerButton = new System.Windows.Forms.Button();
            this.addLayerButton = new System.Windows.Forms.Button();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tileDisplay1 = new CleanTileEditor.TileDisplay();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 611);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1370, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.layersCheckedListBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1080, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 587);
            this.panel1.TabIndex = 5;
            // 
            // layersCheckedListBox
            // 
            this.layersCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layersCheckedListBox.FormattingEnabled = true;
            this.layersCheckedListBox.Location = new System.Drawing.Point(0, 68);
            this.layersCheckedListBox.Name = "layersCheckedListBox";
            this.layersCheckedListBox.Size = new System.Drawing.Size(290, 374);
            this.layersCheckedListBox.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 442);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 145);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.wireFrameCheckBox);
            this.panel3.Controls.Add(this.deleteLayerButton);
            this.panel3.Controls.Add(this.addLayerButton);
            this.panel3.Controls.Add(this.fpsLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 68);
            this.panel3.TabIndex = 6;
            // 
            // wireFrameCheckBox
            // 
            this.wireFrameCheckBox.AutoSize = true;
            this.wireFrameCheckBox.Location = new System.Drawing.Point(28, 14);
            this.wireFrameCheckBox.Name = "wireFrameCheckBox";
            this.wireFrameCheckBox.Size = new System.Drawing.Size(74, 17);
            this.wireFrameCheckBox.TabIndex = 8;
            this.wireFrameCheckBox.Text = "Wireframe";
            this.wireFrameCheckBox.UseVisualStyleBackColor = true;
            // 
            // deleteLayerButton
            // 
            this.deleteLayerButton.Location = new System.Drawing.Point(154, 39);
            this.deleteLayerButton.Name = "deleteLayerButton";
            this.deleteLayerButton.Size = new System.Drawing.Size(110, 23);
            this.deleteLayerButton.TabIndex = 5;
            this.deleteLayerButton.Text = "Remove Layer";
            this.deleteLayerButton.UseVisualStyleBackColor = true;
            // 
            // addLayerButton
            // 
            this.addLayerButton.Location = new System.Drawing.Point(28, 39);
            this.addLayerButton.Name = "addLayerButton";
            this.addLayerButton.Size = new System.Drawing.Size(110, 23);
            this.addLayerButton.TabIndex = 6;
            this.addLayerButton.Text = "Add Layer";
            this.addLayerButton.UseVisualStyleBackColor = true;
            // 
            // fpsLabel
            // 
            this.fpsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpsLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.fpsLabel.Location = new System.Drawing.Point(153, 12);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(53, 17);
            this.fpsLabel.TabIndex = 4;
            this.fpsLabel.Text = "FPS: 0";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(1077, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 587);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // tileDisplay1
            // 
            this.tileDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileDisplay1.AutoDraw = true;
            this.tileDisplay1.ClearColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tileDisplay1.Location = new System.Drawing.Point(0, 24);
            this.tileDisplay1.Margin = new System.Windows.Forms.Padding(0);
            this.tileDisplay1.Name = "tileDisplay1";
            this.tileDisplay1.Size = new System.Drawing.Size(1077, 587);
            this.tileDisplay1.TabIndex = 4;
            this.tileDisplay1.Text = "tileDisplay1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 633);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tileDisplay1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private TileDisplay tileDisplay1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox layersCheckedListBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox wireFrameCheckBox;
        private System.Windows.Forms.Button deleteLayerButton;
        private System.Windows.Forms.Button addLayerButton;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.Splitter splitter1;
    }
}