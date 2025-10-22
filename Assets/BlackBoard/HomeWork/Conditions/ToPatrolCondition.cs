using UnityEngine;

[CreateAssetMenu(fileName = "ToPatrolCondition", menuName = "FSM/Conditions/ToPatrol")]
public class ToPatrolCondition : Condition_Medieval
{
    public override bool Check(StateMachine_Medieval sm)
    {
        return sm.blackboard.Get<float>("Health") >= sm.blackboard.Get<float>("MaxHealth")
            && sm.blackboard.Get<bool>("InCombat") == false;
    }
}
