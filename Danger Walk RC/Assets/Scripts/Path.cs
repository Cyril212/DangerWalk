using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

	public Color lineColor;
    
	private List<Transform> nodes;
    public GameObject car1;
    public bool isUp = false;
    Vector3 currentNode = Vector3.zero;
    Vector3 previousNode = Vector3.zero;
    void Start()
    {
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
        car1.transform.position = new Vector3(currentNode.x, currentNode.y, currentNode.z);
        }
    void Direction()
    {
        if (isUp)
        {
        
            if (nodes[0].transform.position.x < car1.transform.position.x)
                car1.transform.Translate(new Vector3(0.05f, 0, 0));
            else
                car1.transform.position = new Vector3(currentNode.x, currentNode.y, currentNode.z);
        }
        else
        {
            if (nodes[0].transform.position.x > car1.transform.position.x)
                car1.transform.Translate(new Vector3(0.05f, 0, 0));
            else
                car1.transform.position = new Vector3(currentNode.x, currentNode.y, currentNode.z);
        }
    }
    void Update()
    {
        Direction();
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
