using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorScript : MonoBehaviour
{
    public Vector3 rotationSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(rotationSpeed, Space.World);
    }
}
