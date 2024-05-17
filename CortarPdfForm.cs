using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using System.IO;
using iText.Kernel.Utils;

namespace Editter
{
    public partial class CortarPdfForm : Form
    {

        private string txtInputFile;

        public CortarPdfForm(string filePath)
        {
            InitializeComponent();
            txtInputFile = filePath;
        }

        private void ProcessPdf()
        {
            string inputFilePath = txtInputFile;

            if (string.IsNullOrEmpty(inputFilePath))
            {
                MessageBox.Show("Por favor, seleccione un archivo PDF de entrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string pagesToRemoveInput = paginasEliminar.Text;

            if (string.IsNullOrEmpty(pagesToRemoveInput))
            {
                MessageBox.Show("No se ingresaron páginas para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var pagesToRemove = ParsePagesToRemove(pagesToRemoveInput);

            if (pagesToRemove.Count > 0)
            {
                string outputFilePath = GetOutputFilePath(inputFilePath);
                try
                {
                    RemovePagesFromPdf(inputFilePath, outputFilePath, pagesToRemove);
                    MessageBox.Show("El nuevo PDF se ha guardado correctamente sin las páginas especificadas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al procesar el archivo PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese números de página válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string ShowInputDialog(string prompt)
        {
            InputDialog inputDialog = new InputDialog(prompt);
            return inputDialog.ShowDialog() == DialogResult.OK ? inputDialog.UserInput : string.Empty;
        }

        private List<int> ParsePagesToRemove(string pagesToRemoveInput)
        {
            var pagesToRemove = new List<int>();
            var pages = pagesToRemoveInput.Split(',');

            foreach (var page in pages)
            {
                if (int.TryParse(page.Trim(), out int pageNumber))
                {
                    pagesToRemove.Add(pageNumber);
                }
                else
                {
                    MessageBox.Show($"'{page}' no es un número de página válido y será ignorado.");
                }
            }

            return pagesToRemove;
        }

        private string GetOutputFilePath(string inputFilePath)
        {
            string directory = Path.GetDirectoryName(inputFilePath);
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(inputFilePath);
            string extension = Path.GetExtension(inputFilePath);
            return Path.Combine(directory, $"{filenameWithoutExtension}_cortado{extension}");
        }

        private void RemovePagesFromPdf(string inputFilePath, string outputFilePath, List<int> pagesToRemove)
        {
            using (PdfReader pdfReader = new PdfReader(inputFilePath))
            {
                using (PdfWriter pdfWriter = new PdfWriter(outputFilePath))
                {
                    using (PdfDocument pdfDocument = new PdfDocument(pdfReader, pdfWriter))
                    {
                        pdfDocument.InitializeOutlines();

                        int totalNumberOfPages = pdfDocument.GetNumberOfPages();
                        pagesToRemove.Sort((a, b) => b.CompareTo(a)); // Ordenar de mayor a menor

                        foreach (var pageNumber in pagesToRemove)
                        {
                            if (pageNumber > 0 && pageNumber <= totalNumberOfPages)
                            {
                                pdfDocument.RemovePage(pageNumber);
                            }
                            else
                            {
                                MessageBox.Show($"La página {pageNumber} no existe en el documento y no se puede eliminar.");
                            }
                        }
                    }
                }
            }
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            ProcessPdf();
        }
    }
}