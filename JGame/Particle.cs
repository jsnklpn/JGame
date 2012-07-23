using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JGame
{
    public class Particle : NPCObject
    {
        public Particle(Image image, int life)
            : base(image, life)
        {
            
        }

        protected override void UpdateObject()
        {
            base.UpdateObject();
            this.health--;
        }
    }
}
