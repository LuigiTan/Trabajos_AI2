using UnityEngine;

[CreateAssetMenu(fileName = "ReachedPlayerCondition", menuName = "FSM/Mascot/Conditions/ReachedPlayer")]
public class ReachedPlayerCondition : Condition_Mascot
{
    public override bool Check(StateMachine_Mascot sm)
    {
        MascotData MD = sm.GetComponent<MascotData>();
        if (MD == null || MD.player == null) return false;

        float dist = Vector3.Distance(sm.transform.position, MD.player.position);
        return dist <= MD.followOffset;
    }
}