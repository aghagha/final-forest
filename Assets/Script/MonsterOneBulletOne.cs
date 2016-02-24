using UnityEngine;
using System.Collections;

public class MonsterOneBulletOne : BulletFather {

	void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = 200f;
        maxVelocity = 50f;
        life = 300f;
        Physics2D.IgnoreLayerCollision(8, 8, false);
    }

	void Start () {
        SpawnBullet();
	}
	
	// Update is called once per frame
	private void Update () {
        life--;
        //if (life <= 20f)
        //    Kamikaze();
        if (life <= 0f)
            Destroy(gameObject);
        transform.Rotate(0, 0, 360 * Time.deltaTime);
    }

    void FixedUpdate()
    {
        LimitVelocity();
        currMag = rb.velocity.magnitude;
    }

    

    /*void SpawnBullet()
    {
        force = new Vector2(Random.Range(-300f, 300f), -500f);
        rb.AddForce(force * Time.deltaTime, ForceMode2D.Impulse);
    }

    void LimitVelocity()
    {
        float currVelocity = rb.velocity.magnitude;
        Vector2 velocity = rb.velocity;
        if(currVelocity > maxVelocity)
        {
            Vector2 newVelocity = velocity.normalized;
            newVelocity *= maxVelocity;
            rb.velocity = newVelocity;
        }
    }*/
}
