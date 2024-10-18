using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnEnter : MonoBehaviour
{
    public AudioSource audioSource;
    public float maxValue;
    public float currentValue;

    [Range(0,1)]
    public float volume = 1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        maxValue = audioSource.volume;
        StartCoroutine(UpdateAudio());
    }

    IEnumerator UpdateAudio()
    {
        float actualVolume = 0;

        while (true)
        { 
            if(actualVolume < volume)
            {
                actualVolume += Time.deltaTime;
            }
            else if(actualVolume > volume)
            {
                actualVolume -= Time.deltaTime;
                if(actualVolume <= 0)
                {
                    audioSource.Stop();
                }
            }

            actualVolume = Mathf.Clamp(actualVolume, 0, 1);

            currentValue = Mathf.Lerp(0, maxValue, actualVolume);
            audioSource.volume = currentValue;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (volume == 0)
            {
                audioSource.Play();
            }
            volume = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            volume = 0;
        }
    }
}
