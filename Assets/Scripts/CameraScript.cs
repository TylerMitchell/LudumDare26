using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float zMove = Input.GetAxis("Vertical")*0.05f;
		float xMove = Input.GetAxis("Horizontal")*0.05f;
		transform.position += new Vector3(xMove, 0.0f, zMove);
	}
}
