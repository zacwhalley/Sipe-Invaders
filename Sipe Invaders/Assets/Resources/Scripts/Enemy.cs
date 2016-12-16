using UnityEngine;
using System.Collections;

public class Enemy : Character {

    static int direction = 1;     // direction for enemies to move in 
    static float max_posx;        // position of enemy closest to wall
    static public float speed;
    static int numEnemies = 0;
    static float shotTimer = 1000;
    static Game game; 
    float shotCount = 0;

	// Use this for initialization
	void Start () {
        InitializeCharacter();
        Faction = -1;
        Health = 1;
        speed = 3;
        numEnemies++;
    }
	
	// Update is called once per frame
	void Update () {
        if(Health == 0)
        {
            numEnemies--;
            Game.score++;
        }

        ObjectUpdate();
        MoveEnemy();
        AttemptShot();

	}

    void AttemptShot()
    {
        if(shotTimer <= 0)
        {
            Shoot(1, 1000f, Faction);
            shotTimer = 1000f;
        }
        shotTimer -= ((900 + Random.Range(0f, 200f)) * Time.deltaTime) / (numEnemies * speed);
    }

    void OnCollisionEnter2D(Collision2D collider){
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
