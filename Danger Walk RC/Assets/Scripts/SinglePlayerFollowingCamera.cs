using UnityEngine;
using System.Collections;

public class SinglePlayerFollowingCamera : MonoBehaviour {
    Camera mycam;
    public GameObject firstPlayer;
    void Start()
    {
        mycam = GetComponent<Camera>();
        //firstPlayer = GameObject.Find("PlayerOne");
    }

    // Update is called once per frame
    void Update()
    {

        // mycam.orthographicSize = (Screen.height / 100f) /4f;

        if (firstPlayer)
        {
                transform.position = new Vector3(firstPlayer.transform.position.x, firstPlayer.transform.position.y, -5f);
         
        }
    }
}
