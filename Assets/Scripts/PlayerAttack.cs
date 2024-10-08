using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackCol;
    public GameObject Attack2Col;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }


    public void Col1On()
    {
        AttackCol.SetActive(true);
    }

    public void Col1Off()
    {
        Debug.Log("whaaa");
        AttackCol.SetActive(false);
        animator.ResetTrigger("Attack_2");

    }

    public void Col2On()
    {
        Attack2Col.SetActive(true);
    }

    public void Col2Off()
    {
        Attack2Col.SetActive(false);
        animator.ResetTrigger("Attack_2");

    }
}
