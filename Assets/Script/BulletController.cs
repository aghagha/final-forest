using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public GameObject bullet1;
    public GameObject bullet2;    

    public float bulletTimer = 15f;

    public float cooldownA = 1.5f;
    public float cooldownB = 0.5f;
    public float lastSpawn;

	// Use this for initialization
	void Start () {
        lastSpawn = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        bulletTimer -= Time.deltaTime;
        if (bulletTimer > 8f)
        {
            if((Time.time - lastSpawn) > cooldownA)
            {
                AttackTypeOne();
                lastSpawn = Time.time;
            }
        }
        else if(bulletTimer <7.5f && bulletTimer >0.5f)
        {
            if ((Time.time - lastSpawn) > cooldownB)
            {
                AttackTypeTwo();
                lastSpawn = Time.time;
            }
        }
        else if (bulletTimer <= 0f) bulletTimer = 15f;
    }

    void AttackTypeOne()
    {
        Vector3 pos = new Vector3(-0.2f, 10f, 2.8f);
        Instantiate(bullet1, pos, Quaternion.identity);
    }

    void AttackTypeTwo()
    {
        Vector3 pos = new Vector3(Random.Range(-5.9f,5.65f), Random.Range(-0.2f,9.06f), 2.8f);
        Instantiate(bullet2, pos, Quaternion.identity);
        
    }

    private void setIdle()
    {
        gameObject.GetComponent<Animator>().SetBool("Hit", false);
    }
}
