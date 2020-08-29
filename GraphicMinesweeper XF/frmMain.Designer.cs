namespace GraphicMinesweeper_XF
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
            this.lbxMode = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbxMode
            // 
            this.lbxMode.FormattingEnabled = true;
            this.lbxMode.ItemHeight = 16;
            this.lbxMode.Items.AddRange(new object[] {
            "Flag Mode",
            "Guess Mode"});
            this.lbxMode.Location = new System.Drawing.Point(430, 13);
            this.lbxMode.Name = "lbxMode";
            this.lbxMode.Size = new System.Drawing.Size(105, 36);
            this.lbxMode.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 484);
            this.Controls.Add(this.lbxMode);
            this.Name = "frmMain";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMode;
    }
}

