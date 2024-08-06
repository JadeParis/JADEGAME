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

    private void Start()
    {
        spriteRenderer = GetComponent<Image>();
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
            spriteRenderer.sprite = openSprite;
        else
            spriteRenderer.sprite = closeSprite;
    }
}
