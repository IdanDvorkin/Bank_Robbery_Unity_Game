using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Trafficlight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject red;
    public GameObject yellow;
    public GameObject green;

    private float timer;
    private float switchTime = 15f;
    void Start()
    {
        red.SetActive(true);
        yellow.SetActive(false);
        green.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0f && timer < 5f)
        {
            green.SetActive(false);
            red.SetActive(true);
        }
        else if (timer >= 5f && timer < 8f)
        {
            yellow.SetActive(true);
        }
        else if(timer >=8f&&timer<=15f)
        {
            red.SetActive(false);
            yellow.SetActive(false);
            green.SetActive(true);
        }
        if (timer >=switchTime)
            timer = 0f;


    }

  
}

  

