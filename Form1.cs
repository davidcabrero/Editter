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
using PdfSharp.Pdf.Security;

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

        private void protegerPdf_Click(object sender, EventArgs e)
        {
            // Crear un diálogo para seleccionar un archivo PDF
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                Title = "Selecciona un archivo PDF para proteger"
            };

            // Mostrar el diálogo y obtener la ruta del archivo PDF seleccionado
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdfPath = openFileDialog.FileName;

                // Solicitar al usuario que ingrese la contraseña
                string contraseña = Prompt.ShowDialog("Contraseña:", "Contraseña");

                // Verificar si se proporcionó una contraseña
                if (!string.IsNullOrEmpty(contraseña))
                {
                    try
                    {
                        // Cargar el documento PDF
                        PdfSharp.Pdf.PdfDocument pdfDocument = PdfReader.Open(pdfPath, PdfDocumentOpenMode.Modify);

                        // Proteger el documento PDF con la contraseña proporcionada
                        pdfDocument.SecuritySettings.UserPassword = contraseña;

                        // Guardar el documento PDF protegido
                        pdfDocument.Save(pdfPath);

                        MessageBox.Show($"Archivo pdf protegido correctamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al proteger el archivo PDF: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("No se proporcionó una contraseña.");
                }
            }
            else
            {
                MessageBox.Show("No se seleccionó ningún archivo PDF.");
            }
        }
    }

    // Clase para mostrar un cuadro de diálogo de entrada de texto personalizado
    public static class Prompt
    {
        public static string ShowDialog(string texto, string título)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = título,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = texto };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
