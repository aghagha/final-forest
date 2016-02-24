using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public GameObject bullet1;
    public GameObject bullet2;    

    public float bulletTimer = 1000f;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        bulletTimer -= 1f;
        if (bulletTimer > 600f)
        {
            if(bulletTimer % 70 == 0)
                AttackTypeOne();
        }
        else if(bulletTimer <500f && bulletTimer >100f)
        {
            if(bulletTimer % 20f == 0)
            {
                AttackTypeTwo();
            }
        }
        else if (bulletTimer <= 0f) bulletTimer = 1000f;
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
}
