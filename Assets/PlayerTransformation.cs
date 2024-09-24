using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{
    public int transformationIndex;

    public List<MonsterHealth> enemies;
    public RuntimeAnimatorController[] controllers;

    Animator currentAnim;

    private void Start()
    {
        currentAnim = GetComponent<Animator>();

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].playerTransformation = this;
        }
    }

    public void SwapController()
    {
        currentAnim.runtimeAnimatorController = controllers[transformationIndex];
    }

    public void PlayCutscene()
    {
        //show image???????????????
    }

}
