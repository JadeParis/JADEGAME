using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_1 : MonoBehaviour
{

    public float distanceToPlayer;
    public PlayerController player;
    public float speed = 5;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
