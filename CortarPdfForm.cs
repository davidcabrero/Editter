
using System;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Editter
{
    public partial class CortarPdfForm : Form
    {

        private string txtInputFile;

        public CortarPdfForm(string filePath)
        {
            txtInputFile = filePath;
            InitializeComponent();
        }

        private void ProcessPdf()
        {
            try
            {
                string inputPath = txtInputFile;

                if (!File.Exists(inputPath))
                {
                    MessageBox.Show("El archivo no existe.");
                    return;
                }

                string pagesInput = paginasEliminar.Text;

                if (string.IsNullOrEmpty(pagesInput))
                {
                    MessageBox.Show("No se ingresaron páginas.");
                    return;
                }

                string[] pagesToDeleteStr = pagesInput.Split(',');
                int[] pagesToDelete = Array.ConvertAll(pagesToDeleteStr, int.Parse);

                string outputPath = Path.Combine(Path.GetDirectoryName(inputPath),
                                                 Path.GetFileNameWithoutExtension(inputPath) + "_cortado.pdf");

                DeletePdfPages(inputPath, outputPath, pagesToDelete);

                const string message = "¡PDF guardado con éxito!";
                const string caption = "Finalizado";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
        }

        static void DeletePdfPages(string inputPath, string outputPath, int[] pagesToDelete)
        {
            using (PdfDocument inputDocument = PdfReader.Open(inputPath, PdfDocumentOpenMode.Import))
            using (PdfDocument outputDocument = new PdfDocument())
            {
                for (int i = 0; i < inputDocument.PageCount; i++)
                {
                    if (!Array.Exists(pagesToDelete, page => page == i + 1))
                    {
                        outputDocument.AddPage(inputDocument.Pages[i]);
                    }
                }
                outputDocument.Save(outputPath);
            }
        }


        private void botonEliminar_Click(object sender, EventArgs e)
        {
            ProcessPdf();
        }

    }
}