using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JGame
{
    public class Sprite2D : Object2D
    {
        protected Image bitmap;

        public Image Image { get { return bitmap; } }

        public Sprite2D(Image bmp, Point position)
            : base(bmp.Size, position)
        {
            this.bitmap = bmp;
        }

        protected override void DrawObject(Graphics graphics)
        {
            if (bitmap != null)
                graphics.DrawImage(bitmap, -this.Width / 2, -this.Height / 2, this.Width, this.Height);
        }

        protected override void UpdateObject()
        {
            // To be used by subclasses...
        }
    }
}
