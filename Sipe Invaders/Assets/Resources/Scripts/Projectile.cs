using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    public int faction;
    Rigidbody2D projectile;
    int damage;
    float speed;

    public void Initialize(int damage, float speed, int faction)
    {
        Damage = damage;
        Speed = speed;
        Faction = faction;
    }
	// Use this for initialization
	void Start ()
    {
        projectile = GetComponent<Rigidbody2D>();
        projectile.velocity = new Vector3(0, speed * Time.deltaTime);
	}

    // Update is called once per frame
    void Update()
    {
        // Destroy when out of bounds
        if (projectile.transform.position.y > Game.UPPER_BOUNDARY || projectile.transform.position.y < Game.LOWER_BOUNDARY)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        Destroy(gameObject);
    }//OnCollisionEnter


    // Accessors
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }//Speed

    public int Damage
    {
        get { return damage;  }
        set { damage = value;  }
    }//Damage

    public int Faction
    {
        get { return faction; }
        set { faction = value; }
    }//Faction
}
