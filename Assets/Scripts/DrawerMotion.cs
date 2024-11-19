using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject originalCrossHair;
    public GameObject touchCrossHair;
    public Text drawerText;
    public GameObject chest;
    private Animator animator;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        animator = chest.GetComponent<Animator>();
        audio = chest.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; // has info about hitted object
        if(Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
        {
            //checking if hitted object is this object ( drawer for example)
            if (hit.transform.gameObject == this.gameObject)
            {
                originalCrossHair.SetActive(false);
                touchCrossHair.SetActive(true);
                drawerText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))//opening
                {

                    animator.SetBool("Status", true);
                    audio.Play();

                }
                if (Input.GetKeyDown(KeyCode.C))//closing
                {
                    animator.SetBool("Status", false);
                    audio.Play();
                }
            }
            else
            {
                originalCrossHair.SetActive(true);
                touchCrossHair.SetActive(false);
                drawerText.gameObject.SetActive(false);
               
            }
        }
    }
}
