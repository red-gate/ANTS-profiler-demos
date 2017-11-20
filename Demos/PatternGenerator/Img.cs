using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace PattGen
{
    public class Img
    {
        private readonly byte[] m_RgbValues; //Colour values for each pixel
        private readonly int m_Width; //Width of image
        private readonly int m_Height; //Height of image

        public Img (byte[] rgbVals, int recWidth, int recHeight) //Constructor
        {
            m_RgbValues = rgbVals; //Set struct rgbValues to passed param
            m_Width = recWidth; //Set struct width to passed param
            m_Height = recHeight; //Set struct height to passed param
        }

        public int CountRGBVals() { return m_RgbValues.Count(); }
        public int GetRGBValsVal(int index) { return m_RgbValues[index]; }

        public Image ToBitmap() //Function to convert a list of pixel colour, width, height and format to a bitmap
        {
            Bitmap myBitmap = new Bitmap(m_Width, m_Height); //Create a new Bitmap
            Rectangle rect = new Rectangle(0, 0, m_Width, m_Height); //Create a new rect to specify the size of the image to lock
            BitmapData bmpData = myBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb); //Lock the Bitmap's bits
            IntPtr ptr = bmpData.Scan0; //Get the address of the first line
            int bytes = Math.Abs(bmpData.Stride) * m_Height; //Find the number of bytes in the Bitmap

            System.Runtime.InteropServices.Marshal.Copy(m_RgbValues, 0, ptr, bytes); //Copy the RGB values back to the bitmap
            myBitmap.UnlockBits(bmpData); //Unlock the bits

            return myBitmap; //Return the finished bitmap
        }
    }
}
