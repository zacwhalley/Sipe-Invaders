using UnityEngine;
using System.Collections;

public class PlayerController : Character
{
    float speed = 500.0f;
    float timeAtLastShot;
    AudioSource gunSound;
    static GameObject instance;

    public HealthBar healthBar;
    
	// Use this for initialization
	void Start ()
    {
        InitializeCharacter();
        Health = 3;
        Faction = 1;

        gunSound = GetComponent<AudioSource>();
        healthBar = (HealthBar)FindObjectOfType(typeof(HealthBar));
        healthBar.UpdateHealth();
	}//Start
	
	// Update is called once per frame
	void Update ()
    {
        ObjectUpdate();
        
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time - timeAtLastShot > 0.33f))
        {
            Shoot(1, 1000.0f, faction);
            gunSound.Play();
            timeAtLastShot = Time.time;
        }        
    }//Update

    //Move - moves the character left and right
    void Move(float input)
    {
        Vector3 newVelocity;

        if ((character.position.x -0.6 < Game.LEFT_BOUNDARY && input < 0) || 
            (character.position.x + 0.6 > Game.RIGHT_BOUNDARY && input > 0))
            newVelocity = new Vector2(0, 0);
        else
            newVelocity = new Vector2(speed * input * Time.deltaTime, 0);

        character.velocity = newVelocity;
    }//Move

    void OnCollisionEnter2D(Collision2D collider)
    {
        takeDamage(collider);
        healthBar.UpdateHealth();
    }
}
