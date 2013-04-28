using System;
using UnityEngine;
using System.Collections;

public class PathNode : MonoBehaviour {
	
	public PathNode next;
	public PathNode previous;
	
	public PathNode north = null; 
	public PathNode south = null; 
	public PathNode east = null; 
	public PathNode west = null;

    public Sign signRef;
	
	public UnityEngine.Vector3 dirFromPrevious;
	public UnityEngine.Vector3 dirToNext;
	public UnityEngine.Vector3 dirFromNext;
	public UnityEngine.Vector3 dirToPrevious;
	public string behavior;
	public string type;
	public string signType = null;
	
	// Use this for initialization
	void Start () {
		this.gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void CalcDirs(){
		//dirFromPrevious = transform.position - previous.transform.position;
		//dirToNext = next.transform.position - transform.position;
		//dirFromNext = transform.position - next.transform.position;
		//dirToPrevious = previous.transform.position - transform.position;
	}
	
	void OnTriggerEnter(Collider other) {
		if( type == "intersection" ){
			//Left, Right, Streight
			Debug.Log ("INTERSECTION HIT!");
			PathNode left =  null;
			PathNode right =  null;
			PathNode streight = null;
			Vector3 fw = other.transform.forward;
			if( Math.Abs(fw.x) > Math.Abs(fw.z) ){
				//heading east: left is north; right is south
				if( fw.x >= 0 ){ //heading East
					left = north;
					right = south;
					streight = east;
				}
				//heading west: left is south; right is north
				else{ //heading West
					left = south;
					right = north;
					streight = west;
				}
			}
			else if( Math.Abs(fw.z) >= Math.Abs( fw.x ) ){
				//heading North: left is West; right is East
				if( fw.x >= 0 ){ //heading East
					left = west;
					right = east;
					streight = north;
				}
				//heading South: left is East; right is West
				else{ //heading West
					left = east;
					right = west;
					streight = south;
				}
			}
            switch (signRef.type)
            {
                case SignType.None:
                    string options = "";
                    if (left != null) { options += "Left "; }
                    if (right != null) { options += "Right "; }
                    if (streight != null) { options += "Streight"; }
                    string dir = other.GetComponent<CarLogic>().ChoosePath(options);
                    if (dir == "Left") { TowardNode(other, left); }
                    if (dir == "Right") { TowardNode(other, right); }
                    if (dir == "Streight") { TowardNode(other, streight); }
                    break;
                case SignType.OneWayLeft:
                    break;
                case SignType.OneWayRight:
                    break;
                case SignType.Speed15:
                    break;
                case SignType.Speed30:
                    break;
                case SignType.Stop:
                    break;
            }
		}
		else{
			TowardNode(other, next);
		}
    }
	
	public void TowardNode(Collider car, PathNode dir){
		car.rigidbody.velocity = dir.transform.position - car.transform.position;
		car.rigidbody.velocity.Normalize();
		float rotate = Vector3.Angle(dir.transform.position - transform.position, car.transform.forward);
		car.transform.rotation = car.transform.rotation * Quaternion.Euler(0, rotate, 0);
	}
	
}
	public PathNode west = null; 
	
	public UnityEngine.Vector3 dirFromPrevious;
	public UnityEngine.Vector3 dirToNext;
	public UnityEngine.Vector3 dirFromNext;
	public UnityEngine.Vector3 dirToPrevious;
	public string behavior;
	public string type;
	public string signType = null;
	
	// Use this for initialization
	void Start () {
		this.gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void CalcDirs(){
		//dirFromPrevious = transform.position - previous.transform.position;
		//dirToNext = next.transform.position - transform.position;
		//dirFromNext = transform.position - next.transform.position;
		//dirToPrevious = previous.transform.position - transform.position;
	}
	
	void OnTriggerEnter(Collider other) {
		if( type == "intersection" ){
			//Left, Right, Streight
			Debug.Log ("INTERSECTION HIT!");
			PathNode left =  null;
			PathNode right =  null;
			PathNode streight = null;
			Vector3 fw = other.transform.forward;
			if( Math.Abs(fw.x) > Math.Abs(fw.z) ){
				//heading east: left is north; right is south
				if( fw.x >= 0 ){ //heading East
					left = north;
					right = south;
					streight = east;
				}
				//heading west: left is south; right is north
				else{ //heading West
					left = south;
					right = north;
					streight = west;
				}
			}
			else if( Math.Abs(fw.z) >= Math.Abs( fw.x ) ){
				//heading North: left is West; right is East
				if( fw.x >= 0 ){ //heading East
					left = west;
					right = east;
					streight = north;
				}
				//heading South: left is East; right is West
				else{ //heading West
					left = east;
					right = west;
					streight = south;
				}
			}
			string options = "";
			if(left != null){ options += "Left "; }
			if(right != null){ options += "Right "; }
			if(streight != null){ options += "Streight"; }
			string dir = other.GetComponent<CarLogic>().ChoosePath(options);
			if(dir == "Left"){ TowardNode(other, left); }
			if(dir == "Right"){ TowardNode(other, right); }
			if(dir == "Streight"){ TowardNode(other, streight); }
		}
		else{
			TowardNode(other, next);
		}
    }
	
	public void TowardNode(Collider car, PathNode dir){
		car.rigidbody.velocity = dir.transform.position - car.transform.position;
		car.rigidbody.velocity.Normalize();
		float rotate = Vector3.Angle(dir.transform.position - transform.position, car.transform.forward);
		car.transform.rotation = car.transform.rotation * Quaternion.Euler(0, rotate, 0);
	}
	
}
