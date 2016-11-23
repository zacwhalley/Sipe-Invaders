using UnityEngine;
using System.Collections;


public class Character : Object
{
    public Rigidbody2D character;

    // Use this for initialization
    protected void InitializeCharacter () {
        character = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    protected void Shoot(int bulletDamage, float bulletSpeed, int faction)
    {
        GameObject projectile = (GameObject)Instantiate(Resources.Load("Prefabs\\Projectile"),
                                transform.position + transform.up * 1.0f * faction, transform.rotation);
        Projectile bullet = projectile.GetComponent<Projectile>();
        bullet.Initialize(bulletDamage, bulletSpeed, faction);
    }//Shoot
}
