using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[CreateAssetMenu(fileName = "WarriorAttackState", menuName = "FSM/States/WarriorAttackState")]
public class WarriorAttackState : State_Medieval
{
    private bool attacking = false;

    public override void EnterState(StateMachine_Medieval sm)
    {
        attacking = false; //Jodido unity que no borra memoria con scriptable objects
        NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();
        agent.isStopped = false;
        Debug.Log("Entered Attack State. Attacking variable value: " + attacking);
    }

    public override void UpdateState(StateMachine_Medieval sm)
    {
        var bb = sm.blackboard;
        NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();
        var targetObj = bb.Get<GameObject>("CurrentTarget");//No visible desde el initializer, solo queda rezar

        if (targetObj == null)
        {
            bb.Set("WarriorIsInCombat", false);
            return;
        }

        float attackRange = 5f;//Por ahora no lo voy a añadir al blackboard porque no hace falta
        float dist = Vector3.Distance(sm.transform.position, targetObj.transform.position);

        if (dist > attackRange)
        {
            agent.SetDestination(targetObj.transform.position);
            Debug.Log("MovingTowardsEnemy");
        }
        else
        {
            Debug.Log("Reached Enemy");
            agent.isStopped = true;
            if (attacking == false)
            {
                Debug.Log("Should Start Attacking");
                sm.StartCoroutine(AttackCoroutine(sm, targetObj));
            }
            else
            {
                Debug.Log("AttackIsOnCooldown");
                
            }
                
        }
    }

    public override void ExitState(StateMachine_Medieval sm)
    {
        NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();
        agent.isStopped = false;
    }

    private IEnumerator AttackCoroutine(StateMachine_Medieval sm, GameObject target)
    {
        Debug.Log("Entered Attack Coroutine");
        attacking = true;
        var bb = sm.blackboard;
        float damage = bb.Get<float>("WarriorAttackDamage");
        float rate = bb.Get<float>("WarriorAttackSpeed");

        var enemy = target.GetComponent<EnemyScript>();
        

        if (enemy != null)
        {
            Debug.Log("Enemy wasnt null, should take damage");
            enemy.TakeDamage(damage);
            //Esto haria que por ataque, reciba daño
            /*
            hp -= 35f; 
            bb.Set("WarriorHealth", hp);
            */
        }

        

        yield return new WaitForSeconds(rate);
        attacking = false;
    }
}
