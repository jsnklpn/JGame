using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JGame
{
    class AnimatedImage
    {
        // The number of frames determines the size/location of each portion
        // This will be done in constructor

        private Image _image;
        private int _numFrames;

        public int FrameCount { get { return _numFrames; } }

        public AnimatedImage(Image image, int numframes)
        {
            _image = image;
            _numFrames = numframes;
        }

        public void Draw(Graphics graphics, int frame)
        {
            // clip out portion and draw it

            // TODO
        }

        

    }
}
