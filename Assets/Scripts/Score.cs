        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public int intscore;
    
    // Update is called once per frame
    void Update()
    { 
        if (GameMananger.Revive == false)
            scoreText.text = player.position.z.ToString("0");
        else
        {
            scoreText.text = (int.Parse(player.position.z.ToString("0")) + int.Parse(GameMananger.ScoreBeforeRevive)).ToString();
            Debug.Log("Aici");
        }
         
        if (GameMananger.ForMonetization == false)
            Highscore();
        //scoreText.text = player.position.z.ToString("0");
       /* if (SceneManager.GetActiveScene().name == "FreeRide")
        {
            int highscore = PlayerPrefs.GetInt("highscore");
            if (int.Parse(scoreText.text) > highscore)
            {
                highscore = int.Parse(scoreText.text);
                PlayerPrefs.SetInt("highscore", highscore);
            }
        }*/
    }
    public void Highscore()
    {
        if (SceneManager.GetActiveScene().name == "FreeRide")
        {
            int highscore = PlayerPrefs.GetInt("highscore");
            if (int.Parse(scoreText.text) > highscore)
            {
                highscore = int.Parse(scoreText.text);
                PlayerPrefs.SetInt("highscore", highscore);
            }
        }
    }    
}
