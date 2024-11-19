using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    CharacterController cController;
    float speed = 0,sideSpeed = 0;
    float angularSpeed = 120f;
    public GameObject aCamera; // must be defined in Unity
    private AudioSource footstep;
    // Start is called before the first frame update
    void Start()
    {
        // attaching CharacterController of player to cController
        cController = GetComponent<CharacterController>();
        footstep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // example of simplest motion
        // transform.Translate(new Vector3(0, 0, 0.1f));

        float rotationAboutY,rotationAboutX;
        // Time.deltaTime is a time between adjacent frames 
        rotationAboutY = angularSpeed*Input.GetAxis("Mouse X")*Time.deltaTime;
        rotationAboutX = -angularSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        // acts on Player (this)
        transform.Rotate(new Vector3(0, rotationAboutY, 0));

        aCamera.transform.Rotate(new Vector3(rotationAboutX, 0, 0));

        // getAxis returns -1 , 0 or +1
       speed = Input.GetAxis("Vertical");
       sideSpeed = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(0.6f * sideSpeed, -0.5f, 0.3f*speed);
        // change direction to Global coordinates
        direction = transform.TransformDirection(direction);
        cController.Move(direction); // Move gets Vector3 in Global coordinates
        if (speed != 0&& !footstep.isPlaying)
            footstep.Play();
        
    }
}
