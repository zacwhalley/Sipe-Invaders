using UnityEngine;
using System.Collections;

public class Barrier : Object {

    Color green = new Color(0.137f, 0.624f, 0.106f, 1);
    Color yellow = new Color(0.890f, 0.835f, 0.145f, 1);
    Color red = new Color(0.839f, 0.051f, 0.051f, 1);

	// Use this for initialization
	void Start ()
    {
        Health = 3;
        Faction = -1;
        GetComponent<SpriteRenderer>().color = green;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ObjectUpdate();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("Barrier hit");
        takeDamage(collider);
        UpdateColour();
    }

    void UpdateColour()
    {
        Color newBarrierColour = Color.green;
        switch(Health)
        {
            case 3: newBarrierColour = green; break;
            case 2: newBarrierColour = yellow; break;
            case 1: newBarrierColour = red; break;
            default: break;
        }
        GetComponent<SpriteRenderer>().color = newBarrierColour;
    }

}
