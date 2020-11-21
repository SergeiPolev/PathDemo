using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public Vector3 offset;

    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = player.transform.position + offset;

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
