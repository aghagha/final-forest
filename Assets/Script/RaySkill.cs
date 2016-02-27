using UnityEngine;
using System.Collections;

public class RaySkill : MonoBehaviour {
    public Vector2 force;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
	    force = new Vector2(0,10f);
        SpawnRay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnRay()
    {
        rb.velocity = force;
        //rb.AddForce(force * Time.deltaTime, ForceMode2D.Impulse);
    }
}
