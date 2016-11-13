using UnityEngine;
using System.Collections;

public class PlayerController : Character {

    
    float speed = 500.0f;
    
	// Use this for initialization
	void Start () {
        character = GetComponent<Rigidbody2D>();
        health = 3;
        faction = 1;
	}//Start
	
	// Update is called once per frame
	void Update () {
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot(1, 1000.0f, 1);
        
    }//Update

    //Move - moves the character left and right
    void Move(float input)
    {
        Vector3 newVelocity;

        if ((character.position.x < -10 && input < 0) || (character.position.x > 10 && input > 0) || input == 0)
            newVelocity = new Vector2(0, 0);
        else
            newVelocity = new Vector2(speed * input * Time.deltaTime, 0);

        character.velocity = newVelocity;
    }//Move
}
