using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject stick;
    public Transform thumbBackground;
    public Transform chaserIndicator;
    public GameObject thumbParent;
    public Rigidbody2D rb;
    public int JumpForce = 400;

    public Transform chaser;

    public Button jumpButton;

    private GameObject scoreText;

    public int score = 0;

    public float speedMulti = 1000;


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

        chaserIndicator.position = new Vector2(thumbBackground.position.x + 400 - Vector2.Distance(transform.position, chaser.position), thumbBackground.position.y);

        //scoreText.transform.position = new Vector3(525, 1, 0);
        if (transform.position.y < -15){
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("Start");
        }

        if(Input.touchCount > 0){
            if (Input.GetTouch(0).position.x > thumbBackground.position.x - 400 && Input.GetTouch(0).position.x < thumbBackground.position.x + 400)
            {
                stick.transform.position = Input.GetTouch(0).position;

                stick.transform.position = new Vector3(stick.transform.position.x, thumbBackground.position.y, stick.transform.position.z);
            }
            else
            {
                //stick.transform.position = thumbBackground.position;
                if(Input.GetTouch(0).position.x > thumbBackground.position.x)
                {
                    stick.transform.position = new Vector3(thumbBackground.position.x + 400, thumbBackground.position.y, thumbBackground.position.z);
                }

                if (Input.GetTouch(0).position.x < thumbBackground.position.x)
                {
                    stick.transform.position = new Vector3(thumbBackground.position.x - 400, thumbBackground.position.y, thumbBackground.position.z);
                }
            }

            Vector3 translateVector = new Vector3(Vector2.Distance(stick.transform.position, thumbBackground.position) / speedMulti*2, 0, 0);
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

    public void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
}
