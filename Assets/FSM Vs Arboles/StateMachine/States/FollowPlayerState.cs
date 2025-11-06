using UnityEngine;


[CreateAssetMenu(fileName = "FollowPlayerState", menuName = "FSM/Mascot/States/FollowPlayerState")]
public class FollowPlayerState : State_Mascot
{
    public override void UpdateState(StateMachine_Mascot sm)
    {
        MascotData MD = sm.GetComponent<MascotData>();
        if (MD == null || MD.player == null) return;

        float dist = Vector3.Distance(sm.transform.position, MD.player.position);

        
        if (dist > MD.followOffset)//Offset
        {
            sm.transform.position = Vector3.MoveTowards(sm.transform.position,MD.player.position,MD.moveSpeed * Time.deltaTime);
        }
    }
}