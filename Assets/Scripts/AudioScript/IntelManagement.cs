using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelManagement : MonoBehaviour
{
    public AudioClip[] audioClips;
    private int currentClipIndex;
    public static int activatedObjectsCount ;

    private AudioSource audioSource;

    private void Start()
    {
        activatedObjectsCount = 0;
        currentClipIndex = -1;
        audioSource = GetComponent<AudioSource>();
        PlayNextClip();
    }

    public void PlayNextClip()
    {
        if (activatedObjectsCount < audioClips.Length)
        {
            currentClipIndex++;
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            activatedObjectsCount++;

            StartCoroutine(WaitForClipCompletion());
        }
        else
        {
            audioSource.Stop();
        }
    }

    private IEnumerator WaitForClipCompletion()
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);
        PlayNextClip();
    }
}
