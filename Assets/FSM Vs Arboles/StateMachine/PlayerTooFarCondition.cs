using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTooFarCondition", menuName = "FSM/Mascot/Conditions/PlayerTooFarCondition")]
public class PlayerTooFarCondition : Condition_Mascot
{
    public override bool Check(StateMachine_Mascot sm)
    {
        MascotData MD = sm.GetComponent<MascotData>();
        if (MD == null || MD.player == null) return false;

        float dist = Vector3.Distance(sm.transform.position, MD.player.position);
        return dist > MD.maxFollowDistance;
    }
}
