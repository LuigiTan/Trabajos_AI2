using UnityEngine;

[CreateAssetMenu(fileName = "FinishedInvestigationCondition", menuName = "FSM/Conditions/FinishedInvestigationCondition")]
public class FinishedInvestigationCondition : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        // Si no hay currentTarget, significa que acabo de investigar
        return stateMachine.context.currentTarget == null;
    }
}