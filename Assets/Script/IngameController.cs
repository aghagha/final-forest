using UnityEngine;
using System.Collections;

public class IngameController : MonoBehaviour 
{
    private GameObject gameOverContainer;
    private GameObject winContainer;
    private GameObject pauseContainer; 

	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 1;
        gameOverContainer = GameObject.Find("GameOverContainer");
        winContainer = GameObject.Find("WinContainer");
        pauseContainer = GameObject.Find("PauseContainer");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void LoserNotification(GameObject g)
    {
        Time.timeScale = 0;
        if(g.tag == "Player")
        {
            ShowGameOver();
        }
        else if(g.tag == "Enemy")
        {
            ShowWin();
        }
    }

    private void ShowGameOver()
    {
        gameOverContainer.GetComponent<ContainerController>().Open();
    }

    private void ShowWin()
    {
        winContainer.GetComponent<ContainerController>().Open();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseContainer.GetComponent<ContainerController>().Open();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseContainer.GetComponent<ContainerController>().Close();
    }

    public void Retry()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.LoadLevel("worldmap");
    }

    public void Next()
    {
        Time.timeScale = 1;
        string level = Application.loadedLevelName.Split(' ')[1];
        Application.LoadLevel("Level "+ (int.Parse(level)+1) );
    }
}
