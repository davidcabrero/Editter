namespace Editter
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.botonPW = new Sunny.UI.UIButton();
            this.botonWP = new Sunny.UI.UIButton();
            this.VerPdf = new Sunny.UI.UIButton();
            this.cortarPdf = new Sunny.UI.UIButton();
            this.unirPdf = new Sunny.UI.UIButton();
            this.protegerPdf = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // botonPW
            // 
            this.botonPW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonPW.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.botonPW.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.botonPW.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.botonPW.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.botonPW.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.botonPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.botonPW.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.botonPW.Location = new System.Drawing.Point(178, 97);
            this.botonPW.MinimumSize = new System.Drawing.Size(1, 1);
            this.botonPW.Name = "botonPW";
            this.botonPW.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.botonPW.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.botonPW.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.botonPW.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.botonPW.Size = new System.Drawing.Size(180, 64);
            this.botonPW.Style = Sunny.UI.UIStyle.Custom;
            this.botonPW.TabIndex = 0;
            this.botonPW.Text = "PDF a Word";
            this.botonPW.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.botonPW.Click += new System.EventHandler(this.botonPW_Click);
            // 
            // botonWP
            // 
            this.botonWP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonWP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.botonWP.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.botonWP.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.botonWP.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.botonWP.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.botonWP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.botonWP.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.botonWP.Location = new System.Drawing.Point(407, 97);
            this.botonWP.MinimumSize = new System.Drawing.Size(1, 1);
            this.botonWP.Name = "botonWP";
            this.botonWP.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.botonWP.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.botonWP.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.botonWP.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.botonWP.Size = new System.Drawing.Size(180, 64);
            this.botonWP.Style = Sunny.UI.UIStyle.Custom;
            this.botonWP.TabIndex = 1;
            this.botonWP.Text = "Word a PDF";
            this.botonWP.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.botonWP.Click += new System.EventHandler(this.botonWP_Click);
            // 
            // VerPdf
            // 
            this.VerPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VerPdf.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.VerPdf.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.VerPdf.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.VerPdf.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.VerPdf.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.VerPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.VerPdf.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.VerPdf.Location = new System.Drawing.Point(178, 193);
            this.VerPdf.MinimumSize = new System.Drawing.Size(1, 1);
            this.VerPdf.Name = "VerPdf";
            this.VerPdf.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.VerPdf.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.VerPdf.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.VerPdf.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.VerPdf.Size = new System.Drawing.Size(180, 64);
            this.VerPdf.Style = Sunny.UI.UIStyle.Custom;
            this.VerPdf.TabIndex = 2;
            this.VerPdf.Text = "Ver PDF";
            this.VerPdf.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VerPdf.Click += new System.EventHandler(this.verPdf_Click);
            // 
            // cortarPdf
            // 
            this.cortarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cortarPdf.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.cortarPdf.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.cortarPdf.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.cortarPdf.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.cortarPdf.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.cortarPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cortarPdf.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.cortarPdf.Location = new System.Drawing.Point(407, 193);
            this.cortarPdf.MinimumSize = new System.Drawing.Size(1, 1);
            this.cortarPdf.Name = "cortarPdf";
            this.cortarPdf.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.cortarPdf.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.cortarPdf.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.cortarPdf.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.cortarPdf.Size = new System.Drawing.Size(180, 64);
            this.cortarPdf.Style = Sunny.UI.UIStyle.Custom;
            this.cortarPdf.TabIndex = 3;
            this.cortarPdf.Text = "Cortar PDF";
            this.cortarPdf.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cortarPdf.Click += new System.EventHandler(this.cortarPdf_Click);
            // 
            // unirPdf
            // 
            this.unirPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.unirPdf.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.unirPdf.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.unirPdf.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.unirPdf.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.unirPdf.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.unirPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.unirPdf.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.unirPdf.Location = new System.Drawing.Point(178, 287);
            this.unirPdf.MinimumSize = new System.Drawing.Size(1, 1);
            this.unirPdf.Name = "unirPdf";
            this.unirPdf.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.unirPdf.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.unirPdf.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.unirPdf.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.unirPdf.Size = new System.Drawing.Size(180, 64);
            this.unirPdf.Style = Sunny.UI.UIStyle.Custom;
            this.unirPdf.TabIndex = 4;
            this.unirPdf.Text = "Unir PDF";
            this.unirPdf.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.unirPdf.Click += new System.EventHandler(this.unirPdf_Click);
            // 
            // protegerPdf
            // 
            this.protegerPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.protegerPdf.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.protegerPdf.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.protegerPdf.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.protegerPdf.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.protegerPdf.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.protegerPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.protegerPdf.LightColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.protegerPdf.Location = new System.Drawing.Point(407, 287);
            this.protegerPdf.MinimumSize = new System.Drawing.Size(1, 1);
            this.protegerPdf.Name = "protegerPdf";
            this.protegerPdf.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.protegerPdf.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.protegerPdf.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.protegerPdf.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.protegerPdf.Size = new System.Drawing.Size(180, 64);
            this.protegerPdf.Style = Sunny.UI.UIStyle.Custom;
            this.protegerPdf.TabIndex = 5;
            this.protegerPdf.Text = "Proteger PDF";
            this.protegerPdf.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.protegerPdf.Click += new System.EventHandler(this.protegerPdf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.protegerPdf);
            this.Controls.Add(this.unirPdf);
            this.Controls.Add(this.cortarPdf);
            this.Controls.Add(this.VerPdf);
            this.Controls.Add(this.botonWP);
            this.Controls.Add(this.botonPW);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton botonPW;
        private Sunny.UI.UIButton botonWP;
        private Sunny.UI.UIButton VerPdf;
        private Sunny.UI.UIButton cortarPdf;
        private Sunny.UI.UIButton unirPdf;
        private Sunny.UI.UIButton protegerPdf;
    }
}

