using UnityEngine;

public class MascotData : MonoBehaviour
{
    //Deberia haber sido un blackboard?? Si pero no tengo ya mente para eso
    public Transform player;
    public Transform homePosition;

    public float followOffset = 2f;
    public float maxFollowDistance = 10f;
    public float moveSpeed = 3f;

    // Para ver si el jugador se mueve
    private Vector3 lastPlayerPosition;
    public bool playerIsMoving { get; private set; }

    private void Update()
    {
        if (player == null) return;

        playerIsMoving = (player.position - lastPlayerPosition).sqrMagnitude > 0.001f;//Las locuras que se encuentra uno
        lastPlayerPosition = player.position;
    }
}
