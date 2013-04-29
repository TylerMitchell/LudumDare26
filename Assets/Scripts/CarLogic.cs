using UnityEngine;
using System.Collections;

public class CarLogic : MonoBehaviour {
	public PathNode start;
	public PathNode betweenA;
	public PathNode betweenB;
	public float progress = 0.0f;
	// Use this for initialization
	void Start () {
		//GameObject.Find ("GameController").GetComponent<Game>().PutAtNode(this, start);
	}
	
	// Update is called once per frame
	void Update () {
		if(progress < 1.0f){ progress += 0.05f; }
		transform.position = Vector3.Lerp(betweenA.transform.position, betweenB.transform.position, progress);
	}
	
	public string ChoosePath(string options){
		//return "Streight";
		if( options.Contains("Left") ){ return "Left"; }
		if( options.Contains("Right") ){ return "Right"; }
		if( options.Contains("Streight") ){ return "Streight"; }
		return "FAIL";
	}
}
