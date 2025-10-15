using UnityEngine;

[CreateAssetMenu(fileName = "GoBackState", menuName = "FSM/States/GoBackState")]
public class DamnGoBackState : State
{
    public float upSpeed = 5f;


    public override void UpdateState(StateMachine stateMachine)
    {
        stateMachine.transform.Translate(stateMachine.transform.up * upSpeed * Time.deltaTime/*, Space.Self*/);
    }

}
