using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StateMachine_Medieval : MonoBehaviour
{
    public State_Medieval initialState;
    public State_Medieval currentState;

    [Header("Shared Blackboard")]
    public MedievalBlackboard blackboard;

    private void Start()
    {
        ChangeState(initialState);
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
            currentState.CheckTransitions(this);
        }
    }
    public void ChangeState(State_Medieval state)
    {
        if (currentState == state || state == null)
        {
            return;
        }
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = state;
        currentState.EnterState(this);
    }
}