using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterwalking : MonoBehaviour
{
    public GameObject SFXPrefab;


    [SerializeField] private AudioClip Monsterwalk;
    [SerializeField] private AudioClip MonsterAttack1;
    [SerializeField] private AudioClip MonsterAttack2;
    [SerializeField] private AudioClip Monsterdied;
    [SerializeField] private AudioClip Monsterjump;


    [SerializeField] private AudioClip MonsterwalkArray;
    [SerializeField] private AudioClip MonsterAttack1Array;
    [SerializeField] private AudioClip MonsterAttack2Array;
    [SerializeField] private AudioClip MonsterdiedArray;
    [SerializeField] private AudioClip MonsterjumpArray;


    public void PlayAudio(GameObject obj, AudioClip clip)
    {
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(obj, audioSource.clip.length);
    }

    public void MonsterwalkFunction()
    {
        GameObject obj = Instantiate(SFXPrefab);
        PlayAudio(obj, Monsterwalk);
    }

    public void MonsterAttack1Function()
    {
        GameObject obj = Instantiate(SFXPrefab);
        PlayAudio(obj, MonsterAttack1);

    }

    public void MonsterAttack2Function()
    {
        GameObject obj = Instantiate(SFXPrefab);
        PlayAudio(obj, MonsterAttack2);
    }

    public void MonsterdiedFunction()
    {
        GameObject obj = Instantiate(SFXPrefab);
        PlayAudio(obj, Monsterdied);
    }

    public void MonsterjumpFunction()
    {
        GameObject obj = Instantiate(SFXPrefab);
        PlayAudio(obj, Monsterjump);
    }
}
