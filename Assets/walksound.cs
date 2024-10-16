using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterwalking : MonoBehaviour 
{
    [SerializeField]
    private AudioClip Monsterwalk;
    [SerializeField]
    private AudioClip Monsterwalk2;
    [SerializeField]
    private AudioClip MonsterAttack1;
    [SerializeField] private AudioClip MonsterAttack2;
    [SerializeField] private AudioClip Monsterdied;


   [SerializeField]
    private AudioClip MonsterwalkArray;
    [SerializeField]
    private AudioClip MonsterattackArray;

    public void MonsterwalkFunction()
    {
        AudioSource.PlayClipAtPoint(Monsterwalk, transform.position);
    }
   

}
