using UnityEngine;

[CreateAssetMenu(fileName = "ToRestCondition", menuName = "FSM/Conditions/ToRestCondition")]
public class ToRestCondition : Condition_Medieval
{
    public float lowHealthThreshold = 30f;

    public override bool Check(StateMachine_Medieval sm)
    {
        return sm.blackboard.Get<float>("WarriorHealth") <= lowHealthThreshold;
    }
}
