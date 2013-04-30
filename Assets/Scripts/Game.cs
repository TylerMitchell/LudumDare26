using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public GameObject[] nodes;
	public GameObject[] cars;
	public int numCars = 0;
	//public GameObject start;
	// Use this for initialization
	void Start () {
		//gather all objects tagged pathnode
		nodes = GameObject.FindGameObjectsWithTag("PathNode");
		cars = GameObject.FindGameObjectsWithTag("car");
		numCars = cars.Length;
		foreach(var node in nodes){ 
			var nodeScript = node.GetComponent<PathNode>();
			/*if( nodeScript.type == "Begin" ){ 
				start = node; 
			} */
			nodeScript.CalcDirs();
		}
		//PutAtStart( GameObject.Find("car") );
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	/*public void PutAtStart(GameObject go){
		go.transform.position = start.transform.position;
		
	}*/
	public void PutAtNode(CarLogic go, PathNode start){
		go.transform.position = start.transform.position;
		go.rigidbody.velocity = start.next.transform.position - go.transform.position;
	}
	
	public void addCar(){
			
	}
}

//mountNodes where cars can be spawned
//hashtable of nodes connected to a given node
