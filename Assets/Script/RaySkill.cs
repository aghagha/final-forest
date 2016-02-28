using UnityEngine;
using System.Collections;

public class RaySkill : BulletFather {
    float lastEmit;
    EnemyExample enemy;
    Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        lastEmit = Time.time;
        rb = GetComponent<Rigidbody2D>();
        life = 3f;
        damage = 50f;
        enemy = GameObject.Find("EnemyCollider").GetComponent<EnemyExample>();
    }

	// Use this for initialization
	void Start () {
        anim.SetBool("Die", false);
        Physics2D.IgnoreLayerCollision(9, 9, true);
    }
	
	// Update is called once per frame
	void Update () {
        life -= Time.deltaTime;
        
        EmitParticle();
        if (life <= 0f)
        {
            anim.SetBool("Die", true);
        }
    }

    void LateUpdate()
    {
        FaceDirection();
    }

    void RayDie()
    {
        //SpecialEffectHelper.Instance.Poof(transform.position);
        Destroy(gameObject);
        
    }

    void EmitParticle()
    {
        if (Time.time - lastEmit >= 0.1f)
        {
            lastEmit = Time.time;
            SpecialEffectHelper.Instance.RaysParticle(transform.position);
        }
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
