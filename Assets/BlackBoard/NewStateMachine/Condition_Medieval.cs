using UnityEngine;

public abstract class Condition_Medieval : ScriptableObject
{
    public virtual bool Check(StateMachine_Medieval stateMachine_Medieval) { return false; }
}
[System.Serializable]
public class Transition_Medieval
{
    public Condition_Medieval condition;
    public State_Medieval state;
}

