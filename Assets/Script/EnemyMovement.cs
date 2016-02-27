using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour { 
    public Vector2 rightPoint;
    public Vector2 leftPoint;
    public float speed;

    public GameObject enemySprite;
    bool dirRight = true;
    
    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(!isDie())
            Movement();
	}

    void Movement()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }

        if (transform.position.x >= 8.3)
            dirRight = false;
        else if (transform.position.x <= 2.2)
            dirRight = true;
    }

    bool isDie()
    {
        return enemySprite.GetComponent<Animator>().GetBool("Die");
    }
}
