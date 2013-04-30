using UnityEngine;
using System.Collections;

public class GUIScore : MonoBehaviour {
	public int score;
	//public int signsPlaced = 5;
	//public int maxSigns = 8;
	public bool gameOver = false;
	public Game game;
	
	// Use this for initialization
	void Start () {
		game = GetComponent<Game>();
		score = 0;
	}
	
	void OnGUI(){
		GUI.Label(new Rect(0, 10, 100, 25), "Score: " + score);
		if(gameOver){ GUI.Label( new Rect(100, 100, 400, 200), "Game Over\nScore: " + score); }
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameOver){ score = (Time.frameCount/60) * game.numCars; }
	}
}
