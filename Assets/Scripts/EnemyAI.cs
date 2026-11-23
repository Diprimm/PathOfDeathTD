using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
    }
}
