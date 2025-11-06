using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviourTrees
{
    public interface IStrategy
    {
        Node.Status Process();
        void Reset()
        {
            
        }
    }

    public class ArbolCondition : IStrategy
    {
        readonly Func<bool> predicate;
        public ArbolCondition(Func<bool> predicate)
        {
            this.predicate = predicate;
        }

        public Node.Status Process() => predicate() ? Node.Status.Success : Node.Status.Failure;
    }

    public class ActionStrategy : IStrategy
    {
        readonly Action doSomething;

        public ActionStrategy(Action doSomething)
        {
            this.doSomething = doSomething;
        }

        public Node.Status Process()
        {
            doSomething();
            return Node.Status.Success;
        }
    }
    public class MoveToTargetStrategy : IStrategy
    {
        private Transform mascot;
        private Transform target;
        private float speed;
        private float stopDistance;

        public MoveToTargetStrategy(Transform mascot, Transform target, float speed, float stopDistance)
        {
            this.mascot = mascot;
            this.target = target;
            this.speed = speed;
            this.stopDistance = stopDistance;
        }
        public Node.Status Process()
        {
            if (mascot == null || target == null)
            {
                return Node.Status.Failure;
            }
                

            float dist = Vector3.Distance(mascot.position, target.position);
            if (dist <= stopDistance)
            {
                return Node.Status.Success;
            }

            // moverse al objetivo
            mascot.position = Vector3.MoveTowards(mascot.position, target.position, speed * Time.deltaTime);
            return Node.Status.Running;
        }

        public void Reset() { }
    }

    public class WaitStrategy : IStrategy
    {
        private float waitTime;
        private float timer;
        private bool running;

        public WaitStrategy(float waitTime)
        {
            this.waitTime = waitTime;
            timer = 0f;
            running = false;
        }

        public Node.Status Process()
        {
            // start or continue timer
            running = true;
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                // finished waiting
                timer = 0f;
                running = false;
                return Node.Status.Success;
            }
            return Node.Status.Running;
        }

        public void Reset()
        {
            timer = 0f;
            running = false;
        }
    }

}
