using UnityEngine;
using System.Collections;

public class PlayerController : Character
{
    float speed = 500.0f;
    float timeAtLastShot;
    
	// Use this for initialization
	void Start ()
    {
        InitializeCharacter();
        Health = 3;
        Faction = 1;
	}//Start
	
	// Update is called once per frame
	void Update ()
    {
        ObjectUpdate();
        
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time - timeAtLastShot > 0.33f))
        {
            Shoot(1, 1000.0f, faction);
            timeAtLastShot = Time.time;
        }        
    }//Update

    //Move - moves the character left and right
    void Move(float input)
    {
        Vector3 newVelocity;

        if ((character.position.x -0.4 < Game.LEFT_BOUNDARY && input < 0) || (character.position.x + 0.4 > Game.RIGHT_BOUNDARY && input > 0) || input == 0)
            newVelocity = new Vector2(0, 0);
        else
            newVelocity = new Vector2(speed * input * Time.deltaTime, 0);

        character.velocity = newVelocity;
    }//Move

    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("PLAYER COLLISION");
        takeDamage(collider);
    }
}
