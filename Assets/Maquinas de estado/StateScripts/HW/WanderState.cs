using UnityEngine;


[CreateAssetMenu(fileName = "WanderState", menuName = "FSM/States/WanderState")]
public class WanderState : State
{
    public override void EnterState(StateMachine stateMachine)
    {
        //if (stateMachine.context.agent == null)
        //stateMachine.TryGetComponent(out stateMachine.context.agent);

        if (stateMachine.context.agent == null)
        {
            if (!stateMachine.TryGetComponent(out stateMachine.context.agent))
            {
                Debug.LogError("No NavMeshAgent found on the GameObject!");
                return;
            }
        }

        stateMachine.context.agent.isStopped = false;
        stateMachine.context.agent.speed = stateMachine.context.moveSpeed;

        MoveToNextWaypoint(stateMachine);
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var agent = stateMachine.context.agent;
        if (agent == null)
        {
            Debug.Log("El agente es nulo!");
            return;
        }
            
        if (agent.pathPending || agent.remainingDistance > 0.1f)
            return;

        MoveToNextWaypoint(stateMachine);
    }

    private void MoveToNextWaypoint(StateMachine stateMachine)
    {
        if (stateMachine.context.waypoints.Count == 0)
            return;

        stateMachine.context.agent.SetDestination(
            stateMachine.context.waypoints[stateMachine.context.currentWaypointIndex].position
        );

        stateMachine.context.currentWaypointIndex++;
        if (stateMachine.context.currentWaypointIndex >= stateMachine.context.waypoints.Count)
            stateMachine.context.currentWaypointIndex = 0; // Loop
    }
}
