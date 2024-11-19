using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    AudioSource DoorOpen;
    AudioSource DoorClose;
     public GameObject closeSound;
    void Start()
    {
        animator = GetComponent<Animator>();
        DoorOpen= GetComponent<AudioSource>();
        DoorClose =closeSound.GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider other)
    {
        
        animator.SetBool("OpenDoor",true);
        DoorOpen.PlayDelayed(0.3f);
    }
    public void OnTriggerExit(Collider other)
    {
       
        animator.SetBool("OpenDoor", false);
        DoorClose.PlayDelayed(2f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
