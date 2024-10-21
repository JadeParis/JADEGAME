using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{
    public int transformationIndex;

    public List<MonsterHealth> enemies;
    public RuntimeAnimatorController[] controllers;

    public bool isAnimating;

    public GameObject cutsceneCanvas;

    Animator currentAnim;

    private void Start()
    {
        currentAnim = GetComponent<Animator>();

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].playerTransformation = this;
        }
    }

    private void Update()
    {

    }

    public void SwapController()
    {
        currentAnim.runtimeAnimatorController = controllers[transformationIndex];
    }

    public void PlayCutscene()
    {
        Debug.Log("Play Cutscene");
        cutsceneCanvas.SetActive(true);
    }

}
