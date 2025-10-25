using UnityEngine;

[CreateAssetMenu(fileName = "ToFollowFromHealCondition", menuName = "FSM/Conditions/ToFollowFromHealCondition")]
public class ToFollowFromHealCondition : Condition_Medieval
{
    public override bool Check(StateMachine_Medieval sm)
    {
        return sm.blackboard.Get<float>("WarriorHealth") >= sm.blackboard.Get<float>("WarriorMaxHealth")//En teoria qque no podria usar exactamente las mismas condiciones??
            && sm.blackboard.Get<bool>("WarriorIsInCombat") == false;
    }
}
