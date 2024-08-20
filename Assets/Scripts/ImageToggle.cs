using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageToggle : MonoBehaviour
{
    Image spriteRenderer;
    public Image imageToToggle; 
    private bool isImageVisible = false;
    public bool seeimage;
  


    void Start()
    {
        if (imageToToggle == null)
        {
            return;
        }
        imageToToggle.gameObject.SetActive(false);
        spriteRenderer = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isImageVisible = !isImageVisible;
            imageToToggle.gameObject.SetActive(true);
        }

        if
            (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isImageVisible = !isImageVisible;
        }
    }
}
