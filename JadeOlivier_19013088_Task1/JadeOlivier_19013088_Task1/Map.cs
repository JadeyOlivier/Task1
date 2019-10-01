using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeOlivier_19013088_Task1
{
    class Map
    {
        
        Random rgn = new Random();
        public const int HEIGHT = 21;
        public const int WIDTH = 21;

        int unitAmount;
        public Unit[] unitArray;
        public char[,] mapVisuals = new char[20, 20];
        public int numNightRiders, numDayWalkers;

        public int UnitAmount { get => unitAmount; set => unitAmount = value; }

        public Map(int numUnits)
        {
            this.UnitAmount = numUnits;
            unitArray = new Unit[numUnits];
        }


        public void populateMap()
        {
            string teamName;
            char symbol;
            int xPos, yPos, teamNum;


            for (int m = 0; m <= unitArray.Length - 1; m++)
            {
                int type = rgn.Next(0, 2);
                switch (type)
                {
                    case 0:
                        {
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
                            unitArray[m] = new MeleeUnit(xPos,yPos,teamName,symbol,false);
                            break;
                        }

                    case 1:
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
                            unitArray[m] = new RangedUnit(xPos,yPos,teamName,symbol,false);
                            break;
                        }
                }
            }

            foreach (Unit temp in unitArray)
            {
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

            for (int b = 0; b < HEIGHT - 1; b++)
            {
                for (int p = 0; p < WIDTH - 1; p++)
                {
                    if (mapVisuals[p, b] != 'R' && mapVisuals[p, b] != 'r' && mapVisuals[p, b] != 'M' && mapVisuals[p, b] != 'm')
                    {
                        mapVisuals[p, b] = '.';
                    }

                }
            }
        }


        public string drawMap()
        {
            string mapShow = "";

            for (int i = 0; i < HEIGHT - 1; i++)
            {
                for (int j = 0; j < WIDTH - 1; j++)
                {
                    mapShow += Convert.ToString(mapVisuals[j, i]);
                }
                mapShow += Environment.NewLine;
            }

            return mapShow;
        }   
    }
}
