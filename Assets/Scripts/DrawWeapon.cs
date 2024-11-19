using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWeapon : MonoBehaviour
{
    public GameObject gunHand;
    private bool flag = false;
    public GameObject ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo.SetActive(flag);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gunHand.SetActive(!flag);
            ammo.SetActive(!flag);
            flag = !flag;
            

        }
    }


}
