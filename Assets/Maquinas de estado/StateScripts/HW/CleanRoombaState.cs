using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "CleanRoomba", menuName = "FSM/States/CleanRoomba")]
public class CleanRoombaState : State
{
    public float stopDistance = 1.2f;

    public override void EnterState(StateMachine stateMachine)
    {
        if (stateMachine.context.agent == null)
        {
            stateMachine.TryGetComponent(out stateMachine.context.agent);
        }


        // Deberia encontrar el objetivo mas cercas dentro del rango
        FindAndSetClosestTrash(stateMachine);
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        
        var agent = stateMachine.context.agent;//Me dice que es innecesario pero se me hace mas facil.
        var target = stateMachine.context.currentTarget;

        if (target == null)
        {
            FindAndSetClosestTrash(stateMachine);
            return;
        }

        float dist = Vector3.Distance(stateMachine.transform.position, target.position);



        // Si llegamos al objetivo
        
        if (dist <= stopDistance)
        {
            Object.Destroy(target.gameObject);
            stateMachine.context.currentTarget = null;
            stateMachine.context.battery -= 40f;
            if (stateMachine.context.battery > 20f)
            {
                FindAndSetClosestTrash(stateMachine);
            }
        }
    }

    private void FindAndSetClosestTrash(StateMachine stateMachine)
    {
        GameObject[] trashObjects = GameObject.FindGameObjectsWithTag("Trash");
        Transform closest = null;
        float minDist = Mathf.Infinity;
        float range = stateMachine.context.defaultDetectionRange;
        Vector3 origin = stateMachine.transform.position;

        foreach (var obj in trashObjects)
        {
            float dist = Vector3.Distance(origin, obj.transform.position);
            if (dist < minDist && dist <= range)
            {
                minDist = dist;
                closest = obj.transform;
            }
        }

        if (closest != null)
        {
            stateMachine.context.currentTarget = closest;//Debug
            stateMachine.context.agent.isStopped = false;
            stateMachine.context.agent.SetDestination(closest.position);
        }
        else
        {
            // No hay mas basura cerca, se detiene y espera transicion
            stateMachine.context.agent.isStopped = true;
            stateMachine.context.currentTarget = null;
        }
    }
}