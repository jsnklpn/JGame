using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JGame
{
    interface IDrawable
    {
        void Draw(Graphics graphics, float interp);
    }
}
