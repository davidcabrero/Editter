using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using Spire.Doc;
using FileFormat = Spire.Pdf.FileFormat;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;

namespace Editter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void ConvertPdfToWord(string pdfFile, string wordFile)
        {
            Spire.Pdf.PdfDocument pdf = new Spire.Pdf.PdfDocument();
            pdf.LoadFromFile(pdfFile);
            pdf.SaveToFile(wordFile, FileFormat.DOCX);
        }

        private void ConvertWordToPdf(string wordFile, string pdfFile)
        {
            Spire.Doc.Document document = new Spire.Doc.Document();
            document.LoadFromFile(wordFile);
            document.SaveToFile(pdfFile, Spire.Doc.FileFormat.PDF);
        }

        private void botonPW_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Word files (*.docx)|*.docx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ConvertPdfToWord(openFileDialog.FileName, saveFileDialog.FileName);
                    MessageBox.Show("Conversión completada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void botonWP_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word files (*.docx)|*.docx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ConvertWordToPdf(openFileDialog.FileName, saveFileDialog.FileName);
                    MessageBox.Show("Conversión completada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void verPdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                EditPdfForm ventana = new EditPdfForm(openFileDialog.FileName);
                ventana.ShowDialog();
            }
        }

        private void cortarPdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CortarPdfForm ventana = new CortarPdfForm(openFileDialog.FileName);
                ventana.ShowDialog();
            }
        }

        private void unirPdf_Click(object sender, EventArgs e)
        {
            // Crear un diálogo para seleccionar archivos
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                Title = "Selecciona los archivos PDF"
            };

            // Mostrar el diálogo y obtener los archivos seleccionados
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] archivosSeleccionados = openFileDialog.FileNames;
                if (archivosSeleccionados.Length > 0)
                {
                    try
                    {
                        // Obtener la carpeta de origen del primer archivo seleccionado
                        string carpetaOrigen = Path.GetDirectoryName(archivosSeleccionados[0]);

                        // Crear el documento PDF final
                        PdfSharp.Pdf.PdfDocument pdfUnido = new PdfSharp.Pdf.PdfDocument();

                        // Agregar cada página de los archivos seleccionados al documento final
                        foreach (string archivo in archivosSeleccionados)
                        {
                            PdfSharp.Pdf.PdfDocument inputPdf = PdfReader.Open(archivo, PdfDocumentOpenMode.Import);
                            foreach (PdfPage page in inputPdf.Pages)
                            {
                                pdfUnido.AddPage(page);
                            }
                        }

                        // Guardar el documento final en la misma carpeta de origen
                        string nombreSalida = Path.Combine(carpetaOrigen, "pdfUnido.pdf");
                        pdfUnido.Save(nombreSalida);

                        MessageBox.Show($"PDF unidos con éxito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al unir los archivos PDF: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("No se seleccionaron archivos PDF.");
                }
            }
        }
    }
}
