using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JGame
{
    class Animation2D : Object2D
    {
        private List<AnimatedImage> _animations;
        private int _currentAnimation;
        private int _currentFrame;

        public Animation2D(List<AnimatedImage> animations, Size objectSize, PointF location)
            : base(objectSize, location)
        {
            _animations = animations;
            _currentAnimation = 0;
            _currentFrame = 0;
        }

        protected override void DrawObject(Graphics graphics)
        {
            // need to figure out which frame to show...
            // TODO

            _animations[_currentAnimation].Draw(graphics, _currentFrame);
        }

        protected override void UpdateObject()
        {
            // TODO
        }
    }
}
