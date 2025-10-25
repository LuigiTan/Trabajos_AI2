using UnityEngine;

[CreateAssetMenu(fileName = "ToFollowFromFightCondition", menuName = "FSM/Conditions/ToFollowFromFightCondition")]
public class ToFollowFromFightCondition : Condition_Medieval
{
    public float lowHealthThreshold = 30f;//Tengo que poner esto en el blackboard
    public override bool Check(StateMachine_Medieval sm)
    {
        return sm.blackboard.Get<bool>("WarriorIsInCombat") == false
            && sm.blackboard.Get<float>("WarriorHealth") > lowHealthThreshold;
    }
}
