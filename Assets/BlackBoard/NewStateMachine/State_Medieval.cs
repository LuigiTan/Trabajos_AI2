using UnityEngine;

public abstract class State_Medieval : ScriptableObject
{
    public Transition_Medieval[] transitions;

    public virtual void EnterState(StateMachine_Medieval stateMachine_Medieval)
    {

    }
    public virtual void ExitState(StateMachine_Medieval stateMachine_Medieval) { }

    public virtual void UpdateState(StateMachine_Medieval stateMachine_Medieval) { }
    public void CheckTransitions(StateMachine_Medieval stateMachine_Medieval)
    {
        foreach (var t in transitions)
        {
            if (t.condition != null && t.condition.Check(stateMachine_Medieval))
            {
                stateMachine_Medieval.ChangeState(t.state);
                break;
            }
        }
    }
}

