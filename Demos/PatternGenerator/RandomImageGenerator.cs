using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;

namespace PattGen
{
    class RandomImageGenerator : IImageGenerator //Inherits from IImageGenerator
    {
        public event EventHandler<CancelEventArgs> NewImage; //The NewImage event

        private void BeginThread() //Thread that keeps firing the NewImage event
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();
            while(!cancelEventArgs.Cancel) //Loop forever
            {
                if(NewImage != null) //If the event is hooked
                {
                    NewImage(this, cancelEventArgs); //Fire the event
                }
                Thread.Sleep(5); //Don't use 100% CPU!
            }
        }

        public void StartGenerating() //Start the whole process
        {
            Thread t = new Thread(BeginThread) {IsBackground = true}; //Create a new thread and set it to background
            t.Start(); //Start the thread
        }

        public Img GetImage() //This generates and returns a "random" image
        {
            const int width = 700, height = 700; //Our width and height specifications
            Random random = new  Random(); //Create a random to generate random numbers
            byte[] palette = new byte[15]; //An array to keep the colours we will use
            int[] myNumbers = new int[15];

            for ( int i = 0; i < 15; i++ ) //For loop to loop 15 times
            {
                palette[i] = (byte)random.Next(1, 255); //Generate a random colour
                myNumbers[i] = random.Next(1, 10); //Generate a random number between 1 and 10
            }
            
            const int bytes = 4 * width * height; //Find the number of bytes in the Bitmap
            byte[] rgbValues = new byte[bytes]; //Declare an array to hold the bytes of the Bitmap
            

            for (int counter = 0; counter < rgbValues.Length; counter += 3) //For loop to loop through all the image pixels
            {
                for (int i = 0; i < 15; i++) //For loop to loop 15 times
                {
                    if (counter % myNumbers[i] == 0) //If counter is divisible by a random number between 1 and 10 (Just to make the image a bit more interesting)
                    {
                        if(counter + i < rgbValues.Length) //If the counter add i isn't out of the array range
                            rgbValues[counter + i] = palette[i]; //Put a random colour (index of i into myColour) at that place
                    } else
                    {
                        break;
                    }
                }
            }

            return new Img(rgbValues, width, height); //Return our finished product in AoB (Img) form
        }
    }
}
