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

        //Temporary textures
        Texture2D solidBlack;
        Texture2D walkable;
        Texture2D gridSpace;

        public GridDrawManager(SpriteBatch inRef)
        {
            mySpiteBatchRef = inRef;

            backgroundLayer = new int[15, 15];

        }

        public void LoadContent(ContentManager inManager)
        {
            solidBlack = inManager.Load<Texture2D>("Graphics\\Prototype\\SolidBlack.png");
            walkable = inManager.Load<Texture2D>("Graphics\\Prototype\\Walkable.png");
            gridSpace = inManager.Load<Texture2D>("Graphics\\Prototype\\GridSpace.png");
        }

        public void DrawGrid()
        { 
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    mySpiteBatchRef.Draw(gridSpace, new Rectangle(new Point(i * 64, j * 64), new Point(64, 64)), Color.White);
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

        public void DrawWalkable(Pair<int> Position, int walkDistance)
        {
            for(int i = Position.y - walkDistance; i <= Position.y + walkDistance; i++)
            {
                for(int j = Position.x - walkDistance; j <= Position.x + walkDistance; j++)
                {
                    Pair<int> tempDistance = new Pair<int>(j, i);
                    if(!(Position.x == tempDistance.x && Position.y == tempDistance.y)&&  UtilityFunctions.GridDistance(Position, tempDistance) <= walkDistance)
                    {
                        if(tempDistance.x >= 0 && tempDistance.x < 15 && tempDistance.y >= 0 && tempDistance.y < 15)
                        {
                            mySpiteBatchRef.Draw(walkable, new Rectangle(new Point(tempDistance.x * 64, tempDistance.y * 64), new Point(64, 64)), Color.White);
                        }
                    }
                }
            }
        }


        
    }
}
