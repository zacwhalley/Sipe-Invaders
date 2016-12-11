using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour {

    public int faction;
    public int health;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	protected void ObjectUpdate ()
    {
        if (Health <= 0)
            Destroy(this.gameObject);          
    }

    protected void takeDamage(Collision2D collider)
    {
        if (collider.gameObject.tag == "Projectile")
        {
            Projectile projectile = collider.gameObject.GetComponent<Projectile>();
            if (faction != projectile.Faction)
            {               
                Health -= projectile.Damage;
            }
        }//if
    }//OnCollisionEnter

    // Accessors
    public int Health
    {
        get { return health; }
        set
        {
            if (value < 0)
                health = 0;
            else
                health = value;
        }
    }//Health

    public int Faction
    {
        get { return faction; }
        set { faction = value; }
    }//Faction    
}
