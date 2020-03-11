using System;

namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        public int BaseAtk { get; protected set; }
        public int BaseDef { get; protected set; }
        public int BaseSpd { get; protected set; }

        public int MoveRange { get; protected set; }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack
        {
            get { return Attack ; }
            set
            {
                if (Attack != 0)
                {
                    Attack = value;   
                }
                else
                {
                    Attack = BaseAtk + (BaseAtk * BaseAtkAdd); if (Attack > 255)
                    {
                        Attack = 255;
                    }
                }                
            }
        }
        public float Defense
        {
            get { return Defense; }
            set
            {
                if (Defense != 0)
                {
                    Defense = value;
                }
                else
                {
                    Defense = BaseDef + (BaseDef * BaseDefAdd); if (Defense > 255)
                    {
                        Defense = 255;
                    }
                }
            }
        }
        public float Speed
        {
            get { return Speed; }
            set
            {
                if (Speed != 0)
                {
                    Speed = value;
                }
                else
                {
                    Speed = BaseSpd + (BaseSpd * BaseSpdAdd); if (Speed > 255)
                    {
                        Speed = 255;
                    }
                }
            }
        }
        
        protected Position2 CurrentPosition;

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass)
        {
            UnitClass = _unitClass;
            Random Rdm = new Random();
            int Aleatorio = Rdm.Next(1, 10);

            switch (UnitClass)
            {            
                case EUnitClass.Villager:
                    BaseDef = 100;
                    BaseAtk = 100;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0;
                    MoveRange = 3;
                    CurrentPosition = new Position2(Aleatorio, Aleatorio);
                    break;
                case EUnitClass.Squire:
                    BaseAtk = 150;
                    BaseDef = 150;
                    BaseSpd = 100;
                    BaseAtkAdd = 0.02f;
                    BaseDefAdd = 0.01f;
                    BaseSpdAdd = 0;
                    AtkRange = 1;
                    MoveRange = 2;
                    CurrentPosition = new Position2(Aleatorio, Aleatorio);
                    break;
                case EUnitClass.Soldier:
                    BaseAtk = 180;
                    BaseDef = 180;
                    BaseSpd = 100;
                    BaseAtkAdd = 0.03f;
                    BaseDefAdd = 0.02f;
                    BaseSpdAdd = 0.01f;
                    AtkRange = 1;
                    MoveRange = 2;
                    CurrentPosition = new Position2(Aleatorio, Aleatorio);
                    break;
                case EUnitClass.Ranger:
                    BaseAtk = 100;
                    BaseDef = 100;
                    BaseSpd = 1200;
                    BaseAtkAdd = 0.01f;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0.03f;
                    AtkRange = 4;
                    MoveRange = 3;
                    CurrentPosition = new Position2(Aleatorio, Aleatorio);
                    break;
                case EUnitClass.Mage:
                    BaseAtk = 150;
                    BaseDef = 100;
                    BaseSpd = 180;
                    BaseAtkAdd = 0.03f;
                    BaseDefAdd = 0.01f;
                    BaseSpdAdd = -0.01f;
                    AtkRange = 3;
                    MoveRange = 2;
                    CurrentPosition = new Position2(Aleatorio, Aleatorio);
                    break;
                case EUnitClass.Imp:
                    BaseAtk = 150;
                    BaseDef = 100;
                    BaseSpd = 100;
                    BaseAtkAdd = 0.01f;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0;
                    AtkRange = 1;
                    MoveRange = 2;
                    CurrentPosition = new Position2(Aleatorio, Aleatorio);
                    break;
                case EUnitClass.Orc:
                    BaseAtk = 180;
                    BaseDef = 150;
                    BaseSpd = 100;
                    BaseAtkAdd = 0.04f;
                    BaseDefAdd = 0.02f;
                    BaseSpdAdd = -0.02f;
                    AtkRange = 1;
                    MoveRange = 2;
                    CurrentPosition = new Position2(Aleatorio, Aleatorio);
                    break;
                case EUnitClass.Dragon:
                    BaseAtk = 255;
                    BaseDef = 200;
                    BaseSpd = 50;
                    BaseAtkAdd = 0.05f;
                    BaseDefAdd = 0.03f;
                    BaseSpdAdd = 0.02f;
                    AtkRange = 2;
                    MoveRange = 2;
                    CurrentPosition = new Position2(Aleatorio, Aleatorio);
                    break;
                default:
                    break;
            }

            Attack = 0;
            Defense = 0;
            Speed = 0;

        }        

        public virtual bool Interact(Unit otherUnit)
        {
            return false;
        }

        public virtual bool Interact(Prop prop) => false;

        public bool Move(Position2 targetPosition)
        {
            bool CanMove = false;

            if ((targetPosition.x + targetPosition.y) - (CurrentPosition.x +CurrentPosition.y) < MoveRange)
            {
                CanMove = true;
                CurrentPosition = targetPosition;
            }

            return CanMove;

        }
    }
}