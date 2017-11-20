using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PattGen
{
    public partial class ImageWindow : Form
    {
        private const int c_VideoLength = 100;
        private bool m_FinishedGenerating; //Bool for whether we've finished generating or not
        private int m_LastTrackbarValue; //An int for our last trackbar value (so that we don't redraw if we don't have to)

        private readonly Object m_NewImageLock = new Object(); //Create a lock (for the OnNewImage method)

        private readonly IImageGenerator m_ImageGenerator; //ImageGenerator member
        private readonly List<Img> m_MyImages = new List<Img>(); //List for the Bitmap AOBs (Imgs)

        private bool m_Closeable; //A bool for whether we can close the window or not

        public ImageWindow(IImageGenerator imageGenerator) //Constructor
        {
            InitializeComponent();
            m_FinishedGenerating = false; //Set FinishedGenerating to false
            m_ImageGenerator = imageGenerator; //Set our ImageGenerator member to whatever is passed into the constructor
            m_ImageGenerator.NewImage += OnNewImage; //Hook the NewImage action to the OnNewImage function
            m_MyImages.Add(m_ImageGenerator.GetImage()); //Get the first image and add it to the list
            m_ImageGenerator.StartGenerating(); //Tell the ImageGenerator to start!
            trackBar1.Enabled = false; //Disable the trackbar
            m_Closeable = false; //Set the Closeable variable to false
            Opacity = 0; //Set the window opacity to 0 (transparent)
            fadeInTimer.Start(); //Start the fadeInTimer (to make the window fade in)
        }

        private void OnNewImage(object sender, CancelEventArgs cancelEventArgs) //This is called when the NewImage event fires
        {
            try //Atempt to
            {
                lock (m_NewImageLock) //Lock to prevent trackbar glitches
                {
                    m_MyImages.Add(m_ImageGenerator.GetImage()); //Add another picture to the list

                    BeginInvoke((MethodInvoker) UpdatePicture); //Update the picture displayed
                    
                    if (m_MyImages.Count > c_VideoLength) //Reached the limit, need to stop
                    {
                        m_FinishedGenerating = true; //Set our FinishedGenerating variable to true
                        cancelEventArgs.Cancel = true;
                    }

                    BeginInvoke((MethodInvoker)UpdateProgress); //Update the picture displayed
                }
            }
            catch //If fail
            {
                //Window has closed - dont' worry about it.
            }
        }

        private void UpdatePicture() //Update the picture displayed based on the trackbar position
        {
            Img myImage = m_MyImages[trackBar1.Value]; //Create an Img and set it to the one the user wants to see

            if (trackBar1.Value != m_LastTrackbarValue) //If the slider position has changed
            {
                pictureBox.Image = myImage.ToBitmap(); //Set the displayed picture to the value they are at
            }

            m_LastTrackbarValue = trackBar1.Value; //Set our "old" value to the current value
        }

        private void UpdateProgress() //Update the progress bar and trackbar
        {
            if (progressBar1.Value < c_VideoLength) //If the progress bar isn't yet complete
                progressBar1.Value += 1; //Add one to the progress bar's progress

            trackBar1.Maximum = m_MyImages.Count - 1; //Add another point onto the trackbar

            if (!m_FinishedGenerating) //If generation has not finished
            {
                percentageCompleteLabel.Text = (m_MyImages.Count * 100 / c_VideoLength).ToString("#") + "%"; //Output the percentage finished (0 d.p)
                trackBar1.Value = trackBar1.Maximum; //Set the trackbar value to the maximum
            }
            else //If we have finished generating
            {
                percentageCompleteLabel.Text = "Done"; //Set the percentage label to "Done"
                trackBar1.Enabled = true; //Enable the trackbar
            }
        }

        private void fadeInTimer_Tick(object sender, EventArgs e) //Every loop of fadeInTimer
        {
            Opacity += 0.12; //Add 0.12 to the window's opacity
            if (Opacity >= 0.96) //If the window's opacity is 0.96 or over
            {
                Opacity = 1; //Set the window to fully transparent
                fadeInTimer.Enabled = false; //Disable the timer (hence this method won't be called again for this Window)
            }
        }

        private void VideoWindow_FormClosing(object sender, FormClosingEventArgs e) //When the form is closing
        {
            if (!m_Closeable) //If our "Closeable" variable is false
            {
                e.Cancel = true; //Cancel the close
                fadeOutTimer.Enabled = true; //Enable our fade out timer
            }
            /* The fix to the whole memory leak:
            else
            {
                m_ImageGenerator.NewImage -= OnNewImage; //Unhook the NewImage action to the OnNewImage function
            }
             * */
        }

        private void fadeOutTimer_Tick(object sender, EventArgs e) //Every loop of fadeOutTimer
        {
            Opacity -= 0.12; //Minus 0.12 from the window's opacity
            if (Opacity <= 0.04) //If the opacity is less (or equal to) 0.04
            {
                Opacity = 0; //Set the window to invisible
                fadeOutTimer.Enabled = false; //Disable the fadeOutTimer
                m_Closeable = true; //Set the Closeable variable to true (we can now close the window!)
                Close(); //Close the Window
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdatePicture();
        }
    }
}