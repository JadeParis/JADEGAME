using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int health;
    //teseting
    //public GameObject parent;


    private void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    public void Damage()
    {
        //play hit animation
        health--;
    }

    public void Die()
    {
        //play animation
        //StartCoroutine(WaitForDeath());

        //testing
        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackCol");
        {
            Damage();
        }
    }

    //IEnumerator WaitForDeath()
    //{
    //   // yield return new WaitForSeconds(//aniamtion length))
    //Destroy(gameObject)w;
    //}
}
