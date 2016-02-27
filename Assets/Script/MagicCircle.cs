using UnityEngine;
using System.Collections;

public class MagicCircle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Idle();

        if (Input.GetKeyDown(KeyCode.A))
        {
            //StartCoroutine(CastSkill());
        }
        
	}

    void Idle()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }

    IEnumerator CastSkill()
    {
        yield return new WaitForSeconds(1f);
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(2,2,1), Time.deltaTime);
        yield return new WaitForSeconds(1f);
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.5f, 0.5f, 1), Time.deltaTime);
    }
}
