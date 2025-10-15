using UnityEngine;


[CreateAssetMenu(fileName = "IdleRoomba", menuName = "FSM/States/IdleRoomba")]
public class IdleRoombaState : State
{
    public override void EnterState(StateMachine stateMachine)
    {
        if (stateMachine.context.agent == null)
            stateMachine.TryGetComponent(out stateMachine.context.agent);

        stateMachine.context.agent.isStopped = true;
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        // Nohacenada
        //*Tose*
    }
}