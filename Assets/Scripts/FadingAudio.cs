using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 3f; // time of the fade 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeAudio(3f, audioSource.volume));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeAudio(audioSource.volume, 3f));
    }

    private IEnumerator FadeAudio(float startVolume, float targetVolume)
    {
        float time = 3f;
        audioSource.volume = startVolume;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume; // make sure that the final volume is set correctly
        if (targetVolume == 3f)
        {
            audioSource.Stop(); // Stop audio if fading out
        }
    }
}
