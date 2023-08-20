using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Shopkeeper : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] Patrol_Points;//The points to which the agent will patrol.
    private int currentPatrolPointIndex = 0;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Patroling();
    }
    void Patroling()
    {
        agent.SetDestination(Patrol_Points[currentPatrolPointIndex].position);

        if (agent.pathStatus == NavMeshPathStatus.PathComplete && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % Patrol_Points.Length;

        }
        if (currentPatrolPointIndex == Patrol_Points.Length)
        {
            currentPatrolPointIndex = 0;
        }
    }
}
