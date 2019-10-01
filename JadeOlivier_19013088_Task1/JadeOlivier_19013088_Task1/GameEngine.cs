﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeOlivier_19013088_Task1
{
    class GameEngine
    {
        int numRounds= 0;
        Map mapTracker = new Map(10);

        public GameEngine()
        { 

        }

        internal Map MapTracker { get => mapTracker; set => mapTracker = value; }

        public void GameRun()
        {
            ++numRounds;
            bool unitDied;
            string direction;

            foreach (Unit temp in MapTracker.unitArray)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)temp;
                    unitDied = obj.IsDead();
                    if (unitDied == false)
                    {
                        if (numRounds % obj.Speed == 0)
                        {
                            if (obj.Health > (0.25 * obj.MaxHealth))
                            {
                                Unit closest = obj.ClosestUnit(MapTracker.unitArray);

                                if (obj.IsAttacking == false && obj.IsInRange(closest) == false)
                                {
                                    direction = obj.Move(closest);
                                    switch (direction)
                                    {
                                        case "Right":
                                            {
                                                if (obj.XPos != 20)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                }
                                                else
                                                {
                                                    obj.XPos = 0;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, 19] = '.';
                                                }
                                                break;
                                            }
                                        case "Left":
                                            {
                                                if (obj.XPos != -1)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                }
                                                else
                                                {
                                                    obj.XPos = 19;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                }
                                                break;
                                            }
                                        case "Up":
                                            {
                                                if (obj.YPos != 20)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                }
                                                else
                                                {
                                                    obj.YPos = 0;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[19, obj.XPos] = '.';
                                                }
                                                break;
                                            }
                                        case "Down":
                                            {
                                                if (obj.YPos != 0)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                }
                                                else
                                                {
                                                    obj.YPos = 19;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                }
                                                break;
                                            }
                                    }

                                }
                                else if (obj.IsInRange(closest) == true)
                                {
                                    obj.IsAttacking = true;
                                    obj.Combat(closest);
                                }
                            }
                            else
                            {
                                direction = obj.RandomMove();
                                switch (direction)
                                {
                                    case "Right":
                                        {
                                            obj.XPos++;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                            break;
                                        }
                                    case "Left":
                                        {
                                            obj.XPos--;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                            break;
                                        }
                                    case "Up":
                                        {
                                            obj.YPos++;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                            break;
                                        }
                                    case "Down":
                                        {
                                            obj.YPos--;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
                else
                {
                    RangedUnit obj = (RangedUnit)temp;
                    unitDied = obj.IsDead();
                    if (unitDied == false)
                    {
                        if (numRounds % obj.Speed == 0)
                        {
                            if (obj.Health > (0.25 * obj.MaxHealth))
                            {
                                Unit closest = obj.ClosestUnit(MapTracker.unitArray);

                                if (obj.IsAttacking == false && obj.IsInRange(closest) == false)
                                {
                                    direction = obj.Move(closest);
                                    switch (direction)
                                    {
                                        case "Right":
                                            {
                                                if (obj.XPos != 20)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                }
                                                else
                                                {
                                                    obj.XPos = 0;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, 19] = '.';
                                                }
                                                break;
                                            }
                                        case "Left":
                                            {
                                                if (obj.XPos != -1)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                }
                                                else
                                                {
                                                    obj.XPos = 19;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                }
                                                break;
                                            }
                                        case "Up":
                                            {
                                                if (obj.YPos != 20)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                }
                                                else
                                                {
                                                    obj.YPos = 0;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[19, obj.XPos] = '.';
                                                }
                                                break;
                                            }
                                        case "Down":
                                            {
                                                if (obj.YPos != 0)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                }
                                                else
                                                {
                                                    obj.YPos = 19;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                }
                                                break;
                                            }
                                    }
                                }
                                else if (obj.IsInRange(closest) == true)
                                {
                                    obj.IsAttacking = true;
                                    obj.Combat(closest);
                                }
                            }
                            else
                            {
                                direction = obj.RandomMove();
                                switch (direction)
                                {
                                    case "Right":
                                        {
                                            obj.XPos++;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                            break;
                                        }
                                    case "Left":
                                        {
                                            obj.XPos--;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                            break;
                                        }
                                    case "Up":
                                        {
                                            obj.YPos++;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                            break;
                                        }
                                    case "Down":
                                        {
                                            obj.YPos--;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
