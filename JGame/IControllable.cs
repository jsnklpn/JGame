using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGame
{
    interface IControllable
    {
        void Start(KeyState state);
        void Up(KeyState state);
        void Down(KeyState state);
        void Left(KeyState state);
        void Right(KeyState state);
        void Button1(KeyState state);
        void Button2(KeyState state);
    }
}
