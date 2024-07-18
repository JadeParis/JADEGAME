using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // starting postition for the parallax game objects 
    Vector2 startingPostition;

    // start z value of the parallax game object 
    float startingZ;

    // distance that the camrea has moved from the starting postition of that parallax object
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPostition;

    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // the futher the obejct from the player, the faster the parallaxeffect object will move. drage its z value closer to the target to make it move slower.
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startingPostition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // when the target moves, move the parralx object the same distance times a multiplier 
        Vector2 newPosition = startingPostition + camMoveSinceStart * parallaxFactor;

        // the x/y position changes based on the target travel speed times the parallax factor, but z stays consistent
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
