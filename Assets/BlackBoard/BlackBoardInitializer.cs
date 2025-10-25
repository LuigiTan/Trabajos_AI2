using UnityEngine;
using System.Collections.Generic;

public class BlackboardInitializer : MonoBehaviour
{
    [Header("Blackboard")]
    [SerializeField] private MedievalBlackboard blackboard;

    [Header("Datos del Warrior")]
    [SerializeField] private Transform warriorTransform;
    [SerializeField] private List<Transform> warriorWaypoints;
    [SerializeField] private float warriorMaxHealth = 100f;
    [SerializeField] private float warriorAttackDamage = 15f;
    [SerializeField] private float warriorAttackSpeed = 1f;

    [SerializeField] private float EnemyDetectionRadius = 10f;

    [Header("Datos del Healer")]
    //[SerializeField] private Transform healerTransform;
    [SerializeField] private float healerHealingRate = 10f;
    [SerializeField] private float followOffset = 2f;
    [SerializeField] private float fleeOffset = 8f;
    [SerializeField] private float healOffset = 1f;

    private void Awake()
    {
        if (blackboard == null)
        {
            Debug.LogError("No se asigno el MedievalBlackboard");
            return;
        }

        //Warrior
        
        blackboard.Set("WarriorWaypoints", warriorWaypoints);
        blackboard.Set("WarriorHealth", warriorMaxHealth);
        blackboard.Set("WarriorMaxHealth", warriorMaxHealth);
        blackboard.Set("WarriorAttackDamage", warriorAttackDamage);
        blackboard.Set("WarriorAttackSpeed", warriorAttackSpeed);
        blackboard.Set("WarriorIsInCombat", false);
        blackboard.Set("WarriorCurrentWaypointIndex", 0);

        blackboard.Set("WarriorDetectionRadius", EnemyDetectionRadius);

        //Healer
        
        blackboard.Set("HealingRate", healerHealingRate);
        blackboard.Set("FollowOffset", followOffset);
        blackboard.Set("FleeOffset", fleeOffset);
        blackboard.Set("HealOffset", healOffset);

        

        Debug.Log("Blackboard inicializado");
    }

    private void Update()
    {
        //Cosas que los dos necesitarian
        blackboard.Set("WarriorPosition", warriorTransform);
        //blackboard.Set("HealerPosition", healerTransform);
    }
}
