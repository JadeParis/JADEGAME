using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Idle, Chasing, Attacking }
public class Monster_1 : MonoBehaviour
{
    public EnemyState currentState;

    public float distanceToChase;
    public float distanceToAttack;
    public float distanceToGiveUp;
    float distanceToPlayer;

    bool canAttack;
    float timer;
    public float cooldownTime = 3;

    MonsterHealth monsterHealth;
    float rand;

    public Health player;
    public float speed = 5;
    public bool flip;
    public GameObject AttackCol;
    public GameObject Attack2Col;
    public bool isHit;
    Animator anim;
    private Vector2 originalPosition; // Variable to store the original position


    //////////////////////////////////////////////////////////////////////////////////////// 


    void Start()
    {
        player = FindObjectOfType<Health>();
        anim = GetComponent<Animator>();
        monsterHealth = GetComponent<MonsterHealth>();  

        originalPosition = transform.position;
    }

    private void Update()
    {
        if (!monsterHealth.isDead)
        {
            distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
            HandleState();
        }

    }

    void HandleState()
    {
        switch (currentState)
        {
            case EnemyState.Idle:

                Idle();

                break;
            case EnemyState.Chasing:

                ChasePlayer();

                break;
            case EnemyState.Attacking:

                PlayAttackAnimation();

                break;
        }
    }

    public void Idle()
    {
        anim.SetBool("Walking", false);

        if (Vector2.Distance(transform.position, originalPosition) < 0.1f)
        {
            Vector2 direction = (originalPosition - (Vector2)transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            // Snap to the original position to avoid small floating point inaccuracies
            transform.position = originalPosition;
        }

        if (distanceToPlayer <= distanceToChase)
        {
            currentState = EnemyState.Chasing;
        }
    }

    public void ChasePlayer()
    {
        Vector2 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(x:speed * Time.deltaTime, y:0, z:0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1); 
            transform.Translate(x:speed * Time.deltaTime * -1, y:0, z:0);
        }

        transform.localScale = scale;

        if (distanceToPlayer <= distanceToAttack)
        {
            canAttack = true;
            currentState = EnemyState.Attacking;
        }

        if (distanceToPlayer >= distanceToGiveUp)
        {
            currentState = EnemyState.Idle;
        }

        anim.SetBool("Walking", true);
    }


    public void PlayAttackAnimation()
    {
        anim.SetBool("Walking", false);

        if (canAttack)
        {
            rand = Random.value;

            if(rand >= 0.5f)
                anim.Play("fight 1");
            else
                anim.Play("fight 2");

            canAttack = false;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= cooldownTime)
            {
                canAttack = true;
                timer = 0;
            }
        }

        if (distanceToPlayer > distanceToAttack)
        {
            Debug.Log("chasing");
            currentState = EnemyState.Chasing;
        }

        if (distanceToPlayer == distanceToAttack)
        {
            Debug.Log("chasing");
            currentState = EnemyState.Idle;
        }
    }

    public void HitPlayer()
    {
        Col1On();
        //Enable the collider here
        if(isHit)
        {
            //DamagePlayer();
        }
    }

    public void ResetCollider()
    {
        //AttackCol.SetActive(false);
        //Attack2Col.SetActive(false);
    }

    public void DamagePlayer()
    {
        player.LoseHealth(1);
        //check if die, we need to stop attacking etc
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("ishit"); 
            isHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isHit = false;
        }
    }

    //Colliders!
    public void Col1On()
    {
        AttackCol.SetActive(true);
    }

    public void Col1Off()
    {
        AttackCol.SetActive(false);
    }

    public void Col2On()
    {
        Attack2Col.SetActive(true);
    }

    public void Col2Off()
    {
        Attack2Col.SetActive(false);

    }
}


