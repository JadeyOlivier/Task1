using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeOlivier_19013088_Task1
{
    class RangedUnit : Unit 
    {
        Map mapTracker = new Map(10);

        public RangedUnit(int randgedX, int rangedY, string rangedTeam, char rangedSymb,bool rangedAttacking) : base(randgedX, rangedY, 5, 2, 1, 2, rangedTeam, rangedSymb, rangedAttacking)
        {
            
        }
        protected override string Move(Unit closetUnit)
        {
            string returnVal = "";
            string typeCheck = closetUnit.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];

            if (typeCheck == "MeleeUnit")
            {
                MeleeUnit m = (MeleeUnit)closetUnit;
                if ((Math.Abs(m.XPos - this.XPos) > Math.Abs(m.YPos - this.YPos)))
                {
                    if ((m.XPos - this.XPos) > 0)
                    {
                        this.XPos++;
                        returnVal = "Right";
                    }
                    else if ((m.XPos - this.XPos) < 0)
                    {
                        this.XPos--;
                        returnVal = "Left";
                    }
                }
                else
                {
                    if ((m.YPos - this.YPos) > 0)
                    {
                        this.YPos++;
                        returnVal = "Up";
                    }
                    else if ((m.YPos - this.YPos) < 0)
                    {
                        this.YPos--;
                        returnVal = "Down";
                    }
                }
            }
            else
            {
                RangedUnit r = (RangedUnit)closetUnit;
                if ((Math.Abs(r.XPos - this.XPos) > Math.Abs(r.YPos - this.YPos)))
                {
                    if ((r.XPos - this.XPos) > 0)
                    {
                        this.XPos++;
                        returnVal = "Right";
                    }
                    else if ((r.XPos - this.XPos) < 0)
                    {
                        this.XPos--;
                        returnVal = "Left";
                    }
                }
                else
                {
                    if ((r.YPos - this.YPos) > 0)
                    {
                        this.YPos++;
                        returnVal = "Up";
                    }
                    else if ((r.YPos - this.YPos) < 0)
                    {
                        this.YPos--;
                        returnVal = "Down";
                    }
                }
            }

            return returnVal;
        }

        protected override void Combat(Unit attackingUnit)
        {
            string typeCheck = attackingUnit.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];

            if (typeCheck == "MeleeUnit")
            {
                MeleeUnit mu = (MeleeUnit)attackingUnit;
                mu.Health -= this.Attk;
                this.isAttacking = true;
            }
            else
            {
                RangedUnit ru = (RangedUnit)attackingUnit;
                ru.Health -= this.Attk;
                this.IsAttacking = true;
            }
        }

        protected override bool IsInRange(Unit unitInRange)
        {
            bool inRange = false; ;
            string typeCheck = unitInRange.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];

            if (typeCheck == "MeleeUnit")
            {
                MeleeUnit mu = (MeleeUnit)unitInRange;
                if(Math.Abs(this.YPos - mu.YPos) == 2 || Math.Abs(this.XPos - mu.XPos) == 2)
                {
                    inRange = true;
                }
                else
                {
                    inRange = false;
                }
            }
            else
            {
                RangedUnit ru = (RangedUnit)unitInRange;
                if (Math.Abs(this.YPos - ru.YPos) == 2 || Math.Abs(this.XPos - ru.XPos) == 2)
                {
                    inRange = true;
                }
                else
                {
                    inRange = false;
                }
            }

            return inRange;
        }

        protected override Unit ClosestUnit(Unit unitCloset)
        {
            int workingOut, xDis, yDis;
            int closest = 1000;
            Unit returnVal = this;
            foreach (Unit temp in unitClosetCheck)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit m = (MeleeUnit)temp;
                    if (m.XPos != this.XPos && m.YPos != this.YPos)
                    {
                        if (m.Faction != this.Faction)
                        {
                            xDis = Math.Abs(this.XPos - m.XPos);
                            yDis = Math.Abs(this.YPos - m.YPos);
                            workingOut = Convert.ToInt32(Math.Sqrt((xDis * xDis) + (yDis * yDis)));

                            if (workingOut < closest)
                            {
                                closest = workingOut;
                                returnVal = m;
                            }
                        }
                    }
                }
                else
                {
                    RangedUnit r = (RangedUnit)temp;
                    if (r.XPos != this.XPos && r.YPos != this.YPos)
                    {
                        if (r.Faction != this.Faction)
                        {
                            xDis = Math.Abs(this.XPos - r.XPos);
                            yDis = Math.Abs(this.YPos - r.YPos);
                            workingOut = Convert.ToInt32(Math.Sqrt((xDis * xDis) + (yDis * yDis)));

                            if (workingOut < closest)
                            {
                                closest = workingOut;
                                returnVal = r;
                            }
                        }
                    }
                }
            }

            return returnVal;
        }

        protected override bool IsDead()
        {
            bool unitDead;
            if (this.Health <= 0)
            {
                unitDead = true;
            }
            else
            {
                unitDead = false;
            }

            return unitDead;
        }

        protected override string ToString(Unit unitString)
        {
            string returnVal = "";
            returnVal += "A new Ranged Unit enters the battlefield" + Environment.NewLine;
            returnVal += "Their x position is: " + this.XPos + Environment.NewLine;
            returnVal += "Their y position is: " + this.YPos + Environment.NewLine;
            returnVal += "Their hp is: " + this.Health + Environment.NewLine;
            returnVal += "Their attack damage is: " + this.Attk + Environment.NewLine;
            returnVal += "Their range is: " + this.AttkRange + Environment.NewLine;
            returnVal += "Their speed is: " + this.Speed + Environment.NewLine;
            returnVal += "Their team is: " + this.Faction + Environment.NewLine;
            returnVal += "Their symbol is: " + this.Symbol + Environment.NewLine;
            returnVal += "----------------------------------------" + Environment.NewLine;
            returnVal += Environment.NewLine;

            return returnVal;
        }

        public int XPos { get => base.xPos; set => base.xPos = value; }
        public int YPos { get => base.yPos; set => base.yPos = value; }
        public int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get => base.maxHealth; }
        public int Speed { get => base.speed; }
        public int Attk { get => base.attk; }
        public int AttkRange { get => base.attkRange; }
        public string Faction { get => base.faction; }
        public char Symbol { get => base.symbol; }
        public bool IsAttacking { get => base.isAttacking; set => base.isAttacking = value; }
    }
}
