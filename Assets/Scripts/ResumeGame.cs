using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeGame : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    [HideInInspector]
    public static string CurrentScene="Start";
    [HideInInspector]

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(GameIsPause==true)
            {
                Resume();
            }  
            else
            {
                Pause();
                CurrentScene = SceneManager.GetActiveScene().name;
            }
        }
    }
   public void Resume()
    {
         
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;

        
    }
    public  void GoToMenu()
    {
        SceneManager.LoadScene("LevelMenu");
        GameIsPause = false;
        Resume();
    }
    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
        Resume();
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();

    }
    public  void GoToStart()
    {
        SceneManager.LoadScene("Start");
        Resume();
    }
    public void pausebutton()
    {
        Pause();
    }
}
