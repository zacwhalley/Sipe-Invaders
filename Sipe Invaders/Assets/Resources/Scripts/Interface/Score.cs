using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Game game;
	// Use this for initialization
	void Start () {
        game = (Game)FindObjectOfType(typeof(Game));
        GetComponent<Text>().text = "SCORE: N/A";
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "SCORE: " + game.GameScore;
	}
}
