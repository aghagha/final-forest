using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mainmenu : MonoBehaviour {

	public string startLevel;
    public Sprite newSprite;
    Button button;
	
	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        setActive();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	public void PlayGame(){
		Application.LoadLevel(startLevel);
	}

    void setActive()
    {
        string level;
        level = button.name;
        if (PlayerPrefs.GetString(level) == "OK")
            button.interactable = true;
    }
}
