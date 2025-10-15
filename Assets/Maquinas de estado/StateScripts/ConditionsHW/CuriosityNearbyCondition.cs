using UnityEngine;

[CreateAssetMenu(fileName = "CuriosityNearbyCondition", menuName = "FSM/Conditions/CuriosityNearby")]
public class CuriosityNearbyCondition : Condition
{
    public override bool Check(StateMachine stateMachine)
    {
        if (stateMachine.context.isCuriosityCoolingDown)
            return false; // Aun en cooldown, no busca nadota

        GameObject[] curiosities = GameObject.FindGameObjectsWithTag("Curiosities");
        float maxDist = stateMachine.context.investigateDistance;

        Transform closest = null;
        float closestDist = Mathf.Infinity;

        foreach (var obj in curiosities)
        {
            float dist = Vector3.Distance(stateMachine.transform.position, obj.transform.position);
            if (dist <= maxDist && dist < closestDist)
            {
                closestDist = dist;
                closest = obj.transform;
            }
        }

        if (closest != null)
            stateMachine.context.currentTarget = closest;

        return closest != null;
    }
}
