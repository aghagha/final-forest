using UnityEngine;
using System.Collections;

public class Level2BulletController : MonoBehaviour {
    public GameObject bullet1;
    public GameObject bullet2;
    public float bulletTimer = 1500f;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        bulletTimer -= 1f;
        if (bulletTimer > 600f)
        {
            if (bulletTimer % 70 == 0)
                StartCoroutine(AttackTypeOne());
        }
        else if (bulletTimer < 500f && bulletTimer > 100f)
        {
            if (bulletTimer % 10f == 0)
            {
                AttackTypeTwo();
            }
        }
        else if (bulletTimer <= 0f) bulletTimer = 1000f;
    }

    IEnumerator AttackTypeOne()
    {
        Vector3 pos = new Vector3(-0.2f, 10f, 2.8f);

        //WAJUR OE. RAPEKNO NGKOK

        GameObject b1 = (GameObject)Instantiate(bullet1, pos, Quaternion.identity);
        Vector2 force = new Vector2(Random.Range(-300f, 300f), -900f);
        b1.GetComponent<Rigidbody2D>().AddForce(force * Time.deltaTime, ForceMode2D.Impulse); 
        yield return new WaitForSeconds(0.15f);
        b1 = (GameObject)Instantiate(bullet1, pos, Quaternion.identity);
        b1.GetComponent<Rigidbody2D>().AddForce(force * Time.deltaTime, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        b1 = (GameObject)Instantiate(bullet1, pos, Quaternion.identity);
        b1.GetComponent<Rigidbody2D>().AddForce(force * Time.deltaTime, ForceMode2D.Impulse);
    }

    void AttackTypeTwo()
    {
        Vector3 pos = new Vector3(-0.2f, 10f, 2.8f);
        Instantiate(bullet2, pos, Quaternion.identity);
    }
}
