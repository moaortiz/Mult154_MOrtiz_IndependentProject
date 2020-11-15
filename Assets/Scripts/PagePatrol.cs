using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PagePatrol : MonoBehaviour
{
    public List<GameObject> wayPoints;
    private NavMeshAgent agent;
    private const float WP_THRESHOLD = 4.0f;
    private GameObject currentWP;
    private int currentWPIndex = -1;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWP = GetNextWaypoint();
    }

    GameObject GetNextWaypoint()
    {
        currentWPIndex++;
        if (currentWPIndex == wayPoints.Count)
        {
            currentWPIndex = 0;
        }
        return wayPoints[currentWPIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentWP.transform.position) < WP_THRESHOLD)
        {
            currentWP = GetNextWaypoint();
            agent.SetDestination(currentWP.transform.position);
        }
    }
}
