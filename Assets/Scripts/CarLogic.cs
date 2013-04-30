using UnityEngine;
using System.Collections;
using System;

public class CarLogic : MonoBehaviour {
	public PathNode start;
	public PathNode betweenA;
	public PathNode betweenB;
	public float progress = 0.0f;
	public float baseSpeed = 0.01f;
	public float ds;
	public bool paused = false;
	// Use this for initialization
	void Start () {
		//GameObject.Find ("GameController").GetComponent<Game>().PutAtNode(this, start);
		float mag = Vector3.Magnitude(betweenB.transform.position - betweenA.transform.position);;
		if( mag == 0.0f){ mag = 1.0f; }
		ds = baseSpeed * 1.0f/mag;
	}
	
	// Update is called once per frame
	void Update () {
		if(progress < 1.0f){ progress += ds; }
		if(!paused){ transform.position = Vector3.Lerp(betweenA.transform.position, betweenB.transform.position, progress); }
		if(progress >= 1.0f){
			if( betweenB.type == "intersection" ){
				//Left, Right, Streight
				//Debug.Log ("intersection");
				PathNode left =  null;
				PathNode right =  null;
				PathNode streight = null;
				//Vector3 fw = other.rigidbody.velocity;
				Vector3 fw = betweenB.transform.position - betweenA.transform.position;
				if( Math.Abs(fw.x) > Math.Abs(fw.z) ){
					//heading east: left is north; right is south
					if( fw.x >= 0 ){ //heading East
						//Debug.Log ("Detected East!");
						left = betweenB.north;
						right = betweenB.south;
						streight = betweenB.east;
					}
					//heading west: left is south; right is north
					else{ //heading West
						//Debug.Log ("Detected West!");
						left = betweenB.south;
						right = betweenB.north;
						streight = betweenB.west;
					}
				}
				else if( Math.Abs(fw.z) >= Math.Abs( fw.x ) ){
					//heading North: left is West; right is East
					if( fw.x >= 0 ){ //heading North
						//Debug.Log ("Detected North!");
						left = betweenB.west;
						right = betweenB.east;
						streight = betweenB.north;
					}
					//heading South: left is East; right is West
					else{ //heading South
						Debug.Log ("Detected South!");
						left = betweenB.east;
						right = betweenB.west;
						streight = betweenB.south;
					}
				}

				switch (betweenB.signRef.type)
	            {
	                case SignType.None:
	                    string options = "";
	                    if (left != null) { options += "Left "; }
	                    if (right != null) { options += "Right "; }
	                    if (streight != null) { options += "Streight"; }
	                    string dir = ChoosePath(options);
	                    if (dir == "Left") { TowardNode(left); }
	                    if (dir == "Right") { Debug.Log ("Heading Right"); TowardNode(right); }
	                    if (dir == "Streight") { TowardNode(streight); }
                        break;
                    case SignType.OneWayNorth:
                        TowardNode(betweenB.north);
	                    break;
                    case SignType.OneWaySouth:
                        TowardNode(betweenB.south);
                        break;
                    case SignType.OneWayEast:
                        TowardNode(betweenB.east);
                        break;
                    case SignType.OneWayWest:
                        TowardNode(betweenB.west);
                        break;
	            }
			}
			else{
                if (betweenB.next == betweenA) { TowardNode(betweenB.previous); }
                else { TowardNode(betweenB.next); }
			}
		}
	}
	
	public string ChoosePath(string options){
		//return "Streight";
		if( options.Contains("Left") ){ return "Left"; }
		if( options.Contains("Right") ){ return "Right"; }
		if( options.Contains("Streight") ){ return "Streight"; }
		return "FAIL";
	}
	
	public void TowardNode(PathNode dir){
		/*Vector3 tVel = (dir.transform.position - car.transform.position);
		tVel.y = 0.0f;
		car.rigidbody.velocity = tVel;
		car.rigidbody.velocity.Normalize();
		car.rigidbody.velocity *= 0.5f;
		float rotate = Vector3.Angle(dir.transform.position - transform.position, car.transform.forward);
		car.transform.rotation = car.transform.rotation * Quaternion.Euler(0, rotate, 0);*/
		//if( Object.ReferenceEquals(dir, next) ){}
		//Debug.Log ("HIT!");
		if( progress > 0.2f ){
			betweenA = betweenB;
			betweenB = dir;
			progress = 0.0f;
			//Debug.Log(Vector3.Magnitude(betweenB.transform.position - betweenA.transform.position));
			Vector3 vec2 = betweenB.transform.position - betweenA.transform.position;
			Vector2 v1 = new Vector2(1.0f, 0.0f);
			Vector2 v2 = new Vector2(vec2.x, vec2.z);
			ds = baseSpeed * 1/Vector3.Magnitude(vec2);
			transform.eulerAngles = new Vector3(0.0f, Vector2.Angle(v1, v2) + 90, 0.0f);
		}
	}
	
	void OnCollisionEnter( Collision collision){
		if( collision.gameObject.tag == "car"){
			GameObject.Find ("GameController").GetComponent<GUIScore>().gameOver = true;
			paused = true;
		}
	}
}
