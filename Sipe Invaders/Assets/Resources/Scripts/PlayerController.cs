using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody2D player;
    float speed = 500.0f;
    int health;


	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        health = 3;
	}//Start
	

	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Destroy(this.gameObject);
        else
        {
            PlayerMovement();
            if (Input.GetKeyDown(KeyCode.Space))
                Shoot();
        }//else
	}//Update


    //Move - moves the player left and right
    void Move(float input)
    {
        Vector3 newVelocity;

        if ((player.position.x < -10 && input < 0) || (player.position.x > 10 && input > 0))
            newVelocity = new Vector2(0, 0);
        else
            newVelocity = new Vector2(speed * input * Time.deltaTime, 0);

        player.velocity = newVelocity;
    }//Move


    void PlayerMovement()
    {
        if(Input.anyKey)
            Move(Input.GetAxis("Horizontal"));
        else
            player.velocity = new Vector2(0, 0);
    }//PlayerMovement


    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("Hit");
        Health -= collider.gameObject.GetComponent<Projectile>().Damage;
    }//OnCollisionEnter

    void Shoot()
    {
        GameObject projectile = (GameObject)Instantiate(Resources.Load("Prefabs\\Projectile"), 
                                transform.position + transform.up * 1.0f, transform.rotation);
        Projectile bullet = projectile.GetComponent<Projectile>();
        bullet.Speed = 1000f;
        bullet.Damage = 1;
    }//Shoot


    public int Health
    {
        get{ return health; }
        set{ health = value; }
    }//Health
}
