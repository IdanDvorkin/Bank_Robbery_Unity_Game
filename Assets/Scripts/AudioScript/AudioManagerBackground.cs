using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AudioManagerBackground : MonoBehaviour
{
    public AudioClip[] audioClips;
    public float clipDelay = 0.1f; // Time delay between audio clips
    private int currentClipIndex = 0;
    private AudioSource audioSource;

    // Reference to the SceneTransition GameObject

    public UnityEvent OnAudioClipComplete; // Event to trigger when an audio clip finishes playing

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false; // Ensure the audio source does not loop the audio clips
        audioSource.playOnAwake = false; // Disable play on awake to avoid unwanted audio playback
        PlayNextClip();
    }

    private void PlayNextClip()
    {
        if (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            Debug.Log("clip number " + currentClipIndex);
            audioSource.Play();
            StartCoroutine(WaitForClipCompletion());
        }
    }

    private IEnumerator WaitForClipCompletion()
    {
        yield return new WaitForSeconds(audioSource.clip.length + clipDelay);
        // The audio clip has finished playing, invoke the event
        OnAudioClipComplete.Invoke();
        currentClipIndex++;
        PlayNextClip(); // Play the next audio clip
    }
}