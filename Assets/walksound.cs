using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterwalking : MonoBehaviour 
{
    [SerializeField]
    private AudioClip Monsterwalk;

    [SerializeField]
    private AudioClip MonsterwalkArray;

    public void MonsterwalkFunction()
    {
        AudioSource.PlayClipAtPoint(Monsterwalk, transform.position);
    }
}
