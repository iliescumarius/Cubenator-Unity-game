using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenSelectedLevel : MonoBehaviour
{ 
    public int levelIndex;
    private string level;
    public Button[] levelButtons;
    
    private void Start()
    { 
        int levelReached =PlayerPrefs.GetInt("levelReached",1);
        for(int i=0;i<levelButtons.Length;i++)
        { 
            if(i+1>levelReached)
            levelButtons[i].interactable = false;
        }
    }

    public void openselectedlevel()
    {
        level = EventSystem.current.currentSelectedGameObject.name;
        char s = level[5];
        char s1 = level[6];
        int cifra1 = s - '0';
        int cifra2 = s1 - '0'; 
        levelIndex = cifra1*10+cifra2 ;//iau cifrerele de la numele level        
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelIndex);
       
    }
    public void openFreeRide()
    {
        SceneManager.LoadScene("FreeRide");
    }
}
