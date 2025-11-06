using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "GoHomeState", menuName = "FSM/Mascot/States/GoHomeState")]
public class GoHomeState : State_Mascot
{
    public float waitTime = 2f;
    bool waiting = false;

    public override void EnterState(StateMachine_Mascot sm)
    {
        waiting = false;
        sm.StartCoroutine(WaitAndGoHome(sm));
    }

    IEnumerator WaitAndGoHome(StateMachine_Mascot sm)
    {
        waiting = true;
        yield return new WaitForSeconds(waitTime);
        waiting = false;
    }

    public override void UpdateState(StateMachine_Mascot sm)
    {
        MascotData MD = sm.GetComponent<MascotData>();
        if (MD == null) return;

        if (waiting) return;

        sm.transform.position = Vector3.MoveTowards(sm.transform.position,MD.homePosition.position,MD.moveSpeed * Time.deltaTime);
    }
}
