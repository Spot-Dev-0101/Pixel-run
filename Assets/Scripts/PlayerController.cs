using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject stick;
    public Transform thumbBackground;
    public GameObject thumbParent;
    public Rigidbody2D rb;
    public int JumpForce = 400;


    private bool canJump = true;

	// Use this for initialization
	void Start () {
        thumbParent.transform.position = new Vector3(Screen.width-500, 200, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount > 0){
            stick.transform.position = Input.GetTouch(0).position;

            stick.transform.position = new Vector3(stick.transform.position.x, thumbBackground.position.y, stick.transform.position.z);

            Vector3 translateVector = new Vector3(Vector2.Distance(stick.transform.position, thumbBackground.position)/1000, 0, 0);
            print(translateVector);
            if(stick.transform.position.x - thumbBackground.position.x < 0){
                translateVector = -translateVector;
            }
            transform.Translate(translateVector);


            if(Input.GetTouch(0).pressure > 1.5f && canJump == true){
                rb.AddForce(transform.up*JumpForce);
                canJump = false;
            }
            print(Input.GetTouch(0).pressure);
        } else{
            stick.transform.position = thumbBackground.position;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
