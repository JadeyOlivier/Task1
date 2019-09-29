using System;
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
            MapTracker.populateMap();

        }

        internal Map MapTracker { get => mapTracker; set => mapTracker = value; }

        public void GameRun()
        {
            //string roundOutput;
            ++numRounds;
            while(MapTracker.numDayWalkers > 0 && MapTracker.numNightRiders > 0)
            {
                foreach(Unit temp in MapTracker.mapArray)
                {
                    string typeCheck = temp.GetType().ToString();
                    string[] splitArray = typeCheck.Split('.');
                    typeCheck = splitArray[splitArray.Length - 1];
                    
                    if (typeCheck == "MeleeUnit")
                    {
                        MeleeUnit obj = (MeleeUnit)temp;
                        if (obj.Health > (0.25 * obj.MaxHealth))
                        {
                            /*foreach(Unit newUnit in mapTracker.mapArray)
                            {
                                string newUnitType = newUnit.GetType().ToString();
                                string[] newUnitArray = newUnitType.Split('.');
                                newUnitType = splitArray[splitArray.Length - 1];

                                MeleeUnit newUnit
                            }*/
                        }
                        else
                        {
                            //Runaway
                        }
                    }


                }
                ++numRounds;
            }
        }
    }
}
