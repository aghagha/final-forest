using UnityEngine;
using System.Collections;
using System;

public class SpecialEffectHelper : MonoBehaviour {
    public static SpecialEffectHelper Instance;

    public ParticleSystem sparkEffect;
    public ParticleSystem groundEffect;

    void Awake()
    {

        if (Instance != null)
        {
            print("It should be null, Doge.");
        }

        Instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spark(Vector3 position)
    {
        instantiate(sparkEffect, position);
    }

    public void GroundExplosion(Vector3 position)
    {
        instantiate(groundEffect, position);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
            prefab,
            position,
            Quaternion.identity
         ) as ParticleSystem;

        /*if(prefab.name == "GroundExplosion")
        {
            newParticleSystem.transform.parent = GameObject.FindGameObjectWithTag("barrier").transform;
        }*/

        Destroy(
            newParticleSystem.gameObject, 
            newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }
}
