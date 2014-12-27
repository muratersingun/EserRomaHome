namespace EserRomaHome
{
    partial class RomeHome
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
            this.tsbSatis = new System.Windows.Forms.ToolStripMenuItem();
            this.barkodOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aLIŞToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alisFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSatis,
            this.barkodOluşturToolStripMenuItem,
            this.aLIŞToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1365, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsbSatis
            // 
            this.tsbSatis.Name = "tsbSatis";
            this.tsbSatis.Size = new System.Drawing.Size(43, 20);
            this.tsbSatis.Text = "Satıs";
            this.tsbSatis.Click += new System.EventHandler(this.tsbSatis_Click);
            // 
            // barkodOluşturToolStripMenuItem
            // 
            this.barkodOluşturToolStripMenuItem.Name = "barkodOluşturToolStripMenuItem";
            this.barkodOluşturToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.barkodOluşturToolStripMenuItem.Text = "Barkod Oluştur";
            this.barkodOluşturToolStripMenuItem.Click += new System.EventHandler(this.barkodOluşturToolStripMenuItem_Click);
            // 
            // aLIŞToolStripMenuItem
            // 
            this.aLIŞToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alisFormToolStripMenuItem});
            this.aLIŞToolStripMenuItem.Name = "aLIŞToolStripMenuItem";
            this.aLIŞToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.aLIŞToolStripMenuItem.Text = "ALIŞ";
            // 
            // alisFormToolStripMenuItem
            // 
            this.alisFormToolStripMenuItem.Name = "alisFormToolStripMenuItem";
            this.alisFormToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.alisFormToolStripMenuItem.Text = "AlisForm";
            this.alisFormToolStripMenuItem.Click += new System.EventHandler(this.alisFormToolStripMenuItem_Click);
            // 
            // RomeHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 747);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RomeHome";
            this.Text = "RomeHome";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsbSatis;
        private System.Windows.Forms.ToolStripMenuItem barkodOluşturToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aLIŞToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alisFormToolStripMenuItem;
    }
}