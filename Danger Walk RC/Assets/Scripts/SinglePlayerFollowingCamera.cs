using UnityEngine;
using System.Collections;

public class SinglePlayerFollowingCamera : MonoBehaviour {
    Camera mycam;
    public GameObject firstPlayer;
    float yAxisAccelerate = 0.0f;
    bool isPlayer = false; 
    void Start()
    {
        yAxisAccelerate = firstPlayer.transform.position.y;
        mycam = GetComponent<Camera>();
        //firstPlayer = GameObject.Find("PlayerOne");
    }

    // Update is called once per frame
    void Update()
    {

        // mycam.orthographicSize = (Screen.height / 100f) /4f;

        if (firstPlayer.name == "Player")
        {
            transform.position = new Vector3(firstPlayer.transform.position.x, yAxisAccelerate, -5f);
            yAxisAccelerate += 0.025f;
        }
        else
        {
            transform.position = new Vector3(firstPlayer.transform.position.x, firstPlayer.transform.position.y, -5f);
        }
    }
}
