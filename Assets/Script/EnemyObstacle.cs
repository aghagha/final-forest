using UnityEngine;
using System.Collections;

public class EnemyObstacle : MonoBehaviour {
    public Vector3 leftPoint;
    public Vector3 rightPoint;
    public float speed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 100f;
    }
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        
            rb.AddForce(new Vector2(speed * Time.deltaTime,0), ForceMode2D.Impulse);
            //rb.velocity = new Vector2(speed * Time.deltaTime, 0);
        
    }
}
