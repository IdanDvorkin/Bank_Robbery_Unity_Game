using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class GetInVault : MonoBehaviour
{
    public GameObject bomb;
    public GameObject ticking;
    public GameObject boom;
    public GameObject vaultLocation;
    public GameObject player;
    public GameObject vault;
    NavMeshAgent agent;
    Animator animator;
    bool flag=true;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(agent.transform.position, vaultLocation.transform.position);
        if (distance <= 5&&flag)
        {
            agent.enabled = false;
            agent.enabled = true;
            flag = false;
            animator.SetInteger("Status", 2);
            bomb.SetActive(true);
            ticking.GetComponent<AudioSource>().Play();
            StartCoroutine(Plant());
            StartCoroutine(BombT());


        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetInteger("Status", 1);
            agent.SetDestination(vaultLocation.transform.position);
            



        }
    }
    IEnumerator Plant()
    {
        yield return new WaitForSeconds(1.0f);
        agent.speed = 20;
        animator.SetInteger("Status", 1);
        agent.SetDestination(player.transform.position);

    }
    IEnumerator BombT()
    {

        StartCoroutine(Turn());
       
        yield return new WaitForSeconds(3.3f);
        agent.enabled = true;
        animator.SetInteger("Status", 3);
        agent.enabled = false;
        boom.GetComponent<AudioSource>().Play();
        vault.SetActive(false);
        bomb.SetActive(false);
        

    }
    IEnumerator Turn()
    {
        yield return new WaitForSeconds(2.9f);

        transform.Rotate(0, 180, 0);
        agent.enabled = false;
    }
}
