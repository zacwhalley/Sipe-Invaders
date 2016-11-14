using UnityEngine;
using System.Collections;

public class Barrier : Object {

	// Use this for initialization
	void Start ()
    {
        Health = 3;
        Faction = -1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ObjectUpdate();
    }

}
