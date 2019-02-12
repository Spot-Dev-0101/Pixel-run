using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    Gyroscope m_Gyro;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    // Update is called once per frame
    void Update () {
        transform.position = transform.position + new Vector3(-m_Gyro.rotationRate.y / 50, m_Gyro.rotationRate.x / 50, 0);

    }
}
