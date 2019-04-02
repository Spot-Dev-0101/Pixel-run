using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    private Animation anim;
    private bool started = false;

    private PlayerController pc;

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();

        anim = gameObject.GetComponent<Animation>();
        //Physics.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
    }

    // Update is called once per frame
    void Update () {



        if(started == true){
            if(anim.isPlaying == false){
                Destroy(gameObject);
            }
        }
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //the coin has been hit. Trigger annimation, add score then destroy
        //anim.Play();
        //started = true;
        //Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player"){
            anim.Play();
            started = true;
            pc.score += 1;
        }


    }

}
