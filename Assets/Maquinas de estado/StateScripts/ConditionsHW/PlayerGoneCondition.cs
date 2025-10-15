using UnityEngine;

[CreateAssetMenu(fileName = "PlayerGoneCondition", menuName = "FSM/Conditions/PlayerGoneCondition")]
public class PlayerFarCondition : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        if (stateMachine.context.player == null)
            return false;

        float dist = Vector3.Distance(stateMachine.transform.position, stateMachine.context.player.position);
        return dist > stateMachine.context.scaredDistance;
    }
}