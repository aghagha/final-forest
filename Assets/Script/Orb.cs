using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Orb : MonoBehaviour {
	
	public float speed = 20f;
    public GameObject barrier;
    public Button barrierButton;
    public Animator impale;

    public float coolDown;
    float currentCoolDown;
	Rigidbody2D rb;
    public float barrierTimer = 0f;

	void Awake(){
        currentCoolDown = coolDown;
		rb = GetComponent<Rigidbody2D>();
        barrier.GetComponent<Renderer>().enabled = false;
        barrier.GetComponent<Collider2D>().enabled = false;
        impale = barrier.GetComponent<Animator>();
        //barrierButton.enabled = false;
    }
	
	void Start () {
		
	}

	void Update () {
        currentCoolDown--;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        BarrierSkill();
        CountCooldown();
    }
	
	void FixedUpdate(){
		Vector3 pos = Input.mousePosition;
		pos.z = 0;
		pos = GetWorldPositionOnPlane(pos,pos.z);
		
		InvisWall(ref pos);
		MoveToFinger(pos);
	}
	
	void InvisWall(ref Vector3 pos){
		if(pos.y > -3f) pos.y = -3f;
	}
	
	void MoveToFinger(Vector3 pos){
		rb.velocity = (pos - transform.position)*speed;
	}
	
	public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}

    public void ActivateBarrier()
    {
        impale.Play("Barrier");
        SpecialEffectHelper.Instance.GroundExplosion(barrier.transform.position - new Vector3(0,2.5f,0));
        barrierTimer = 100f;
        currentCoolDown = coolDown;
        barrierButton.enabled = false;
    }

    public void CountCooldown()
    {
        if (currentCoolDown > 0)
            barrierButton.image.fillAmount = ( coolDown - currentCoolDown )/ coolDown;
        else barrierButton.enabled = true;
    }
	

    void BarrierSkill()
    {
        if (barrierTimer > 0f)
        {
            barrier.GetComponent<Renderer>().enabled = true;
            barrier.GetComponent<Collider2D>().enabled = true;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), barrier.GetComponent<Collider2D>());
            barrierTimer -= 1f;
        }
        else
        {
            barrier.GetComponent<Renderer>().enabled = false;
            barrier.GetComponent<Collider2D>().enabled = false;
        }
    }
}
