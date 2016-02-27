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
}
