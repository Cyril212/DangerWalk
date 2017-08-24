using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

	public Color lineColor;
    private Transform playerTransform;
    private List<Transform> nodes;
    public GameObject[] car1;
    private GameObject currentCar;
    private List<GameObject> carTodelete = new List<GameObject>();
    private int index = 0;
    public bool isUp = false;
    Vector3 currentNode = Vector3.zero;
    Vector3 previousNode = Vector3.zero;
    void setNewCar()
    {
        index = Random.Range(0, car1.Length);
        //currentCar = Instantiate(car1[index]) as GameObject;
        if (isUp)
            currentCar.transform.rotation = new Quaternion(0, 0, 180, 0);
        else
            currentCar.transform.rotation = new Quaternion(0, 0, 0, 0);

    //    carTodelete.Add(currentCar);
    }
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //car1 = GameObject.Find("car1");
        // car1 = GetComponent<GameObject>();
        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        //List<Transform> pathTransform = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        
        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }
        for (int i = 0; i < nodes.Count; i++)
        {
            currentNode = nodes[i].position;
            
            if (i > 0)
            {
                previousNode = nodes[i - 1].position;
            }
            else if (i == 0 && nodes.Count > 1)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }
        }
        index = Random.Range(0, car1.Length);
        currentCar = Instantiate(car1[index]) as GameObject;
        currentCar.transform.position = new Vector3(previousNode.x, previousNode.y, previousNode.z);
       

    }
    void Direction()
    {
        if (currentCar != null)
        {
            if (isUp)
            {
                if (nodes[0].transform.position.x < currentCar.transform.position.x)
                    currentCar.transform.Translate(new Vector3(0.05f, 0, 0));
                else
                {
                    setNewCar();
                    currentCar.transform.position = new Vector3(currentNode.x, currentNode.y, currentNode.z);

                }
            }
            else
            {
                if (nodes[0].transform.position.x > currentCar.transform.position.x)
                {
                    currentCar.transform.Translate(new Vector3(0.05f, 0, 0));
                }
                else
                {
                    setNewCar();
                    currentCar.transform.position = new Vector3(currentNode.x, currentNode.y, currentNode.z);
                    // setNewCar();
                }
            }

        }
    }
    void Update()
    {
        Direction();
         if(GameObject.FindGameObjectsWithTag("Car").Length > 10)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Car")[GameObject.FindGameObjectsWithTag("Car").Length - 7]);
        }
       // Debug.Log(GameObject.FindGameObjectsWithTag("Car").Length);
    }
	void OnDrawGizmosSelected()
	{
		Gizmos.color = lineColor;

        Transform[] pathTransform = GetComponentsInChildren<Transform>();
		//List<Transform> pathTransform = GetComponentsInChildren<Transform>();
		nodes = new List<Transform>(); 
        
        for(int i = 0; i<pathTransform.Length; i++)
        {
            if(pathTransform[i] != transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }
        for(int i = 0; i < nodes.Count;i++)
        {
            Vector3 currentNode = nodes[i].position;
            Vector3 previousNode = Vector3.zero;
            if (i > 0)
            {
                previousNode = nodes[i - 1].position;
            }
            else if(i == 0 && nodes.Count > 1)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }
            // Debug.Log(previousNode - currentNode);

            
            
            Gizmos.DrawLine(previousNode, currentNode);
        }

	}

}
