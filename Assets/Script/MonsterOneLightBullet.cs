using UnityEngine;
using System.Collections;

public class MonsterOneLightBullet : BulletFather {
    GameObject player;
    GameObject otherBullet;
    Quaternion _lookRotation;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = 50f;
        maxVelocity = 50f;
        life = 0.5f;
        Physics2D.IgnoreLayerCollision(8, 8);
    }

	void Start () {
        SpawnBullet();
        player = GameObject.Find("Hit Box");
        transform.rotation = Quaternion.AngleAxis(GetAngle() + 90f, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        life-=Time.deltaTime;
        if(life <= 0)
        {
            Kamikaze();
        }
    }

	void FixedUpdate () {
        LimitVelocity();
        currMag = rb.velocity.magnitude;
	}

    public override void SpawnBullet()
    {
        force = new Vector2(-100f, -500f);
        //rb.AddForce(force * Time.deltaTime, ForceMode2D.Impulse);
    }

    float GetAngle()
    {
        Vector3 pos = transform.position;
        Vector3 dir = player.transform.position - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return angle;
    }

    void Kamikaze()
    {
        player = GameObject.Find("Hit Box");
        Vector3 target = player.transform.position;
        this.rb.AddForce((target - transform.position) * maxVelocity);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "bullets")
            Destroy(gameObject);
    }
}
