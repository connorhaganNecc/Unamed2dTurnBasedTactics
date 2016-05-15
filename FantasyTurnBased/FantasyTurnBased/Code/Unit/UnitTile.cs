using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FantasyTurnBased
{
    class UnitTile
    {
        public Pair<int> coordinates;

        public UnitStats myStats;

        public Texture2D myGraphics;

        public string pathToArt;

        public bool active;

        public UnitTile()
        {
            myStats = new UnitStats();
            coordinates = new Pair<int>(0,0);
            active = false;
            myStats.unitMaxSpeed = 4;
        }

        public void LoadContent(ContentManager inManager)
        {
            myGraphics = inManager.Load<Texture2D>(pathToArt);
        }

        public void Draw(SpriteBatch inBatch)
        {
            inBatch.Draw(myGraphics, new Rectangle(new Point(coordinates.x * 64, coordinates.y * 64), new Point(64, 64)), Color.White);
        }

    }
}
