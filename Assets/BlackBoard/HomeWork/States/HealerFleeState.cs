using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "HealerFleeState", menuName = "FSM/States/HealerFleeState")]

public class HealerFleeState : State_Medieval
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

        float FleeOffset = bb.Get<float>("FleeOffset");

        Transform WarriorPosition = bb.Get<Transform>("WarriorPosition");

        //En teoria esto deberia de hacer que en el momento que entra en combate el healer se va a alejar lo mas posible

        Vector3 direction = (agent.transform.position - WarriorPosition.position).normalized;

        Vector3 targetPos = WarriorPosition.position + direction * FleeOffset;


        agent.SetDestination(targetPos);

        
        
        
    }
}
