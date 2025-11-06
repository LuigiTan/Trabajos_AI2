using UnityEngine;

public abstract class State_Mascot : ScriptableObject
{
    public Transition_Mascot[] transitions;

    public virtual void EnterState(StateMachine_Mascot stateMachine_Mascot)
    {

    }
    public virtual void ExitState(StateMachine_Mascot stateMachine_Mascot) { }

    public virtual void UpdateState(StateMachine_Mascot stateMachine_Mascot) { }
    public void CheckTransitions(StateMachine_Mascot stateMachine_Mascot)
    {
        foreach (var t in transitions)
        {
            if (t.condition != null && t.condition.Check(stateMachine_Mascot))
            {
                stateMachine_Mascot.ChangeState(t.state);
                break;
            }
        }
    }
}

