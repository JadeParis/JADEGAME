using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    int direction = 1;
    public AnimationCurve animationCurve;
    float t;
    Vector3 startPos;

    private void Start()
    {
        startPos = platform.position;
    }

    private void Update()
    {
        Vector2 target = currentMovementTarget();
        t += speed * Time.deltaTime;

        platform.position = Vector2.Lerp(startPos, target, animationCurve.Evaluate(t));

        float distance = (target - (Vector2)platform.position).magnitude;

        if (t >= 1)
        {
            t = 0;
            direction *= -1;
            startPos = platform.position;
        }
    }

    Vector2 currentMovementTarget()
    {


        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (platform!=null && startPoint!=null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }

}
