using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FantasyTurnBased
{
    static class UtilityFunctions
    {
        public static Pair<int> mousePositionToGridArray(Point inPoint)
        {
            inPoint.X -= 32;
            inPoint.Y -= 32;
            return new Pair<int>(((int)Math.Round(inPoint.X / 64d) * 64) / 64, ((int)Math.Round((inPoint.Y / 64d)) * 64) / 64);
        }
    }

    class Pair<t>
    {
        public t x;
        public t y;
        public Pair(t in1, t in2)
        {
            x = in1;
            y = in2;
        }
        
    }
}
