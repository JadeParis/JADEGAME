using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        // CHECKING TO SEE IF THE CURRENT SCENE IS IN THE MAIN GAME SCEEN (1)
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            // STOP THE AUDIO IF ITS PLAYING
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        // CHECKING TO SEE IF THE CURRENT SCENE IS IN THE MAIN GAME SCEEN (1)
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            // STOP THE AUDIO IF ITS PLAYING
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        // CHECKING TO SEE IF THE CURRENT SCENE IS IN THE MAIN GAME SCEEN (2)
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            // STOP THE AUDIO IF ITS PLAYING
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

}
