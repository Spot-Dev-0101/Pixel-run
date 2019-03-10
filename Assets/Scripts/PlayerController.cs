using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject stick;
    public Transform thumbBackground;
    public GameObject thumbParent;
    public Rigidbody2D rb;
    public int JumpForce = 400;

    public Button jumpButton;

    private GameObject scoreText;

    public int score = 0;

    private float speedMulti = 1000;


    private bool canJump = true;

	// Use this for initialization
	void Start () {
        //thumbParent.transform.position = new Vector3(Screen.width - 750, 200, 0);
        jumpButton.transform.position = new Vector3(500, 200, 0);
        scoreText = GameObject.Find("ScoreText");
        jumpButton.onClick.AddListener(setJumpToTrue);

        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            jumpButton.gameObject.SetActive(false);
            thumbParent.transform.position = new Vector3(Screen.width - 500, 200, 0);
        } else if(Application.platform == RuntimePlatform.Android)
        {
            speedMulti = 3000;
            thumbParent.transform.position = new Vector3(Screen.width - 750, 200, 0);
        }

        //scoreText.transform.position = new Vector3(Screen.width - 500, 200, 0);
        //scoreText.transform.position = new Vector3(525, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.GetComponent<Text>().text = "Score: " + score;
        //scoreText.transform.position = new Vector3(525, 1, 0);
        if (transform.position.y < -15){
            Application.LoadLevel(Application.loadedLevel);
        }

        if(Input.touchCount > 0){
            if (Input.GetTouch(0).position.x > 0)
            {
                stick.transform.position = Input.GetTouch(0).position;

                stick.transform.position = new Vector3(stick.transform.position.x, thumbBackground.position.y, stick.transform.position.z);

                Vector3 translateVector = new Vector3(Vector2.Distance(stick.transform.position, thumbBackground.position) / speedMulti, 0, 0);
                print(translateVector);
                if (stick.transform.position.x - thumbBackground.position.x < 0)
                {
                    translateVector = -translateVector;
                }
                transform.Translate(translateVector);


                if (Input.GetTouch(0).pressure > 1.5f && canJump == true)
                {
                    rb.AddForce(transform.up * JumpForce);
                    canJump = false;
                }
                print(Input.GetTouch(0).pressure);
            }
        } else{
            stick.transform.position = thumbBackground.position;
        }

    }

    void setJumpToTrue(){
        if (canJump == true)
        {
            rb.AddForce(transform.up * JumpForce);
            canJump = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
