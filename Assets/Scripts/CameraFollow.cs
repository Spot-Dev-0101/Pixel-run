using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    Gyroscope m_Gyro;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }


    private void LateUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        smoothedPosition.y = 0;
        smoothedPosition.z = -8.5f;
        transform.position = smoothedPosition;
        transform.eulerAngles = new Vector3(m_Gyro.rotationRate.x / 20, m_Gyro.rotationRate.y / 20, m_Gyro.rotationRate.z / 20);
    }
}
   