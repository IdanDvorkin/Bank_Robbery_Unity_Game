using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalObjectManager : MonoBehaviour
{

   static private GlobalObjectManager instance;
    private string objectID;
    private void Awake()
    {
        objectID= name+transform.position.ToString();
    }
    // public static int gold; remove green after adding gold to project

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < Object.FindObjectsOfType<GlobalObjectManager>().Length; i++)
        {
            if (Object.FindObjectsOfType<GlobalObjectManager>()[i] != this)
            {
                if (Object.FindObjectsOfType<GlobalObjectManager>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        if (instance == null)
        {
            instance = this;
            //  gold = 0; remove green after adding gold to project
            DontDestroyOnLoad(gameObject); //preserver the original object
        }
            
        else
            Destroy(this.gameObject);

        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
