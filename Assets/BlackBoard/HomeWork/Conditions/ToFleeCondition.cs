using UnityEngine;

[CreateAssetMenu(fileName = "ToFleeCondition", menuName = "FSM/Conditions/ToFleeCondition")]
public class ToFleeCondition : Condition_Medieval
{
    public override bool Check(StateMachine_Medieval sm)
    {
        return sm.blackboard.Get<bool>("WarriorIsInCombat");
    }
}
