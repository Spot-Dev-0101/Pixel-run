using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {

    public Button startButton;

	// Use this for initialization
	void Start () {
        startButton.onClick.AddListener(startGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void startGame(){
        SceneManager.LoadScene("TestPlatformer");
    }
}
