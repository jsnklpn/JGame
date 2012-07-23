using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JGame
{
    // A stage can be a menu, level, credits, whatever...
    // The purpose of stages is to handle input differently and draw differently
    public interface IGameStage
    {
        void Draw(Graphics graphics, float interp); // Drawing
        void KeyHandler(Keys key, KeyState state); // User input
        void Update(); // Update game (move, etc)
        void AddActor(Object2D obj);
    }
}
