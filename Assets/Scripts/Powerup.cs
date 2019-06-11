using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public string type = "speed";
    public bool active = false;
    public float countDown = 0;
    public float maxCountdown = 10;
    public PlayerController player;
    public RectTransform powerupIndicator;
    float maxIndicatorWidth = 800;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player").GetComponent<PlayerController>();
        powerupIndicator = GameObject.Find("powerupCountdown").GetComponent<RectTransform>();

        float randInt = Random.RandomRange(0, 100);

        if(randInt >= 50){
            type = "jump";
        }
        //maxIndicatorWidth = powerupIndicator.sizeDelta.x;
        countDown = maxCountdown;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(active == true){
            countDown -= Time.deltaTime;
            float width = maxIndicatorWidth / (maxCountdown / countDown);
            //print(maxIndicatorWidth + " / " + "(" + maxCountdown + "/" + countDown + ") = " + width);
            powerupIndicator.sizeDelta = new Vector2(width, powerupIndicator.sizeDelta.y);
            //print(countDown);
        }

        if(countDown <= 0){
            powerupIndicator.sizeDelta = new Vector2(0, powerupIndicator.sizeDelta.y);
            if (type == "speed")
            {
                player.speedMulti = 1000;
            }
            if (type == "jump")
            {
                player.JumpForce = 400;
            }

            Destroy(gameObject);

        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (type == "speed")
            {
                player.speedMulti = 1100;
                active = true;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
            }
            if (type == "jump")
            {
                player.JumpForce = 600;
                active = true;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
            }

            //print("triggered");
        }
    }


}
