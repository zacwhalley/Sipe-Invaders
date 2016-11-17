using UnityEngine;
using System.Collections;

public class Enemy : Character {

	// Use this for initialization
	void Start () {
        Faction = -1;
        Health = 1;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollision2DEnter(Collision2D collider)
    {
        takeDamage(collider);
    }
}
