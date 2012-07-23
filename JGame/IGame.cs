using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JGame
{
    // This interface is used by the VIEW
    interface IGame
    {
        void Start();
        bool IsGameRunning();
        void KeyHandler(Keys key, KeyState state);
        void Draw(Graphics graphics, float interp);
        void ChangeDisplaySize(Size displaySize);
    }
}
