using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyTurnBased
{
    class UnitManager
    {
        public List<UnitTile> battleUnits;

        public UnitManager()
        {
            battleUnits = new List<UnitTile>();
        }

        public void Draw(SpriteBatch inBatch)
        {
            for(int i = 0; i < battleUnits.Count; i++)
            {
                if(battleUnits[i].active)
                {
                    battleUnits[i].Draw(inBatch);
                }
            }
        }

        public UnitTile unitWithSpace(Pair<int> inPair)
        {
            for(int i = 0; i < battleUnits.Count; i++)
            {
                if(battleUnits[i].coordinates.x == inPair.x && battleUnits[i].coordinates.y == inPair.y)
                {
                    return battleUnits[i];
                }
            }
            return null;
        }

        public void LoadContent(ContentManager inManager)
        {
            for(int i = 0; i < battleUnits.Count; i++)
            {
                battleUnits[i].LoadContent(inManager);
            }
        }
    }
}
