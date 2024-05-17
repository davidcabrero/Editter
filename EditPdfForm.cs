using System;
using System.Windows.Forms;



namespace Editter
{
    public partial class EditPdfForm : Form
    {
        private string pdfFilePath;

        public EditPdfForm(string filePath)
        {
            InitializeComponent();
            pdfFilePath = filePath;
            MostrarPDF(pdfFilePath);
        }

        private void MostrarPDF(string filePath)
        {
            // Crea una URL especial que apunta al archivo PDF
            string fileUrl = "file:///" + filePath.Replace("\\", "/");

            // Carga la URL del archivo PDF en el control WebBrowser
            webBrowser.Navigate(fileUrl);
        }
    }
}