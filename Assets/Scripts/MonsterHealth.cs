using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public bool isDead;
    Animator anim;
    public int health;

    private void Start()
    {
        
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if(health <= 0 && !isDead)
        {
            Die();
            isDead = true;
        }
    }

    public void Damage()
    {
        health--;
    }

    public void Die()
    {
        if (anim != null)
        {
            anim.Play("monsterdeath");
        }
        else
        {
            Destroy(gameObject);
        }
        //anim.Play("monsterdeath");
    }

    public void DestroyEnemy()
    {
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
