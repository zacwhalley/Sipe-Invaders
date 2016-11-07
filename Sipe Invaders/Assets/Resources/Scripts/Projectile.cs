using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    Rigidbody2D projectile;
    float speed = 0.0f;
    int damage = 0;

	// Use this for initialization
	void Start ()
    {
        projectile = GetComponent<Rigidbody2D>();
        projectile.velocity = new Vector3(0, speed * Time.deltaTime);
	}

    // Update is called once per frame
    void Update()
    {
        if (projectile.transform.position.y > 6.0f)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        Debug.Log("Hit bullet");
        Destroy(gameObject);
    }//OnCollisionEnter

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




}
