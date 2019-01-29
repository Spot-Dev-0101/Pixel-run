using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        smoothedPosition.y = 0;
        transform.position = smoothedPosition;
    }
}
