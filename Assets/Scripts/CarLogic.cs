using UnityEngine;
using System.Collections;

public class CarLogic : MonoBehaviour {
	public PathNode start;
	// Use this for initialization
	void Start () {
		GameObject.Find ("GameController").GetComponent<Game>().PutAtNode(this, start);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public string ChoosePath(string options){
		//return "Streight";
		if( options.Contains("Left") ){ return "Left"; }
		if( options.Contains("Right") ){ return "Right"; }
		if( options.Contains("Streight") ){ return "Streight"; }
		return "FAIL";
	}
}
