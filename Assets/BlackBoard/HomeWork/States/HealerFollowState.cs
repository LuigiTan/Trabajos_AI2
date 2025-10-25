using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "HealerFollowState", menuName = "FSM/States/HealerFollowState")]
public class HealerFollowState : State_Medieval
{
     public override void EnterState(StateMachine_Medieval sm)
    {
        //var bb = sm.blackboard;
        //NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();


    }
    public override void UpdateState(StateMachine_Medieval sm)
    {
        var bb = sm.blackboard;
        NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();

        float normalOffset = bb.Get<float>("FollowOffset");

        Transform WarriorPosition = bb.Get<Transform>("WarriorPosition");


        //Esto es para que siempre este detras de el 

        Vector3 targetPos = WarriorPosition.position - WarriorPosition.forward * normalOffset;

        agent.SetDestination(targetPos);

        //Esto deberia hacer que lo siga como caiga.
        /*
        Vector3 direction = (agent.transform.position - WarriorPosition.position).normalized;

        Vector3 targetPos = WarriorPosition.position + direction * normalOffset;
        */
    }

}
