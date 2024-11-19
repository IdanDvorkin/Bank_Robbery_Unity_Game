using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator Animator;
    public GameObject player;
    private NavMeshAgent agent;
    void Start()
    {
        Animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (Input.GetKeyDown(KeyCode.F))
        {

            Animator.SetBool("Status", true);
            agent.SetDestination(player.transform.position);

        }
    }
}
