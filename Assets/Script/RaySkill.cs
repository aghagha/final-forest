using UnityEngine;
using System.Collections;

public class RaySkill : MonoBehaviour {
    public Vector2 force;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
	    force = new Vector2(0,-300f);
        SpawnRay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnRay()
    {
        rb.AddForce(force * Time.deltaTime, ForceMode2D.Impulse);
    }
}
