using UnityEngine;

[CreateAssetMenu(fileName = "ToAttackCondition", menuName = "FSM/Conditions/ToAttack")]
public class ToAttackCondition : Condition_Medieval
{
    public override bool Check(StateMachine_Medieval sm)
    {
        return sm.blackboard.Get<bool>("InCombat");
    }
}
