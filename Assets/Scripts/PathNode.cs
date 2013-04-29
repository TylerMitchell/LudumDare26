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
	
	public string behavior;
	public string type;
	public string signType = null;
	
	// Use this for initialization
	void Start () {
		this.gameObject.renderer.enabled = false;
		signRef = new Sign();
	}
	
	// Update is called once per frame
	void Update () {
	}	
	
	public void CalcDirs(){
	}
	
	void OnTriggerEnter(Collider other) {
		if( type == "intersection" ){
			//Left, Right, Streight
			//Debug.Log ("intersection");
			PathNode left =  null;
			PathNode right =  null;
			PathNode streight = null;
			//Vector3 fw = other.rigidbody.velocity;
			CarLogic tComp = other.GetComponent<CarLogic>();
			Vector3 fw = tComp.betweenB.transform.position - tComp.betweenA.transform.position;
			if( Math.Abs(fw.x) > Math.Abs(fw.z) ){
				//heading east: left is north; right is south
				if( fw.x >= 0 ){ //heading East
					//Debug.Log ("Detected East!");
					left = north;
					right = south;
					streight = east;
				}
				//heading west: left is south; right is north
				else{ //heading West
					//Debug.Log ("Detected West!");
					left = south;
					right = north;
					streight = west;
				}
			}
			else if( Math.Abs(fw.z) >= Math.Abs( fw.x ) ){
				//heading North: left is West; right is East
				if( fw.x >= 0 ){ //heading North
					//Debug.Log ("Detected North!");
					left = west;
					right = east;
					streight = north;
				}
				//heading South: left is East; right is West
				else{ //heading South
					Debug.Log ("Detected South!");
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
                    if (dir == "Right") { Debug.Log ("Heading Right"); TowardNode(other, right); }
                    if (dir == "Streight") { TowardNode(other, streight); }
                    print("zoinks");
                    break;
                case SignType.OneWayNorth:
                    TowardNode(other, north);
                    break;
                case SignType.OneWaySouth:
                    TowardNode(other, south);
                    break;
                case SignType.OneWayEast:
                    TowardNode(other, east);
                    break;
                case SignType.OneWayWest:
                    TowardNode(other, west);
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
		/*Vector3 tVel = (dir.transform.position - car.transform.position);
		tVel.y = 0.0f;
		car.rigidbody.velocity = tVel;
		car.rigidbody.velocity.Normalize();
		car.rigidbody.velocity *= 0.5f;
		float rotate = Vector3.Angle(dir.transform.position - transform.position, car.transform.forward);
		car.transform.rotation = car.transform.rotation * Quaternion.Euler(0, rotate, 0);*/
		//if( Object.ReferenceEquals(dir, next) ){}
		CarLogic script = car.GetComponent<CarLogic>();
		script.betweenA = script.betweenB;
		script.betweenB = dir;
		script.progress = 0.0f;
		Vector3 vec2 = script.betweenB.transform.position - script.betweenA.transform.position;
		Vector2 v1 = new Vector2(1.0f, 0.0f);
		Vector2 v2 = new Vector2(vec2.x, vec2.z);
		script.ds = script.baseSpeed * 1/Vector3.Magnitude(script.betweenB.transform.position - script.betweenA.transform.position);
		car.transform.eulerAngles = new Vector3(0.0f, Vector2.Angle(v1, v2) + 90, 0.0f);
	}
	
}
