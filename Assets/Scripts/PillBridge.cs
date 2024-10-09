using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBridge : MonoBehaviour
{
    public PillBottle pillBottle;
    //gameobject ref to your platform

    public bool platformsActive;
    public GameObject platform;

    private void Start()
    {
      //  platform.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (pillBottle.bottleOpen)
            {
                if (!platformsActive)
                    ActivatePlatforms(true);
            }
            else
            {
                if(platformsActive)
                    ActivatePlatforms(false);
            }
        }
       
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        //if platforms are active
    //        //deactivate them
    //    }
    //}

    void ActivatePlatforms(bool active)
    {
        platform.SetActive(active);
        platformsActive = active;
    }
}
