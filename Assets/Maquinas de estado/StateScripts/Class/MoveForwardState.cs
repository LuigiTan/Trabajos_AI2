using UnityEngine;

[CreateAssetMenu(fileName = "StatePatito", menuName = "FSM/States/StatePatito")]
public class MoveForwardState : State
{
    public float speed = 2f;


    public override void UpdateState(StateMachine stateMachine)
    {
        stateMachine.transform.Translate(Vector3.forward * speed * Time.deltaTime/*, Space.Self*/);
    }

}
