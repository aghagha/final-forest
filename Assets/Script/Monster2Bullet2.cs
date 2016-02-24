using UnityEngine;
using System.Collections;

public class Monster2Bullet2 : BulletFather {
    
	// Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = 100f;
        maxVelocity = 50f;
        life = 200f;
        Physics2D.IgnoreLayerCollision(8, 8);
    }

	void Start () {
        SpawnBullet();
	}
	
	// Update is called once per frame
	void Update () {
        life--;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
        FaceDirection();
	}

    void FixedUpdate()
    {
        LimitVelocity();
        currMag = rb.velocity.magnitude;
    }

    void FaceDirection()
    {
        Vector3 moveDirection = rb.velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90 ;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

}
