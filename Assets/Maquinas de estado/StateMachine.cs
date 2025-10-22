using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    public State currentState;

    public FSMContext context = new FSMContext();//Segun tengo entendido esto es para poder pasar variables entre scripts
    public Blackboard blackBoard = new Blackboard();
    private void Start()
    {
        blackBoard.Set("Player", GameObject.FindGameObjectsWithTag("Player"));
        ChangeState(initialState);
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
            currentState.CheckTransitions(this);
        }
    }
    public void ChangeState(State state)
    {
        if (currentState == state || state == null)
        {
            return;
        }
        if(currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = state;
        currentState.EnterState(this);
    }
}
[Serializable]
public class FSMContext
{
    //Objetivo actual del roomba, va a ser null cuando lo destruya
    //Tambien es el waypoint actual para la curiosa
    public Transform currentTarget;


    //Esto es del gameObject que traiga el StateMachine
    //Deberia sacarlo desde los states en EnterState
    public NavMeshAgent agent;
    //Energia
    public float battery = 100f;

    //Creo que hice algo mal, esto no jalo
    //public string trashTag = "Trash";
    //public string rechargeTag = "RechargeStation";

    //Esto se puede sobrescribir en la condicion.
    public float defaultDetectionRange = 15f;

    //Lista para wanderer
    public List<Transform> waypoints;

    //Indice de waypoints
    public int currentWaypointIndex = 0;

    //Distancia para investigar
    public float investigateDistance = 5f;

    //Rango para huir del jugador
    public float scaredDistance = 2f;


    //Tiempo perdido investigando
    public float investigateTime = 2f;

    //Velocidad (espero jale)
    public float moveSpeed = 3f;

    // Referencia al jugador
    public Transform player;

    //Para evitar loop en la investigacion
    public bool isCuriosityCoolingDown = false;
    public float investigateCooldown = 6f;//Esto tiene que ser minimo el doble que el tiempo de investigar

    //Por ahorita no creo usar esto
    //public GameObject playah;
    //public int neccesaryInt;
}
