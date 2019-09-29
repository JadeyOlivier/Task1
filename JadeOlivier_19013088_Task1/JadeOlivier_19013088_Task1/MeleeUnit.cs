using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeOlivier_19013088_Task1
{
    class MeleeUnit : Unit
    {
        
        public MeleeUnit(int meleeX, int meleeY, string meleeTeam, char meleeSymb, bool meleeAttacking) : base(meleeX, meleeY, 6, 2, 2, 1, meleeTeam, meleeSymb, meleeAttacking)
        {

        }

        protected override void Move(Unit unitToEngage)
        {
            throw new NotImplementedException();
        }

        protected override int ClosestUnit(Unit unitCloset)
        {
            throw new NotImplementedException();
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

        protected override bool IsInRange(Unit unitInRange)
        {
            bool inRange = false; ;
            string typeCheck = unitInRange.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];

            if (typeCheck == "MeleeUnit")
            {
                MeleeUnit mu = (MeleeUnit)unitInRange;
                if (Math.Abs(this.YPos - mu.YPos) == 1 || Math.Abs(this.XPos - mu.XPos) == 1 )
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
        public int MaxHealth { get => base.maxHealth;}
        public int Speed { get => base.speed;}
        public int Attk { get => base.attk;}
        public int AttkRange { get => base.attkRange;}
        public string Faction { get => base.faction;}
        public char Symbol { get => base.symbol;}
        public bool IsAttacking { get => base.isAttacking; set => base.isAttacking = value; }


    }
}
