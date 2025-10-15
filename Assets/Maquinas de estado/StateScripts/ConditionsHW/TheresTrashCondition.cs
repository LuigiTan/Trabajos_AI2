using UnityEngine;

[CreateAssetMenu(fileName = "TrashCondition", menuName = "FSM/Conditions/TrashCondition")]
public class TheresTrashCondition : Condition
{
    public float detectionRange = 15f;

    public override bool Check(StateMachine stateMachine)
    {
        GameObject[] trashObjects = GameObject.FindGameObjectsWithTag("Trash");
        foreach (var obj in trashObjects)
        {
            if (Vector3.Distance(stateMachine.transform.position, obj.transform.position) <= detectionRange)
            {
                return true;
            }
                
        }
        return false;
    }
}