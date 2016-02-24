using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 20f;
	private Rigidbody2D rb;
	// Use this for initialization
	void Awake(){
		rb = GetComponent<Rigidbody2D>();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//transform.position =  Vector2.MoveTowards(this.transform.position, pos, speed*Time.deltaTime);
	}

	void FixedUpdate(){
		Vector3 pos = Input.mousePosition;
		pos.z = 0;
		pos = GetWorldPositionOnPlane(pos,pos.z);

		InvisWall(ref pos);
		MoveToFinger(pos);
	}

	void InvisWall(ref Vector3 pos){
		if(pos.y > -5f) pos.y = -5f;
		//if(pos.y < -10.5f) pos.y = -10.5f;
		//if(pos.x > 6.2f) pos.x = 6.2f;
		//if(pos.x < -6.8f) pos.x = -6.8f;
	}

	void MoveToFinger(Vector3 pos){
		rb.velocity = (pos - this.transform.position)*speed;
	}

	public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}
	
}
