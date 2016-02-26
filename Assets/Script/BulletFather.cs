using UnityEngine;
using System.Collections;

public class BulletFather : MonoBehaviour {
    public float currMag;
    public float damage;
    public float speed;
    public float life;
    public float maxVelocity;

    protected Vector2 direction;
    protected Vector2 force;
    protected Rigidbody2D rb;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        life = life - Time.deltaTime;
        print(life);
	}

    public virtual void SpawnBullet()
    {
        force = new Vector2(Random.Range(-300f, 300f), -500f);
        rb.AddForce(force * Time.deltaTime, ForceMode2D.Impulse);
    }

    protected void LimitVelocity()
    {
        float currVelocity = rb.velocity.magnitude;
        Vector2 velocity = rb.velocity;
        if (currVelocity > maxVelocity)
        {
            Vector2 newVelocity = velocity.normalized;
            newVelocity *= maxVelocity;
            rb.velocity = newVelocity;
        }
    }

    protected void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag != "Player")
        {
            SpecialEffectHelper.Instance.Spark(transform.position);
        }
    }
}
