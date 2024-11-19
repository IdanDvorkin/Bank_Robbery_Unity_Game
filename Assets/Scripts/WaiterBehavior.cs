using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaiterBehavior : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
    public GameObject starting;
    public GameObject TrayInHand;
    public GameObject TrayOnTable;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position,target.transform.position);
        if(distance < 6)
        {
            TrayOnTable.SetActive(true);
            TrayInHand.SetActive(false);
            agent.SetDestination(starting.transform.position);


        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetInteger("Status", 1);
            if (agent.enabled)
                agent.SetDestination(target.transform.position);      
        }
     
        

    }
}
