namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }        

    public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            switch (UnitClass)
            {
                case EUnitClass.Villager:
                    BaseAtk = 0;
                    BaseDef = 0;
                    BaseSpd = 100;
                    MoveRange = _moveRange;                    
                    break;

                case EUnitClass.Squire:
                    BaseAtk = 150;
                    BaseDef = 150;
                    BaseSpd = 100;
                    MoveRange = _moveRange;
                    break;

                case EUnitClass.Soilder:
                    BaseAtk = 200;
                    BaseDef = 200;
                    BaseSpd = 100;
                    MoveRange = _moveRange;
                    break;

                case EUnitClass.Ranger:
                    BaseAtk = 100;
                    BaseDef = 100;
                    BaseSpd = 200;
                    MoveRange = _moveRange;
                    break;

                case EUnitClass.Mage:
                    BaseAtk = 225;
                    BaseDef = 100;
                    BaseSpd = 150;
                    MoveRange = _moveRange;
                    break;

                default:
                    _unitClass = EUnitClass.Villager;
                    break;

            }
        }

        

    public virtual bool ChangeClass(EUnitClass newClass)
        {
            bool canChange = false;            

            if (EUnitClass.Ranger == UnitClass.Mage)
            {
                canChange = true;
            }
            else if (EUnitClass.Mage == UnitClass.Ranger)
            {
                canChange = true;
            }
            else if (EUnitClass.Squire == UnitClass.Soilder)
            {
                canChange = true;
            }
            else if (EUnitClass.Soilder == UnitClass.Squire)
            {
                canChange = true;
            }
            return false;
        }
    }
}