using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeOlivier_19013088_Task1
{
    class Map
    {
        //Various methods to handle the amount of units and an array that holds the newly created units
        Random rgn = new Random();
        public const int HEIGHT = 20;
        public const int WIDTH = 20;

        int unitAmount;
        public Unit[] unitArray;
        public char[,] mapVisuals = new char[20, 20];
        private int numDayWalkers; //trackers for amount of units in each team
        private int numNightRiders;

        public int UnitAmount { get => unitAmount; set => unitAmount = value; }
        public int NumNightRiders { get => numNightRiders; set => numNightRiders = value; }
        public int NumDayWalkers { get => numDayWalkers; set => numDayWalkers = value; }

        public Map(int numUnits)
        {
            this.UnitAmount = numUnits;
            unitArray = new Unit[numUnits];
        }


        public void populateMap()
        {
            //Variables are going to be constantly repopulated with random values as a new unit is created
            string teamName;
            char symbol;
            int xPos, yPos, teamNum;

            for (int m = 0; m <= unitArray.Length - 1; m++)
            {
                int type = rgn.Next(0, 2);
                switch (type)
                {
                    case 0: //Case 0 creates a new Melee unit 
                        {
                            //All values of the unit are generated randomly including the teams they are assigned to
                            xPos = rgn.Next(0, 20);
                            yPos = rgn.Next(0, 20);
                            teamNum = rgn.Next(0, 2);
                            if (teamNum == 0)
                            {
                                teamName = "Night Riders";
                                symbol = 'M';
                                ++numNightRiders;
                            }
                            else
                            {
                                teamName = "Day Walkers";
                                symbol = 'm';
                                ++numDayWalkers;
                            }
                            unitArray[m] = new MeleeUnit(xPos, yPos, teamName, symbol, false);
                            break;
                        }

                    case 1: //Case 1 creates a new Ranged unit
                        {
                            xPos = rgn.Next(0, 20);
                            yPos = rgn.Next(0, 20);
                            teamNum = rgn.Next(0, 2);
                            if (teamNum == 0)
                            {
                                teamName = "Night Riders";
                                symbol = 'R';
                                ++numNightRiders;
                            }
                            else
                            {
                                teamName = "Day Walkers";
                                symbol = 'r';
                                ++numDayWalkers;
                            }
                            unitArray[m] = new RangedUnit(xPos, yPos, teamName, symbol, false);
                            break;
                        }
                }
            }

            foreach (Unit temp in unitArray)
            {
                //Units added to a visual representation of the map by placing their symbol on their position on the grid
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)temp;
                    mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                }
                else
                {
                    RangedUnit obj = (RangedUnit)temp;
                    mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                }
            }

            //Rest of map is populated with grass
            for (int b = 0; b <= HEIGHT - 1; b++)
            {
                for (int p = 0; p <= WIDTH - 1; p++)
                {
                    if (mapVisuals[b, p] != 'R' && mapVisuals[b, p] != 'r' && mapVisuals[b, p] != 'M' && mapVisuals[b, p] != 'm')
                    {
                        mapVisuals[b, p] = '.';
                    }

                }
            }

        }

        //returns string of visual map to the form in order to be displayed
        public string drawMap()
        {
            string mapShow = "";

            for (int i = 0; i <= HEIGHT - 1; i++)
            {
                for (int j = 0; j <= WIDTH - 1; j++)
                {
                    mapShow += Convert.ToString(mapVisuals[j, i]);
                }
                mapShow += Environment.NewLine;
            }

            return mapShow;
        }   
    }
}
