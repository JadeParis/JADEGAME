using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public GameObject staticCamera;
    public GameObject currentPlayerCamera;

    private void Start()
    {
        staticCamera.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            currentPlayerCamera.SetActive(false);
            staticCamera.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            currentPlayerCamera.SetActive(true);
            staticCamera.SetActive(false);
        }

    }
}
