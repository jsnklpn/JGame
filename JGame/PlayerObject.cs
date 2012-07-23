using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGame
{
    class PlayerObject : Sprite2D, IControllable
    {
        int health;

        public PlayerObject(System.Drawing.Image image)
            : base(image, System.Drawing.Point.Empty)
        {
            health = 100;
        }

        protected override void UpdateObject()
        {
            base.UpdateObject();

            // Every tick, this will be called
            
            
        }

        #region User input
        public void Start(KeyState state)
        {
            
        }

        public void Up(KeyState state)
        {
            if (state == KeyState.Down)
            {
                this.velocity.Y += -10f;
            }
            else
            {
                this.velocity.Y += 10f;
            }
        }

        public void Down(KeyState state)
        {
            if (state == KeyState.Down)
            {
                this.velocity.Y += 10f;
            }
            else
            {
                this.velocity.Y += -10f;
            }
        }

        public new void Left(KeyState state)
        {
            if (state == KeyState.Down)
            {
                this.velocity.X += -10f;
            }
            else
            {
                this.velocity.X += 10f;
            }
        }

        public new void Right(KeyState state)
        {
            if (state == KeyState.Down)
            {
                this.velocity.X += 10f;
            }
            else
            {
                this.velocity.X += -10f;
            }
        }

        public void Button1(KeyState state)
        {
            
        }

        public void Button2(KeyState state)
        {

        }
        #endregion

    }
}
