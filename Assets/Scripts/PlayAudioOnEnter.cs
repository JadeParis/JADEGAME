using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnEnter : MonoBehaviour
{
    public FadingAudio fadingAudio;
    public AudioSource audioSource;
    public float maxValue;

    [Range(0,1)]
    public float volume = 1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fadingAudio = GetComponent<FadingAudio>();
        maxValue = audioSource.volume;
    }

    private void Update()
    {
        UpdateAudio();
    }

    void UpdateAudio()
    {
        float currentValue = Mathf.Lerp(0, maxValue, volume);
        audioSource.volume = currentValue;
        fadingAudio.audioSource.volume = currentValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
            fadingAudio.FadeIn(); // Start fading in the audio
            fadingAudio.audioSource.Play(); // Play audio
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Stop(); // Stop the audio when the player exits
            fadingAudio.FadeOut(); // Start fading out the audio
        }
    }
}
