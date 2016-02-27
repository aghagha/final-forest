using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Orb : MonoBehaviour {
	
	public float speed = 20f;

    //skill 1 - barrier
    public float coolDownA;
    float currentCoolDownA;
    public GameObject barrier;
    public Button barrierButton;

    //skill 2 - bullet
    public float coolDownB;
    float currentCoolDownB;
    public GameObject rays;
    Vector2 force;
    public Button rayButton;

    Rigidbody2D rb;
    public float barrierTimer = 0f;
    Animator impale;

    void Awake(){
        currentCoolDownA = coolDownA;
        currentCoolDownB = coolDownB;
		rb = GetComponent<Rigidbody2D>();
        barrier.GetComponent<Renderer>().enabled = false;
        barrier.GetComponent<Collider2D>().enabled = false;
        impale = barrier.GetComponent<Animator>();
        barrierButton.enabled = false;
        rayButton.enabled = false;
    }
	
	void Start () {
		
	}

	void Update () {
        currentCoolDownA -= Time.deltaTime;
        currentCoolDownB -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        BarrierSkill();

        CountCooldown(barrierButton, coolDownA, currentCoolDownA);
        CountCooldown(rayButton, coolDownB, currentCoolDownB);
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

    //skill 1 - barrier

    public void ActivateBarrier()
    {
        impale.SetBool("Active", true);
        SpecialEffectHelper.Instance.GroundExplosion(barrier.transform.position - new Vector3(0,2.5f,0));
        barrierTimer = 2f;
        currentCoolDownA = coolDownA;
        barrierButton.enabled = false;
    }

    //skill 2 - ray
    public void ShootRays()
    {
        /*Instantiate(rays, new Vector3(0, -7.7f, 10.41f), Quaternion.identity);
        currentCoolDownB = coolDownB;
        rayButton.enabled = false;*/
        currentCoolDownB = coolDownB;
        Vector3 pos = new Vector3(-0.2f, -7.7f, 2.8f);
        GameObject[] obj;
        obj = new GameObject[3];
        int i;

        for (i = 0; i < 3; i++)
        {
            obj[i] = (GameObject)Instantiate(rays, pos, Quaternion.identity);
            obj[i].GetComponent<Rigidbody2D>().velocity = new Vector2(-5 + i * 5, 15);
        }
    }

    public void CountCooldown(Button button, float coolDown, float currentCoolDown)
    {
        if (currentCoolDown > 0)
            button.image.fillAmount = ( coolDown - currentCoolDown )/ coolDown;
        else button.enabled = true;
    }
	
    void BarrierSkill()
    {
        if (barrierTimer > 0f)
        {
            
            barrier.GetComponent<Renderer>().enabled = true;
            barrier.GetComponent<Collider2D>().enabled = true;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), barrier.GetComponent<Collider2D>());
            barrierTimer -= Time.deltaTime;
        }
        else
        {
            impale.SetBool("Active", false);
            barrier.GetComponent<Renderer>().enabled = false;
            barrier.GetComponent<Collider2D>().enabled = false;
        }
    }
}
