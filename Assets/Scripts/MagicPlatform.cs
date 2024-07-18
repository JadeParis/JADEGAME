using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPlatform : MonoBehaviour
{
    public GameObject squarePrefab;
    private GameObject squareInstance;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.LeftControl))
        {
            if (squareInstance == null)
            {
                squareInstance = Instantiate(squarePrefab, Vector3.zero, Quaternion.identity);
            }
        }
       else
        {
            if (squareInstance != null)
            {
                Destroy(squareInstance);
            }
        }
    }
}
