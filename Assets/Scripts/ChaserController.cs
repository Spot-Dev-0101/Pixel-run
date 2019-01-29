using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserController : MonoBehaviour {

    public float speed = 1;
    public WorldController wc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(speed, 0, 0));
	}
}
