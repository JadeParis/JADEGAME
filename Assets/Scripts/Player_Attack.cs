using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public GameObject collider;

    public void TurnColOn()
    {
        collider.SetActive(true);
    }

    public void TurnColOff()
    {
        collider.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //enemyhealth--;
        }
    }
}
