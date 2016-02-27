using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    bool isDead = false;

    public float hp;
    public Text hpText;
    public GameObject playerAvatar;
    public Slider healthBar;

    private IngameController ingameController;

	// Use this for initialization

    void Awake()
    {
        hp = 500f;
        hpText.text = Mathf.CeilToInt(hp).ToString();
        healthBar.maxValue = hp;
        healthBar.value = hp;
    }
	void Start ()
    {
        ingameController = GameObject.Find("IngameController").GetComponent<IngameController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "bullets")
        {
            float damage = col.gameObject.GetComponent<BulletFather>().damage;
            float force = col.gameObject.GetComponent<BulletFather>().currMag;
            float totalDamage = damage + force;
            hp -= totalDamage;
            hpText.text = Mathf.CeilToInt(hp).ToString();
            healthBar.value = hp;
            print("You took " + totalDamage + " damage!");
            Destroy(col.gameObject);
            if(hp <= 0)
            {
                hp = 0;
                hpText.text = "0";
                healthBar.value = 0;
                Destroy(playerAvatar);
                isDead = true;

                ingameController.LoserNotification(this.gameObject);
            }
        }
    }
}
