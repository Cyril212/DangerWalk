using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour {
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnY = 0.0f;
    private float tileLength = 2.0f;
    private int amnTilesOnScreen = 3;
    private float safeZone = 2.5f;
    private int number = 0;
    private List<GameObject> activeTiles = new List<GameObject>();
	// Use this for initialization
	void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
            
        }
	}
	private void SpawnTile(int prefabIndex = -1)
    {      
        GameObject go;        
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(-1.25f, spawnY,tilePrefabs[0].transform.position.z);
        
        spawnY += tileLength;
        activeTiles.Add(go);     
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.y - safeZone > (spawnY - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}
}
