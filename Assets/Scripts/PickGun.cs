using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    public GameObject gunHand;
    public GameObject gunInBox;
    public GameObject Mag;
    // Start is called before the first frame update
    void Start()
    {
        Mag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gunHand.SetActive(true);
            gunInBox.SetActive(false);
            Mag.SetActive(true);

        }
    }
    

}
