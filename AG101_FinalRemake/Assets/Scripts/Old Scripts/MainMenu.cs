using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static MainMenu instance;

    public string MainMenuScene = "MainMenu";
    public string tut = "Tutorial";
    public string Lvl1 = "Level1";
    public string Lvl2 = "Level2";
    public string Lvl3 = "Level3";
    public string endScene = "TheEnd";

    private void Awake()
    {
        // check if there's an instance already
        if (instance == null)
        {
            // Setting this to be our instance
            instance = this;

        }
        else
        {
            // Getting rid of extra instance
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}

    public void StartGame()
    {

        SceneManager.LoadScene(tut);
    }

    public void Level1()
    {
        SceneManager.LoadScene(Lvl1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(Lvl2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(Lvl3);
    }

    public void TheEnd()
    {
        SceneManager.LoadScene(endScene);
    }

    public void EndGame()
    {

        SceneManager.LoadScene(MainMenuScene);
    }

    public void End()
    {
        Application.Quit();
    }
}
