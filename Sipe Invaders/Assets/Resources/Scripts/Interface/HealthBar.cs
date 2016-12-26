using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    PlayerController player;
    Color newColour;

	// Use this for initialization
	void Start () {
        player = (PlayerController)FindObjectOfType(typeof(PlayerController));
    }
	
	// Update is called once per frame
	public void UpdateHealth () {

		switch(player.Health)
        {
            case 0:
                GetComponent<Text>().text = "RIP"; 
                newColour = new Color(0.839f, 0.051f, 0.051f, 1); break;
            case 1:
                GetComponent<Text>().text = "<3";
                newColour = new Color(0.839f, 0.051f, 0.051f, 1); break;
            case 2:
                GetComponent<Text>().text = "<3 <3";
                newColour = new Color(0.890f, 0.835f, 0.145f, 1); break;
            case 3:
                GetComponent<Text>().text = "<3 <3 <3";
                newColour = new Color(0.0353f, 0.3490f, 1, 1); break;
            default:
                GetComponent<Text>().text = "ERROR";
                newColour = new Color(0.0353f, 0.3490f, 1, 1); break;
        }
        GetComponent<Text>().color = newColour;
	}
}
