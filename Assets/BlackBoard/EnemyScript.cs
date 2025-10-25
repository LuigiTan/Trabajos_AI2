using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Blackboard")]
    [SerializeField] private MedievalBlackboard blackboard;
    public float health = 100f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log("Enemy Damaged HP:" + health);
        if (health <= 0) 
        {
            Debug.Log("EnemyDamage");
            OnDeath();
            Destroy(gameObject);
        } 
    }
    private void OnDeath()
    {
        
        float WarriorHP = blackboard.Get<float>("WarriorHealth");
        WarriorHP -= 70f;// daño fijo, costo por atacas

        blackboard.Set("WarriorHealth", WarriorHP);
        blackboard.Set("WarriorIsInCombat", false);

        Debug.Log("Enemy died -> Warrior took colateral damage, new HP = " + WarriorHP);



    }
}