﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JGame
{
    interface IDisplay
    {
        void Draw(float interp);
        void Exit();
    }
}