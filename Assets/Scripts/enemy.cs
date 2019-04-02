using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemy : MonoBehaviour {

    public float moveDirection = 1; // 1 = right -1 = left

	// Use this for initialization
	void Start () {
        if(Random.RandomRange(-1, 1) < 0){
            moveDirection = -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(moveDirection/50, 0));

        Debug.DrawRay(transform.position + new Vector3(0.6f, 0, 0), Vector2.down, Color.green);
        Debug.DrawRay(transform.position + new Vector3(-0.6f, 0, 0), Vector2.down, Color.green);

        if(!Physics2D.Raycast(transform.position + new Vector3(0.6f, 0, 0), Vector2.down, 2))
        {
            moveDirection = -1;
            //print("moveDirection = -1");
        }
        if (!Physics2D.Raycast(transform.position + new Vector3(-0.6f, 0, 0), Vector2.down, 2))
        {
            moveDirection = 1;
           //print("moveDirection = 1");
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player"){
            //Destroy(collision.gameObject);
            SceneManager.LoadScene("Start");
        }
    }
}
