using UnityEngine;
using System.Collections;

public class RaySkill : BulletFather {

    EnemyExample enemy;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        life = 3f;
        damage = 150f;
        enemy = GameObject.Find("EnemyCollider").GetComponent<EnemyExample>();
    }

	// Use this for initialization
	void Start () {
        
        Physics2D.IgnoreLayerCollision(9, 9, true);
    }
	
	// Update is called once per frame
	void Update () {
        FaceDirection();
    }

    void FaceDirection()
    {
        Vector3 moveDirection = rb.velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "bullets")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
