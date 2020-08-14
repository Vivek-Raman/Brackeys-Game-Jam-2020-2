using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // TODO: pre-determined patrol path
    // TODO: override path on player encountered

    [SerializeField] private float inCircleRadius = 10f;

    private Camera cam = null;
    private NavMeshAgent agent = null;
    private RaycastHit[] hitBuffer;

    private void Awake()
    {
        cam = Camera.main;
        agent = this.GetComponent<NavMeshAgent>();
        hitBuffer = new RaycastHit[2];
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.01f)
        {
            OnReachDestination();
        }
    }

    private void OnReachDestination()
    {
        Vector3 newDestination = inCircleRadius * Random.insideUnitSphere;
        newDestination.y = 0f;
        agent.destination = newDestination;
    }
}
