using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "InvestigateState", menuName = "FSM/States/InvestigateState")]
public class InvestigateState : State
{
    //public bool coroutineStarted = false;//Si llego a spawnear mas de una mejor la meto al context (Ya no porque saco error)

    public override void EnterState(StateMachine stateMachine)
    {
        if (stateMachine.context.agent == null)
            stateMachine.TryGetComponent(out stateMachine.context.agent);

        if (stateMachine.context.currentTarget != null)
        {
            stateMachine.context.agent.isStopped = false;
            stateMachine.context.agent.speed = stateMachine.context.moveSpeed;
            stateMachine.context.agent.SetDestination(stateMachine.context.currentTarget.position);
        }
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        var agent = stateMachine.context.agent;
        var target = stateMachine.context.currentTarget;

        if (target == null)
            return;

        float dist = Vector3.Distance(stateMachine.transform.position, target.position);

        if (dist <= stateMachine.context.investigateDistance)
        {
            agent.isStopped = true;

            // Inicia la espera si aun no se inicio otra
            if (!stateMachine.context.isCuriosityCoolingDown)
            {
                stateMachine.StartCoroutine(InvestigateCoroutine(stateMachine));
            }
        }
    }

    private IEnumerator InvestigateCoroutine(StateMachine stateMachine)
    {
        stateMachine.context.isCuriosityCoolingDown = true;
        yield return new WaitForSeconds(stateMachine.context.investigateTime);

        // Termino de investigar
        stateMachine.context.currentTarget = null;

        //Espera otro rato para evitar loops 
        yield return new WaitForSeconds(stateMachine.context.investigateCooldown);
        stateMachine.context.isCuriosityCoolingDown = false;
    }
}
