using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "WarriorPatrolState", menuName = "FSM/States/WarriorPatrol")]
public class WarriorPatrolState : State_Medieval
{
    //public float detectionRadius = 5f;

    public override void EnterState(StateMachine_Medieval sm)
    {
        var bb = sm.blackboard;
        NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();
        //Esto estaba mal
        //Transform[] waypoints = bb.Get<Transform[]>("WarriorWaypoints");


        List<Transform> waypoints = bb.Get<List<Transform>>("WarriorWaypoints");//Esto si deberia funcionar
        int current = bb.Get<int>("WarriorCurrentWaypointIndex");//Neew


        if (waypoints == null || waypoints.Count == 0)
        {
            Debug.LogError("Theres no waypoints assigned in (EnterState)");
            return;
        }

        if (agent != null && waypoints[current] != null)
        {
            agent.SetDestination(waypoints[current].position);
        }
        else
        {
            Debug.LogError("Agent o waypoint actual es null en (EnterState)");
        }

    }

    public override void UpdateState(StateMachine_Medieval sm)
    {
        var bb = sm.blackboard;
        NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();


        List<Transform> waypoints = bb.Get<List<Transform>>("WarriorWaypoints");

        int current = bb.Get<int>("WarriorCurrentWaypointIndex");
        float detectionRadius = bb.Get<float>("WarriorDetectionRadius");

        if (waypoints == null || waypoints.Count == 0)
        {
            Debug.LogError("There's no waypoints assigned for the warrior in (UpdateState)");
            return;
        }
        //Viejo Debug
        /*
        if (current < 0 || current >= waypoints.Count)
        {
            current = 0;
            bb.Set("WarriorCurrentWaypointIndex", current);
        }
        */

        // Mover al siguiente waypoint
        if (agent != null && !agent.pathPending && agent.remainingDistance < 0.3f)
        {
            current = (current + 1) % waypoints.Count;
            bb.Set("WarriorCurrentWaypointIndex", current);


            if (waypoints[current] != null)
                agent.SetDestination(waypoints[current].position);
            else
                Debug.LogError("Waypoint en index " + current + " es null.");
        }

        // Deteccion de enemigos
        Collider[] hits = Physics.OverlapSphere(sm.transform.position, detectionRadius);//Que esto este aqui *en teoria* evita que explote si hay mas de un enemigo
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                bb.Set("CurrentTarget", hit.gameObject);
                bb.Set("WarriorIsInCombat", true);
                break;
            }
        }
    }
}
