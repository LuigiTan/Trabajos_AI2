using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "WarriorRestState", menuName = "FSM/States/WarriorRestState")]
public class WarriorRestState : State_Medieval
{
    public override void EnterState(StateMachine_Medieval sm)
    {
        var bb = sm.blackboard;
        NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();
        List<Transform> waypoints = bb.Get<List<Transform>>("WarriorWaypoints");

        int last = bb.Get<int>("CurrentWaypoint");

        if (waypoints != null && waypoints.Count > 0)
            agent.SetDestination(waypoints[last].position);
    }

    public override void UpdateState(StateMachine_Medieval sm)
    {
        var bb = sm.blackboard;
        NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();

        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            agent.isStopped = true;
        }

        //Prueba para ver si regeneracion pasiva funcionaba, no para usarse 
        /*
         * 
         * 
        float health = bb.Get<float>("WarriorHealth");
        float maxHealth = bb.Get<float>("WarriorMaxHealth");

        
        if (health < maxHealth)
        {
            health += 10f * Time.deltaTime; 
            bb.Set("WarriorHealth", health);
        }
        */
    }

    public override void ExitState(StateMachine_Medieval sm)
    {
        NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();
        agent.isStopped = false;
    }
}
