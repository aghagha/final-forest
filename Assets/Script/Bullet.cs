using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed = 5f;
	private Vector2 direction;
	public Vector2 force;
	private float maxVelocity = 50f;
	public float currMag;
	private Rigidbody2D rb;
	private float life;
	public float damage = 200f;
	// Use this for initialization
	void Awake(){
		rb = GetComponent<Rigidbody2D>();
		life = 200f;
	}

	void Start () {
		SpawnBullet();
	}
	
	// Update is called once per frame
	void Update(){
		LifeSpan();
	}

	void FixedUpdate () {
		LimitVelocity();
		currMag = rb.velocity.magnitude;
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		
	}

	void LifeSpan(){
		life--;
		if(life<=0f)
			Destroy(gameObject);
	}
	
	void SpawnBullet(){
		force = new Vector2(Random.Range(-300f, 300f), -500f);
		rb.AddForce(force * Time.deltaTime, ForceMode2D.Impulse);
	}

	void LimitVelocity(){
		float currVelocity = rb.velocity.magnitude;
		Vector2 velocity = rb.velocity;
		if(currVelocity > maxVelocity){
			Vector3 newVelocity = velocity.normalized;
			newVelocity *= maxVelocity;
			rb.velocity = newVelocity;
		}
	}
}