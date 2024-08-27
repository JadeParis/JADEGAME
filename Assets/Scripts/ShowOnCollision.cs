using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnCollision : MonoBehaviour
{
    public GameObject objectToShow;
    public bool pickupable; // The GameObject that will be shown upon collision
    bool canPickup;

    Health health;

    void Start()
    {
        // Ensure the object is initially hidden
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F) && canPickup && pickupable)
        {
            health.GainHealth();
            Destroy(gameObject);
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
               health = collision.GetComponent<Health>();
               canPickup = true;
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
                canPickup = false;
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
