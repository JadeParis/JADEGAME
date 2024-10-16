using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walksound : MonoBehaviour
{
    [SerializeField]
    private AudioClip WalkingSound;


    [SerializeField]
    private AudioClip WalkingSoundArray;

    public void WalkingSoundFunction1()
    {
        AudioSource.PlayClipAtPoint(WalkingSound, transform.position);
    }
}
