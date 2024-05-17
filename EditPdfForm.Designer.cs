namespace Editter
{
    partial class EditPdfForm
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
            this.RichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.botonGuardar = new Sunny.UI.UIButton();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.FillColor = System.Drawing.Color.White;
            this.RichTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.RichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RichTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.RichTextBox1.ScrollBarStyleInherited = false;
            this.RichTextBox1.ShowText = false;
            this.RichTextBox1.Size = new System.Drawing.Size(270, 180);
            this.RichTextBox1.TabIndex = 0;
            this.RichTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // botonGuardar
            // 
            this.botonGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.botonGuardar.Location = new System.Drawing.Point(0, 0);
            this.botonGuardar.MinimumSize = new System.Drawing.Size(1, 1);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(100, 35);
            this.botonGuardar.TabIndex = 0;
            this.botonGuardar.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(751, 521);
            this.webBrowser.TabIndex = 0;
            // 
            // EditPdfForm
            // 
            this.ClientSize = new System.Drawing.Size(751, 521);
            this.Controls.Add(this.webBrowser);
            this.Name = "EditPdfForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIRichTextBox RichTextBox1;
        private Sunny.UI.UIButton botonGuardar;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}