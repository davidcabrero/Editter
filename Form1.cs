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
using PdfSharp.Drawing;
using iText.Kernel.Pdf.Canvas.Wmf;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net.Http;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Geom;
using System.Diagnostics;

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
                        string carpetaOrigen = System.IO.Path.GetDirectoryName(archivosSeleccionados[0]);

                        // Crear el documento PDF final
                        PdfSharp.Pdf.PdfDocument pdfUnido = new PdfSharp.Pdf.PdfDocument();

                        // Agregar cada página de los archivos seleccionados al documento final
                        foreach (string archivo in archivosSeleccionados)
                        {
                            PdfSharp.Pdf.PdfDocument inputPdf = PdfSharp.Pdf.IO.PdfReader.Open(archivo, PdfDocumentOpenMode.Import);
                            foreach (PdfSharp.Pdf.PdfPage page in inputPdf.Pages)
                            {
                                pdfUnido.AddPage(page);
                            }
                        }

                        // Guardar el documento final en la misma carpeta de origen
                        string nombreSalida = System.IO.Path.Combine(carpetaOrigen, "pdfUnido.pdf");
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
                        PdfSharp.Pdf.PdfDocument pdfDocument = PdfSharp.Pdf.IO.PdfReader.Open(pdfPath, PdfDocumentOpenMode.Modify);

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

        [STAThread]  // Requerido para permitir el uso de ventanas de diálogo en el hilo principal
        static async void TraducirPDFAsync()
        {
            // Mostrar un cuadro de diálogo para seleccionar un archivo PDF
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                Title = "Selecciona un archivo PDF para traducir"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaPdf = openFileDialog.FileName;

                // Solicitar el idioma de destino
                string idiomaDestino = Prompt.ShowDialog("Introduce el código del idioma de destino (ej: 'es' para español, 'fr' para francés):", "Idioma de destino");

                if (!string.IsNullOrEmpty(idiomaDestino))
                {
                    // Extraer el texto del PDF
                    string textoExtraido = ExtraerTextoDePdf(rutaPdf);
                    Console.WriteLine("Texto extraído del PDF: ");
                    Console.WriteLine(textoExtraido);

                    // Traducir el texto extraído
                    string textoTraducido = await TraducirTextoConOpentranslate(textoExtraido, idiomaDestino);

                    // Crear un nuevo PDF con el texto traducido
                    string rutaPdfTraducido = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rutaPdf), $"{System.IO.Path.GetFileNameWithoutExtension(rutaPdf)}_traducido.pdf");
                    CrearPdfConTextoTraducido(textoTraducido, rutaPdfTraducido);
                    Console.WriteLine($"PDF traducido guardado en: {rutaPdfTraducido}");
                }
            }
        }

        // Método para extraer texto de un PDF usando iText7
        static string ExtraerTextoDePdf(string rutaPdf)
        {
            using (iText.Kernel.Pdf.PdfReader pdfReader = new iText.Kernel.Pdf.PdfReader(rutaPdf))
            using (iText.Kernel.Pdf.PdfDocument pdfDoc = new iText.Kernel.Pdf.PdfDocument(pdfReader))
            {
                string texto = "";
                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    texto += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i));
                }
                return texto;
            }
        }

        // Método para traducir el texto utilizando la API de Opentranslate
        static async Task<string> TraducirTextoConOpentranslate(string texto, string idiomaDestino)
        {
            try
            {
                var client = new RestClient("https://translate.opentranslate.com/translate");
                var request = new RestRequest
                {
                    Method = Method.Post,
                    RequestFormat = DataFormat.Json
                };

                // Formato del body que requiere OpenTranslate para la solicitud
                string body = $"{{\"q\": \"{texto}\", \"source\": \"auto\", \"target\": \"{idiomaDestino}\"}}";
                request.AddStringBody(body, DataFormat.Json);

                // Ejecución de la solicitud y recepción de la respuesta
                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    JObject jsonResponse = JObject.Parse(response.Content);
                    return jsonResponse["translatedText"].ToString();
                }
                else
                {
                    throw new Exception($"Error en la traducción: {response.StatusCode} {response.Content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la traducción: {ex.Message}");
                return texto;  // Retorna el texto original si falla la traducción
            }

        }

        // Método para crear un nuevo PDF con el texto traducido
        public static void CrearPdfConTextoTraducido(string textoTraducido, string rutaSalida)
        {
            try
            {
                // Validar el texto y la ruta de salida
                if (string.IsNullOrWhiteSpace(textoTraducido))
                {
                    throw new ArgumentException("El texto traducido no puede ser nulo o vacío.");
                }

                if (string.IsNullOrWhiteSpace(rutaSalida))
                {
                    throw new ArgumentException("La ruta de salida no puede ser nula o vacía.");
                }

                // Asegurarse de que la carpeta existe
                string directory = System.IO.Path.GetDirectoryName(rutaSalida);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Crear el PDF
                using (PdfWriter writer = new PdfWriter(rutaSalida))
                {
                    using (iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer))
                    {
                        iText.Layout.Document document = new iText.Layout.Document(pdf);

                        // Establecer fuente
                        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                        document.SetFont(font);

                        Console.WriteLine(textoTraducido);

                        // Agregar texto al documento
                        document.Add(new Paragraph(textoTraducido));

                        // Cerrar el documento
                        document.Close();
                    }
                }

                Console.WriteLine($"PDF traducido guardado en: {rutaSalida}");
            }
            catch (iText.Kernel.Exceptions.PdfException ex)
            {
                Console.WriteLine($"Error al crear el PDF: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
            }
        }

        private void iaPDF_Click(object sender, EventArgs e)
        {
            // Ruta al ejecutable
            string rutaExe = @"C:\Editter\utilidades\main.exe";

            // Iniciar el proceso
            Process.Start(rutaExe);
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
