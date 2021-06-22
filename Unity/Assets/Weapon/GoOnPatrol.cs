using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoOnPatrol : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public GameObject[] target;
    int index = 0;

    void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(target[index].transform.position);
        lastTime = Time.time;
    }
    // Update is called once per frame
    private float lastTime;
    private float curTime;

    void Update()
    {
        curTime = Time.time;
        if (navMeshAgent.remainingDistance <= 0.5f)
        {
            if (curTime - lastTime >= Random.Range(3, 6))
            {
                lastTime = curTime;
                index = Random.Range(0, 4);
            }
            navMeshAgent.SetDestination(target[index].transform.position);
        }
    }
}
