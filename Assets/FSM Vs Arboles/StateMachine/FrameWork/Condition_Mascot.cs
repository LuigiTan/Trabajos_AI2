using UnityEngine;

public abstract class Condition_Mascot : ScriptableObject
{
    public virtual bool Check(StateMachine_Mascot stateMachine_Mascot) { return false; }
}
[System.Serializable]
public class Transition_Mascot
{
    public Condition_Mascot condition;
    public State_Mascot state;
}

