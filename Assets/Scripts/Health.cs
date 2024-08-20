using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public GameObject[] hearts; // Change from Image[] to GameObject[]
    public Animator[] heartAnimators; // Array of animators corresponding to each heart

    void Start()
    {
        // Initialize animators if not assigned
        if (heartAnimators.Length == 0)
        {
            heartAnimators = new Animator[hearts.Length];
            for (int i = 0; i < hearts.Length; i++)
            {
                heartAnimators[i] = hearts[i].GetComponent<Animator>();
            }
        }
    }

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].SetActive(true);
                Animator animator = heartAnimators[i];
                if (i < health)
                {
                    animator.SetBool("IsFull", true);
                }
                else
                {
                    animator.SetBool("IsFull", false);
                }
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    public void GainHealth()
    {
        if (health < numOfHearts)
        {
            health++;
        }
    }

    public void LoseHealth(int v)
    {
        if (health > 0)
        {
            health -= v;
        }
    }
}
