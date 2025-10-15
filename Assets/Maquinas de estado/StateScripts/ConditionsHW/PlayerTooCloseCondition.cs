using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTooCloseCondition", menuName = "FSM/Conditions/PlayerTooClose")]
public class PlayerTooCloseCondition : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        if (stateMachine.context.player == null)
            return false;

        float dist = Vector3.Distance(stateMachine.transform.position, stateMachine.context.player.position);
        return dist <= stateMachine.context.scaredDistance;
    }
}