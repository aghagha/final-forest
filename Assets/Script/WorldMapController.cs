using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldMapController : MonoBehaviour {
    public Button level12;
    public Button level13;
	// Use this for initialization
    void Awake ()
    {
        PlayerPrefs.SetString("Level 1-2", "False");
        PlayerPrefs.SetString("Level 1-3", "False");
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
