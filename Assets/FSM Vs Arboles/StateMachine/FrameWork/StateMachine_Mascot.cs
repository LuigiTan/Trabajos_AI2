using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StateMachine_Mascot : MonoBehaviour
{
    public State_Mascot initialState;
    public State_Mascot currentState;

    //[Header("Shared Blackboard")]
    //public MedievalBlackboard blackboard;

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
    public void ChangeState(State_Mascot state)
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