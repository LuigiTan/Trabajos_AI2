using UnityEngine;
using BehaviourTrees;


public class TreeDog_Behaviour : MonoBehaviour
{

    
    [Header("References")]
    [SerializeField] public Transform player;
    [SerializeField] public Transform home;

    [Header("Movement")]
    [SerializeField] public float moveSpeed = 3f;
    [SerializeField] public float followOffset = 2f; //offset del jugador para que no se clippie
    [SerializeField] public float maxFollowDistance = 10f;

    [Header("GoHome Shito")]
    [SerializeField] public float waitBeforeGoingHome = 2f;
    [SerializeField] public float homeStopDistance = 0.1f;

    private BehaviourTree treeRoot;//La root

    //Forma mas facil de sacar distancias
    private float DistToPlayer => player ? Vector3.Distance(transform.position, player.position) : Mathf.Infinity;
    private float DistToHome => home ? Vector3.Distance(transform.position, home.position) : Mathf.Infinity;

    private void Start()
    {
        Ivern();
    }

    private void Update()
    {
        if (treeRoot != null)
            treeRoot.Process();
    }

    private void Ivern()
    {
        var condPlayerTooFar = new ArbolCondition(() => DistToPlayer > maxFollowDistance);
        var condPlayerBeyondOffset = new ArbolCondition(() => DistToPlayer > followOffset);
        var condReachedHome = new ArbolCondition(() => DistToHome <= homeStopDistance);

        var waitStrategy = new WaitStrategy(waitBeforeGoingHome);
        var moveToHome = new MoveToTargetStrategy(transform, home, moveSpeed, homeStopDistance);
        var moveToPlayer = new MoveToTargetStrategy(transform, player, moveSpeed, followOffset);

        var idleAction = new ActionStrategy(() => { /* nohacenada */ });

        treeRoot = new BehaviourTree("MascotRoot");

        Sequence goHomeSequence = new Sequence("GoHomeSequence");
        goHomeSequence.AddChild(new Leaf("PlayerTooFar?", condPlayerTooFar));
        goHomeSequence.AddChild(new Leaf("WaitBeforeGoHome", waitStrategy));
        goHomeSequence.AddChild(new Leaf("MoveToHome", moveToHome));

        Sequence followSequence = new Sequence("FollowSequence");
        followSequence.AddChild(new Leaf("PlayerBeyondOffset?", condPlayerBeyondOffset));
        followSequence.AddChild(new Leaf("MoveToPlayer", moveToPlayer));

        Leaf idleLeaf = new Leaf("Idle", idleAction);


        Selector rootSelector = new Selector("RootSelector");
        rootSelector.AddChild(goHomeSequence);
        rootSelector.AddChild(followSequence);
        rootSelector.AddChild(idleLeaf);

        treeRoot.AddChild(rootSelector);
    }
}
