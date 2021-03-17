using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void startGame()
    {
       //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("LevelMenu"); 
    }
    public void shop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void options()
    {
        SceneManager.LoadScene("Options");
    }
    public void leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
    public void startmenu()
    {
        SceneManager.LoadScene("Start");
    }
    public void quitgame()
    {
        print("quit");
        Application.Quit();
    }
}
