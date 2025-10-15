using UnityEngine;

[CreateAssetMenu(fileName = "FullChargeCondition", menuName = "FSM/Conditions/FullChargeCondition")]
public class FullChargeCondition : Condition
{
    public float Fullcharge = 100f;
    public override bool Check(StateMachine stateMachine)
    {
        return stateMachine.context.battery >= Fullcharge;//Se lo cambia otro script 
    }
}