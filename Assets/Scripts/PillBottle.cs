using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PillBottle : MonoBehaviour
{
    public bool bottleOpen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            bottleOpen = !bottleOpen;
            SeeSpooky(bottleOpen);
        }
    }

    void SeeSpooky(bool open)
    {
        //if its open show the stuff for the visuals
        //if it's false remove them
    }
}
