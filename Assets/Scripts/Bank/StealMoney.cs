using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StealMoney : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject money;
    public GameObject before;
    public GameObject after;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            before.SetActive(false);
            after.SetActive(true);
            money.SetActive(false);
        }
            


        
    }
}
