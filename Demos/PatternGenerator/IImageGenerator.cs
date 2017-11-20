using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing; //For Image
using System.Linq;
using System.Text;

namespace PattGen
{
    public interface IImageGenerator
    {
        //Every IImageGenerator must have:
        event EventHandler<CancelEventArgs> NewImage; //A NewImage event
        Img GetImage(); //A GetImage function which returns an Image
        void StartGenerating(); //A StartGenerating function
    }
}
