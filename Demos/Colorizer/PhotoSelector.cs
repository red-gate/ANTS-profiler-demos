using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureManager
{
    public partial class FormPhotoSelector : Form
    {

        public event EventHandler LoadImage;

        public FormPhotoSelector()
        {
            InitializeComponent();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            openFileDialogChooseImage.ShowDialog();
        }

        private void openFileDialogChooseImage_FileOk(object sender, CancelEventArgs e)
        {
            if (LoadImage != null)
            {
                LoadImage(this, EventArgs.Empty);
            }
            PhotoColorizer editorWindow = new PhotoColorizer(this, openFileDialogChooseImage.FileName);
        }

    }
}