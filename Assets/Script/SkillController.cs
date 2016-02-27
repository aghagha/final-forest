using UnityEngine;
using System.Collections;

public class SkillController : MonoBehaviour {
    public GameObject rays;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShootRays();
        }
	}

    void ShootRays()
    {
        Vector3 pos = new Vector3(0, -7.7f, 2.8f);
        Vector2 dir;
        GameObject[] obj;
        obj = new GameObject[3];
        int i;

        for(i = 0;i <3; i++)
        {
            obj[i] = (GameObject)Instantiate(rays, pos, Quaternion.identity);
            obj[i].GetComponent<Rigidbody2D>().velocity = new Vector2(-5 + i*5, 15);
        }
        
    }
}
