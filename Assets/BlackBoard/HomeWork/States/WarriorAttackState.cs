using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[CreateAssetMenu(fileName = "WarriorAttackState", menuName = "FSM/States/WarriorAttack")]
public class WarriorAttackState : State_Medieval
{
    private bool attacking = false;

    public override void EnterState(StateMachine_Medieval sm)
    {
        var agent = sm.GetComponent<NavMeshAgent>();
        agent.isStopped = false;
    }

    public override void UpdateState(StateMachine_Medieval sm)
    {
        var bb = sm.blackboard;
        var agent = sm.GetComponent<NavMeshAgent>();
        var targetObj = bb.Get<GameObject>("CurrentTarget");

        if (targetObj == null)
        {
            bb.Set("InCombat", false);
            return;
        }

        float attackRange = 1.5f;
        float dist = Vector3.Distance(sm.transform.position, targetObj.transform.position);

        if (dist > attackRange)
        {
            agent.SetDestination(targetObj.transform.position);
        }
        else
        {
            agent.isStopped = true;
            if (!attacking)
                sm.StartCoroutine(AttackCoroutine(sm, targetObj));
        }
    }

    private IEnumerator AttackCoroutine(StateMachine_Medieval sm, GameObject target)
    {
        attacking = true;
        var bb = sm.blackboard;
        float damage = bb.Get<float>("AttackDamage");
        float rate = bb.Get<float>("AttackRate");

        var enemy = target.GetComponent<EnemyScript>();
        var hp = bb.Get<float>("Health");

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            hp -= 5f; // daño fijo, costo por atacas
            bb.Set("Health", hp);
        }

        yield return new WaitForSeconds(rate);
        attacking = false;
    }
}
