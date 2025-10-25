using UnityEngine;

[CreateAssetMenu(fileName = "ToPatrolFromHealingCondition", menuName = "FSM/Conditions/ToPatrolFromHealingCondition")]
public class ToPatrolFromHealingCondition : Condition_Medieval
{
    public override bool Check(StateMachine_Medieval sm)
    {
        return sm.blackboard.Get<float>("WarriorHealth") >= sm.blackboard.Get<float>("WarriorMaxHealth")
            && sm.blackboard.Get<bool>("WarriorIsInCombat") == false;
    }
}
