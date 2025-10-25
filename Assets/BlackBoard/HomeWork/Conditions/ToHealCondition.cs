using UnityEngine;

[CreateAssetMenu(fileName = "ToHealCondition", menuName = "FSM/Conditions/ToHealCondition")]
public class ToHealCondition : Condition_Medieval
{
    public float lowHealthThreshold = 30f;

    public override bool Check(StateMachine_Medieval sm)
    {
        return sm.blackboard.Get<float>("WarriorHealth") <= lowHealthThreshold;
    }
}
