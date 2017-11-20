using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PictureManager
{
    public partial class PhotoColorizer : Form
    {
        private string fileName;

        public PhotoColorizer(FormPhotoSelector parentWindow, string filePath)
        {
            fileName = filePath;
            this.Show();
            parentWindow.LoadImage += newWindowLoaded;
            InitializeComponent();
        }

        private void newWindowLoaded(object sender, EventArgs e) //memory leak tastic.
        {
            this.Close();
        }

        private void PhotoEditor_Shown(object sender, EventArgs e)
        {
            Bitmap sourceImage = (Bitmap)Bitmap.FromFile(fileName);

            //random recolorisations
            List<ColorSet> colorSets = new List<ColorSet>();
            colorSets.Add(new ColorSet(255, 255, 255));
            colorSets.Add(new ColorSet(255, 0, 0));
            colorSets.Add(new ColorSet(120, 0, 0));
            colorSets.Add(new ColorSet(0, 255, 0));
            colorSets.Add(new ColorSet(0, 120, 0));
            colorSets.Add(new ColorSet(0, 0, 255));
            colorSets.Add(new ColorSet(0, 0, 120));
            colorSets.Add(new ColorSet(255, 255, 0));
            colorSets.Add(new ColorSet(120, 255, 0));
            colorSets.Add(new ColorSet(255, 120, 0));
            colorSets.Add(new ColorSet(255, 0, 255));
            colorSets.Add(new ColorSet(255, 0, 120));
            colorSets.Add(new ColorSet(120, 0, 255));
            colorSets.Add(new ColorSet(0, 255, 255));
            colorSets.Add(new ColorSet(0, 255, 120));

            foreach (ColorSet colorSet in colorSets)
            {
                tableLayoutPanelThumbnails.Controls.Add(new PictureBox() { Image = sourceImage.ColorBalance(colorSet), SizeMode = PictureBoxSizeMode.Zoom, Padding = new Padding(0), Width = 120, Height = 80 });
                tableLayoutPanelThumbnails.Refresh();
            }

            foreach (PictureBox pictureBox in tableLayoutPanelThumbnails.Controls)
            {
                pictureBox.Click += newPreview;
            }

            pictureBoxPreview.Image = sourceImage;
        }

        

        public void newPreview(object sender, EventArgs e)
        {
            pictureBoxPreview.Image = (Image)sender.GetType().GetProperty("Image").GetValue(sender, null);
        }
    }

    public class ColorSet
    {
        public int red;
        public int green;
        public int blue;

        public ColorSet(int redVal, int greenVal, int blueVal)
        {
            red = redVal;
            green = greenVal;
            blue = blueVal;
        }
    }

    public static class Colorizer
    {
        public static Bitmap ColorBalance(this Bitmap sourceBitmap, ColorSet colorSet)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                        sourceBitmap.Width, sourceBitmap.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            sourceBitmap.UnlockBits(sourceData);


            float blue = 0;
            float green = 0;
            float red = 0;


            float blueLevelFloat = colorSet.blue;
            float greenLevelFloat = colorSet.green;
            float redLevelFloat = colorSet.red;


            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = 255.0f / blueLevelFloat * (float)pixelBuffer[k];
                green = 255.0f / greenLevelFloat * (float)pixelBuffer[k + 1];
                red = 255.0f / redLevelFloat * (float)pixelBuffer[k + 2];

                if (blue > 255) { blue = 255; }
                else if (blue < 0) { blue = 0; }

                if (green > 255) { green = 255; }
                else if (green < 0) { green = 0; }

                if (red > 255) { red = 255; }
                else if (red < 0) { red = 0; }

                pixelBuffer[k] = (byte)blue;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)red;
            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                        resultBitmap.Width, resultBitmap.Height),
                                       ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
        }

    }
}