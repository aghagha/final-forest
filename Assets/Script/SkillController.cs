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
        Instantiate(rays, pos, Quaternion.identity);
    }
}
