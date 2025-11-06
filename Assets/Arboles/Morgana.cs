using BehaviourTrees;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
/*
namespace BehaviourTrees 
{
    public class Morgana : MonoBehaviour
    {
        public BehaviourTree tree;
        public GameObject prize;
        public List<Transform> patrolPoints = new List<Transform>();

        public NavMeshAgent agent;
        private void Awake()
        {
            tree = new BehaviourTree("Le Morgana");

            agent = GetComponent<NavMeshAgent>();

            var foo = new Condition(() => prize.activeSelf);

            Leaf isPrizePresent = new Leaf("IsPrizePresent", foo);

            Leaf moveToPrize = new Leaf("MoveToPrize", new ActionStrategy(() => agent.SetDestination(prize.transform.position)));

            Sequence findPrize = new Sequence("FindPrize");
            findPrize.AddChild(isPrizePresent);
            findPrize.AddChild(moveToPrize);

            Selector baseSelector = new Selector("Base Selector");
            baseSelector.AddChild(findPrize);

            baseSelector.AddChild(new Leaf("Patrol", new PatrolStrategy(transform, agent, patrolPoints, 5)));


            tree.AddChild(baseSelector);
        }
    }
}
*/