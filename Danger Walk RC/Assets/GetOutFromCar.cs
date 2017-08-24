using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOutFromCar : MonoBehaviour {

    private GameObject cam;
    private GameObject player;
    SinglePlayerFollowingCamera gameManager; 
    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("Main Camera").GetComponent<SinglePlayerFollowingCamera>();
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<Renderer>().enabled = true;
        Debug.Log("Stop");   
        gameManager.firstPlayer = player;    
    }
}
