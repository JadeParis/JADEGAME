using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PillBottle : MonoBehaviour
{
    Image spriteRenderer;
    public bool bottleOpen;

    public Sprite openSprite;
    public Sprite closeSprite;

    public Image okyspooky;
    public Image smoke;
    public Image smoke2;

    private void Start()
    {
        spriteRenderer = GetComponent<Image>();
        okyspooky.enabled = false;
        smoke.enabled = false;
        smoke2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            bottleOpen = !bottleOpen;
            SeeSpooky();
        }
    }

    void SeeSpooky()
    {
        if (bottleOpen)
        {
            okyspooky.enabled = true;
            smoke.enabled = true;
            smoke2.enabled = true;
            spriteRenderer.sprite = openSprite;
        }
        else
        {
            okyspooky.enabled = false;
            smoke.enabled = false;
            smoke2.enabled = false;
            spriteRenderer.sprite = closeSprite;
        }
           
    }
}
