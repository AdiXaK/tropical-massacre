using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navMeshAgent;
    public float attackRange = 2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (player != null && navMeshAgent != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            navMeshAgent.SetDestination(player.position);
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                Attack(); 
            }
        }
    }

    private void Attack()
    {
        Debug.Log("Атака!");
    }
}
