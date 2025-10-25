using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[CreateAssetMenu(fileName = "HealerHealState", menuName = "FSM/States/HealerHealState")]
public class HealerHealState : State_Medieval
{
    private bool isHealOnCooldown = false;
    public override void EnterState(StateMachine_Medieval sm)
    {
        //var bb = sm.blackboard;
        //NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();
        isHealOnCooldown = false;

    }
    public override void UpdateState(StateMachine_Medieval sm)
    {
        var bb = sm.blackboard;
        NavMeshAgent agent = sm.GetComponent<NavMeshAgent>();


        float HealOffset = bb.Get<float>("HealOffset");

        Transform WarriorPosition = bb.Get<Transform>("WarriorPosition");

        

        //Ahora esto deberia de hacer que se regrese por donde sea

        Vector3 direction = (agent.transform.position - WarriorPosition.position).normalized;

        Vector3 targetPos = WarriorPosition.position + direction * HealOffset;


        agent.SetDestination(targetPos);

        float distance = Vector3.Distance(agent.transform.position, targetPos);
        if (distance <= HealOffset )
        {
            Debug.Log("Llego al warrior");
            //agent.isStopped = false;//Si pongo esto, bajo ciertas situaciones se puede quedar atorado
            if (isHealOnCooldown == false)
            {
                sm.StartCoroutine(HealCoroutine(sm));
            }
            else
            {
                Debug.Log("Heal is on cooldown");
            }
            
        }
        else
        {
            Debug.Log("Moviendose al warrior pero aun no llega");
        }
    }

    private IEnumerator HealCoroutine(StateMachine_Medieval sm)
    {
        isHealOnCooldown = true;
        var bb = sm.blackboard;
        float WarriorHealth = bb.Get<float>("WarriorHealth");
        float HealingRate = bb.Get<float>("HealingRate");//Should be 1
        float HealAmount = bb.Get<float>("HealAmount");//Should be 10
        float MaxHealth = bb.Get<float>("WarriorMaxHealth"); //Should be 100

        WarriorHealth += HealAmount;
        if (WarriorHealth > MaxHealth)
        {
            WarriorHealth = MaxHealth;
        }
        bb.Set("WarriorHealth", WarriorHealth);

        Debug.Log("Warrior Healed. New HP:" + WarriorHealth);

        yield return new WaitForSeconds(HealingRate);
        isHealOnCooldown = false;
    }
}
