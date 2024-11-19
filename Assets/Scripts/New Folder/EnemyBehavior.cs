 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            agent.enabled = true;
            animator.SetInteger("Status", 1);
        }
        if (agent.enabled)
        {
            agent.SetDestination(target.transform.position);
        }
       
    }
}
