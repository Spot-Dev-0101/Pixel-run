using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    Gyroscope m_Gyro;
    public GameObject lightningPrefab;

    private float rotationAmount = 50;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;

        createLightning();

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            rotationAmount = 50;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            rotationAmount = 100;
        }

    }

    // Update is called once per frame
    void Update () {
        transform.position = transform.position + new Vector3(-m_Gyro.rotationRate.y / rotationAmount, m_Gyro.rotationRate.x / rotationAmount, 0);

    }

    private void createLightning(){
        Transform prev = null;
        int chance = 2;
        List<GameObject> lightningList = new List<GameObject>();
        foreach (Transform child in transform){
            if(prev != null && Random.RandomRange(0, 10) < chance){
                Vector3 origin = child.position;
                Vector3 target = prev.position;

                Vector3 direction = target - origin;
                float dist = direction.magnitude;

                GameObject lightning = Instantiate(lightningPrefab, origin + (direction / 2.0f), Quaternion.identity);

                lightning.transform.localScale = new Vector3(0.1f, 0.1f, dist);
                //lightning.transform.LookAt(target/2);
                lightning.transform.rotation = Quaternion.LookRotation(direction);
                lightningList.Add(lightning);
                //lightning.transform.SetParent(gameObject.transform);

            }
            prev = child;
        }

        foreach(GameObject lightning in lightningList){
            lightning.transform.SetParent(gameObject.transform);
        }

    }
}
