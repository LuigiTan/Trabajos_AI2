using UnityEngine;

[CreateAssetMenu(fileName = "StatePatito", menuName = "FSM/States/StatePatito")]
public class MoveForwardState : State
{
    public float speed = 2f;

    public override void EnterState(StateMachine state)
    {
        state.blackBoard.Set("RoombaBattery", 100f);
    }
    public override void UpdateState(StateMachine stateMachine)
    {
        stateMachine.transform.Translate(stateMachine.transform.forward * speed * Time.deltaTime, Space.Self);
        stateMachine.blackBoard.Set(BBKeys.Battery, stateMachine.blackBoard.Get<float>("RoombaBattery"));
            
    }


}
public static class BBKeys
{
        public const string Battery = "0";
}
