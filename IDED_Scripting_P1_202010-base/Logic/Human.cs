namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, float _potential)
            : base(_unitClass)
        {

            Potential = _potential;

            switch (_unitClass)
            {
                case EUnitClass.Villager:
                    Defense = Defense + (Defense * 0.03f);
                    UnitClass = EUnitClass.Villager;
                    break;
                case EUnitClass.Squire:
                    Attack = Attack + (Attack * 0.04f);
                    Defense = Defense + (Defense * 0.04f);
                    UnitClass = EUnitClass.Squire;
                    break;
                case EUnitClass.Soldier:
                    Attack = Attack + (Attack * 0.05f);
                    Defense = Defense + (Defense * 0.05f);
                    UnitClass = EUnitClass.Soldier;
                    break;
                case EUnitClass.Ranger:
                    UnitClass = EUnitClass.Ranger;
                    Attack = Attack + (Attack * 0.04f);
                    Defense = Defense + (Defense * 0.04f);
                    break;
                case EUnitClass.Mage:
                    Attack = Attack + (Attack * 0.05f);
                    Defense = Defense + (Defense * 0.05f);
                    UnitClass = EUnitClass.Mage;
                    break;
                default:
                    UnitClass = EUnitClass.Villager;
                    Defense = Defense + (Defense * 0.03f);
                    break;                
            }

        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {

            bool Change = false;
            
            switch (UnitClass)
            {                                              
                case EUnitClass.Squire:
                    if (newClass == EUnitClass.Soldier)
                    {
                        UnitClass = newClass;
                        Change = true;
                    }
                    break;
                case EUnitClass.Soldier:
                    if (newClass == EUnitClass.Squire)
                    {
                        UnitClass = newClass;
                        Change = true;
                    }
                    break;
                case EUnitClass.Ranger:
                    if (newClass == EUnitClass.Mage)
                    {
                        UnitClass = newClass;
                        Change = true;
                    }
                    break;
                case EUnitClass.Mage:
                    if (newClass == EUnitClass.Ranger)
                    {
                        UnitClass = newClass;
                        Change = true;
                    }
                    break;
                default:
                    Change = false;
                    break;                    
            }

            return Change;
        }

        public override bool Interact(Unit otherUnit)
        {
            bool CanInteract = false;

            switch (UnitClass)
            {
                case EUnitClass.Villager:
                    CanInteract = false;
                    break;
                case EUnitClass.Squire:
                    if (otherUnit.UnitClass != EUnitClass.Squire)
                    {
                        CanInteract = true;
                    }
                    break;
                case EUnitClass.Soldier:
                    if (otherUnit.UnitClass != EUnitClass.Soldier)
                    {
                        CanInteract = true;
                    }
                    break;
                case EUnitClass.Ranger:
                    if (otherUnit.UnitClass != EUnitClass.Dragon || otherUnit.UnitClass != EUnitClass.Mage)
                    {
                        CanInteract = true;
                    }
                    break;
                case EUnitClass.Mage:
                    if (otherUnit.UnitClass != EUnitClass.Mage)
                    {
                        CanInteract = true;
                    }
                    break;
                case EUnitClass.Imp:
                    if (otherUnit.UnitClass != EUnitClass.Dragon)
                    {
                        CanInteract = true;
                    }
                    break;
                case EUnitClass.Orc:
                    { 
                    if (otherUnit.UnitClass != EUnitClass.Dragon)
                        CanInteract = true;
                    }
                    break;
                case EUnitClass.Dragon:
                    CanInteract = true;
                    break;              
            }

            return CanInteract;
        }

        public override bool Interact(Prop prop)
        {
            bool CanInteract;

            if (UnitClass == EUnitClass.Villager)
            {
                CanInteract = true;
            }
            else
            {
                CanInteract = false;
            }

            return CanInteract;
        }


    }
}