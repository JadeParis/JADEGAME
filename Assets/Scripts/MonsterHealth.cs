using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public bool isDead;
    Animator anim;
    public int health;

    [HideInInspector] public PlayerTransformation playerTransformation;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if(health <= 0 && !isDead)
        {
            Die();
            
        }
    }

    public void Damage()
    {
        if (!isDead)
        {
            health--;
        }

    }

    public void Die()
    {
        if (anim != null)
        {
            anim.Play("monsterdeath");
            isDead = true;

            playerTransformation.transformationIndex++;

            if (playerTransformation.transformationIndex == 1)
            {
                playerTransformation.PlayCutscene();
                //Replace this line with whatever plays the transformation cutscehene
            }


            playerTransformation.SwapController();
            playerTransformation.enemies.Remove(this);

            //play first cutscene

            StartCoroutine(killHim());
        }

        //anim.Play("monsterdeath");
    }

    IEnumerator killHim()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public void DestroyEnemy()
    {
        Debug.Log("Plz Die");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackCol")
        {
            Damage();
        }
    }
   
}
