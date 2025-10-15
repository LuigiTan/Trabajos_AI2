using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "ScaredState", menuName = "FSM/States/ScaredState")]
public class ScaredState : State
{
    public float fleeDistance = 5f;

    public override void EnterState(StateMachine stateMachine)
    {
        if (stateMachine.context.agent == null)
        {
            stateMachine.TryGetComponent(out stateMachine.context.agent);
        }
            

        stateMachine.context.agent.isStopped = false;
        stateMachine.context.agent.speed = stateMachine.context.moveSpeed;

        MoveAwayFromPlayer(stateMachine);
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var agent = stateMachine.context.agent;

        if (!agent.pathPending && agent.remainingDistance <= 0.1f)
        {
            MoveAwayFromPlayer(stateMachine);
        }
    }

    private void MoveAwayFromPlayer(StateMachine stateMachine)
    {
        if (stateMachine.context.player == null)
            return;

        Vector3 dir = (stateMachine.transform.position - stateMachine.context.player.position).normalized;
        Vector3 fleePoint = stateMachine.transform.position + dir * fleeDistance;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(fleePoint, out hit, fleeDistance, NavMesh.AllAreas))//Realmente esto solo es por si creara un mapa en si, en este momento
        {                                                                              //mas bien se caeria del mapa xd
            stateMachine.context.agent.SetDestination(hit.position);
        }
    }
}