namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit : EUnitClass
    {
        public int BaseAtk { get; protected set; }
        public int BaseDef { get; protected set; }
        public int BaseSpd { get; protected set; }

        public int MoveRange { get; protected set; }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; }
        public float Defense { get; }
        public float Speed { get; }

        protected Position CurrentPosition;

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;

            switch (UnitClass)
            {
                case EUnitClass.Imp:
                    BaseAtk = 125;
                    BaseDef = 125;
                    BaseSpd = 100;
                    MoveRange = _moveRange;
                    break;

                case EUnitClass.Orc:
                    BaseAtk = 150;
                    BaseDef = 150;
                    BaseSpd = 100;
                    MoveRange = _moveRange;
                    break;

                case EUnitClass.Villager:
                    BaseAtk = 255;
                    BaseDef = 100;
                    BaseSpd = 100;
                    MoveRange = _moveRange;
                    break;

                default:
                    break;
            }
        }


    public virtual bool Interact(Unit otherUnit)
        {
            bool PropInteraction = false;
            bool atkInteraction = false;

            if (UnitClass == EUnitClass.Villager)
            {
                PropInteraction = true;
            }
            return PropInteraction;

            if (UnitClass == EUnitClass.Squire)
            {

            }
        }

        public virtual bool Interact(Prop prop) => false;

        public bool Move(Position targetPosition)
        {
            bool canMove = false;
            if (targetPosition -= CurrentPosition < MoveRange)
            {
                CurrentPosition == targetPosition;
                canMove = true;
            }
            else
            {
                CurrentPosition == CurrentPosition;
                canMove = false;
            }
            return canMove;
        }
    }
}