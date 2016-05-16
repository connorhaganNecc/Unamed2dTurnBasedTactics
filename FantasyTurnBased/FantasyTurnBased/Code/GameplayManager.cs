using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FantasyTurnBased
{
    class GameplayManager
    {
        GridDrawManager myGridManager;
        UnitManager myUnitManager;
        SpriteBatch mySpriteRef;
        Texture2D selected;
        bool waitForMouseUp = false;

        UnitTile activeUnit;

        public GameplayManager()
        {
            activeUnit = null;
        }

        public void LoadContent(ContentManager inManager, SpriteBatch inBatch)
        {
            myGridManager = new GridDrawManager(inBatch);
            myGridManager.LoadContent(inManager);
            myUnitManager = new UnitManager();
            UnitTile temp = new UnitTile();
            temp.active = true;
            temp.coordinates = new Pair<int>(1, 1);
            temp.pathToArt = "Graphics\\Prototype\\SolidBlack.png";
            temp.myStats.unitCurrSpeed = 5;
            myUnitManager.battleUnits.Add(temp);
            UnitTile temp2 = new UnitTile();
            temp2.active = true;
            temp2.coordinates = new Pair<int>(5,5);
            temp2.pathToArt = "Graphics\\Prototype\\SolidBlack.png";
            temp2.myStats.unitCurrSpeed = 8;
            myUnitManager.battleUnits.Add(temp2);
            UnitTile temp3 = new UnitTile();
            temp3.active = true;
            temp3.coordinates = new Pair<int>(2, 9);
            temp3.pathToArt = "Graphics\\Prototype\\SolidBlack.png";
            temp3.myStats.unitCurrSpeed = 3;
            myUnitManager.battleUnits.Add(temp3);

            selected = inManager.Load<Texture2D>("Graphics\\Prototype\\Selected.png");


            myUnitManager.LoadContent(inManager);
            mySpriteRef = inBatch;
        }

        public void Draw()
        {
            myGridManager.DrawGrid();
            myUnitManager.Draw(mySpriteRef);

            if(activeUnit!= null)
            {
                mySpriteRef.Draw(selected, activeUnit.myPosition(), Color.White);
                myGridManager.DrawWalkable(activeUnit.coordinates, activeUnit.myStats.unitCurrSpeed);
            }
        }
        
        public void Update()
        {
            MouseState currState = Mouse.GetState();
            if (currState.LeftButton == ButtonState.Pressed && !waitForMouseUp)
            {
                Console.WriteLine("GotHere");
                Pair<int> mousePosition = UtilityFunctions.mousePositionToGridArray(new Point(currState.X, currState.Y));
                if(activeUnit!= null)
                {

                    if(UtilityFunctions.GridDistance(mousePosition, activeUnit.coordinates) <= activeUnit.myStats.unitCurrSpeed)
                    {
                        activeUnit.coordinates = mousePosition;
                    }
                }
                else
                {
                    activeUnit = myUnitManager.unitWithSpace(mousePosition);
                }
                //myGridManager.ToggleBlock(UtilityFunctions.mousePositionToGridArray(new Point(currState.X, currState.Y)));
                waitForMouseUp = true;
            }
            else if (currState.LeftButton == ButtonState.Released)
            {
                waitForMouseUp = false;
            }
            if(currState.RightButton == ButtonState.Pressed)
            {
                activeUnit = null;
            }
        }
    }
}
