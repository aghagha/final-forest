using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyExample : MonoBehaviour {
	public float startingHealth;
	public float health;
	public Text healthText;
	public Slider healthSlider;
	public GameObject monster;

    private IngameController ingameController;

	// Use this for initialization
	void Awake(){
        health = 1000f;
		SetHealthText();
		healthSlider.maxValue = health;
		healthSlider.value = health;

	}

    void Start()
    {
        ingameController = GameObject.Find("IngameController").GetComponent<IngameController>();

	}
	
	// Update is called once per frame
	void Update () {
		IsDead();
	}

	void IsDead(){
		if(health <= 0f){
            Destroy(monster);
            PlayerPrefs.SetString("Level 2", "OK");
            ingameController.LoserNotification(this.gameObject);
            
        }
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "bullets"){
			float damage = col.gameObject.GetComponent<BulletFather>().damage;
			float force = col.gameObject.GetComponent<BulletFather>().currMag;
			float totalDamage = damage + force;
			print("BAM! You Dealt "+totalDamage+" damage!");
			health -= (totalDamage);
			if(health<0f)health=0f;
			SetHealthText();
			Destroy(col.gameObject);
		}
	}

	void SetHealthText(){
		int hp = (int)health;
		healthText.text = "Enemy : " + hp.ToString();
		healthSlider.value = health;
	}
}
