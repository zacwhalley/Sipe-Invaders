using UnityEngine;
using System.Collections;

public class Enemy : Character {

    static public float speed = 3;
    static int numEnemies = 0;
    static int maxEnemies = 0;
    float shotTimer;


	// Use this for initialization
	void Start () {
        InitializeCharacter();
        Faction = -1;
        Health = 1;
        numEnemies++;
        maxEnemies++;
        character.velocity = RandomDirection((int)Random.Range(0, 4.99f));
        shotTimer = Random.Range(1000f, 2000f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Health == 0)
        {
            numEnemies--;
            Game.score++;
            speed+=0.5f;
        }

        ObjectUpdate();
        MoveEnemy();
        AttemptShot();
        Physics2D.IgnoreLayerCollision(8, 8);
	}

    void AttemptShot()
    {
        if(shotTimer <= 0)
        {
            Shoot(1, 1000f, Faction);
            shotTimer = Random.Range(500, 1500);
        }
        shotTimer -= (200 *(5 + Random.Range(-5f, 15f)) / (maxEnemies * numEnemies * 3));
    }

    void OnCollisionEnter2D(Collision2D collider){
        takeDamage(collider);
    }

    void MoveEnemy()
    {
        if (transform.position.x + 0.28 > Game.RIGHT_BOUNDARY)
            character.velocity = RandomDirection(0);
        else if (transform.position.y > Game.UPPER_BOUNDARY)
            character.velocity = RandomDirection(1);
        else if (transform.position.x - 0.25 < Game.LEFT_BOUNDARY)
            character.velocity = RandomDirection(2);
        else if (transform.position.y < Game.LOWER_ENEMY_BOUNDARY)
            character.velocity = RandomDirection(3);
    }

    Vector2 RandomDirection(int bounds)
    {
        int x, y;
        int rnd;
        Vector2 newDirection;

        if (Random.value > 0.5)
            rnd = -1;
        else
            rnd = 1;

        switch(bounds)
        {
            case 0: x = -1; y = rnd; break;
            case 1: x = rnd; y = -1; break;
            case 2: x = 1; y = rnd; break;
            case 3: x = rnd; y = 1; break;

            default: x = y = 1; break;
        }

        float theta = Random.Range(0, 0.5f * 3.1415926f);
        newDirection = speed * new Vector2(x * Mathf.Cos(theta), y * Mathf.Sin(theta));

        return newDirection;
    }

}
