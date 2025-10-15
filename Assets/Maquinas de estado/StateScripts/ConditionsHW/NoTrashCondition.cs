using UnityEngine;

[CreateAssetMenu(fileName = "NoTrashCondition", menuName = "FSM/Conditions/NoTrashCondition")]
public class NoTrashLeftCondition : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        Transform origin = stateMachine.transform;
        float range = stateMachine.context.defaultDetectionRange;

        GameObject[] trashObjects = GameObject.FindGameObjectsWithTag("Trash");

        foreach (var obj in trashObjects)
        {
            float dist = Vector3.Distance(origin.position, obj.transform.position);//Ya se que no es lo mejor pero tengo sueño
            if (dist <= range)
            {
                // Hay basura en el rango
                return false;
            }
        }

        // No hay basura en el rango
        return true;
    }
}