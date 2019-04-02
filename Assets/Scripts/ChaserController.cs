using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player"){
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("Start");
        } else if(collision.gameObject.name == "enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
