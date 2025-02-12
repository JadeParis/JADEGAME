using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PillBottle : MonoBehaviour
{
    //public float time;
    float timer;

    Image spriteRenderer;
    public bool bottleOpen;
    public bool canOpen;

    public Sprite openSprite;
    public Sprite closeSprite;

    public Image okyspooky;

    public AudioSource interact;
    public AudioSource closeinteract;


    private void Start()
    {
        spriteRenderer = GetComponent<Image>();
        okyspooky.enabled = false;
        canOpen = false;
        bottleOpen = false;
        timer = 0;
        //time = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            // toggle bottle open/close
            bottleOpen = !bottleOpen;

            // player closed bottle
            if (!bottleOpen)
            {
                canOpen = false;
                timer = 0;
                SeeSpooky();
                closeinteract.Play();

            }
            // player opens bottle
            if (bottleOpen && canOpen)
            {
                SeeSpooky();
                interact.Play();
            }
            // player opened bottle but they shouldn't yet
            if (bottleOpen && !canOpen)
            {
                bottleOpen = false;
            }
          
        }
    }

    private void FixedUpdate()
    {
        //start timer when bottle is just opened
        //at end of timer set bottle open to false
        if (bottleOpen)
        {
            timer += Time.deltaTime;
            if (timer > 15f)
            {
                // close bottle
                bottleOpen = false;
                SeeSpooky();
                timer = 0;
                closeinteract.Play();
            }
        }
        // start timer when bottle is just closed
        else if (!bottleOpen && !canOpen)
        {
            timer += Time.deltaTime;
            if (timer > 2f)
            {
                canOpen = true;
                timer = 0;
            }
        }
    }

    void SeeSpooky()
    {
        if (bottleOpen)
        {
            okyspooky.enabled = true;
            spriteRenderer.sprite = openSprite;
        }
        else
        {
            okyspooky.enabled = false;
            spriteRenderer.sprite = closeSprite;
        }
           
    }
}
