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
    class GridDrawManager
    {
        SpriteBatch mySpiteBatchRef;

        int[,] backgroundLayer;
        int[,] objectLayer;
        int[,] actorLayer;

        //Temporary textures
        Texture2D solidBlack;

        public GridDrawManager(SpriteBatch inRef)
        {
            mySpiteBatchRef = inRef;

            backgroundLayer = new int[15, 15];
            for(int i = 0; i < 15; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    backgroundLayer[i, j] = 0;
                }
            }
        }

        public void LoadContent(ContentManager inManager)
        {
            solidBlack = inManager.Load<Texture2D>("Graphics\\Prototype\\SolidBlack.png");
        }

        public void DrawGrid()
        {
            backgroundLayer[4, 7] = 1;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if(backgroundLayer[i, j] != 0)
                    {
                        mySpiteBatchRef.Draw(solidBlack, new Rectangle(new Point(i * 64, j * 64), new Point(64, 64)), Color.White);
                    }
                }
            }

        }

        public void ToggleBlock(Pair<int> inPair)
        {
            if(inPair.x < 15 && inPair.y < 15)
            {
                if (backgroundLayer[inPair.x, inPair.y] != 0)
                {
                    backgroundLayer[inPair.x, inPair.y] = 0;
                }
                else
                {
                    backgroundLayer[inPair.x, inPair.y] = 1;
                }
            }
            
        }


        
    }
}
