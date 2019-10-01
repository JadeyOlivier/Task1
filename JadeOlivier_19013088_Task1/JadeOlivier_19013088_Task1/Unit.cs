using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeOlivier_19013088_Task1
{
    abstract class Unit
    {
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected int attk;
        protected int attkRange;
        protected string faction;
        protected char symbol;
        protected bool isAttacking;

        //Constructor intialiser for Unit class
        protected Unit(int x, int y, int hp, int howFast, int attack, int range, string team, char symb, bool attkConfirmed)
        {
            this.xPos = x;
            this.yPos = y;
            this.health = hp;
            this.speed = howFast;
            this.attk = attack;
            this.attkRange = range;
            this.faction = team;
            this.symbol = symb;
            this.isAttacking = attkConfirmed;
            this.maxHealth = hp;
        }

        //Abstract methods to be used by subclasses
        public abstract string Move(Unit unitToEngage);

        public abstract void Combat(Unit attackingUnit);

        public abstract bool IsInRange(Unit unitInRange);

        public abstract Unit ClosestUnit(Unit[] unitClosetCheck);

        public abstract bool IsDead();

        public abstract string ToString(Unit unitString);   
        
        
    }

}
