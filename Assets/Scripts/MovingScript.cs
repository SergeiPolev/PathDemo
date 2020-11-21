using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public Vector3 targetPoint;
    Vector3 startingPoint;
    Vector3 currentTargetPoint;

    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3f;
    private void Start()
    {
        startingPoint = transform.localPosition;
        currentTargetPoint = targetPoint;
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.localPosition, currentTargetPoint) >= 0.1f)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, currentTargetPoint, ref velocity, smoothTime);
        }
        else
        {
            currentTargetPoint = (currentTargetPoint == targetPoint ? startingPoint : targetPoint);
        }
    }
}
