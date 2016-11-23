using UnityEngine;
using System.Collections;

public class Enemy : Character {

    static int direction = 1;   // direction for enemies to move in 
    static float max_posx;        // position of enemy closest to wall
    static public float speed;

	// Use this for initialization
	void Start () {
        InitializeCharacter();
        Faction = -1;
        Health = 1;
        speed = 3;
	}
	
	// Update is called once per frame
	void Update () {
        ObjectUpdate();
        MoveEnemy();
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        takeDamage(collider);
    }

    void MoveEnemy()
    {
        character.transform.Translate(Time.deltaTime * direction * speed, 0, 0);
        Max_posx = character.transform.position.x;
        SwitchDirection();
    }

    // Switches the direction of movement when any enemy is too close to the walls
    void SwitchDirection()
    {
        if ((Max_posx > (Game.RIGHT_BOUNDARY - 0.25) && direction == 1) ||
            (Max_posx < (Game.LEFT_BOUNDARY + 0.25) && direction == -1))
            direction *= -1;
    }

    // Accessors
    float Max_posx
    {
        get { return max_posx; }
        set
        {
            if ((value > max_posx && direction == 1) || (value < max_posx && direction == -1))
                max_posx = value;
        }
    }
}
