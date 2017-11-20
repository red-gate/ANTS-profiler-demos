using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PattGen
{
    public partial class Welcome : Form
    {

        private readonly RandomImageGenerator m_ImageGenerator = new RandomImageGenerator(); //Create an instance of RandomImageGenerator for use
        private bool m_Closeable; //A bool which tells the program if the window can be closed or not (this is for fading out)

        public Welcome() //Constructor
        {
            InitializeComponent();
            m_Closeable = false; //Set the Closeable variable to false
            Opacity = 0; //Set the window opacity to 0 (transparent)
            fadeInTimer.Start(); //Star the fade-in timer to make the window fade in
        }

        private void StartButton_Click(object sender, EventArgs e) //If "Start" is clicked
        {
            ImageWindow imageWindowForm = new ImageWindow(m_ImageGenerator); //Create the ImageWindow
            imageWindowForm.Show(); //Show the ImageWindow
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

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e) //When the form is closing
        {
            if (!m_Closeable) //If our "Closeable" variable is false
            {
                e.Cancel = true; //Cancel the close
                fadeOutTimer.Enabled = true; //Enable our fade out timer
            }
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
    }
}
