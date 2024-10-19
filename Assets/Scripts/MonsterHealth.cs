using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public bool isDead;
    Animator anim;
    public int health;
    public bool finalBoss;
    private GameObject gameEndUI;

    [HideInInspector] public PlayerTransformation playerTransformation;

    private Collider2D monsterCollider;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    public GameObject hitPrefab;
    public Transform partPos;

    private void Start()
    {
        anim = GetComponent<Animator>();
        monsterCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (finalBoss)
        {
            gameEndUI = GameObject.Find("When Monster is dead");
            gameEndUI.SetActive(false);
        }
      
    }


    private void Update()
    {
        // Ensure health does not go below 0 and check if the monster is dead
        health = Mathf.Clamp(health, 0, int.MaxValue);

        if (health <= 0 && !isDead)
        {
            Die();
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

            Instantiate(hitPrefab, partPos.transform.position, partPos.transform.rotation);
        }

    }

    public void Die()
    {

        if (finalBoss)
        {
            gameEndUI.SetActive(true);
        }

        if (anim != null && !isDead)
        {
            isDead = true;
            anim.SetBool("die", true);

            if (monsterCollider != null) monsterCollider.enabled = false;

            if (playerTransformation != null)
            {
                playerTransformation.transformationIndex++;

                if (playerTransformation.transformationIndex == 1)
                {
                    playerTransformation.PlayCutscene();
                }
            }
        }
    
        else if (anim == null)
        {
            Debug.LogError("Why the fuck are you not animating!");
        }

    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead && collision.gameObject.tag == "AttackCol")
        {
            Damage();
        }
    }
  
}
   
