using UnityEngine;

[CreateAssetMenu(fileName = "ReachedHomeCondition", menuName = "FSM/Mascot/Conditions/ReachedHomeCondition")]
public class ReachedHomeCondition : Condition_Mascot
{
    public override bool Check(StateMachine_Mascot sm)
    {
        MascotData MD = sm.GetComponent<MascotData>();
        if (MD == null) return false;

        return Vector3.Distance(sm.transform.position, MD.homePosition.position) < 0.1f;
    }
}
