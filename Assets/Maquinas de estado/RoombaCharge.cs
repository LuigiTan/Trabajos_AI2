using Unity.VisualScripting;
using UnityEngine;

public class RoombaCharge : MonoBehaviour
{
    [SerializeField]
    private StateMachine fsm;

    private void Awake()
    {
        fsm = GetComponent<StateMachine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Chager Station");
        if (other.CompareTag("RechargeStation"))
        {
            fsm.context.battery = 100f;
            Debug.Log("Shouldve given charge");
        }
    }
}