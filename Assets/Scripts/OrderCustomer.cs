using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class OrderCustomer : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
    public GameObject TrayInHand;
    public GameObject TrayOnTable;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
        agent.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance ==3)
        {
            animator.SetInteger("Status", 2);
            TrayOnTable.SetActive(true);
            TrayInHand.SetActive(false);
            
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            audio.Play();
            animator.SetInteger("Status", 1);
            if (agent.enabled)
                agent.SetDestination(target.transform.position);
        }
    }
}
