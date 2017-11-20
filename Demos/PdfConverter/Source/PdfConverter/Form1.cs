using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MuPDFLib;

namespace PdfConverter
{
    public partial class Form1 : Form
    {
        private static Bitmap[] bitmaps = new Bitmap[0];
        private int pageCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBegin_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void loadPdf(string pdfFilename)
        {
            MuPDF muPdf = new MuPDF(pdfFilename, "");
            pageCount = muPdf.PageCount;
            Array.Resize(ref bitmaps, pageCount);
            MuPDF pdfPage;
            for (int page = 1; page <= pageCount; page++)
            {
                pdfPage = new MuPDF(pdfFilename, "");
                pdfPage.Page = page;
                bitmaps[page - 1] = pdfPage.GetBitmap(450, 0, 300, 300, 0, RenderType.RGB, false, false, 10000000);

            }
            numericUpDownPageSelector.Value = 1;
            pictureBox1.Image = bitmaps[0];
        }

        private void updateImage()
        {
            if (numericUpDownPageSelector.Value > 0 && numericUpDownPageSelector.Value <= pageCount && pageCount > 0)
            {
                pictureBox1.Image = bitmaps[(int)numericUpDownPageSelector.Value-1];
            }
            else
            {
                numericUpDownPageSelector.Value = 1;
            }
            
        }

        private void numericUpDownPageSelector_ValueChanged(object sender, EventArgs e)
        {
            updateImage();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            label3.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
            loadPdf(openFileDialog1.FileName);
            label2.Enabled = true;
            numericUpDownPageSelector.Enabled = true;
            buttonChooseOutput.Enabled = true;
        }

        private void buttonSaveOutput_Click(object sender, EventArgs e)
        {
            //Some other time, perhaps.
            MessageBox.Show("Success!");
        }

        private void buttonChooseOutput_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                label4.Text = folderBrowserDialog1.SelectedPath;
                buttonSaveOutput.Enabled = true;
            }
        }


    }
}
