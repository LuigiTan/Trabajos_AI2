using UnityEngine;

[CreateAssetMenu(fileName = "LowBatteryCondition", menuName = "FSM/Conditions/LowBatteryCondition")]
public class LowBatteryCondition : Condition
{
    public float AmountConsideredLow = 20f;
    public override bool Check(StateMachine stateMachine)
    {
        return stateMachine.context.battery <= AmountConsideredLow;
    }
}