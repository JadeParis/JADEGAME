using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine.Editor;

public class CameraZoom : MonoBehaviour
{
    public GameObject staticCamera;
    public GameObject currentPlayerCamera;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Player has arrived!");
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
