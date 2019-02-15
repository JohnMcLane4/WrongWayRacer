using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static bool GameIsMuted = false;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Scoreboard()
    {

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the application");
    }

    public void Mute()
    {

    }
}
