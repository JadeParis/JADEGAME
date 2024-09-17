using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] emptyHearts; // Change from Image[] to GameObject[]

    public Image[] fullHearts;
    public Animator[] heartAnimators; // Array of animators corresponding to each heart

    void Start()
    {
        // Initialize animators if not assigned
        if (heartAnimators.Length == 0)
        {
            heartAnimators = new Animator[fullHearts.Length];
            for (int i = 0; i < fullHearts.Length; i++)
            {
                heartAnimators[i] = fullHearts[i].GetComponent<Animator>();
            }
        }
    }

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        if (heartAnimators.Length > 0)
        {
            for (int i = 0; i < heartAnimators.Length; i++)
            {
                if (i < numOfHearts)
                {
                    if (i < health)
                    {
                        emptyHearts[i].enabled = false;
                        heartAnimators[i].SetBool("IsFull", true);
                        fullHearts[i].enabled = true;
                    }
                    else
                    {
                        heartAnimators[i].SetBool("IsFull", false);
                        emptyHearts[i].enabled = true;
                        fullHearts[i].enabled = false;
                    }
                }
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
