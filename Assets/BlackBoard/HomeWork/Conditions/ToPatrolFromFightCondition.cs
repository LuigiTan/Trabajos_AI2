using UnityEngine;

[CreateAssetMenu(fileName = "ToPatrolFromFightCondition", menuName = "FSM/Conditions/ToPatrolFromFightCondition")]
public class ToPatrolFromFightCondition : Condition_Medieval
{
    public float lowHealthThreshold = 30f;//Tengo que poner esto en el blackboard
    public override bool Check(StateMachine_Medieval sm)
    {
        return sm.blackboard.Get<bool>("WarriorIsInCombat") == false
            && sm.blackboard.Get<float>("WarriorHealth") > lowHealthThreshold;
    }
}
