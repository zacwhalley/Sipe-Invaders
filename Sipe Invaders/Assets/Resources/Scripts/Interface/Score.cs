using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "SCORE: N/A";
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "SCORE: " + Game.score;
	}
}
