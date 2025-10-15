using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "RechargeRoomba", menuName = "FSM/States/RechargeRoomba")]
public class RechargeRoombaState : State
{
    public override void EnterState(StateMachine stateMachine)
    {
        if (stateMachine.context.agent == null)
            stateMachine.TryGetComponent(out stateMachine.context.agent);

        GameObject rechargeStation = GameObject.FindGameObjectWithTag("RechargeStation");
        if (rechargeStation != null)
        {
            stateMachine.context.agent.isStopped = false;
            stateMachine.context.agent.SetDestination(rechargeStation.transform.position);
        }
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        // No se si es trampa, pero se recarga en cuanto entra al trigger con otro script.
    }
}