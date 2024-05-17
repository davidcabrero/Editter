using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editter
{
    public partial class InputDialog : Form
    {
        public string UserInput { get; private set; }

        public InputDialog(string prompt)
        {
            this.Text = "Entrada requerida";
            Label label = new Label() { Left = 50, Top = 20, Text = prompt, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Aceptar", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => { this.UserInput = textBox.Text; this.Close(); };

            this.Controls.Add(label);
            this.Controls.Add(textBox);
            this.Controls.Add(confirmation);
            this.AcceptButton = confirmation;
        }
    }
}
