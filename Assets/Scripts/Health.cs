using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public bool isDead;
    Animator anim;
    public int health;
    public int numOfHearts;
    private SpriteRenderer spriteRenderer;

    public Image[] emptyHearts; // Change from Image[] to GameObject[]

    public Image[] fullHearts;
    public Animator[] heartAnimators; // Array of animators corresponding to each heart

    [SerializeField] GameObject DeathUI;
    [SerializeField] float delayBeforeDeathUI = 2f; // Delay before showing death UI in seconds


    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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

        //if health 0
        //cutscene, wait til finished (?) - use transformation script for referencwe 
        //restartt / reload scene
        //SceneManager.LoadScene("name of scene");
        // Ensure health does not go below 0 and check if the monster is dead
       
        health = Mathf.Clamp(health, 0, int.MaxValue);

        if (health <= 0 && !isDead)
        {
            Die();
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
   
    public void Damage()
    {
        if (!isDead)
        {
            health--;
            health = Mathf.Clamp(health, 0, int.MaxValue);
            if (health <= 0)
            {
                Die();
            }
        }

    }
    public void Die()
    {
        if (anim != null && !isDead)
        {
            Debug.Log("Die() called. Starting death animation.");
            anim.SetBool("die", true);
            // Start the coroutine to delay the death UI
            StartCoroutine(ShowDeathUIAfterDelay());
            isDead = true;

        }
    }
    // Coroutine to delay the showing of the Death UI
    IEnumerator ShowDeathUIAfterDelay()
    {
        Debug.Log("Coroutine started. Waiting for " + delayBeforeDeathUI + " seconds.");
        // Wait for the delay
        yield return new WaitForSeconds(delayBeforeDeathUI);

        // Check if DeathUI is assigned
        if (DeathUI != null)
        {
            Debug.Log("Displaying Death UI.");
            // Show the death UI after the delay
            DeathUI.SetActive(true);
        }
        else
        {
            Debug.LogError("DeathUI GameObject is not assigned!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ouch")
        {
            Damage();
        }
    }
}


