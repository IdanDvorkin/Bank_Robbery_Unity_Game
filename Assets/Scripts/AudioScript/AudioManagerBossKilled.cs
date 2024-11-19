using System.Collections;
using UnityEngine;

public class AudioManagerBossKilled : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private int currentClipIndex = 0;
    private bool isPlaying = false;
    // public GunFire gunFire;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GunFire.bossDead && !isPlaying)
        {
            StartCoroutine(PlayAudioClipsSequentially());
        }
    }

    IEnumerator PlayAudioClipsSequentially()
    {
        isPlaying = true;

        while (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();

            yield return new WaitForSeconds(audioClips[currentClipIndex].length);

            currentClipIndex++;
        }

        currentClipIndex = 0;
        isPlaying = false;
    }
}