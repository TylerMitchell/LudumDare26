using UnityEngine;
using System.Collections;

public class CarLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public string ChoosePath(string options){
		if( options.Contains("Left") ){ Debug.Log ("left!"); return "Left"; }
		if( options.Contains("Right") ){ Debug.Log ("right!"); return "Right"; }
		if( options.Contains("Streight") ){ Debug.Log ("streight!"); return "Streight"; }
		return "FAIL";
	}
}
