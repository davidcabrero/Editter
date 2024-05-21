namespace Editter
{
    partial class CortarPdfForm
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
            this.paginasEliminar = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.botonEliminar = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // paginasEliminar
            // 
            this.paginasEliminar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.paginasEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.paginasEliminar.Location = new System.Drawing.Point(58, 99);
            this.paginasEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.paginasEliminar.MinimumSize = new System.Drawing.Size(1, 16);
            this.paginasEliminar.Name = "paginasEliminar";
            this.paginasEliminar.Padding = new System.Windows.Forms.Padding(5);
            this.paginasEliminar.ShowText = false;
            this.paginasEliminar.Size = new System.Drawing.Size(520, 49);
            this.paginasEliminar.TabIndex = 0;
            this.paginasEliminar.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.paginasEliminar.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(55, 31);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(571, 49);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "Páginas a eliminar: (Separadas por comas y sin espacios)";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // botonEliminar
            // 
            this.botonEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.botonEliminar.Location = new System.Drawing.Point(599, 99);
            this.botonEliminar.MinimumSize = new System.Drawing.Size(1, 1);
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Size = new System.Drawing.Size(138, 49);
            this.botonEliminar.TabIndex = 2;
            this.botonEliminar.Text = "Eliminar";
            this.botonEliminar.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.botonEliminar.Click += new System.EventHandler(this.botonEliminar_Click);
            // 
            // CortarPdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 202);
            this.Controls.Add(this.botonEliminar);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.paginasEliminar);
            this.Name = "CortarPdfForm";
            this.Text = "CortarPdfForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox paginasEliminar;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton botonEliminar;
    }
}