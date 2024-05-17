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
            PdfDocument pdf = new PdfDocument();
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

        }
    }
}
