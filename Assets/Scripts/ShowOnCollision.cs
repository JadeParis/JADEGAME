using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnCollision : MonoBehaviour
{
    public GameObject objectToShow;  // The GameObject that will be shown upon collision

    void Start()
    {
        // Ensure the object is initially hidden
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with a BoxCollider2D
        if (collision.gameObject.tag == "Player")
        {
            // Show the GameObject
            if (objectToShow != null)
            {
                objectToShow.SetActive(true);
                Debug.Log("show image");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collision is with a BoxCollider2D
        if (collision.gameObject.tag == "Player")
        {
            // Show the GameObject
            if (objectToShow != null)
            {
                objectToShow.SetActive(false);
                Debug.Log("hide image");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a BoxCollider2D
        if (collision.collider is BoxCollider2D)
        {
            // Show the GameObject
            if (objectToShow != null)
            {
                objectToShow.SetActive(true);
                Debug.Log("show image");
            }
        }
    }
}
