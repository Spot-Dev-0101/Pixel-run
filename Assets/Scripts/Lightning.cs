using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
    bool enabled = false;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    // Use this for initialization
    void Start () {
        nextActionTime = Random.RandomRange(0, 10);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextActionTime)
        {

            if(Random.RandomRange(0, 10) > 6){
                nextActionTime += Random.RandomRange(5, 8);
                enabled = false;
            } else{
                nextActionTime += Random.RandomRange(0.01f, 0.1f);
                enabled = !enabled;
            }



        }
        gameObject.GetComponent<MeshRenderer>().enabled = enabled;
    }
}
