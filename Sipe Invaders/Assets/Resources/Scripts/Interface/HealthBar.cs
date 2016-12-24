using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    PlayerController player;

	// Use this for initialization
	void Start () {
        player = (PlayerController)FindObjectOfType(typeof(PlayerController));
    }
	
	// Update is called once per frame
	public void UpdateHealth () {
		switch(player.Health)
        {
            case 0: GetComponent<Text>().text = "RIP"; break;
            case 1: GetComponent<Text>().text = "<3"; break;
            case 2: GetComponent<Text>().text = "<3 <3"; break;
            case 3: GetComponent<Text>().text = "<3 <3 <3"; break;
            default: GetComponent<Text>().text = "ERROR"; break;
        }
	}
}
