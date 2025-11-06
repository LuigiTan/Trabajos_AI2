using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovedAgainCondition", menuName = "FSM/Mascot/Conditions/PlayerMovedAgainCondition")]
public class PlayerMovedAgainCondition : Condition_Mascot
{
    public override bool Check(StateMachine_Mascot sm)
    {
        MascotData MD = sm.GetComponent<MascotData>();
        if (MD == null) return false;

        return MD.playerIsMoving;
    }
}