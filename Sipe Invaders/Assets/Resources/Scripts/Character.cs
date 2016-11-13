using UnityEngine;
using System.Collections;



public class Character : MonoBehaviour {

    protected Rigidbody2D character;
    protected int faction;
    protected int health;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.GetType() == typeof(Projectile))
        {
            Projectile projectile = collider.gameObject.GetComponent<Projectile>();
            if (faction == projectile.Faction)
                Health -= projectile.Damage;
        }//if
    }//OnCollisionEnter

    protected void Shoot(int bulletDamage, float bulletSpeed, int bulletFaction)
    {
        GameObject projectile = (GameObject)Instantiate(Resources.Load("Prefabs\\Projectile"),
                                transform.position + transform.up * 1.0f * faction, transform.rotation);
        Projectile bullet = projectile.GetComponent<Projectile>();
        bullet.Initialize(bulletDamage, bulletSpeed, bulletFaction);
    }//Shoot

    public int Health
    {
        get { return health; }
        set { health = value; }
    }//Health
}
