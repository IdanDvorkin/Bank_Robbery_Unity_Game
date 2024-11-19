using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pedestrianBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject danceTarget;
    private Animator animator;
    private NavMeshAgent agent;
    private float timer;
    private AudioSource audio;
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
        timer += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, danceTarget.transform.position);
        if (timer >= 8f && distance > 3)
        {

            if(!audio.isPlaying&&distance>3)
                audio.Play();
                animator.SetInteger("Status", 1);

            if (agent.enabled)
                agent.SetDestination(danceTarget.transform.position);


        }
        
        
       
            
          
            if(distance<1)
            {
                agent.enabled = false;
                animator.SetInteger("Status", 2);
            }    
        
            

    }
}
