using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAnimeGirl : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < 3)
        {
            agent.enabled = false;
            animator.SetInteger("Status", 0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            
            if (agent.enabled)
                agent.SetDestination(target.transform.position);

            animator.SetInteger("Status", 1);

        }
    }
}
