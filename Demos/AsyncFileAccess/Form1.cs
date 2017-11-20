using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AsyncFileAccess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSourceBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserSource.ShowDialog() == DialogResult.OK)
            {
                textBoxSourceSelect.Text = folderBrowserSource.SelectedPath;
            }
        }

        private void buttonDestBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDest.ShowDialog() == DialogResult.OK)
            {
                textBoxDestSelect.Text = folderBrowserDest.SelectedPath;
            }
        }

        private async void buttonCopy_Click(object sender, EventArgs e)
        {
            labelResult.Visible = false;
            progressBarCopied.Visible = true;

            var dirIn = textBoxSourceSelect.Text;
            var dirOut = textBoxDestSelect.Text;
            
            var filesCopied = await CopyFilesAsync(dirIn, dirOut);
            
            labelResult.Visible = true;
            progressBarCopied.Visible = false;
            labelResult.Text = filesCopied + " files were copied";
        }

        private async Task<int> CopyFilesAsync(string dirIn, string dirOut)
        {
            int fileCount = 0;
            var files = Directory.EnumerateFiles(dirIn);
            var totalFiles = files.Count();
            foreach (string filename in files)
            {
                CopySingleFileAsync(dirOut, filename);
                fileCount++;
                progressBarCopied.Value = (100 * fileCount) / totalFiles;
                progressBarCopied.Refresh();
            }
            return fileCount;
        }

        private async void CopySingleFileAsync(string dirOut, string filename)
        {
            using (var sourceStream = File.Open(filename, FileMode.Open))
            {
                using (var destinationStream = File.Create(dirOut + filename.Substring(filename.LastIndexOf('\\'))))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                    AddFileToMasterIndexAsync(dirOut, filename);
                }
            }
        }

        private async void AddFileToMasterIndexAsync(string dirOut, string filename)
        {
            var outputFile = dirOut + filename.Substring(filename.LastIndexOf('\\'));
            var indexHash = await BuildIndividualFileIndexAsync(outputFile);
            AddIndexToStoreAsync();
        }

        private async Task<string> BuildIndividualFileIndexAsync(string outputFile)
        {
            var hash = await Task.Run(() => CreateFileHashAsync(outputFile));
            return hash;
        }

        private async Task<string> CreateFileHashAsync(string filename)
        {
            var md5 = MD5.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(filename));
            return md5.ToString();
        }


        
        private void Form1_Load(object sender, EventArgs e)
        {
            var defaultInputDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input");
            var defaultOutputDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");

            textBoxSourceSelect.Text = folderBrowserSource.SelectedPath = defaultInputDirectory;
            textBoxDestSelect.Text = folderBrowserDest.SelectedPath = defaultOutputDirectory;

            var dir = new DirectoryInfo(defaultOutputDirectory);
            if (dir.Exists)
            {
                dir.Delete(true);
            }
            dir.Create();

            var neverUsedMd5 = MD5.Create();
        }




        private async Task<int> AddIndexToStoreAsync()
        {
            var randomDelay = new Random().Next(50, 150);
            Thread.Sleep(randomDelay);
            return randomDelay;
        }

    }
}