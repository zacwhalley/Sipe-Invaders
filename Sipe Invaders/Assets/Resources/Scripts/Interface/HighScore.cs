using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    Game game;

    // Use this for initialization
    void Start()
    {
        game = (Game)FindObjectOfType(typeof(Game));
        GetComponent<Text>().text = "HIGH SCORE: 0";
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "HIGH SCORE: " + game.GameHighScore;
    }
}
