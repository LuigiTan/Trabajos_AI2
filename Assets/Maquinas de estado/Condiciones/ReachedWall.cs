using UnityEngine;

[CreateAssetMenu(fileName = "ReachedWallCondition", menuName = "FSM/Conditions/ReachedWallCondition")]
public class ReachedWall : Condition
{
    public float checkDistance = 1.5f;
    public LayerMask WallMask;
    public override bool Check(StateMachine stateMachine)
    {
        Ray ray = new Ray(stateMachine.transform.position, Vector3.forward);
        return Physics.Raycast(ray, checkDistance, WallMask);
    }
}
