using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterwalking : MonoBehaviour
{
    [SerializeField] private AudioClip Monsterwalk;
    [SerializeField] private AudioClip MonsterAttack1;
    [SerializeField] private AudioClip MonsterAttack2;
    [SerializeField] private AudioClip Monsterdied;


    [SerializeField] private AudioClip MonsterwalkArray;
    [SerializeField] private AudioClip MonsterAttack1Array;
    [SerializeField] private AudioClip MonsterAttack2Array;
    [SerializeField] private AudioClip MonsterdiedArray;

    
    public void MonsterwalkFunction()
    {
        AudioSource.PlayClipAtPoint(Monsterwalk, transform.position);

    }

    public void MonsterAttack1Function()
    {
        AudioSource.PlayClipAtPoint(MonsterAttack1, transform.position);

    }

    public void MonsterAttack2Function()
    {
        AudioSource.PlayClipAtPoint(MonsterAttack2, transform.position);

    }

    public void MonsterdiedFunction()
    {
        AudioSource.PlayClipAtPoint(Monsterdied, transform.position);

    }
}
