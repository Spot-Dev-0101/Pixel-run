using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

    public GameObject[] worldSegments;
    public GameObject[] backgrounds;
    public float segmentWidth = 16.3f;
    public GameObject player;

    public List<GameObject> currentSegments = new List<GameObject>();

	// Use this for initialization
	void Start () {
        GameObject newSegment = Instantiate(worldSegments[0], new Vector2(0, 0), Quaternion.identity);
        currentSegments.Add(newSegment);
	}
	

	// Update is called once per frame
	void Update () {
        if(player.transform.position.x > (segmentWidth*currentSegments.Count)-segmentWidth){

            int randomSegmentNumber = Random.Range(0, worldSegments.Length);
            int randomBackgroundNumber = Random.Range(0, backgrounds.Length);

            GameObject newSegment = Instantiate(worldSegments[randomSegmentNumber], new Vector2(segmentWidth * currentSegments.Count, 0), Quaternion.identity);
            Instantiate(backgrounds[randomBackgroundNumber], new Vector3(segmentWidth * currentSegments.Count, 0, -7.61f), Quaternion.identity);
            currentSegments.Add(newSegment);
        } else{
            print((player.transform.position.x) + " =-= " + ((segmentWidth * currentSegments.Count) - segmentWidth));
        }
	}
}