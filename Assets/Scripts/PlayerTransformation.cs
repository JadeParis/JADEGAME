using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{
    public int transformationIndex;

    public List<MonsterHealth> enemies;
    public RuntimeAnimatorController[] controllers;

    public bool isAnimating;

    public GameObject cutsceneCanvas;
    public Animation cutsceneAnimation;

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
        if (isAnimating)
        {
            if (!cutsceneAnimation.isPlaying)
            {
                SwapController();
                cutsceneCanvas.SetActive(false);
                isAnimating = false;
            }
        }
    }

    public void SwapController()
    {
        currentAnim.runtimeAnimatorController = controllers[transformationIndex];
    }

    public void PlayCutscene()
    {
        cutsceneCanvas.SetActive(true);
        cutsceneAnimation.Play();
        isAnimating = true;
    }

}
