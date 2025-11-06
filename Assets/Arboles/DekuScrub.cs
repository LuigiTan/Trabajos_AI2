using UnityEngine;
using BehaviourTrees;
using UnityEngine.AI;
using System.Collections.Generic;
using NUnit.Framework;
/*
public class DekuScrub : MonoBehaviour
{
    public BehaviourTree dekuTree;
    private NavMeshAgent navMeshAgent;
    public List<Transform> patrolPoints = new List<Transform>();

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        dekuTree = new BehaviourTree("El Deku Tree");
        IStrategy patrolStrategy = new PatrolStrategy(transform, navMeshAgent, patrolPoints, 3f);
        dekuTree.AddChild(new Leaf("Patrullando", patrolStrategy));
    }

    // Update is called once per frame
    void Update()
    {
        dekuTree.Process();
    }
}
*/
