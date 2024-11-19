using System.Collections;
using UnityEngine;

public class IntelActivation : MonoBehaviour
{
    private bool vaultHasActivated;
    private bool nextSectionAudio;
    public IntelManagement intelManagement;


    private void Start()
    {
        vaultHasActivated = false;
        nextSectionAudio = false;
    }

    private void Update()
    {
        if (!vaultHasActivated)
        {
            vaultHasActivated = true;
        }
        if (vaultHasActivated && !nextSectionAudio)
        {
            nextSectionAudio = true;
        }
    }
}
